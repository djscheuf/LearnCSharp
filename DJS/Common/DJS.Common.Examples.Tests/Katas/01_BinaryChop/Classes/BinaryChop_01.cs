using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DJS.Common.Examples.Tests.Katas._01_BinaryChop.Classes
{
    internal class BinaryChop_01
    {
        public int chop(int q, int[] input)
        {
            var max = input.Count() - 1;
            if (max < 0)
                return -1;

            var min = 0;

            if (max == min)
                return (input[min] == q) ? min : -1;

            return RecursiveChop(q,input, min, max,-1);
        }

        private int RecursiveChop(int q,int[] input, int start, int end,int lastIdx)
        {
            if(start >= end)
                return -1;

            var dist = Math.Ceiling((end - start)/2.0);
            var idx = (int)(end - dist);

            if (lastIdx == idx)
                idx = lastIdx + 1;

            var value = input[idx];

            if (value == q)
                return idx;

            if (value > q)
                end = idx;
            else
                start = idx;

            return RecursiveChop(q, input, start, end,idx);
        }
    }
}
