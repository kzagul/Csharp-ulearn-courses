using System;
using System.Diagnostics.CodeAnalysis;

namespace Inheritance.Geometry
{
    public readonly struct Vector3
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 CreatePoint(double dx = 0, double dy = 0, double dz = 0)
        {
            return new Vector3(X + dx, Y + dy, Z + dz);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                v1.X + v2.X,
                v1.Y + v2.Y,
                v1.Z + v2.Z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                v1.X - v2.X,
                v1.Y - v2.Y,
                v1.Z - v2.Z);
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }

        public static bool operator >=(Vector3 v1, Vector3 v2)
        {
            return v1.X >= v2.X && v1.Y >= v2.Y && v1.Z >= v2.Z;
        }

        public static bool operator <=(Vector3 v1, Vector3 v2)
        {
            return v1.X <= v2.X && v1.Y <= v2.Y && v1.Z <= v2.Z;
        }

        public double GetLength2()
        {
            return X * X + Y * Y + Z * Z;
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != this.GetType()) return false;

            var otherVector = (Vector3) obj;
            return X == otherVector.X
                   && Y == otherVector.Y
                   && Z == otherVector.Z;
        }

        public bool Equals(Vector3 otherVector, double inaccuracy)
        {
            return Math.Abs(X - otherVector.X) < inaccuracy
                   && Math.Abs(Y - otherVector.Y) < inaccuracy
                   && Math.Abs(Z - otherVector.Z) < inaccuracy;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"[{X},{Y},{Z}]";
        }
    }
}
