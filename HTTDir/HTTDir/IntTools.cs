using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTTDir
{
	public class IntTools
	{
		public static int ToRange(int value, int minval, int maxval)
		{
			return Math.Min(Math.Max(value, minval), maxval);
		}

		public static int Parse(string str, int defval)
		{
			try
			{
				return int.Parse(str);
			}
			catch
			{
				return defval;
			}
		}

		public static int Parse(string str, int defval, int minval, int maxval)
		{
			try
			{
				int ret = int.Parse(str);

				if (ret < minval || maxval < ret) // ? out of range
				{
					return defval;
				}
				return ret;
			}
			catch
			{
				return defval;
			}
		}
	}
}
