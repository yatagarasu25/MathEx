﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using SystemEx;

namespace MathEx
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct rect2
	{
		public vec2 xy;
		public vec2 size;

		public struct Dto
		{
			public vec2.Dto xy;
			public vec2.Dto size;
		}

		public Dto ToDto() => new Dto { xy = xy.ToDto(), size = size.ToDto() };

		public vec2 a {
			get => xy;
			set { var d = value - xy; xy = value; size -= d; }
		}

		public vec2 b {
			get => a + size;
			set => size = value - a;
		}

		public vec2 center => xy + size / 2;


		public static readonly rect2 empty = xywh(vec2.empty, vec2.empty);
		public static readonly rect2 zero = xywh(vec2.zero, vec2.zero);
		public static readonly rect2 one = rect2.ab(vec2.zero, vec2.one);


		public bool isEmpty => a.isEmpty || size.isEmpty;

		public static vec4 operator %(rect2 a, vec4 b) { return vec4.trbl(b.t.Lerp(a.a.y, a.b.y), b.r.Lerp(a.a.x, a.b.x), b.b.Lerp(a.a.y, a.b.y), b.l.Lerp(a.a.x, a.b.x)); }

		//public static rect2 operator +(rect2 a, vec2 v) => xywh(a.xy + v, a.size);
		//public static rect2 operator -(rect2 a, vec2 v) => xywh(a.xy - v, a.size);
		public static rect2 operator *(rect2 a, int v) => xywh(a.xy * v, a.size * v);

		public static bool operator &(rect2 a, vec2 b)
			=> b.ge(a.xy) && b.le(a.b);

		public static rect2 operator +(rect2 a, vec2 b) => a.dXY(b);
		public static rect2 operator -(rect2 a, vec2 b) => a.dXY(-b);

		public static rect2 wh(float w, float h) => new rect2(vec2.zero, (w, h));
		public static rect2 wh(vec2 wh) => new rect2(vec2.zero, wh);
		public static rect2 wh(vec2i wh) => new rect2(vec2.zero, (vec2)wh);

		public static rect2 xywh(float x, float y, float w, float h) => new rect2((x, y), (w, h));
		public static rect2 xywh(vec2 xy, vec2 wh) => new rect2(xy, wh);
		public static rect2 xywh(vec2 xy, vec2i wh) => new rect2(xy, (vec2)wh);
		public static rect2 xywh(vec2i xy, vec2 wh) => new rect2((vec2)xy, wh);
		public static rect2 xywh(vec2i xy, vec2i wh) => new rect2((vec2)xy, (vec2)wh);

		public static rect2 ab(vec2 a, vec2 b) => new rect2(a, b - a);

		public static rect2 tlrb(vec4 tlrb) => ab(tlrb.lt(), tlrb.rb());
		public static rect2 tlrb(vec2 tl, vec2 rb) => ab(tl, rb);

		public rect2 pivot(vec2 pivot) => xywh(xy - size*pivot, size);

		public rect2(vec2 xy, vec2 wh)
		{
			this.xy = xy;
			size = wh;
		}

		public rect2 normalized =>
			rect2.xywh(size.x >= 0 ? a.x : a.x + size.x, size.y >= 0 ? a.y : a.y + size.y
				, size.x >= 0 ? size.x : -size.x, size.y >= 0 ? size.y : -size.y);

		public rect2 grow(int v) => ab(a - v, b + v);
		public rect2 grow(float v) => ab(a - v, b + v);

		// Intersect - clamp one rect by other
		public rect2 n(rect2 v)
			=> ab(a.Clamp(v.a, v.b), b.Clamp(v.a, v.b));
		// Union - extend rect
		public rect2 u(rect2 v)
			=> ab(a.Min(v.a), b.Max(v.b));


		public rect2 Extend(vec2 point)
		{
			var dp = point - a;

			return xywh(a.Min(point), size.Max(dp));
		}

		public static vec2 operator %(rect2 rect, vec2 position) // Project
		{
			vec2 translated = position - rect.xy;
			vec2 scaled = (translated / rect.size);
			return scaled;
		}

		public static explicit operator aabb2(rect2 r) => aabb2.xywh(r.xy, r.size);
		public static explicit operator rect2(aabb2 r) => xywh(r.a, r.size);
		public static explicit operator rect2(aabb2i r) => xywh(r.a, r.size);
		public static explicit operator rect2(vec2i r) => wh(r);

		public override string ToString() => "{0}, {1}".format(CultureInfo.InvariantCulture, a, b);
	}
}
