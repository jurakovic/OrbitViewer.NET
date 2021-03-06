using System;

namespace OrbitViewer.Applet
{
	public class Comet
	{
		#region Const

		private const int MAXAPPROX = 80;
		private const double TOLERANCE = 1.0E-12;

		#endregion

		#region Properties

		/// <summary>
		/// Object name
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Epoch
		/// </summary>
		private double T { get; set; }

		/// <summary>
		/// Eccentricity
		/// </summary>
		public double e { get; private set; }

		/// <summary>
		/// Perihelion distance
		/// </summary>
		public double q { get; private set; }

		/// <summary>
		/// Argument of pericenter
		/// </summary>
		private double w { get; set; }

		/// <summary>
		/// Ascending node
		/// </summary>
		private double N { get; set; }

		/// <summary>
		/// Inclination
		/// </summary>
		private double i { get; set; }

		/// <summary>
		/// Equinox (eg. 2000)
		/// </summary>
		private double Equinox { get; set; }

		/// <summary>
		/// Equinox in ATime
		/// </summary>
		private ATime ATimeEquinox { get; set; }

		/// <summary>
		/// Equinox Julian date
		/// </summary>
		public double EquinoxJD { get { return this.ATimeEquinox.JD; } }

		/// <summary>
		/// Vector constant
		/// </summary>
		public Matrix VectorConstant { get; private set; }

