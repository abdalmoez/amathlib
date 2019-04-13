# AMathLib

AMathLib is a C# library. It provides classes and functions designed and implemented for Matrix and Vectors operations.
This project was build using Visual Studio 2017 and .Net Framework 3.5 Client Profile.

# Vectors
  - Vectors of size 2,3 and 4 are available with operations **+ , - , / , * , ^ (Cross Product for Vec3) , == , !=**
  - You can access each element of the vector using square bracket **v[i]**
  - Norm can be calculated using GetNorm() function
  - Normal Vector can be calculated using **GetNormalizedVector()** or you can normalize your current vector using **Normalize()** function
  - **SumXYZW()**, **SumXYZ()** and **SumXY()** allow you to calculate the sum of each component of the vector
  - **ToArray()** convert your current vector to array
  - **Distance(Vec? v)** Calculate the distance between current vector and the vector v
  - **ApplyFunction(Func<T, T> f)** allow you to apply a function to each component of the vector where T is the type of the component(double, float, ...)

# Matrix
  - Matrix of size 4 are available with operations matrix and vector multiplication 
  - You can acces matrix using square bracket **mat[int row, int col]** or **mat[int col]**
  - **ApplyFunction(Func<T, T> f)** allow you to apply a function to each component of the matrix where T is the type of the component(double, float, ...)
  - To Calculate determinant use **Det()** function
  - To create a matrix identity use **Mat4.Identity()**
  - To create new vector containing the values of a matrix row / column use **GetRow(i)** / **GetCol(i)**;
  - Matrix Manipulation
    * **Translate(Vec3 v)**
    * **Scale(Vec3 v)**
    * **Rotate(double angle, Vec3 v)**
    * **Transpose()**
    * **Inverse()**

# TODO
  - Create Matrix and vectors of type int, uint, short, ushort, byte, ubyte and bool


License
----

**This project is under GNU General Public License version 2 only**

