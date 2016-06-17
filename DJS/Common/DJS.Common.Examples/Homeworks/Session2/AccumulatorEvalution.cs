// Instructions: Given the setup code for the group, what is the result of the labelled lines? Answer the requests of each of the labelled lines.

using System.Collections.Generic;

namespace DJS.Common.Examples.Assessments.Session2
{
    class AccumulatorEvalution
    {
        public void Test()
        {
            var mixedList = new List<float>()
            {
                1.0f,
                -1.0f,
                0.0f,
                2.0f,
                -2.0f
            };

            // Group 1
            var acc = new Accumulator(-1.0f); // 1) what is _ min?
            foreach (var item in mixedList)
            {
                acc.Accumulate(item); // 2) what is PreviousInputs? for each iteration step
            }

            var result = acc.Accumulate(); // 3) what is Result?

            //Group 2
            acc = new Accumulator();
            for (int i = 0; i < 5; i++)
            {
                acc.Accumulate(i); // 4) Can this be done?
            }

            result = acc.Accumulate(); // 5) What is result?

            //Group 3
            int min = (14/2+3);
            acc = new Accumulator(min); // 6) Can this be done?

            foreach (var item in mixedList)
            {
                acc.Accumulate(item*7); // 7) What is PreviousInputs? for each iteration step
            }

            result = acc.Accumulate(); // 8) what is result?

        }
    }
}
