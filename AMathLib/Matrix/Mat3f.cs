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
    public class Mat3f
    {
        public const int Size = 3;

        protected Vec3f[] cols = new Vec3f[Size];

        /// <summary>
        /// Create new instance of the column i
        /// </summary>
        /// <param name="i">Column number</param>
        /// <returns></returns>
        public Vec3f GetCol(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec3f(cols[i]);
        }
        /// <summary>
        /// Create new instance of the row i
        /// </summary>
        /// <param name="i">Row number</param>
        /// <returns></returns>
        public Vec3f GetRow(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec3f(cols[0][i], cols[1][i], cols[2][i]);
        }


        public Mat3f()
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec3f();
        }
        public Mat3f(Mat3f m)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec3f(m.cols[i]);
        }
        public Mat3f(Mat2f m, Vec3f v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec3f(m[i]);

            cols[Size - 1] = new Vec3f(v);
        }
        public Mat3f(Vec3f c0, Vec3f c1, Vec3f c2)
        {
            cols[0] = new Vec3f(c0);
            cols[1] = new Vec3f(c1);
            cols[2] = new Vec3f(c2);
        }
        public Mat3f(Vec3f[] columns)
        {
            for(int i=0;i< Size; i++)
                cols[i] = new Vec3f(columns[i]);
        }

        public static Mat3f Identity()
        {
            Mat3f m = new Mat3f();
            m[0, 0] = 1;
            m[1, 1] = 1;
            m[2, 2] = 1;
            return m;
        }

        public float[] ToArray()
        {
            float[] r = new float[Size * Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    r[i * Size + i] = this[i, j];
            return r;
        }

        public void Set(Mat3f m)
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
        public Vec3f this[int col]
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
        public static Vec3f operator *(Mat3f l, Vec3f r)
        {
            Vec3f Vr = new Vec3f();
            for (int i = 0; i < Size; i++)
                Vr[i] = (new Vec3f(l.cols[0][i], l.cols[1][i], l.cols[2][i]) * r).SumXYZ();

            return Vr;
        }
        public static Mat3f operator *(Mat3f l, Mat3f r)
        {
            Mat3f Result = new Mat3f();
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

            Mat3f r = new Mat3f();

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
        public void ApplyFunction(Func<float, float> f)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = f(this[i, j]);
        }
    }
}
