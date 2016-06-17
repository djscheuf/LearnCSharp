using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DJS.Common.Examples.Tests.Katas._01_BinaryChop.Classes
{
    internal class BinaryChop_02
    {
        private int _q;
        private int[] _input;

        public int chop(int q, int[] input)
        {
            _q = q;
            _input = input;
            var end = input.Count() - 1;
            if (end < 0)
                return -1;

            if (end == 0)
               return (input[0] == q) ? 0 : -1;

            var half = (int) Math.Ceiling(end/2.0);

            return SplitSearching(0, half, end);
        }

        private int SplitSearching(int start, int half, int stop)
        {
            var leftResult = ChopHalf(start, half);

            if (leftResult < 0)
            {
                var rightResult = ChopHalf(half, stop);
                if (rightResult < 0)
                    return -1;
                return rightResult;
            }

            return leftResult;
        }

        private int ChopHalf(int start, int stop)
        {
            if (start == stop)
                return -1;

            if((stop-start) == 1)
                if (_input[start] == _q)
                    return start;
                else if (_input[stop] == _q)
                    return stop;
                else
                    return -1;

            var half = GetHalfway(start, stop);
            if (_input[half] == _q)
                return half;

            return SplitSearching(start, half, stop);
        }

        private int GetHalfway(int start, int stop)
        {
            var dist = (int) Math.Ceiling((stop - start)/2.0);
            if (dist == 0)
                dist = 1;
            var next = stop - dist;

            if (next == start)
                return start + 1;
            return next;
        }
    }
}
