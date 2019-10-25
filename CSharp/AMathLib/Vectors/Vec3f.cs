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
    public class Vec3f
    {
        public float x;
        public float y;
        public float z;
        
        public double GetNorm() { return System.Math.Sqrt(x * x + y * y + z * z); }
        public Vec3f CreateNormalizedVector() { return this / (float)GetNorm(); }
        public void Normalize() { float n = (float)GetNorm(); x /= n; y /= n; z /= n; }

        public Vec3f(float x =0,float y =0,float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3f(Vec2f v, float z = 0)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
        }

        public Vec3f(Vec3f v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public float SumXYZ()
        {
            return x + y + z;
        }

        public void Set(Vec3f v)
        {
            if (v != null)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }

        public float[] ToArray()
        {
            return new float[] { x, y, z };
        }

        public override string ToString()
        {
            return x + " " + y + " " + z;
        }
        /// <summary>
        /// Calculate the distance between current vector and v
        /// </summary>
        /// <param name="v">vector</param>
        public double Distance(Vec3 v)
        {
            return System.Math.Sqrt((x - v.x) * (x - v.x) + (y - v.y) * (y - v.y) + (z - v.z) * (z - v.z));
        }

        /// <summary>
        /// Calculate the distance between current vector and v
        /// </summary>
        /// <param name="v">vector</param>
        public double Distance(Vec3f v)
        {
            return System.Math.Sqrt((x - v.x) * (x - v.x) + (y - v.y) * (y - v.y) + (z - v.z) * (z - v.z));
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
                    default: throw new Exception("Out of range");
                }
            }
        }

        // overload operator +
        public static Vec3f operator +(Vec3f a, Vec3f b)
        {
            return new Vec3f(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        // overload operator -
        public static Vec3f operator -(Vec3f a, Vec3f b)
        {
            return new Vec3f(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        // overload operator *
        public static Vec3f operator *(Vec3f a, float k)
        {
            return new Vec3f(a.x * k, a.y * k, a.z * k);
        }
        public static Vec3f operator *(float k, Vec3f a)
        {
            return new Vec3f(a.x * k, a.y * k, a.z * k);
        }

        // overload operator /
        public static Vec3f operator /(Vec3f a, float k)
        {
            return new Vec3f(a.x / k, a.y / k, a.z / k);
        }

        // cross product
        public static Vec3f operator ^(Vec3f a, Vec3f b)
        {
            return new Vec3f(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        //simple product
        public static Vec3f operator *(Vec3f a, Vec3f b)
        {
            return new Vec3f(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        // overload implicit cast to Vec3
        public static implicit operator Vec3(Vec3f v) => new Vec3(v);

        // overload comparison
        public override bool Equals(object obj)
        {
            if (obj is Vec3f)
                return (obj as Vec3f) != null &&
                       x == (obj as Vec3f).x &&
                       y == (obj as Vec3f).y &&
                       z == (obj as Vec3f).z;
            else
                return false;
        }

        public static bool operator ==(Vec3f l, Vec3f r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec3f l, Vec3f r)
        {
            return !(l == r);
        }

        public override int GetHashCode()
        {
            var hashCode = -1743314642;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }

        #endregion
    }
}
