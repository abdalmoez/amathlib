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
    public class Vec3
    {
        public double x;
        public double y;
        public double z;

        public double GetNorm() { return System.Math.Sqrt(x * x + y * y + z * z ); }
        public Vec3 CreateNormalizedVector() { return this / GetNorm(); }
        public void Normalize() { double n = GetNorm(); x /= n; y /= n; z /= n;}

        public Vec3(double x =0,double y =0,double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3(Vec2 v, double z = 0)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
        }

        public Vec3(Vec2f v, double z = 0)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
        }

        public Vec3(Vec3f v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public Vec3(Vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public double SumXYZ()
        {
            return x + y + z;
        }

        public double[] ToArray()
        {
            return new double[] { x, y, z };
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
        public void ApplyFunction(Func<double, double> f)
        {
            x = f(x);
            y = f(y);
            z = f(z);
        }

        #region Operators definition
        // overload square bracket 
        public double this[int i]
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
        public static Vec3 operator +(Vec3 a, Vec3 b)
        {
            return new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vec3 operator +(Vec3 a, Vec3f b)
        {
            return new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vec3 operator +(Vec3f a, Vec3 b)
        {
            return new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        // overload operator -
        public static Vec3 operator -(Vec3 a, Vec3 b)
        {
            return new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vec3 operator -(Vec3f a, Vec3 b)
        {
            return new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vec3 operator -(Vec3 a, Vec3f b)
        {
            return new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        // overload operator /
        public static Vec3 operator /(Vec3 a, double k)
        {
            return new Vec3(a.x / k, a.y / k, a.z / k);
        }

        //cross product
        public static Vec3 operator ^(Vec3 a, Vec3 b)
        {
            return new Vec3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        public static Vec3 operator ^(Vec3 a, Vec3f b)
        {
            return new Vec3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        public static Vec3 operator ^(Vec3f a, Vec3 b)
        {
            return new Vec3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }
        //simple product
        public static Vec3 operator *(Vec3 a, Vec3 b)
        {
            return new Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public static Vec3 operator *(Vec3 a, Vec3f b)
        {
            return new Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public static Vec3 operator *(Vec3f a, Vec3 b)
        {
            return new Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        }


        // overload operator *
        public static Vec3 operator *(Vec3 a, double k)
        {
            return new Vec3(a.x * k, a.y * k, a.z * k);
        }
        public static Vec3 operator *(double k, Vec3 a)
        {
            return new Vec3(k, a.y * k, a.z * k);
        }

        // overload explicit cast to vec3f
        public static explicit operator Vec3f(Vec3 v) => new Vec3f((float)v.x, (float)v.y, (float)v.z);

        // overload comparison
        public override bool Equals(object obj)
        {
            if (obj is Vec3)
                return (obj as Vec3) != null &&
                       x == (obj as Vec3).x &&
                       y == (obj as Vec3).y &&
                       z == (obj as Vec3).z;
            else if (obj is Vec3f)
                return (obj as Vec3f) != null &&
                       x == (obj as Vec3f).x &&
                       y == (obj as Vec3f).y &&
                       z == (obj as Vec3f).z;
            else
                return false;
        }

        public static bool operator ==(Vec3 l, Vec3 r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec3 l, Vec3 r)
        {
            return !(l == r);
        }

        public static bool operator ==(Vec3 l, Vec3f r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec3 l, Vec3f r)
        {
            return !(l == r);
        }

        public static bool operator ==(Vec3f l, Vec3 r)
        {
            if (Object.ReferenceEquals(r, null))
                return false;

            return r.Equals(l);
        }
        public static bool operator !=(Vec3f l, Vec3 r)
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
