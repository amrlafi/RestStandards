using System;
using System.Collections.Generic;

namespace RestStandards.Rql
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SupportedOperatorsAttribute : Attribute
    {
        private readonly IEnumerable<string> _operators;

        public SupportedOperatorsAttribute(params string[] operators)
        {
            _operators = operators;
        }

        public HashSet<string> Operators
        {
            get
            {
                return new HashSet<string>(_operators);
            }
        }
    }
}
