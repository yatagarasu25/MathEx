using System;

namespace MathEx
{
	public static class vecEc
	{
		public static int Clamp(this vec2 v, int f) { return MathExOps.Clamp(f, (int)v.x, (int)v.y); }
		public static float Clamp(this vec2 v, float f) { return MathExOps.Clamp(f, v.x, v.y); }
		public static vec2 Clamp(this vec2 v, vec2 min, vec2 max) { return MathExOps.Clamp(v, min, max); }

		public static int Clamp(this vec2i v, int f) { return MathExOps.Clamp(f, v.x, v.y); }
		public static float Clamp(this vec2i v, float f) { return MathExOps.Clamp(f, v.x, v.y); }
		public static vec2i Clamp(this vec2i v, vec2i min, vec2i max) { return MathExOps.Clamp(v, min, max); }

		public static vec2 Adc(this vec2 v, float th) { return new vec2(MathExOps.Abs(v.x) < th ? 0 : MathExOps.Sign(v.x), MathExOps.Abs(v.y) < th ? 0 : MathExOps.Sign(v.y)); }

		public static float Min(this vec2 v) => (v.x, v.y).Min();
		public static vec2 Min(this vec2 a, vec2 b) => ((a.x, b.x).Min(), (a.y, b.y).Min());

		public static float Max(this vec2 v) => (v.x, v.y).Max();
		public static vec2 Max(this vec2 a, vec2 b) => ((a.x, b.x).Max(), (a.y, b.y).Max());
		public static vec3 Max(this vec3 a, vec3 b) => ((a.x, b.x).Max(), (a.y, b.y).Max(), (a.z, b.z).Max());
		public static vec4 Max(this vec4 a, vec4 b) => ((a.x, b.x).Max(), (a.y, b.y).Max(), (a.z, b.z).Max(), (a.w, b.w).Max());

		public static vec2 Add(this vec2 l, float x, float y) { return new vec2(l.x + x, l.y + y); }
		public static vec2 Add(this vec2 l, vec2 r) { return new vec2(l.x + r.x, l.y + r.y); }
		public static vec2 Sub(this vec2 l, float x, float y) { return new vec2(l.x - x, l.y - y); }
		public static vec2 Sub(this vec2 l, vec2 r) { return new vec2(l.x - r.x, l.y - r.y); }
		public static vec2 Mul(this vec2 l, float x, float y) { return new vec2(l.x * x, l.y * y); }
		public static vec2 Mul(this vec2 l, vec2 r) { return new vec2(l.x * r.x, l.y * r.y); }
		public static vec2 Div(this vec2 l, float v) { return new vec2(l.x / v, l.y / v); }
		public static vec2 Div(this vec2 l, float x, float y) { return new vec2(l.x / x, l.y / y); }
		public static vec2 Div(this vec2 l, vec2 r) { return new vec2(l.x / r.x, l.y / r.y); }

		public static vec2 Mul(this vec2 l, int x, int y) { return new vec2(l.x * x, l.y * y); }
		public static vec2 Mul(this vec2 l, vec2i r) { return new vec2(l.x * r.x, l.y * r.y); }
		public static vec2 Div(this vec2 l, int v) { return new vec2(l.x / v, l.y / v); }
		public static vec2 Div(this vec2 l, int x, int y) { return new vec2(l.x / x, l.y / y); }
		public static vec2 Div(this vec2 l, vec2i r) { return new vec2(l.x / r.x, l.y / r.y); }

		public static vec3 s(this vec3 l, float x, float y, float z) { return new vec3(l.x * x, l.y * y, l.z * z); }
		public static vec3 Mul(this vec3 l, vec3 r) { return new vec3(l.x * r.x, l.y * r.y, l.z * r.z); }
		public static vec3 Div(this vec3 l, vec3 r) { return new vec3(l.x / r.x, l.y / r.y, l.z / r.z); }

		public static vec4 Div(this vec4 l, vec4 r) { return new vec4(l.x / r.x, l.y / r.y, l.z / r.z, l.w / r.w); }


		public static vec2 Floor(this vec2 v)
		{
			return new vec2(v.x.Floor(), v.y.Floor());
		}


		public static vec2i X(this vec2i v, int x) { return new vec2i(x, v.y); }
		public static vec2i Y(this vec2i v, int y) { return new vec2i(v.x, y); }

