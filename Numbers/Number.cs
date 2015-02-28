using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class Number
    {
        private readonly List<List<String>> _representation;
        private readonly int _value;

        public Number(List<List<String>> representation)
        {
            this._representation = representation;
        }

        public Number(List<List<String>> repersentation, int value)
            : this(repersentation)
        {
            this._value = value;
        }

        public List<List<String>> GetRepresentation()
        {
            return _representation;
        }

        public int GetValue()
        {
            return _value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var toCompareWith = (Number)obj;
            if (_representation.Count != toCompareWith.GetRepresentation().Count) return false;
            for (int i = 0; i < _representation.Count; i++)
            {
                if (_representation[i].Count != toCompareWith.GetRepresentation()[i].Count) return false;
                for (int j = 0; j < _representation[i].Count; j++)
                {
                    if (_representation[i][j] != toCompareWith.GetRepresentation()[i][j]) return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return _representation.GetHashCode();
        }
    }
}
