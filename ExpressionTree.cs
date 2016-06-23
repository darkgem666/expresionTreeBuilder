
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication
{
public class ExpressionTree
{
    private string  infix,postfix = "";
    private StringBuilder constant = new StringBuilder("");
    private ParameterExpression jobcode = Expression.Parameter(typeof(string),"x");
    private ParameterExpression centro = Expression.Parameter(typeof(string),"centro");
    private string operators = "=!&|";

    public Func<string,bool> ContructFunction(string function){
       string postfix = function;
       string[] lista = postfix.Split(',');
        Stack<Expression> stack = new Stack<Expression>();
      for (int i = 0; i < lista.Length; i++)
      {
          string pos = lista[i];
          if(!operators.Contains(pos)){
              if (!pos.Equals("x"))
              {
                  string next = lista[i + 1];
                  if (!next.Equals("x") && !operators.Contains(next))
                  {
                      constant.Append(next);
                  }else
                  {
                      stack.Push(Expression.Constant( pos));
                  }
              }else if (pos.Equals("x"))
              {
                  stack.Push(jobcode);
                  constant.Clear();
              }
          }else
          {
              constant.Clear();
              Expression operand1 = stack.Pop();
              Expression operand2 = stack.Pop();
              switch (pos)
              {
                  case "|":
                    stack.Push(Expression.OrElse(operand1,operand2));
                    break;
                  case "&":
                    stack.Push(Expression.AndAlso(operand1,operand2));
                    break;
                case "!":
                    stack.Push(Expression.NotEqual(operand1,operand2));
                    break;
                case "=":
                    stack.Push(Expression.Equal(operand1,operand2));
                break;
              }

          }
      }

      Expression result = stack.Pop();
      Expression<Func<string,bool>> e = Expression.Lambda<Func<string,bool>>(result,jobcode);
      Func<string,bool> f = e.Compile();
      return f;
      }





    }
}