		public static vec2 X(this vec2 v, float x) { return new vec2(x, v.y); }
		public static vec2 Y(this vec2 v, float y) { return new vec2(v.x, y); }

		public static vec3i X(this vec3i v, int x) { return new vec3i(x, v.y, v.z); }
		public static vec3i Y(this vec3i v, int y) { return new vec3i(v.x, y, v.z); }
		public static vec3i Z(this vec3i v, int z) { return new vec3i(v.x, v.y, z); }

		public static vec3 X(this vec3 v, float x) { return new vec3(x, v.y, v.z); }
		public static vec3 Y(this vec3 v, float y) { return new vec3(v.x, y, v.z); }
		public static vec3 Z(this vec3 v, float z) { return new vec3(v.x, v.y, z); }

		public static vec4 X(this vec4 v, float x) { return new vec4(x, v.y, v.z, v.w); }
		public static vec4 Y(this vec4 v, float y) { return new vec4(v.x, y, v.z, v.w); }
		public static vec4 Z(this vec4 v, float z) { return new vec4(v.x, v.y, z, v.w); }
		public static vec4 W(this vec4 v, float w) { return new vec4(v.x, v.y, v.x, w); }

		public static vec4 T(this vec4 v, float x) { return vec4.trbl(x, v.r, v.b, v.l); }
		public static vec4 R(this vec4 v, float y) { return vec4.trbl(v.t, y, v.b, v.l); }
		public static vec4 B(this vec4 v, float z) { return vec4.trbl(v.t, v.r, z, v.l); }
		public static vec4 L(this vec4 v, float w) { return vec4.trbl(v.t, v.r, v.b, w); }

		public static vec2 dX(this vec2 v, float dx) { return new vec2(v.x + dx, v.y); }
		public static vec2 dY(this vec2 v, float dy) { return new vec2(v.x, v.y + dy); }
		public static vec2 dXY(this vec2 v, float dx, float dy) { return new vec2(v.x + dx, v.y + dy); }

		public static vec2i dX(this vec2i v, int dx) { return new vec2i(v.x + dx, v.y); }
		public static vec2i dY(this vec2i v, int dy) { return new vec2i(v.x, v.y + dy); }
		public static vec2i dXY(this vec2i v, int dx, int dy) { return new vec2i(v.x + dx, v.y + dy); }

		public static vec3 dX(this vec3 v, float dx) { return new vec3(v.x + dx, v.y, v.z); }
		public static vec3 dY(this vec3 v, float dy) { return new vec3(v.x, v.y + dy, v.z); }
		public static vec3 dZ(this vec3 v, float dz) { return new vec3(v.x, v.y, v.z + dz); }

		public static vec2 iX(this vec2 v) { return new vec2(-v.x, v.y); }
		public static vec2 iY(this vec2 v) { return new vec2(v.x, -v.y); }


		public static vec2 nx(this vec2 v) => v.X(-v.x);
		public static vec2 ny(this vec2 v) => v.Y(-v.y);

		public static vec3 nx(this vec3 v) => v.X(-v.x);
		public static vec3 ny(this vec3 v) => v.Y(-v.y);
		public static vec3 nz(this vec3 v) => v.Z(-v.z);

		public static vec2 maxX(this vec2 v, float x) => v.X(v.x.Max(x));
		public static vec2 maxY(this vec2 v, float y) => v.Y(v.y.Max(y));


		public static vec2 x2(this float x) => new vec2(x, 0);
		public static vec2 y2(this float x) => new vec2(0, x);
		public static vec2 xx(this float x) => new vec2(x, x);
		public static vec3 x3(this float x) => new vec3(x, 0, 0);
		public static vec3 y3(this float x) => new vec3(0, x, 0);
		public static vec3 z3(this float x) => new vec3(0, 0, x);
		public static vec3 xxx(this float x) => new vec3(x, x, x);

		public static vec3i xyz(this vec2i v, int z) { return new vec3i(v.x, v.y, z); }
		public static vec3i zxy(this vec2i v, int z) { return new vec3i(z, v.x, v.y); }
		public static vec3i yzx(this vec2i v, int z) { return new vec3i(v.y, z, v.x); }

		public static vec4 xyzw(this vec2i v, float z = 0, float w = 0) { return new vec4(v.x, v.y, z, w); }


