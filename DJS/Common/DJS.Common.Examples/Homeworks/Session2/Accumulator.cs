// Instructions: Highlight any and all items in this class which have a specific name. For example, public/private access modifies, or variable declarations.

using System.Collections.Generic;

namespace DJS.Common.Examples.Assessments.Session2
{
    internal class Accumulator
    {
        private readonly List<float> _inputs;

        public List<float> PreviousInputs
        {
            get { return _inputs; }
        } 

        public Accumulator(float min=0)
        {
            _inputs = new List<float>();
            _min = min;
        }

        private float _min;

        public float Accumulate(float input=0)
        {
            if (input > _min)
                _inputs.Add(input);

            return Sum();
        }

        private float Sum()
        {
            var result = 0.0f;

            foreach(var item in _inputs)
            {
                result += item;
            }

            return result;
        }
    }
}
