using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using SystemEx;

namespace MathEx
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct vec2i
	{
		//
		// Fields
		//
		public int x;
		public int y;
		public int d => y - x;

		public struct Dto
		{
			public int x;
			public int y;
		}

		public vec2i(Dto dto)
		{
			this.x = dto.x;
			this.y = dto.y;
		}

		public Dto ToDto() => new Dto { x = x, y = y };

		//
		// Static Properties
		//
		public static readonly vec2i zero = new vec2i(0, 0);
		public static readonly vec2i empty = new vec2i(int.MinValue, int.MinValue);
		public static readonly vec2i one = new vec2i(1, 1);
		public static readonly vec2i right = new vec2i(1, 0);
		public static readonly vec2i left = new vec2i(-1, 0);
		public static readonly vec2i up = new vec2i(0, 1);
		public static readonly vec2i down = new vec2i(0, -1);


		public bool isEmpty => x == int.MinValue && y == int.MinValue;
		public bool isZero => x == 0 && y == 0;

		public int product => x * y;
		public float aspect => (float)x / y;
		public float length => MathExOps.Sqrt(magnitude);
		public int magnitude => x * x + y * y;
		//public vec2 normalized { get { return this / length; } }

		/// <summary>
		///  Quads: position in coordinate system [0, 0]
		///  1 | 0
		/// ---+---
		///  2 | 3
		/// </summary>
		public int quad {
			get {
				if (x > 0)
					if (y > 0)
						return 0;
					else
						return 3;
				else
					if (y > 0)
					return 1;
				else
					return 2;
			}
		}

		/// <summary>
		///  Octants: position in coordinate system [0, 0]
		///  \2|1/
		///  3\|/0
		/// ---+---
		///  4/|\7
		///  /5|6\
		/// </summary>
		public int oct {
			get {
				if (x > 0)
				{
					if (y > 0)
					{
						if (x > y)
							return 0;
						else
							return 1;
					}
					else
					{
						if (x > -y)
							return 7;
						else
							return 6;
					}
				}
				else
				{
					if (y > 0)
					{
						if (-x > y)
							return 3;
						else
							return 2;
					}
					else
					{
						if (-x > -y)
							return 4;
						else
							return 5;
					}
				}
			}
		}


		//
		// Operators
		//
		public static bool operator ==(vec2i a, vec2i b) { return a.x == b.x && a.y == b.y; }
		public static bool operator !=(vec2i a, vec2i b) { return a.x != b.x || a.y != b.y; }
		public bool Equals(vec2i obj) { return obj == this; }
		public override bool Equals(object obj) { return obj is vec2i ? Equals((vec2i)obj) : false; }
		public override int GetHashCode() => ObjectEx.GetHashCode(x, y);


		public static vec2i operator +(vec2i a, int d) { return new vec2i(a.x + d, a.y + d); }
		public static vec2i operator -(vec2i a, int d) { return new vec2i(a.x - d, a.y - d); }

		public static vec2i operator *(vec2i a, int d) { return new vec2i(a.x * d, a.y * d); }
		public static vec2i operator /(vec2i a, int d) { return new vec2i(a.x / d, a.y / d); }
		public static vec2i operator *(int d, vec2i a) { return new vec2i(a.x * d, a.y * d); }
		public static vec2i operator /(int d, vec2i a) { return new vec2i(a.x / d, a.y / d); }
		public static vec2 operator *(vec2i a, float d) { return new vec2(a.x * d, a.y * d); }
		public static vec2 operator /(vec2i a, float d) { return new vec2(a.x / d, a.y / d); }
		public static vec2 operator *(float d, vec2i a) { return new vec2(a.x * d, a.y * d); }
		public static vec2 operator /(float d, vec2i a) { return new vec2(a.x / d, a.y / d); }

		public static vec2i operator -(vec2i a) { return new vec2i(-a.x, -a.y); }
		public static vec2i operator +(vec2i a, vec2i b) { return new vec2i(a.x + b.x, a.y + b.y); }
		public static vec2i operator -(vec2i a, vec2i b) { return new vec2i(a.x - b.x, a.y - b.y); }
		public static vec2i operator *(vec2i a, vec2i b) { return new vec2i(a.x * b.x, a.y * b.y); }
		public static vec2i operator /(vec2i a, vec2i b) { return new vec2i(a.x / b.x, a.y / b.y); }

		public static int operator %(vec2i i, vec2i w) { return i.x + i.y * w.x; }

		public static bool operator <(vec2i a, vec2i b)
			=> a.y < b.y
			|| (a.x < b.x && !(a.y > b.x));

		public static bool operator >(vec2i a, vec2i b)
			=> a.y < b.y || a.x < b.x
			|| !(a.y > b.y);

		public bool le(vec2i r)
			=> r.x > x && r.y > y;

		public bool ge(vec2i r)
			=> r.x < x && r.y < y;

		public bool cont(int v)
			=> v >= x && v <= y;

		public static vec2i xy(int xy) => new vec2i(xy, xy);
		public static vec2i xy(int x, int y) => new vec2i(x, y);

		public static vec2i wh(int xy) => new vec2i(xy, xy);
		public static vec2i wh(int x, int y) => new vec2i(x, y);

		public (vec2i, vec2i) w(int y) => (xy(0, y), xy(x, y)); // bad
		public (vec2i, vec2i) h(int x) => (xy(x, 0), xy(x, y)); // bad

		public vec2i(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static implicit operator vec2i(ValueTuple<int, int> v) => xy(v.Item1, v.Item2);
		public static implicit operator vec2i(vec2 v) => xy(v.x.Round(), v.y.Round());

		public aabb2i wh() => aabb2i.wh(this);


		public static void order(ref vec2i a, ref vec2i b)
		{
			vec2i la = a;
			vec2i lb = b;

			a = Min(la, lb);
			b = Max(la, lb);
		}

		public static vec2i Min(vec2i a, vec2i b)
		{
			return new vec2i(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
		}

		public static vec2i Max(vec2i a, vec2i b)
		{
			return new vec2i(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
		}

		public override string ToString() => "{0}, {1}".format(CultureInfo.InvariantCulture, x, y);
		public string ToString(string f) => "{0}, {1}".format(CultureInfo.InvariantCulture, x.ToString(f), y.ToString(f));

		public static vec2i Parse(string s)
		{
			var match = new Regex(@"\((\d+),(\d+)\)", RegexOptions.IgnoreCase).Match(s);
			if (match.Success)
			{
				return new vec2i(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
			}
			return vec2i.empty;
		}
		public static vec2i Parse(string s, out int length)
		{
			var match = new Regex(@"\((\d+),(\d+)\)", RegexOptions.IgnoreCase).Match(s);
			if (match.Success)
			{
				length = match.Length;
				return new vec2i(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
			}

			length = 0;
			return vec2i.empty;
		}

		public void Deconstruct(out int x, out int y)
		{
			x = this.x; y = this.y;
		}

#if UNITY || UNITY_5_3_OR_NEWER
		public static implicit operator UnityEngine.Vector2(vec2i v) => new UnityEngine.Vector2(v.x, v.y);
		public static implicit operator UnityEngine.Vector2Int(vec2i v) => new UnityEngine.Vector2Int(v.x, v.y);
		public static implicit operator vec2i(UnityEngine.Vector2 v) => xy(v.x.Round(), v.y.Round());
		public static implicit operator vec2i(UnityEngine.Vector2Int v) => xy(v.x, v.y);
#endif
	}
}
