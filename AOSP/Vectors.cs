// Copyright (c) 2016 SolarLiner - Part of the TLE Orbiter Sceneraio Generator (TLEOSG)
using System;
/// <summary>
/// A class for storing 3-axies variables.
/// </summary>
/// <remarks></remarks>
public struct Vector3: IComparable
{
    /// <summary>
    /// X axis (Left)
    /// </summary>
    public double x
    {
        get
        {
            return _x;
        }
        set
        {
            _x = value;
        }
    }

    /// <summary>
    /// Y axis (Forward)
    /// </summary>
    public double y
    {
        get
        {
            return _y;
        }
        set
        {
            _y = value;
        }
    }

    /// <summary>
    /// Z axis (Up)
    /// </summary>
    public double z
    {
        get
        {
            return _z;
        }
        set
        {
            _z = value;
        }
    }

    double _x;
    double _y;
    double _z;

    /// <summary>
    /// Initializes a new Vector3 var.
    /// </summary>
    /// <param name="X">X axis</param>
    /// <param name="Y">Y axis</param>
    /// <param name="Z">Z axis</param>
    /// <remarks></remarks>
    public Vector3(double X, double Y, double Z)
    {
        _x = X;
        _y = Y;
        _z = Z;
    }

    // Operations section
    // Implicit cast from OrbitTools' Vector
    public static implicit operator Vector3(Zeptomoby.OrbitTools.Vector a)
    {
        if( a == null ) return new Vector3();
        return new Vector3(a.X, a.Y, a.Z) * 1000; // Convert km -> m
    }

