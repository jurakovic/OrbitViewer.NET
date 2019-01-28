using OrbitViewer.Applet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrbitViewer.Application
{
	public static class ImportUtil
	{
		#region ImportComets

		public static List<Comet> ImportComets()
		{
			string filename = "comets.dat";

			List<Comet> list = new List<Comet>();
			Comet c;

			if (File.Exists(filename))
			{
				string[] lines = File.ReadAllLines(filename);

				foreach (string line in lines)
				{
					try
					{
						string name = line.Substring(102, 55).Trim();
						string sortKey = GetCometSortKey(name);

						int y = Convert.ToInt32(line.Substring(14, 4).Trim());
						int m = Convert.ToInt32(line.Substring(19, 2).Trim());
						int d = Convert.ToInt32(line.Substring(22, 2).Trim());
						int h = Convert.ToInt32(line.Substring(25, 4).Trim().PadRight(4, '0'));
						ATime T = new ATime(y, m, d + h / 10000.0, 0.0);

						double e = Convert.ToDouble(line.Substring(41, 8).Trim());
						double q = Convert.ToDouble(line.Substring(30, 9).Trim());
						double w = Convert.ToDouble(line.Substring(51, 8).Trim()) * Math.PI / 180.0;
						double N = Convert.ToDouble(line.Substring(61, 8).Trim()) * Math.PI / 180.0;
						double i = Convert.ToDouble(line.Substring(71, 8).Trim()) * Math.PI / 180.0;
						double eq = 2000.0;

						c = new Comet(name, T.JD, e, q, w, N, i, eq, sortKey);
					}
					catch
					{
						continue;
					}

					list.Add(c);
				}
			}

			if (!list.Any())
			{
				// add example comet
				string name = "1P/Halley";
				ATime T = new ATime(1986, 1, 30.0459, 0.0);
				double e = 0.967969;
				double q = 0.571943;
				double w = 111.6212 * Math.PI / 180.0;
				double N = 58.7611 * Math.PI / 180.0;
				double i = 162.2555 * Math.PI / 180.0;
				double eq = 2000.0;
				string sortkey = "1";

				c = new Comet(name, T.JD, e, q, w, N, i, eq, sortkey);
				list.Add(c);
			}

			return list.OrderBy(x => x.SortKey).ToList();
		}

		#endregion

		#region ImportAsteroids

		public static List<Comet> ImportAsteroids()
		{
			string filename = "asteroids.dat";

			List<Comet> list = new List<Comet>();
			Comet c;

			if (File.Exists(filename))
			{
				string[] lines = File.ReadAllLines(filename);

				foreach (string line in lines)
				{
					try
					{
						string name = line.Substring(166, line.Length - 166).Trim();
						string sortKey = GetAsteroidSortKey(name);

						string ep = line.Substring(20, 5);
						ATime epoch = GetATime(ep);

						double M = Convert.ToDouble(line.Substring(26, 10).Trim()) * Math.PI / 180.0;
						double w = Convert.ToDouble(line.Substring(36, 11).Trim()) * Math.PI / 180.0;
						double N = Convert.ToDouble(line.Substring(47, 11).Trim()) * Math.PI / 180.0;
						double i = Convert.ToDouble(line.Substring(58, 11).Trim()) * Math.PI / 180.0;
						double e = Convert.ToDouble(line.Substring(69, 11).Trim());
						double a = Convert.ToDouble(line.Substring(93, 12).Trim());
						double n = Astro.GAUSS / (a * Math.Sqrt(a));
						double q = a * (1.0 - e);

						ATime T = M < Math.PI
							? new ATime(epoch.JD - M / n, 0.0)
							: new ATime(epoch.JD + (Math.PI * 2.0 - M) / n, 0.0);

						double eq = 2000.0;

						c = new Comet(name, T.JD, e, q, w, N, i, eq, sortKey);
					}
					catch
					{
						continue;
					}

					list.Add(c);
				}
			}

			return list.OrderBy(x => x.SortKey).ToList();
		}

		#endregion

		#region GetCometSortkey

		private static string GetCometSortKey(string name)
		{
			string id, sortkey;
			string fragment = String.Empty;

			string[] parts = name.Split('/', '(', ')');

			if (Char.IsDigit(name[0]))
			{
				id = parts.FirstOrDefault() ?? name;

				if (id.Contains('-'))
				{
					var idfr = id.Split('-');
					id = idfr[0].Trim();
					fragment = idfr[1].Trim();
				}

				sortkey = id.PadLeft(10, '0') + fragment.PadRight(5, '0');
			}
			else
			{
				id = parts[1];

				if (id.Contains('-'))
				{
					var idfr = id.Split('-');
					id = idfr[0].Trim();
					fragment = idfr[1].Trim();
				}

				sortkey = id.Replace(" ", String.Empty).PadRight(10, '0') + fragment.PadRight(5, '0');
			}

			return sortkey;
		}

		#endregion

		#region GetAsteroidSortkey

		private static string GetAsteroidSortKey(string name)
		{
			string id, sortkey;

			string[] parts = name.Split('(', ')');

			if (Char.IsDigit(name[0]))
			{
				id = parts.FirstOrDefault() ?? name;
				sortkey = id.Replace(" ", String.Empty).PadRight(15, '0');
			}
			else
			{
				id = parts[1];
				sortkey = id.PadLeft(15, '0');
			}

			return sortkey;
		}

		#endregion

		#region GetAtime

		private static ATime GetATime(string packedEpoch)
		{
			// https://minorplanetcenter.net/iau/info/PackedDates.html
			string sy = (packedEpoch[0] - 55).ToString() + packedEpoch.Substring(1, 2);
			string sm = packedEpoch[3].ToString(); // char
			string sd = packedEpoch[4].ToString(); // char

			int y = Convert.ToInt32(sy);
			int m = Convert.ToInt32(sm);
			int d = Char.IsDigit(sd[0]) ? Convert.ToInt32(sd) : sd[0] - 55; // ascii offset

			return new ATime(y, m, d, 0.0);
		}

		#endregion
	}
}
