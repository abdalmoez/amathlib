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
    public class Mat3
    {
        public const int Size = 3;

        protected Vec3[] cols = new Vec3[Size];

        /// <summary>
        /// Create new instance of the column i
        /// </summary>
        /// <param name="i">Column number</param>
        /// <returns></returns>
        public Vec3 GetCol(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec3(cols[i]);
        }
        /// <summary>
        /// Create new instance of the row i
        /// </summary>
        /// <param name="i">Row number</param>
        /// <returns></returns>
        public Vec3 GetRow(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec3(cols[0][i], cols[1][i], cols[2][i]);
        }


        public Mat3()
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec3();
        }
        public Mat3(Mat3 m)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec3(m.cols[i]);
        }
        public Mat3(Mat3f m)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec3(m[i]);
        }
        public Mat3(Mat2 m, Vec3 v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec3(m[i]);

            cols[Size - 1] = new Vec3(v);
        }
        public Mat3(Mat2 m, Vec3f v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec3(m[i]);

            cols[Size - 1] = new Vec3(v);
        }
        public Mat3(Mat2f m, Vec3 v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec3(m[i]);

            cols[Size - 1] = new Vec3(v);
        }
        public Mat3(Mat2f m, Vec3f v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec3(m[i]);

            cols[Size - 1] = new Vec3(v);
        }
        public Mat3(Vec3 c0, Vec3 c1, Vec3 c2)
        {
            cols[0] = new Vec3(c0);
            cols[1] = new Vec3(c1);
            cols[2] = new Vec3(c2);
        }
        public Mat3(Vec3[] columns)
        {
            for(int i=0;i< Size; i++)
                cols[i] = new Vec3(columns[i]);
        }


        public static Mat3 Identity()
        {
            Mat3 m = new Mat3();
            m[0, 0] = 1;
            m[1, 1] = 1;
            m[2, 2] = 1;
            return m;
        }

        public double[] ToArray()
        {
            double[] r = new double[Size * Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    r[i + Size * j] = this[i, j];
            return r;
        }

        public void Set(Mat3 m)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = m[i, j];
        }

        public override string ToString()
        {
            return String.Format(
                 "[{00} {01} {02} ; "+
                  "{03} {04} {05} ; "+
                  "{06} {07} {08} ; ",
                this[0, 0], this[0, 1], this[0, 2],
                this[1, 0], this[1, 1], this[1, 2],
                this[2, 0], this[2, 1], this[2, 2]);
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
        public Vec3 this[int col]
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
        public static Vec3 operator *(Mat3 l, Vec3 r)
        {
            Vec3 Vr = new Vec3();
            for (int i = 0; i < Size; i++)
                Vr[i] = (new Vec3(l.cols[0][i], l.cols[1][i], l.cols[2][i]) * r).SumXYZ();

            return Vr;
        }
        public static Mat3 operator *(Mat3 l, Mat3 r)
        {
            Mat3 Result = new Mat3();
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

            var det = 
                this[0, 0] * (this[1, 1] * this[2, 2] - this[1, 2] * this[2, 1])
                - this[0, 1] * (this[1, 0] * this[2, 2] - this[1, 2] * this[2, 0])
                + this[0, 2] * (this[1, 0] * this[2, 1] - this[1, 1] * this[2, 0]);


            if (det == 0)
                throw new Exception("Error: determinant is zero can't calculate inverse");
            det = 1 / det;

            Mat3 r = new Mat3();

            r[0, 0] = det * (this[1, 1] * this[2, 2] - this[1, 2] * this[2, 1]);
            r[0, 1] = det * -(this[0, 1] * this[2, 2] - this[0, 2] * this[2, 1]);
            r[0, 2] = det * (this[0, 1] * this[1, 2] - this[0, 2] * this[1, 1]);
            r[1, 0] = det * -(this[1, 0] * this[2, 2] - this[1, 2] * this[2, 0]);
            r[1, 1] = det * (this[0, 0] * this[2, 2] - this[0, 2] * this[2, 0]);
            r[1, 2] = det * -(this[0, 0] * this[1, 2] - this[0, 2] * this[1, 0]);
            r[2, 0] = det * (this[1, 0] * this[2, 1] - this[1, 1] * this[2, 0]);
            r[2, 1] = det * -(this[0, 0] * this[2, 1] - this[0, 1] * this[2, 0]);
            r[2, 2] = det * (this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0]);
            
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = r[i, j];
        }
        #endregion

        public double Det()
        {
            return    this[0, 0] * (this[1, 1] * this[2, 2] - this[1, 2] * this[2, 1])
                    - this[0, 1] * (this[1, 0] * this[2, 2] - this[1, 2] * this[2, 0])
                    + this[0, 2] * (this[1, 0] * this[2, 1] - this[1, 1] * this[2, 0]);
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
