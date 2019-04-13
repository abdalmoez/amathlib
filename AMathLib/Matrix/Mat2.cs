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
    public class Mat2
    {
        public const int Size = 2;

        protected Vec2[] cols = new Vec2[Size];

        /// <summary>
        /// Create new instance of the column i
        /// </summary>
        /// <param name="i">Column number</param>
        /// <returns></returns>
        public Vec2 GetCol(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec2(cols[i]);
        }
        /// <summary>
        /// Create new instance of the row i
        /// </summary>
        /// <param name="i">Row number</param>
        /// <returns></returns>
        public Vec2 GetRow(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec2(cols[0][i], cols[1][i]);
        }


        public Mat2()
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec2();
        }
        public Mat2(Mat2 m)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec2(m.cols[i]);
        }
        public Mat2(Mat2f m)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec2(m[i]);
        }
        public Mat2(Vec2 c0, Vec2 c1)
        {
            cols[0] = new Vec2(c0);
            cols[1] = new Vec2(c1);
        }
        public Mat2(Vec2[] columns)
        {
            for(int i=0;i< Size; i++)
                cols[i] = new Vec2(columns[i]);
        }

        public static Mat2 Identity()
        {
            Mat2 m = new Mat2();
            m[0, 0] = 1;
            m[1, 1] = 1;
            return m;
        }

        public void Set(Mat2 m)
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
        public double this[int row, int col]
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
        public Vec2 this[int col]
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
        public static Vec2 operator *(Mat2 l, Vec2 r)
        {
            Vec2 Vr = new Vec2();
            for (int i = 0; i < Size; i++)
                Vr[i] = (new Vec2(l.cols[0][i], l.cols[1][i]) * r).SumXY();

            return Vr;
        }
        public static Mat2 operator *(Mat2 l, Mat2 r)
        {
            Mat2 Result = new Mat2();
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

            Mat2 r = new Mat2();

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
        /// <summary>
        /// Apply a function to each element of the matrix
        /// </summary>
        /// <param name="f">function</param>
        public void ApplyFunction(Func<double, double> f)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = f(this[i, j]);
        }
    }
}
