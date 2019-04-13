///////////////////////////////////////////////////////////////////////////////
//     Copyright (C) 2019 Bouraoui Al-Moez L.A. (abdalmoez720@gmail.com)     //
///////////////////////////////////////////////////////////////////////////////
//                                                                           //
//     This file is part of the AMathLib, and is made available under        //
//     the terms of the GNU General Public License version 2 only.           //
//                                                                           //
///////////////////////////////////////////////////////////////////////////////
using AMathLib.Vectors;
using System;

namespace AMathLib.Matrix
{
    public class Mat2f
    {
        public const int Size = 2;

        protected Vec2f[] cols = new Vec2f[Size];

        /// <summary>
        /// Create new instance of the column i
        /// </summary>
        /// <param name="i">Column number</param>
        /// <returns></returns>
        public Vec2f GetCol(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec2f(cols[i]);
        }
        /// <summary>
        /// Create new instance of the row i
        /// </summary>
        /// <param name="i">Row number</param>
        /// <returns></returns>
        public Vec2f GetRow(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec2f(cols[0][i], cols[1][i]);
        }


        public Mat2f()
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec2f();
        }
        public Mat2f(Mat2f m)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec2f(m.cols[i]);
        }
        public Mat2f(Vec2f c0, Vec2f c1)
        {
            cols[0] = new Vec2f(c0);
            cols[1] = new Vec2f(c1);
        }
        public Mat2f(Vec2f[] columns)
        {
            for(int i=0;i< Size; i++)
                cols[i] = new Vec2f(columns[i]);
        }

        public static Mat2f Identity()
        {
            Mat2f m = new Mat2f();
            m[0, 0] = 1;
            m[1, 1] = 1;
            return m;
        }

        public void Set(Mat2f m)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = m[i, j];
        }

        public override string ToString()
        {
            return String.Format(
                 "[{00} {01} ; "+
                  "{02} {03} ; ",
                this[0, 0], this[0, 1],
                this[1, 0], this[1, 1]);
        }
        
        #region Operators definition
        // overload square bracket 
        public float this[int row, int col]
        {
            get
            {
                return cols[col][row];
            }
            set
            {
                cols[col][row] = value;
            }
        }
        public Vec2f this[int col]
        {
            get
            {
                return cols[col];
            }
            set
            {
                cols[col] = value;
            }
        }

        // overload operator *
        public static Vec2f operator *(Mat2f l, Vec2f r)
        {
            Vec2f Vr = new Vec2f();
            for (int i = 0; i < Size; i++)
                Vr[i] = (new Vec2f(l.cols[0][i], l.cols[1][i]) * r).SumXY();

            return Vr;
        }
        public static Mat2f operator *(Mat2f l, Mat2f r)
        {
            Mat2f Result = new Mat2f();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int k = 0; k < Size; k++)
                    {
                        Result[i, j] += l[i, k] * r[k, j];
                    }
                }
            }
            return Result;
        }
        #endregion

        #region Matrix Manipulation
        public void Transpose()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    cols[i][j] = cols[j][i];
        }

        public void Inverse()
        {
            //Generated with https://github.com/willnode/N-Matrix-Programmer

            var det =     this[0, 0] * this[1, 1]
                        - this[0, 1] * this[1, 0];

            if (det == 0)
                throw new Exception("Error: determinant is zero can't calculate inverse");
            det = 1 / det;

            Mat2f r = new Mat2f();

            r[0, 0] = det * (this[1, 1]);
            r[0, 1] = det * -(this[0, 1]);
            r[1, 0] = det * -(this[1, 0]);
            r[1, 1] = det * (this[0, 0]);
            
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = r[i, j];
        }
        #endregion

        public double Det()
        {
            return    this[0, 0] * this[1, 1]
                    - this[0, 1] * this[1, 0];
        }

    }
}
