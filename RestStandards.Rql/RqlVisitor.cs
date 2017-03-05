using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using RestStandards.Rql.Grammar;

namespace RestStandards.Rql
{
    public class RqlVisitor : RqlBaseVisitor<object>
    {
        private readonly QueryDiscoverer _queryDiscoverer;

        public RqlVisitor()
        {
            _queryDiscoverer = new QueryDiscoverer();
        }


        #region Overrides

        public override object Visit(IParseTree tree)
        {
            return base.Visit(tree);
        }

        public override object VisitText([NotNull] RqlParser.TextContext context)
        {
            var queries = context.query();
            
            foreach(var query in queries)
            {

            }

            return base.VisitText(context);
        }

        public override object VisitQuery([NotNull] RqlParser.QueryContext context)
        {
            return _queryDiscoverer.Discover(context.opr());
        }


        public override object VisitOpr([NotNull] RqlParser.OprContext context)
        {
            return base.VisitOpr(context);
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
