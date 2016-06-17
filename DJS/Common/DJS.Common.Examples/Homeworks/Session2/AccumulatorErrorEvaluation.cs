// Instructions: For each of the labels lines( 1-6) explain what error is present if any. Assume the a

using System.Collections.Generic;
using DJS.Common.Examples.Assessments.Session2;

namespace DJS.Common.Examples.Assessments
{
    public class AccumulatorErrorEvaluation
    {
        public void Test()
        {
            var acc = new Accumulator();

            acc.Accumulate(); // 1
            acc.Accumulate(3.0f); // 2
            acc.Accumulate(acc); // 3

            acc = null;
            acc.Accumulate(); // 4

            acc = new Accumulator();
            acc._min = -3.0f; // 5

            acc.PreviousInputs = new List<float>(); // 6
        }
    }
}
