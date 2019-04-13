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
    public class Vec2
    {
        public double x;
        public double y;

        public double GetNorm() { return System.Math.Sqrt(x * x + y * y); }

        public Vec2(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2(Vec2f v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        
        public Vec2(Vec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public double SumXY()
        {
            return x + y;
        }

        public double[] ToArray()
        {
            return new double[] { x, y };
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
        public void ApplyFunction(Func<double, double> f)
        {
            x = f(x);
            y = f(y);
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
        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x + b.x, a.y + b.y);
        }
        public static Vec2 operator +(Vec2 a, Vec2f b)
        {
            return new Vec2(a.x + b.x, a.y + b.y);
        }
        public static Vec2 operator +(Vec2f a, Vec2 b)
        {
            return new Vec2(a.x + b.x, a.y + b.y);
        }
        // overload operator -
        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x - b.x, a.y - b.y);
        }
        public static Vec2 operator -(Vec2f a, Vec2 b)
        {
            return new Vec2(a.x - b.x, a.y - b.y);
        }
        public static Vec2 operator -(Vec2 a, Vec2f b)
        {
            return new Vec2(a.x - b.x, a.y - b.y);
        }

        // overload operator *
        public static Vec2 operator *(Vec2 a, double k)
        {
            return new Vec2(a.x * k, a.y * k);
        }
        public static Vec2 operator *(double k, Vec2 a)
        {
            return new Vec2(a.x * k, a.y * k);
        }
        //simple product
        public static Vec2 operator *(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x * b.x, a.y * b.y);
        }
        public static Vec2 operator *(Vec2 a, Vec2f b)
        {
            return new Vec2(a.x * b.x, a.y * b.y);
        }
        public static Vec2 operator *(Vec2f a, Vec2 b)
        {
            return new Vec2(a.x * b.x, a.y * b.y);
        }

        // overload explicit cast to vec2f
        public static explicit operator Vec2f(Vec2 v) => new Vec2f((float)v.x, (float)v.y);

        // overload comparison
        public override bool Equals(object obj)
        {
            if (obj is Vec2)
                return (obj as Vec2) != null &&
                       x == (obj as Vec2).x &&
                       y == (obj as Vec2).y;
            else if (obj is Vec2f)
                return (obj as Vec2f) != null &&
                       x == (obj as Vec2f).x &&
                       y == (obj as Vec2f).y;
            else
                return false;
        }

        public static bool operator ==(Vec2 l, Vec2 r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec2 l, Vec2 r)
        {
            return !(l == r);
        }

        public static bool operator ==(Vec2 l, Vec2f r)
        {
            if (Object.ReferenceEquals(l, null))
                return false;

            return l.Equals(r);
        }
        public static bool operator !=(Vec2 l, Vec2f r)
        {
            return !(l == r);
        }

        public static bool operator ==(Vec2f l, Vec2 r)
        {
            if (Object.ReferenceEquals(r, null))
                return false;

            return r.Equals(l);
        }
        public static bool operator !=(Vec2f l, Vec2 r)
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
