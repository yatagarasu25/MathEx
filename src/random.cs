﻿using System;
using System.Collections.Generic;

namespace MathEx
{
	public static class RandomEx
	{
		static Random rnd_ = new Random();

		public static int rnd(this (int min, int max) range)
			=> rnd_.Next(range.min, range.max);
	}
#if false
	public static class random
	{


		public static RandomGenerator Create(int seed)
		{
			return new RandomGenerator(new Random(seed));
		}

		/// <summary>
		/// Returns next random value in the range of 0..1.
		/// </summary>
		public static float Next {
			get { return (float)rnd.NextDouble(); }
		}

		/// <summary>
		/// Returns next normally distributed value int he range -0.5..0.5.
		/// </summary>
		public static float NextNormal {
			get {
				float r = 0;
				for (int i = 0; i < 12; i++)
					r += Next;
				return r / 6.0f - 0.5f;
			}
		}

		public static IEnumerable<float> NormalDistribution()
		{
			bool ready = false;
			float second = 0.0f;

			while (true)
			{
				if (ready)
				{
					ready = false;
					yield return second;
				}
				else
				{
					var cr = UnityEngine.Random.insideUnitCircle;
					var lcr = cr.magnitude;
					var r = MathExOps.Sqrt(-2.0f * MathExOps.Log(lcr) / lcr);

					second = r * cr.x;
					ready = true;
					yield return r * cr.y;
				}
			}

			// yield break;
		}
	}

	public class RandomGenerator
	{
		Random rnd;

		public RandomGenerator(Random rnd)
		{
			this.rnd = rnd;
		}

		public float Next {
			get { return (float)rnd.NextDouble(); }
		}

		public float NextNormal {
			get {
				float r = 0;
				for (int i = 0; i < 12; i++)
					r += Next;
				return r / 12.0f - 0.5f;
			}
		}

		public svec3 NextSVec3 {
			get { return new svec3(1.0f, (Next - 0.5f) * 2 * UnityEngine.Mathf.PI, Next * 2 * UnityEngine.Mathf.PI); }
		}
	}
#endif
}
