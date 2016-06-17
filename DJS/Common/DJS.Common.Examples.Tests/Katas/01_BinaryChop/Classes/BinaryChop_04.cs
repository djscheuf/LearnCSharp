using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DJS.Common.Examples.Tests.Katas._01_BinaryChop.Classes
{
    class BinaryChop_04
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

            var min = 0;
            if (max == min)
                return (_input[min] == _q) ? min : -1;
            
            return FindByEstimatedMidPoint(min, max);
        }

        private int FindByEstimatedMidPoint(int min, int max)
        {
            var checkIdx = GetEstimatedMidPoint(min, max);

            if (checkIdx < 0)
                return -1;

            var value = _input[checkIdx];
            if (value == _q)
                return checkIdx;
            if (value < _q)
                min = checkIdx+1;
            if (value > _q)
                max = checkIdx-1;

            return FindByEstimatedMidPoint(min, max);
        }

        private int GetEstimatedMidPoint(int min, int max)
        {
            if (min > max || max < 0)
                return -1;

            var valueMin = _input[min];
            var valueMax = _input[max];

            var slope = (float)(valueMax - valueMin)/(max - min);

            var qLessMin = _q - valueMin;

            var check = (int) Math.Ceiling(qLessMin/slope)+min;

            if(check < min || check > max)
                return -1;

            return check;
        }
    }
}
