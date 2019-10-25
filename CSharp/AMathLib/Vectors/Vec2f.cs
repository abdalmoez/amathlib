///////////////////////////////////////////////////////////////////////////////
//     Copyright (C) 2019 Bouraoui Al-Moez L.A. (abdalmoez720@gmail.com)     //
///////////////////////////////////////////////////////////////////////////////
//                                                                           //
//     This file is part of the AMathLib, and is made available under        //
//     the terms of the GNU General Public License version 2 only.           //
//                                                                           //
///////////////////////////////////////////////////////////////////////////////
using System;

namespace AMathLib.Vectors
{
    public class Vec2f
    {
        public float x;
        public float y;

        public double GetNorm() { return System.Math.Sqrt(x * x + y * y); }
        public Vec2f CreateNormalizedVector() { return this / (float)GetNorm(); }
        public void Normalize() { float n = (float)GetNorm(); x /= n; y /= n; }

        public Vec2f(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2f(Vec2f v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public float SumXY()
        {
            return x + y;
        }

        public void Set(Vec2f v)
        {
            if (v != null)
            {
                x = v.x;
                y = v.y;
            }
        }

        public float[] ToArray()
        {
            return new float[] { x, y };
        }

        public override string ToString()
        {
            return x + " " + y;
        }

        /// <summary>
        /// Calculate the distance between current vector and v
        /// </summary>
        /// <param name="v">vector</param>
        public double Distance(Vec2 v)
        {
            return System.Math.Sqrt((x - v.x) * (x - v.x) + (y - v.y) * (y - v.y));
        }

        /// <summary>
        /// Calculate the distance between current vector and v
        /// </summary>
        /// <param name="v">vector</param>
        public double Distance(Vec2f v)
        {
            return System.Math.Sqrt((x - v.x) * (x - v.x) + (y - v.y) * (y - v.y));
        }

        /// <summary>
        /// Apply a function to each element of the vector
        /// </summary>
        /// <param name="f">function</param>
        public void ApplyFunction(Func<float, float> f)
        {
            x = f(x);
            y = f(y);
        }


        #region Operators definition
        // overload square bracket 
        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return x;
                    case 1: return y;
                    default: throw new Exception("Out of range");
                }
            }
            set
            {
                switch (i)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: throw new Exception("Out of range");
                }
            }
        }

        // overload operator +
        public static Vec2f operator +(Vec2f a, Vec2f b)
        {
            return new Vec2f(a.x + b.x, a.y + b.y);
        }
        // overload operator -
        public static Vec2f operator -(Vec2f a, Vec2f b)
        {
            return new Vec2f(a.x - b.x, a.y - b.y);
        }

        // overload operator *
        public static Vec2f operator *(Vec2f a, float k)
        {
            return new Vec2f(a.x * k, a.y * k);
        }
        public static Vec2f operator *(float k, Vec2f a)
        {
            return new Vec2f(a.x * k, a.y * k);
        }
        //simple product
        public static Vec2f operator *(Vec2f a, Vec2f b)
        {
            return new Vec2f(a.x * b.x, a.y * b.y);
        }

        // overload operator /
        public static Vec2f operator /(Vec2f a, float k)
        {
            return new Vec2f(a.x / k, a.y / k);
        }

        // overload implicit cast to Vec2
        public static implicit operator Vec2(Vec2f v) => new Vec2(v);

        // overload comparison
        public override bool Equals(object obj)
        {
            if (obj is Vec2f)
                return (obj as Vec2f) != null &&
                       x == (obj as Vec2f).x &&
                       y == (obj as Vec2f).y;
            else
                return false;
        }

        public static bool operator ==(Vec2f l, Vec2f r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec2f l, Vec2f r)
        {
            return !(l == r);
        }

        public override int GetHashCode()
        {
            var hashCode = -1743314642;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}
