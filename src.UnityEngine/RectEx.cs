using UnityEngine;

namespace MathEx
{
	public static class RectEx
	{
		public static Rect Empty = new Rect(float.NaN, float.NaN, float.NaN, float.NaN);


		public static bool IsEmpty(this Rect rect)
		{
			return float.IsNaN(rect.xMin) || float.IsNaN(rect.yMin);
		}

		public static bool IsZero(this Rect rect)
		{
			return rect.width == 0 || rect.height == 0;
		}

		public static Vector2 GetMin(this Rect rect)
		{
			return new Vector2(rect.xMin, rect.yMin);
		}

		public static Vector2 GetMax(this Rect rect)
		{
			return new Vector2(rect.xMax, rect.yMax);
		}

		/// <summary>
		/// Extend Rect so p is inside rect. If Rect is empty creates new point rect.
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		public static Rect Extend(this Rect rect, Vector2 p)
		{
			if (rect.IsEmpty())
				return new Rect(p.x, p.y, 0, 0);
			if (rect.Contains(p))
				return rect;

			float xMin = Mathf.Min(rect.xMin, p.x);
			float yMin = Mathf.Min(rect.yMin, p.y);
			float xMax = Mathf.Max(rect.xMax, p.x);
			float yMax = Mathf.Max(rect.yMax, p.y);

			return new Rect(xMin, yMin, xMax - xMin, yMax - yMin);
		}

		public static Rect Extend(this Rect rect, Rect r)
		{
			if (r.IsEmpty())
				return rect;

			return rect.Extend(r.GetMin()).Extend(r.GetMax());
		}

		/// <summary>
		/// Returns normalized point in Rect space. If point is inside Rect its coordinates will be in range [0..1], otherwise point is outside.
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Vector2 Normalize(this Rect rect, Vector2 v)
		{
			return new Vector2((v.x - rect.xMin) / rect.width, (v.y - rect.yMin) / rect.height);
		}

		public static int Position(this Rect rect, Vector2 v)
		{
			if (rect.IsEmpty())
				return 0x0f;
			if (v.IsEmpty())
				return 0x00;

			Vector3 a = rect.min;
			Vector3 b = rect.max;

			int res = 0;
			if (v.x < a.x)
				res |= 0x01;
			else if (v.x > b.x)
				res |= 0x02;

			if (v.y < a.y)
				res |= 0x04;
			else if (v.y > b.y)
				res |= 0x08;

			return res;
		}

		public static Rect SetHeight(this Rect rect, float height)
		{
			return new Rect(rect.x, rect.y, rect.width, height);
		}

		public static Rect DeltaTop(this Rect rect, float dtop)
		{
			return new Rect(rect.x, rect.y + dtop, rect.width, rect.height - dtop);
		}
	}
}

