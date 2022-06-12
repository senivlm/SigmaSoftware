using System;
using System.Diagnostics.CodeAnalysis;

namespace Lesson7
{
    public class IntComparator: IComparable<int>
    {
        public IntComparator()
        {
        }

        public int CompareTo(int x, int y)
        {
            return x-y;
        }

        public int CompareTo([AllowNull] int other)
        {
            return - other;
        }
    }
}
