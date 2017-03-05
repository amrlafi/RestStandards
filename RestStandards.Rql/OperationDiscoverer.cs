using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Antlr4.Runtime.Tree;

using RestStandards.Rql.Operations;

namespace RestStandards.Rql
{
    public class OperationDiscoverer
    {
        private static IEnumerable<Type> OperationTypes;  
        static OperationDiscoverer()
        {
            OperationTypes = Assembly.GetExecutingAssembly()
                                 .GetTypes()
                                 .Where(t => t.Namespace == typeof(UnknownOperation).Namespace)
                                 .Where(t => t.GetCustomAttributes(typeof(SupportedOperatorsAttribute), true).Length > 0)
                                 .Where(t => t.BaseType == typeof(OperationBase));
                                 
        }

        public IOperation Discover(IParseTree tree)
        {
            IOperation operation = new UnknownOperation(tree);

            if (tree != null && tree.ChildCount > 0)
            {
                var opr = tree.GetChild(0).GetText();
                foreach (var type in OperationTypes)
                {
                    var attribute = (SupportedOperatorsAttribute)type.GetCustomAttribute(typeof(SupportedOperatorsAttribute));
                    if (attribute.Operators.Contains(opr))
                    {
                        operation = (IOperation)Activator.CreateInstance(type, tree);
                        break;
                    }
                }
            }

            return operation;
        }
    }
}
