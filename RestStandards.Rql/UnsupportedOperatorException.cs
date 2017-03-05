using System;

namespace RestStandards.Rql
{
    public class UnsupportedOperatorException : Exception
    {
        public UnsupportedOperatorException(string opr, Type type) : base(string.Format("Type {0} does not support operator '{1}'", type.FullName, opr))
        {

        }
    }
}
