namespace MathEx
{
	public class aabb2i
	{
		public static readonly aabb2i empty = new aabb2i(vec2i.empty, vec2i.empty);
		public static readonly aabb2i zero = new aabb2i(vec2i.zero, vec2i.zero);
		public static readonly aabb2i one = new aabb2i(vec2i.zero, vec2i.one);

		public vec2i a;
		public vec2i b;

		public int x { get { return b.x - a.x; } }
		public int y { get { return b.y - a.y; } }
		public vec2i size { get { return b - a; } }

		public aabb2i(vec2i a, vec2i b)
		{
			this.a = a;
			this.b = b;
		}

		public bool isEmpty { get { return a.isEmpty || b.isEmpty; } }


		//
		// Operators
		//
		public static aabb2i operator +(aabb2i a, vec2i v) { return new aabb2i(a.a + v, a.b + v); }
		public static aabb2i operator -(aabb2i a, vec2i v) { return new aabb2i(a.a - v, a.b - v); }
		public static aabb2i operator *(aabb2i a, vec2i v) { return new aabb2i(a.a * v, a.b * v); }


		public aabb2i Extend(vec2i p)
		{
			if (isEmpty)
				return new aabb2i(p, p);

			var min = vec2i.Min(a, p);
			var max = vec2i.Max(b, p);

			return new aabb2i(min, max);
		}

		public vec2i[] ToArray()
		{
			return new vec2i[4] {
				a, new vec2i(a.x, b.y),
				b, new vec2i(b.x, a.y)
			};
		}

		public override string ToString()
		{
			return string.Format("({0}, {1})", a, b);
		}

		public string ToString(string f)
		{
			return string.Format("({0}, {1})", a.ToString(f), b.ToString(f));
		}
	}

	public class aabb3i
	{
		public vec3i a;
		public vec3i b;

		public int x { get { return b.x - a.x; } }
		public int y { get { return b.y - a.y; } }
		public int z { get { return b.z - a.z; } }
		public vec3i size { get { return b - a; } }

		public aabb3i(vec3i a, vec3i b)
		{
			this.a = a;
			this.b = b;
		}

		public bool isEmpty { get { return a.isEmpty || b.isEmpty; } }
	}
}
