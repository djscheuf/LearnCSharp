using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DJS.Common.Examples.Tests.Katas._01_BinaryChop.Classes
{
    class BinaryChop_00
    {
        public int chop(int q, int[] input)
        {
            var max = input.Count() - 1;
            var min = 0;

            if (max < 0)
                return -1;

            var check = GetNextCheck(min, max,-1);
            var value = 0;

            if (check < 0)
            {
                value = input[min];
                return (value == q) ? min : -1;
            }

            value = input[check];
            while (value != q && check != -1)
            {
                if (value > q)
                    max = check;
                else
                    min = check;

                check = GetNextCheck(min, max,check);
                if (check != -1)
                    value = input[check];
            }
            return check;
        }


        private int GetNextCheck(int min, int max,int last)
        {
            if (min >= max)
                return -1;

            var dist = Math.Ceiling((max - min)/2.0);
            var next  =  (int)(max- dist);

            if (next == last)
                return next + 1;
            return next;
        }

    }
}
