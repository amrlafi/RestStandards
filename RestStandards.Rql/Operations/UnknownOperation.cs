using System;
using Antlr4.Runtime.Tree;

namespace RestStandards.Rql.Operations
{
    [SupportedOperators]
    public class UnknownOperation : OperationBase
    {
        public UnknownOperation(IParseTree tree) : base(tree)
        {

        }

        public override void Build()
        {
        }
    }
}
