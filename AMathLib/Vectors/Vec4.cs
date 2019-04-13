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
    public class Vec4
    {
        public double x;
        public double y;
        public double z;
        public double w;
        
        public double GetNorm() { return System.Math.Sqrt(x * x + y * y + z * z + w * w); }

        public Vec4(double x = 0, double y = 0, double z = 0, double w = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public Vec4(Vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }
        public Vec4(Vec4f v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }
        public Vec4(Vec2f v1, Vec2f v2)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v2.x;
            this.w = v2.y;
        }
        public Vec4(Vec2f v1, Vec2 v2)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v2.x;
            this.w = v2.y;
        }
        public Vec4(Vec2 v1, Vec2 v2)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v2.x;
            this.w = v2.y;
        }
        public Vec4(Vec2 v1, Vec2f v2)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v2.x;
            this.w = v2.y;
        }
        public Vec4(Vec2 v1, double z, double w)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = z;
            this.w = w;
        }
        public Vec4(Vec3f v1, double w)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v1.z;
            this.w = w;
        }
        public Vec4(Vec3 v1, double w)
        {
            this.x = v1.x;
            this.y = v1.y;
            this.z = v1.z;
            this.w = w;
        }

        public double SumXYZW()
        {
            return x + y + z + w;
        }

        public double[] ToArray()
        {
            return new double[] { x, y, z, w };
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
        public void ApplyFunction(Func<double, double> f)
        {
            x = f(x);
            y = f(y);
            z = f(z);
            w = f(w);
        }

        #region Operators definition
        // overload square bracket 
        public double this[int i]
        {
            get {
                switch (i) {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    case 3: return w;
                    default:throw new Exception("Out of range");
                }
            }
            set {
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
        public static Vec4 operator +(Vec4 a, Vec4 b)
        {
            return new Vec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        public static Vec4 operator +(Vec4 a, Vec4f b)
        {
            return new Vec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        public static Vec4 operator +(Vec4f a, Vec4 b)
        {
            return new Vec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        // overload operator -
        public static Vec4 operator -(Vec4 a, Vec4 b)
        {
            return new Vec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        public static Vec4 operator -(Vec4f a, Vec4 b)
        {
            return new Vec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        public static Vec4 operator -(Vec4 a, Vec4f b)
        {
            return new Vec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }

        // overload operator *
        public static Vec4 operator *(Vec4 a, double k)
        {
            return new Vec4(a.x * k, a.y * k, a.z * k, a.w * k);
        }
        public static Vec4 operator *(double k, Vec4 a)
        {
            return new Vec4(a.x * k, a.y * k, a.z * k, a.w * k);
        }
        //simple product
        public static Vec4 operator *(Vec4 a, Vec4 b)
        {
            return new Vec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        public static Vec4 operator *(Vec4f a, Vec4 b)
        {
            return new Vec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        public static Vec4 operator *(Vec4 a, Vec4f b)
        {
            return new Vec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        // overload operator neg
        public static Vec4 operator -(Vec4 v)
        {
            return new Vec4(-v.x, -v.y, -v.z, -v.w);
        }
        // overload explicit cast to vec4f
        public static explicit operator Vec4f(Vec4 v) => new Vec4f((float)v.x, (float)v.y, (float)v.z, (float)v.w);

        // overload comparison
        public override bool Equals(object obj)
        {
            if (obj is Vec4)
                return (obj as Vec4) != null &&
                       x == (obj as Vec4).x &&
                       y == (obj as Vec4).y &&
                       z == (obj as Vec4).z &&
                       w == (obj as Vec4).w;
             else if (obj is Vec4f)
                return (obj as Vec4f) != null &&
                       x == (obj as Vec4f).x &&
                       y == (obj as Vec4f).y &&
                       z == (obj as Vec4f).z &&
                       w == (obj as Vec4f).w;
            else 
                return false;
        }

        public static bool operator ==(Vec4 l, Vec4 r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec4 l, Vec4 r)
        {
            return !(l == r);
        }

        public static bool operator ==(Vec4 l, Vec4f r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec4 l, Vec4f r)
        {
            return !(l == r);
        }
        
        public static bool operator ==(Vec4f l, Vec4 r)
        {
            if (Object.ReferenceEquals(r, null))
                return false;

            return r.Equals(l);
        }
        public static bool operator !=(Vec4f l, Vec4 r)
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
