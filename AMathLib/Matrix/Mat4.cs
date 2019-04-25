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
    public class Mat4
    {
        public const int Size = 4;

        protected Vec4[] cols = new Vec4[Size];

        /// <summary>
        /// Create new instance of the column i
        /// </summary>
        /// <param name="i">Column number</param>
        /// <returns></returns>
        public Vec4 GetCol(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec4(cols[i]);
        }
        /// <summary>
        /// Create new instance of the row i
        /// </summary>
        /// <param name="i">Row number</param>
        /// <returns></returns>
        public Vec4 GetRow(int i)
        {
            if (i < 0 || i >= Size)
                throw new Exception("Out of range");
            return new Vec4(cols[0][i], cols[1][i], cols[2][i], cols[3][i]);
        }


        public Mat4()
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();
        }
        public Mat4(Mat4 m)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4(m.cols[i]);
        }
        public Mat4(Vec4 c0, Vec4 c1, Vec4 c2, Vec4 c3)
        {
            cols[0] = new Vec4(c0);
            cols[1] = new Vec4(c1);
            cols[2] = new Vec4(c2);
            cols[3] = new Vec4(c3);
        }
        public Mat4(Vec4[] columns)
        {
            for(int i=0;i< Size; i++)
                cols[i] = new Vec4(columns[i]);
        }
        public Mat4(Mat3 m, Vec4 v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec4(m[i]);

            cols[Size - 1] = new Vec4(v);
        }
        public Mat4(Mat3 m, Vec4f v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec4(m[i]);

            cols[Size - 1] = new Vec4(v);
        }
        public Mat4(Mat3f m, Vec4 v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec4(m[i]);

            cols[Size - 1] = new Vec4(v);
        }
        public Mat4(Mat3f m, Vec4f v)
        {
            for (int i = 0; i < Size - 1; i++)
                cols[i] = new Vec4(m[i]);

            cols[Size - 1] = new Vec4(v);
        }
        public Mat4(Mat2f topLeft, Mat2f topRight, Mat2f bottomLeft, Mat2f bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2f topLeft, Mat2f topRight, Mat2f bottomLeft, Mat2 bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2f topLeft, Mat2f topRight, Mat2 bottomLeft, Mat2f bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2f topLeft, Mat2f topRight, Mat2 bottomLeft, Mat2 bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2f topLeft, Mat2 topRight, Mat2f bottomLeft, Mat2f bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2f topLeft, Mat2 topRight, Mat2f bottomLeft, Mat2 bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2f topLeft, Mat2 topRight, Mat2 bottomLeft, Mat2f bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2f topLeft, Mat2 topRight, Mat2 bottomLeft, Mat2 bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2 topLeft, Mat2f topRight, Mat2f bottomLeft, Mat2f bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2 topLeft, Mat2f topRight, Mat2f bottomLeft, Mat2 bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2 topLeft, Mat2f topRight, Mat2 bottomLeft, Mat2f bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2 topLeft, Mat2f topRight, Mat2 bottomLeft, Mat2 bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2 topLeft, Mat2 topRight, Mat2f bottomLeft, Mat2f bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2 topLeft, Mat2 topRight, Mat2f bottomLeft, Mat2 bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2 topLeft, Mat2 topRight, Mat2 bottomLeft, Mat2f bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
        public Mat4(Mat2 topLeft, Mat2 topRight, Mat2 bottomLeft, Mat2 bottomRight)
        {
            for (int i = 0; i < Size; i++)
                cols[i] = new Vec4();

            this[0, 0] = topLeft[0, 0]; this[0, 1] = topLeft[0, 1]; this[0, 2] = topRight[0, 0]; this[0, 3] = topRight[0, 1];
            this[1, 0] = topLeft[1, 0]; this[1, 1] = topLeft[1, 1]; this[1, 2] = topRight[1, 0]; this[1, 3] = topRight[1, 1];
            this[2, 0] = bottomLeft[0, 0]; this[2, 1] = bottomLeft[0, 1]; this[2, 2] = bottomRight[0, 0]; this[2, 3] = bottomRight[0, 1];
            this[3, 0] = bottomLeft[1, 0]; this[3, 1] = bottomLeft[1, 1]; this[3, 2] = bottomRight[1, 0]; this[3, 3] = bottomRight[1, 1];
        }
       

        public static Mat4 Identity()
        {
            Mat4 m = new Mat4();
            m[0, 0] = 1;
            m[1, 1] = 1;
            m[2, 2] = 1;
            m[3, 3] = 1;
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

        public void Set(Mat4 m)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = m[i, j];
        }

        public override string ToString()
        {
            return String.Format(
                 "[{00} {01} {02} {03} ; "+
                  "{04} {05} {06} {07} ; "+
                  "{08} {09} {10} {11} ; "+
                  "{12} {13} {14} {15}]",
                this[0, 0], this[0, 1], this[0, 2], this[0, 3],
                this[1, 0], this[1, 1], this[1, 2], this[1, 3],
                this[2, 0], this[2, 1], this[2, 2], this[2, 3],
                this[3, 0], this[3, 1], this[3, 2], this[3, 3]);
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
        public Vec4 this[int col]
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
        public static Vec4 operator *(Mat4 l, Vec4 r)
        {
            Vec4 Vr = new Vec4();
            for (int i = 0; i < Size; i++)
                Vr[i] = (new Vec4(l.cols[0][i], l.cols[1][i], l.cols[2][i], l.cols[3][i]) * r).SumXYZW();

            return Vr;
        }
        public static Mat4 operator *(Mat4 l, Mat4 r)
        {
            Mat4 Result = new Mat4();
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
        public void Translate(Vec3 v)
        {
            this[3] = this[0] * v[0] + this[1] * v[1] + this[2] * v[2] + this[3];
        }

        public void Scale(Vec3 v)
        {
            this[0] = this[0] * v[0];
            this[1] = this[1] * v[1];
            this[2] = this[2] * v[2];
            this[3] = this[3];
        }

        public void Rotate(double angle, Vec3 v)
        {
            var a = angle;
            var c = Math.Cos(a);
            var s = Math.Sin(a);

            Vec3 axis = v.CreateNormalizedVector();
            Vec3 temp = (1 - c) * axis;

            Mat4 Rotate = new Mat4();
            Rotate[0][0] = c + temp[0] * axis[0];
            Rotate[0][1] = temp[0] * axis[1] + s * axis[2];
            Rotate[0][2] = temp[0] * axis[2] - s * axis[1];

            Rotate[1][0] = temp[1] * axis[0] - s * axis[2];
            Rotate[1][1] = c + temp[1] * axis[1];
            Rotate[1][2] = temp[1] * axis[2] + s * axis[0];

            Rotate[2][0] = temp[2] * axis[0] + s * axis[1];
            Rotate[2][1] = temp[2] * axis[1] - s * axis[0];
            Rotate[2][2] = c + temp[2] * axis[2];

            Mat4 Result = new Mat4();
            Result[0] = this[0] * Rotate[0][0] + this[1] * Rotate[0][1] + this[2] * Rotate[0][2];
            Result[1] = this[0] * Rotate[1][0] + this[1] * Rotate[1][1] + this[2] * Rotate[1][2];
            Result[2] = this[0] * Rotate[2][0] + this[1] * Rotate[2][1] + this[2] * Rotate[2][2];
            Result[3] = this[3];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Result[i, j] = (float)Result[i, j];
            Set(Result);
        }

        public void Transpose()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    cols[i][j] = cols[j][i];
        }

        public void Inverse()
        {
            //Generated with https://github.com/willnode/N-Matrix-Programmer

            var A2323 = this[2, 2] * this[3, 3] - this[2, 3] * this[3, 2];
            var A1323 = this[2, 1] * this[3, 3] - this[2, 3] * this[3, 1];
            var A1223 = this[2, 1] * this[3, 2] - this[2, 2] * this[3, 1];
            var A0323 = this[2, 0] * this[3, 3] - this[2, 3] * this[3, 0];
            var A0223 = this[2, 0] * this[3, 2] - this[2, 2] * this[3, 0];
            var A0123 = this[2, 0] * this[3, 1] - this[2, 1] * this[3, 0];
            var A2313 = this[1, 2] * this[3, 3] - this[1, 3] * this[3, 2];
            var A1313 = this[1, 1] * this[3, 3] - this[1, 3] * this[3, 1];
            var A1213 = this[1, 1] * this[3, 2] - this[1, 2] * this[3, 1];
            var A2312 = this[1, 2] * this[2, 3] - this[1, 3] * this[2, 2];
            var A1312 = this[1, 1] * this[2, 3] - this[1, 3] * this[2, 1];
            var A1212 = this[1, 1] * this[2, 2] - this[1, 2] * this[2, 1];
            var A0313 = this[1, 0] * this[3, 3] - this[1, 3] * this[3, 0];
            var A0213 = this[1, 0] * this[3, 2] - this[1, 2] * this[3, 0];
            var A0312 = this[1, 0] * this[2, 3] - this[1, 3] * this[2, 0];
            var A0212 = this[1, 0] * this[2, 2] - this[1, 2] * this[2, 0];
            var A0113 = this[1, 0] * this[3, 1] - this[1, 1] * this[3, 0];
            var A0112 = this[1, 0] * this[2, 1] - this[1, 1] * this[2, 0];

            var det = this[0, 0] * (this[1, 1] * A2323 - this[1, 2] * A1323 + this[1, 3] * A1223)
                    - this[0, 1] * (this[1, 0] * A2323 - this[1, 2] * A0323 + this[1, 3] * A0223)
                    + this[0, 2] * (this[1, 0] * A1323 - this[1, 1] * A0323 + this[1, 3] * A0123)
                    - this[0, 3] * (this[1, 0] * A1223 - this[1, 1] * A0223 + this[1, 2] * A0123);

            if (det == 0)
                throw new Exception("Error: determinant is zero can't calculate inverse");

            det = 1 / det;

            Mat4 r = new Mat4();

            r[0, 0] = det * (this[1, 1] * A2323 - this[1, 2] * A1323 + this[1, 3] * A1223);
            r[0, 1] = det * -(this[0, 1] * A2323 - this[0, 2] * A1323 + this[0, 3] * A1223);
            r[0, 2] = det * (this[0, 1] * A2313 - this[0, 2] * A1313 + this[0, 3] * A1213);
            r[0, 3] = det * -(this[0, 1] * A2312 - this[0, 2] * A1312 + this[0, 3] * A1212);
            r[1, 0] = det * -(this[1, 0] * A2323 - this[1, 2] * A0323 + this[1, 3] * A0223);
            r[1, 1] = det * (this[0, 0] * A2323 - this[0, 2] * A0323 + this[0, 3] * A0223);
            r[1, 2] = det * -(this[0, 0] * A2313 - this[0, 2] * A0313 + this[0, 3] * A0213);
            r[1, 3] = det * (this[0, 0] * A2312 - this[0, 2] * A0312 + this[0, 3] * A0212);
            r[2, 0] = det * (this[1, 0] * A1323 - this[1, 1] * A0323 + this[1, 3] * A0123);
            r[2, 1] = det * -(this[0, 0] * A1323 - this[0, 1] * A0323 + this[0, 3] * A0123);
            r[2, 2] = det * (this[0, 0] * A1313 - this[0, 1] * A0313 + this[0, 3] * A0113);
            r[2, 3] = det * -(this[0, 0] * A1312 - this[0, 1] * A0312 + this[0, 3] * A0112);
            r[3, 0] = det * -(this[1, 0] * A1223 - this[1, 1] * A0223 + this[1, 2] * A0123);
            r[3, 1] = det * (this[0, 0] * A1223 - this[0, 1] * A0223 + this[0, 2] * A0123);
            r[3, 2] = det * -(this[0, 0] * A1213 - this[0, 1] * A0213 + this[0, 2] * A0113);
            r[3, 3] = det * (this[0, 0] * A1212 - this[0, 1] * A0212 + this[0, 2] * A0112);

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    this[i, j] = r[i, j];
        }
        #endregion

        public double Det()
        {

            var A2323 = this[2, 2] * this[3, 3] - this[2, 3] * this[3, 2];
            var A1323 = this[2, 1] * this[3, 3] - this[2, 3] * this[3, 1];
            var A1223 = this[2, 1] * this[3, 2] - this[2, 2] * this[3, 1];
            var A0323 = this[2, 0] * this[3, 3] - this[2, 3] * this[3, 0];
            var A0223 = this[2, 0] * this[3, 2] - this[2, 2] * this[3, 0];
            var A0123 = this[2, 0] * this[3, 1] - this[2, 1] * this[3, 0];
            var A2313 = this[1, 2] * this[3, 3] - this[1, 3] * this[3, 2];
            var A1313 = this[1, 1] * this[3, 3] - this[1, 3] * this[3, 1];
            var A1213 = this[1, 1] * this[3, 2] - this[1, 2] * this[3, 1];
            var A2312 = this[1, 2] * this[2, 3] - this[1, 3] * this[2, 2];
            var A1312 = this[1, 1] * this[2, 3] - this[1, 3] * this[2, 1];
            var A1212 = this[1, 1] * this[2, 2] - this[1, 2] * this[2, 1];
            var A0313 = this[1, 0] * this[3, 3] - this[1, 3] * this[3, 0];
            var A0213 = this[1, 0] * this[3, 2] - this[1, 2] * this[3, 0];
            var A0312 = this[1, 0] * this[2, 3] - this[1, 3] * this[2, 0];
            var A0212 = this[1, 0] * this[2, 2] - this[1, 2] * this[2, 0];
            var A0113 = this[1, 0] * this[3, 1] - this[1, 1] * this[3, 0];
            var A0112 = this[1, 0] * this[2, 1] - this[1, 1] * this[2, 0];

            return this[0, 0] * (this[1, 1] * A2323 - this[1, 2] * A1323 + this[1, 3] * A1223)
                    - this[0, 1] * (this[1, 0] * A2323 - this[1, 2] * A0323 + this[1, 3] * A0223)
                    + this[0, 2] * (this[1, 0] * A1323 - this[1, 1] * A0323 + this[1, 3] * A0123)
                    - this[0, 3] * (this[1, 0] * A1223 - this[1, 1] * A0223 + this[1, 2] * A0123);
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