    // Addition
    public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);

    public static Vector3 operator +(Vector3 a, double b) => new Vector3(a.x + b, a.y + b, a.z + b);
    public static Vector3 operator +(double a, Vector3 b) => b + a;

    // Subtraction
    public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

    public static Vector3 operator -(Vector3 a, double b) => new Vector3(a.x - b, a.y - b, a.z - b);

    public static Vector3 operator -(double a, Vector3 b) => new Vector3(a - b.x, a - b.y, a - b.z);

    // Negation
    public static Vector3 operator -(Vector3 a) => new Vector3(-a.x, -a.y, -a.z);

    // Reinforcement
    public static Vector3 operator +(Vector3 a) => new Vector3(+a.x, +a.y, +a.z);

    // Multiplication (scalar and cross product)
    public static Vector3 operator *(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);

    public static Vector3 operator *(Vector3 a, double b) => new Vector3(a.x * b, a.y * b, a.z * b);

    public static Vector3 operator *(double a, Vector3 b) => b * a;

    // Division (scalar, vector)
    public static Vector3 operator /(Vector3 a, Vector3 b) => new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);

    public static Vector3 operator /(Vector3 a, double b) => new Vector3(a.x / b, a.y / b, a.z / b);

    public static Vector3 operator /(double a, Vector3 b) => new Vector3(a / b.x, a / b.y, a / b.z);

    // Comparaison
    public static bool operator ==(Vector3 a, Vector3 b) => (a.x == b.x && a.y == b.y && a.z == b.z);

    public static bool operator !=(Vector3 a, Vector3 b) => !(a == b);

    public static bool operator <(Vector3 a, Vector3 b) => a.length < b.length;
    public static bool operator >(Vector3 a, Vector3 b) => b < a;

    public static bool operator <=(Vector3 a, Vector3 b) => a.length <= b.length;
    public static bool operator >=(Vector3 a, Vector3 b) => b <= a;


    // Extended functionality

    /// <summary>
    /// Sum of the square of each axis.
    /// </summary>
    /// <returns>The absolute value of the axis.</returns>
    public double absolute => x * x + y * y + z * z;

    /// <summary>
    /// Magnetude of the vector.
    /// </summary>
    public double length => Math.Sqrt(absolute);

    /// <summary>
    /// Get the normalized vector.
    /// </summary>
    /// <returns>Return the normalized vector.</returns>
    public Vector3 normalized => new Vector3(x / length, y / length, z / length);

    /// <summary>
    /// Convert the current vector into a normalized (length = 1) vector.
    /// </summary>
    public void Normalize()
    {
        this = this.normalized;
    }

    /// <summary>
    /// True if length is 1 (normalized vector).
    /// </summary>
    public bool IsUnit => length == 1;

    // Static functions, to be used without Vec3 defined

    /// <summary>
    /// Converts vector to Relative space.
    /// </summary>
    /// <param name="parent">Parent vector.</param>
    /// <param name="point2">"Future" child.</param>
    /// <returns>Relative child vector.</returns>
    public static Vector3 Relative(Vector3 parent, Vector3 point2) => point2 - parent;

    /// <summary>
    /// Converts vector to Global space.
    /// </summary>
    /// <param name="parent">parent vector</param>
    /// <param name="child">child vector</param>
    /// <returns>Global space vector of the current one.</returns>
    public static Vector3 Global(Vector3 parent, Vector3 child) => parent + child;

    internal static bool IsZero(Vector3 v) => v.absolute < double.Epsilon;

    /// <summary>
    /// Dot product of two vectors
    /// </summary>
    /// <param name="a">first vector.</param>
    /// <param name="b">second vector.</param>
    /// <returns>double value with the dot product.</returns>
    public static double dot(Vector3 a, Vector3 b) => a.x * b.x + a.y * b.y + a.z * b.z;

    /// <summary>
    /// Checks for a normalized vector.
    /// </summary>
    /// <param name="a">Vector to be checked.</param>
    /// <returns>True if normalized, else false.</returns>
    public static bool IsUnitVector(Vector3 a) => a.length == 1;

    /// <summary>
    /// Linearly interpolate two vectors.
    /// </summary>
    /// <param name="a">start point</param>
    /// <param name="b">end point</param>
    /// <param name="control">position between the two vectors, between 0 and 1.</param>
    /// <returns>The vector between the two given vector, at control point.</returns>
    public static Vector3 Interpolate(Vector3 a, Vector3 b, float control) => new Vector3(
        a.x * (1 - control) + b.x * control,
        a.y * (1 - control) + b.y * control,
        a.z * (1 - control) + b.z * control);

    /// <summary>
    /// Calculates the distance between two points.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <returns>The distance between the points.</returns>
    public static double Distance(Vector3 a, Vector3 b) => Math.Sqrt(
    Math.Pow(a.x - b.x, 2) +
    Math.Pow(a.y - b.y, 2) +
    Math.Pow(a.z - b.z, 2));

    /// <summary>
    /// Calculate the angle between two vectors and the origin.
    /// </summary>
    /// <param name="a">First vector.</param>
    /// <param name="b">Second vector.</param>
    /// <returns>Angle in radians.</returns>
    public static double Angle(Vector3 a, Vector3 b) => Math.Acos(dot(a.normalized, b.normalized));

    /// <summary>
    /// Calculates the triple scalar product. Also volume of a parallelepiped geometric shape.
    /// </summary>
    /// <param name="a">vector a</param>
    /// <param name="b">vector b</param>
    /// <param name="c">vector c</param>
    /// <returns>Returns the scalar triple product</returns>
    [Obsolete("MixedProduct is no longer supported, it will be removed on the next version.")]
    public static double MixedProduct(Vector3 a, Vector3 b, Vector3 c) => ScalarProduct(a, b, c);

    /// <summary>
    /// Calculates the triple scalar product. Also volume of a parallelepiped geometric shape.
    /// </summary>
    /// <param name="a">vector a</param>
    /// <param name="b">vector b</param>
    /// <param name="c">vector c</param>
    /// <returns>Returns the scalar triple product</returns>
    public static double ScalarProduct(Vector3 a, Vector3 b, Vector3 c) => dot(a * b, c);

    /// <summary>
    /// Elevate a Vector to a power.
    /// </summary>
    /// <param name="a">Vector input</param>
    /// <param name="power">Power to raise the vector with</param>
    /// <returns>Returns the multiplied vector by a specific power</returns>
    public static Vector3 Pow(Vector3 a, double power) => new Vector3(
    Math.Pow(a.x, power),
    Math.Pow(a.y, power),
    Math.Pow(a.z, power));

    /// <summary>
    /// Transforms each axis of the current vector using the given function.
    /// </summary>
    /// <param name="function">Function to transform the vector. Have to output a double.</param>
    /// <returns>Transformed vector.</returns>
    public Vector3 ForEachAxis(Func<double, double> function) => new Vector3(function(this.x), function(this.y), function(this.z));

    // Usability funcs,  (Interfaces implementations such as IComparable)

    /// <summary>
    /// Orbiter formatted "x y z" string format.
    /// </summary>
    /// <returns>Returns string "Orbiter-ready" formatted "x y z"</returns>
    public override string ToString() => string.Format("{0} {1} {2}", x, y, z);

    /// <summary>
    /// Returns string with the asked axis
    /// </summary>
    /// <param name="format">returning axis (x, y or z)</param>
    /// <param name="fmProvider">format provider</param>
    /// <returns></returns>
    public string ToString(string format, IFormatProvider fmProvider)
    {
        char first = format[0];
        string remainder = null;

        if (format.Length > 1) remainder = format.Substring(1);

        switch (first)
        {
            case 'x':
                return x.ToString(remainder, fmProvider);
            case 'y':
                return y.ToString(remainder, fmProvider);
            case 'z':
                return z.ToString(remainder, fmProvider);
            default:
                throw new ArgumentException("Wrong format");
        }
    }

    /// <summary>
    /// Get Hash code (for system use)
    /// </summary>
    /// <returns>Hash code [int].</returns>
    public override int GetHashCode() => (int)((x + y + z) % Int32.MaxValue);

    /// <summary>
    /// Same as operator ==. True if equal, false if not or not same type.
    /// </summary>
    /// <param name="obj">other parameter</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj is Vector3)
        {
            Vector3 b = (Vector3)obj;

            return this == b;
        }
        else return false;
    }

    /// <summary>
    /// Compare function to implement the IComparable[Vector3] interfaces
    /// </summary>
    /// <param name="other">Other object to compare.</param>
    /// <returns></returns>
    public int CompareTo(object other)
    {
        if( other is Vector3 )
        {
            Vector3 b = (Vector3)other;
            if( this < b ) return 1;
            else if( this > b ) return -1;
            else return 0;
        }
        throw new ArgumentException("Cannot compare Vector and non-Vector: " + other.GetType(), nameof(other));
    }

    // Constants

    /// <summary>
    /// Origin.
    /// </summary>
    public static readonly Vector3 Zero = new Vector3(0, 0, 0);

    /// <summary>
    /// Forward normalized vector
    /// </summary>
    public static readonly Vector3 Forward = new Vector3(0, 1, 0);

    /// <summary>
    /// Left normalized vector, assuming left-handed world
    /// </summary>
    public static readonly Vector3 Left = new Vector3(1, 0, 0);

    /// <summary>
    /// Up normalized vector
    /// </summary>
    public static readonly Vector3 Up = new Vector3(0, 0, 1);

    /// <summary>
    /// Minimum values that can be entered.
    /// </summary>
    public static readonly Vector3 MinValue = new Vector3(double.MinValue, double.MinValue, double.MinValue);

    /// <summary>
    /// Maximum value that can be entered.
    /// </summary>
    public static readonly Vector3 MaxValue = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);

    /// <summary>
    /// Minimum non-zero value that can be entered.
    /// </summary>
    public static readonly Vector3 Epsilon = new Vector3(double.Epsilon, double.Epsilon, double.Epsilon); /// Minimum positive non-zero vector
}