		public static vec3 xyz(this vec2 v, float z) { return new vec3(v.x, v.y, z); }
		public static vec3 xzy(this vec2 v, float z) { return new vec3(v.x, z, v.y); }
		public static vec3 zxy(this vec2 v, float z) { return new vec3(z, v.x, v.y); }
		public static vec3 yxz(this vec2 v, float z) { return new vec3(v.y, v.x, z); }
		public static vec3 yzx(this vec2 v, float z) { return new vec3(v.y, z, v.x); }

		public static vec4 xyzw(this vec2 v, float z = 0, float w = 0) { return new vec4(v.x, v.y, z, w); }

		public static vec2i xy(this vec3i v) { return new vec2i(v.x, v.y); }
		public static vec2i yz(this vec3i v) { return new vec2i(v.y, v.z); }
		public static vec2i zx(this vec3i v) { return new vec2i(v.z, v.x); }

		public static vec3 xzy(this vec3 v) { return new vec3(v.x, v.z, v.y); }
		public static vec3 xzy(this vec3 v, float sx, float sz, float sy) { return new vec3(sx * v.x, sz * v.z, sy * v.y); }
		public static vec3 yzx(this vec3 v) { return new vec3(v.y, v.z, v.x); }
		public static vec3 yzx(this vec3 v, float sy, float sz, float sx) { return new vec3(sy * v.y, sz * v.z, sx * v.x); }
		public static vec2 xy(this vec3 v) { return new vec2(v.x, v.y); }
		public static vec2 xz(this vec3 v) { return new vec2(v.x, v.z); }
		public static vec2 zx(this vec3 v) { return new vec2(v.z, v.x); }
		public static vec2 yz(this vec3 v) { return new vec2(v.y, v.z); }
		public static vec2 zy(this vec3 v) { return new vec2(v.z, v.y); }

		public static vec3 xyz(this vec4 v) { return new vec3(v.x, v.y, v.z); }
		public static vec2 xy(this vec4 v) { return new vec2(v.x, v.y); }
		public static vec2 zw(this vec4 v) { return new vec2(v.z, v.w); }

		public static vec2 rl(this vec4 v) { return new vec2(v.r, v.l); }
		public static vec2 tb(this vec4 v) { return new vec2(v.t, v.b); }
		public static vec2 lt(this vec4 v) { return new vec2(v.l, v.t); }
		public static vec2 rb(this vec4 v) { return new vec2(v.r, v.b); }


		public static aabb3 xyz(this aabb2 aabb, vec2 z) => new aabb3(aabb.a.xyz(z.x), aabb.b.xyz(z.y));
		public static aabb3 xzy(this aabb2 aabb, vec2 z) => new aabb3(aabb.a.xzy(z.x), aabb.b.xzy(z.y));


		public static rect2 X(this rect2 r, float x) => rect2.xywh(r.a.X(x), r.size);
		public static rect2 Y(this rect2 r, float y) => rect2.xywh(r.a.Y(y), r.size);
		public static rect2 XY(this rect2 r, float x, float y) => rect2.xywh((x, y), r.size);
		public static rect2 XY(this rect2 r, vec2 xy) => rect2.xywh(xy, r.size);
		public static rect2 WH(this rect2 r, float width, float height) => rect2.xywh(r.a, (width, height));
		public static rect2 WH(this rect2 r, vec2 wh) => rect2.xywh(r.a, wh);


		public static rect2 dX(this rect2 r, float x) => rect2.xywh(r.a.dX(x), r.size);
		public static rect2 dY(this rect2 r, float y) => rect2.xywh(r.a.dY(y), r.size);
		public static rect2 dXY(this rect2 r, float x, float y) => rect2.xywh(r.a + (x, y), r.size);
		public static rect2 dXY(this rect2 r, vec2 xy) => rect2.xywh(r.a + xy, r.size);
		public static rect2 dWH(this rect2 r, float width, float height) => rect2.xywh(r.a, r.size + (width, height));
		public static rect2 dWH(this rect2 r, vec2 wh) => rect2.xywh(r.a, r.size + wh);


		public static float Distance(this ValueTuple<vec2, vec2> v) => (v.Item1 - v.Item2).length;
		public static float Distance(this ValueTuple<vec3, vec3> v) => (v.Item1 - v.Item2).length;

		public static float DistanceSq(this ValueTuple<vec2, vec2> v) => (v.Item1 - v.Item2).magnitude;
		public static float DistanceSq(this ValueTuple<vec3, vec3> v) => (v.Item1 - v.Item2).magnitude;
	}
}
