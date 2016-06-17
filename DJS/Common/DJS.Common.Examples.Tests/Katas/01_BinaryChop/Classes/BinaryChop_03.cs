using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DJS.Common.Examples.Tests.Katas._01_BinaryChop.Classes
{
    class BinaryChop_03
    {
        private int _q;
        private int[] _input;

        public int chop(int q, int[] input)
        {
            _q = q;
            _input = input;

            var max = input.Count() - 1;
            if (max<0)
                return -1;

            if (max == 0)
                return (_input[0] == _q) ? 0 : -1;

            return ConstrainedCheck(0, max);
        }

        private int ConstrainedCheck(int min, int max)
        {
            var boundsCheck = CheckBounds(min, max);
            if (boundsCheck >= 0)
                return boundsCheck;

            var midCheck = GetMidCheck(min, max);
            if (midCheck < 0)
                return -1;

            var value = _input[midCheck];
            if (value == _q)
                return midCheck;
            if (value > _q)
                max = midCheck - 1;
            if (value < _q)
                min = midCheck + 1;

            return ConstrainedCheck(min, max);
        }

        private int GetMidCheck(int min, int max)
        {
            if (min >= max)
                return -1;
            var dist = (int)Math.Round((max - min)/2.0);
            if (dist == 0)
                return min + 1;
            return min + dist;
        }

        private int CheckBounds(int min, int max)
        {
            if (min > max || max < min)
                return -1;

            if (_input[min] == _q)
                return min;
            if (_input[max] == _q)
                return max;
            return -1;
        }
    }
}
