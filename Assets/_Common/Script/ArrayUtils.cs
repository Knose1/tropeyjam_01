using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Github.Knose1.Common
{
	public static class ArrayUtils
	{
		public static void Shuffle<T>(this List<T> list)
		{
			list.Sort(ListShuffle);	
		}

		private static int ListShuffle<T>(T x, T y)
		{
			return UnityEngine.Random.Range(-1, 2);
		}
	}
}
