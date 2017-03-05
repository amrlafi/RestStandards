using System.Linq;
using Antlr4.Runtime.Tree;

namespace RestStandards.Rql.Operations
{
    [SupportedOperators("eq", "lt", "le", "gt", "ge", "ne")]
    public class CompareOperation : OperationBase
    {
        private const int IdTokenType = 38;
        private const int ValueTokenType = 16;

        public CompareOperation(IParseTree tree) : base(tree)
        {
            Build();
        }

        public Comparison Comparison { get; private set; }
        public string ID { set; get; }
        public string Value { set; get; }

        public override void Build()
        {
            var opr = Tree.GetChild(0).GetText();
            switch (opr)
            {
                case "eq":
                    Comparison = Comparison.Equal;
                    break;
                case "lt":
                    Comparison = Comparison.LessThan;
                    break;
                case "le":
                    Comparison = Comparison.LessThanOrEqual;
                    break;
                case "gt":
                    Comparison = Comparison.GreaterThan;
                    break;
                case "ge":
                    Comparison = Comparison.GreaterThanOrEqual;
                    break;
                case "ne":
                    Comparison = Comparison.NotEqual;
                    break;
                default:
                    throw new UnsupportedOperatorException(opr, typeof(CompareOperation));
            }

            ID = Trees.FindAllTokenNodes(Tree, IdTokenType).First().GetText();
            Value = Trees.FindAllTokenNodes(Tree, ValueTokenType).First().GetText();
        }
    }

    public enum Comparison
    {
        Equal,
        NotEqual,
        LessThan,
        GreaterThan,
        LessThanOrEqual,
        GreaterThanOrEqual
    }
}
