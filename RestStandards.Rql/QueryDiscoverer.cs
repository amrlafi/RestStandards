using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Antlr4.Runtime.Tree;

using RestStandards.Rql.Queries;

namespace RestStandards.Rql
{
    public class QueryDiscoverer
    {
        private static IEnumerable<Type> QueryTypes;  
        static QueryDiscoverer()
        {
            QueryTypes = Assembly.GetExecutingAssembly()
                                 .GetTypes()
                                 .Where(t => t.Namespace == "RestStandards.Rql.Queries")
                                 .Where(t => t.GetCustomAttributes(typeof(SupportedOperatorsAttribute), true).Length > 0)
                                 .Where(t => t.BaseType == typeof(QueryBase));
                                 
        }

        public IQuery Discover(IParseTree tree)
        {
            IQuery query = new UnknownQuery(tree);

            if (tree != null && tree.ChildCount > 0)
            {
                var opr = tree.GetChild(0).GetText();
                foreach (var type in QueryTypes)
                {
                    var attribute = (SupportedOperatorsAttribute)type.GetCustomAttribute(typeof(SupportedOperatorsAttribute));
                    if (attribute.Operators.Contains(opr))
                    {
                        query = (IQuery)Activator.CreateInstance(type, tree);
                        break;
                    }
                }
            }

            return query;
        }
    }
}