		/// <summary>
		/// Sortkey
		/// </summary>
		public string SortKey { get; private set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="T"></param>
		/// <param name="e"></param>
		/// <param name="q"></param>
		/// <param name="w"></param>
		/// <param name="N"></param>
		/// <param name="i"></param>
		/// <param name="eq"></param>
		/// <param name="sortKey"></param>
		public Comet(string name, double T, double e, double q, double w, double N, double i, double eq, string sortKey)
		{
			this.Name = name;
			this.T = T;
			this.e = e;
			this.q = q;
			this.w = w;
			this.N = N;
			this.i = i;
			this.SortKey = sortKey;
			this.Equinox = eq;

			int eqYear = (int)Math.Floor(eq);
			double eqM = (eq - (double)eqYear) * 12.0;
			int eqMonth = (int)Math.Floor(eqM);
			double eqDay = (eqM - (double)eqMonth) * 30.0;
			this.ATimeEquinox = new ATime(eqYear, eqMonth, eqDay, 0.0);

			this.VectorConstant = Matrix.VectorConstant(w, N, i, this.ATimeEquinox);
		}

		#endregion

		#region CometStatusEllip

		/// <summary>
		/// Get Position on Orbital Plane for Elliptical Orbit
		/// </summary>
		/// <param name="jd"></param>
		/// <returns></returns>
		private Xyz CometStatusEllip(double jd)
		{
			if (this.q == 0.0)
			{
				throw new ArithmeticException();
			}

			double axis = this.q / (1.0 - this.e);
			double M = Astro.GAUSS * (jd - this.T) / (Math.Sqrt(axis) * axis);
			double E1 = M + this.e * Math.Sin(M);
			int count = MAXAPPROX;

			if (this.e < 0.6)
			{
				double fE2;
				do
				{
					fE2 = E1;
					E1 = M + this.e * Math.Sin(fE2);
				} while (Math.Abs(E1 - fE2) > TOLERANCE && --count > 0);
			}
			else
			{
				double dv;
				do
				{
					double dv1 = (M + this.e * Math.Sin(E1) - E1);
					double dv2 = (1.0 - this.e * Math.Cos(E1));
					if (Math.Abs(dv1) < TOLERANCE || Math.Abs(dv2) < TOLERANCE)
					{
						break;
					}
					dv = dv1 / dv2;
					E1 += dv;
				} while (Math.Abs(dv) > TOLERANCE && --count > 0);
			}

			if (count == 0)
			{
				throw new ArithmeticException();
			}

			double X = axis * (Math.Cos(E1) - this.e);
			double Y = axis * Math.Sqrt(1.0 - this.e * this.e) * Math.Sin(E1);

			return new Xyz(X, Y, 0.0);
		}

		#endregion

		#region CometStatusPara

		/// <summary>
		/// Get Position on Orbital Plane for Parabolic Orbit
		/// </summary>
		/// <param name="jd"></param>
		/// <returns></returns>
		private Xyz CometStatusPara(double jd)
		{
			if (this.q == 0.0)
			{
				throw new ArithmeticException();
			}

			double N = Astro.GAUSS * (jd - this.T) / (Math.Sqrt(2.0) * this.q * Math.Sqrt(this.q));
			double tanV2 = N;
			double oldTanV2, tan2V2;
			int count = MAXAPPROX;

			do
			{
				oldTanV2 = tanV2;
				tan2V2 = tanV2 * tanV2;
				tanV2 = (tan2V2 * tanV2 * 2.0 / 3.0 + N) / (1.0 + tan2V2);
			} while (Math.Abs(tanV2 - oldTanV2) > TOLERANCE && --count > 0);

			if (count == 0)
			{
				throw new ArithmeticException();
			}

			tan2V2 = tanV2 * tanV2;
			double X = this.q * (1.0 - tan2V2);
			double Y = 2.0 * this.q * tanV2;

			return new Xyz(X, Y, 0.0);
		}

		#endregion

		#region CometStatusNearPara

		/// <summary>
		/// Get Position on Orbital Plane for Nearly Parabolic Orbit
		/// </summary>
		/// <param name="jd"></param>
		/// <returns></returns>
		private Xyz CometStatusNearPara(double jd)
		{
			if (this.q == 0.0)
			{
				throw new ArithmeticException();
			}

			double A = Math.Sqrt((1.0 + 9.0 * this.e) / 10.0);
			double B = 5.0 * (1 - this.e) / (1.0 + 9.0 * this.e);
			double A1, B1, X1, A0, B0, X0, N;
			A1 = B1 = X1 = 1.0;
			int count1 = MAXAPPROX;

			do
			{
				A0 = A1;
				B0 = B1;
				N = B0 * A * Astro.GAUSS * (jd - this.T) / (Math.Sqrt(2.0) * this.q * Math.Sqrt(this.q));
				int count2 = MAXAPPROX;
				do
				{
					X0 = X1;
					double temp = X0 * X0;
					X1 = (temp * X0 * 2.0 / 3.0 + N) / (1.0 + temp);
				} while (Math.Abs(X1 - X0) > TOLERANCE && --count2 > 0);
				if (count2 == 0)
				{
					throw new ArithmeticException();
				}
				A1 = B * X1 * X1;
				B1 = (-3.809524e-03 * A1 - 0.017142857) * A1 * A1 + 1.0;
			} while (Math.Abs(A1 - A0) > TOLERANCE && --count1 > 0);

			if (count1 == 0)
			{
				throw new ArithmeticException();
			}

			double C1 = ((0.12495238 * A1 + 0.21714286) * A1 + 0.4) * A1 + 1.0;
			double D1 = ((0.00571429 * A1 + 0.2) * A1 - 1.0) * A1 + 1.0;
			double TanV2 = Math.Sqrt(5.0 * (1.0 + this.e) / (1.0 + 9.0 * this.e)) * C1 * X1;
			double X = this.q * D1 * (1.0 - TanV2 * TanV2);
			double Y = 2.0 * this.q * D1 * TanV2;
			return new Xyz(X, Y, 0.0);
		}

		#endregion

		#region GetPos

		/// <summary>
		/// Get Position in Heliocentric Equatorial Coordinates 2000.0
		/// </summary>
		/// <param name="JD"></param>
		/// <returns></returns>
		public Xyz GetPos(double JD)
		{
			Xyz xyz;

			// CometStatus' may be throw ArithmeticException
			if (this.e < 0.995)
			{
				xyz = CometStatusEllip(JD);
			}
			else if (Math.Abs(this.e - 1.0) < TOLERANCE)
			{
				xyz = CometStatusPara(JD);
			}
			else
			{
				xyz = CometStatusNearPara(JD);
			}

			xyz = xyz.Rotate(this.VectorConstant);
			Matrix mtxPrec = Matrix.PrecMatrix(this.ATimeEquinox.JD, Astro.JD2000);
			return xyz.Rotate(mtxPrec);
		}

		#endregion
	}
}