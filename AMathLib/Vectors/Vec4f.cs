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
    public class Vec4f
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public double GetNorm() { return System.Math.Sqrt(x * x + y * y + z * z + w * w); }
        public Vec4f GetNormalizedVector() { return this / (float)GetNorm(); }
        public void Normalize() { float n = (float)GetNorm(); x /= n; y /= n; z /= n; w /= n; }

        public Vec4f(float x = 0, float y = 0, float z = 0, float w = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public Vec4f(Vec2f v1, Vec2f v2)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v2.x;
            this.w = v2.y;
        }
        public Vec4f(Vec2f v1, float z,float w)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = z;
            this.w = w;
        }
        public Vec4f(Vec3f v1, float w)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v1.z;
            this.w = w;
        }
        public Vec4f(Vec4f v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        public float SumXYZW()
        {
            return x + y + z + w;
        }

        public float[] ToArray()
        {
            return new float[] { x, y, z, w };
        }

        public override string ToString()
        {
            return x + " " + y + " " + z + " " + w;
        }
        /// <summary>
        /// Calculate the distance between current vector and v
        /// </summary>
        /// <param name="v">vector</param>
        public double Distance(Vec4 v)
        {
            return System.Math.Sqrt((x - v.x) * (x - v.x) + (y - v.y) * (y - v.y) + (z - v.z) * (z - v.z) + (w - v.w) * (w - v.w));
        }

        /// <summary>
        /// Calculate the distance between current vector and v
        /// </summary>
        /// <param name="v">vector</param>
        public double Distance(Vec4f v)
        {
            return System.Math.Sqrt((x - v.x) * (x - v.x) + (y - v.y) * (y - v.y) + (z - v.z) * (z - v.z) + (w - v.w) * (w - v.w));
        }

        /// <summary>
        /// Apply a function to each element of the vector
        /// </summary>
        /// <param name="f">function</param>
        public void ApplyFunction(Func<float, float> f)
        {
            x = f(x);
            y = f(y);
            z = f(z);
            w = f(w);
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
                    case 2: return z;
                    case 3: return w;
                    default: throw new Exception("Out of range");
                }
            }
            set
            {
                switch (i)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    case 3: w = value; break;
                    default: throw new Exception("Out of range");
                }
            }
        }

        // overload operator +
        public static Vec4f operator +(Vec4f a, Vec4f b)
        {
            return new Vec4f(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        // overload operator -
        public static Vec4f operator -(Vec4f a, Vec4f b)
        {
            return new Vec4f(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }

        // overload operator *
        public static Vec4f operator *(Vec4f a, float k)
        {
            return new Vec4f(a.x * k, a.y * k, a.z * k, a.w * k);
        }
        public static Vec4f operator *(float k, Vec4f a)
        {
            return new Vec4f(a.x * k, a.y * k, a.z * k, a.w * k);
        }
        //simple product
        public static Vec4f operator *(Vec4f a, Vec4f b)
        {
            return new Vec4f(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }

        // overload operator /
        public static Vec4f operator /(Vec4f a, float k)
        {
            return new Vec4f(a.x / k, a.y / k, a.z / k, a.w / k);
        }

        // overload implicit cast to vec4
        public static implicit operator Vec4(Vec4f v) => v!=null?new Vec4(v):null;

        // overload comparison
        public override bool Equals(object obj)
        {
            if (obj is Vec4f)
                return (obj as Vec4f) != null &&
                       x == (obj as Vec4f).x &&
                       y == (obj as Vec4f).y &&
                       z == (obj as Vec4f).z &&
                       w == (obj as Vec4f).w;
            else
                return false;
        }

        public static bool operator ==(Vec4f l, Vec4f r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec4f l, Vec4f r)
        {
            return !(l == r);
        }

        public override int GetHashCode()
        {
            var hashCode = -1743314642;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            hashCode = hashCode * -1521134295 + w.GetHashCode();
            return hashCode;
        }
        #endregion

    }
}
