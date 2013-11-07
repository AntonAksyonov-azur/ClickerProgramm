using System;
using System.Threading;

namespace Clicker.com.arazect.clicker.data
{
    public struct ClickPoint
    {
        public int X;
        public int Y;
        public String Name;

        public override string ToString()
        {
            return String.Format("{0} ({1}:{2})", Name, X, Y);
        }

        public static bool operator ==(ClickPoint a, ClickPoint b)
        {
            return a.X == b.X && a.Y == b.Y && a.Name == b.Name;
        }

        public static bool operator !=(ClickPoint a, ClickPoint b)
        {
            return !(a == b);
        }

        public bool Equals(ClickPoint other)
        {
            return X == other.X && Y == other.Y && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ClickPoint && Equals((ClickPoint)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
