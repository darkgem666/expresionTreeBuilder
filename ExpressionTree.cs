
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApplication
{
public class ExpressionTree
{
    private string  infix,postfix = "";
    private StringBuilder constant = new StringBuilder("");
    private ParameterExpression jobcode = Expression.Parameter(typeof(string),"x");
    private ParameterExpression centro = Expression.Parameter(typeof(string),"y");
    private string operators = "=&|>";

    public Func<string,string,bool> ContructFunction(string function){
       string postfix = function;
      // Console.WriteLine(postfix);
       string[] lista = postfix.Split(',');
        Stack<Expression> stack = new Stack<Expression>();
      for (int i = 0; i < lista.Length; i++)
      {
          string pos = lista[i];
          if(!operators.Contains(pos)){
              if (!pos.Equals("x") && !pos.Equals("y"))
              {
                  string next = lista[i + 1];
                  if (!(next.Equals("x") && pos.Equals("y")) && !operators.Contains(next))
                  {
                      constant.Append(next);
                  }else
                  {
                      stack.Push(Expression.Constant( pos));
                  }
              }else if (pos.Equals("x"))
              {
                  stack.Push(jobcode);
                  
              }else if (pos.Equals("y"))
              {
                  stack.Push(centro);
              }
              constant.Clear();
          }else
          {
              constant.Clear();
              //Console.WriteLine(stack.Peek().ToString());
              Expression operand1 = stack.Pop();
              Expression operand2 = stack.Pop();
              switch (pos)
              {
                  case "|":
                   // Console.WriteLine(operand1.ToString()+ "  "+operand2.ToString());
                    stack.Push(Expression.OrElse(operand1,operand2));
                    break;
                  case "&":
                    stack.Push(Expression.AndAlso(operand1,operand2));
                    break;
                case ">":
                    stack.Push(Expression.NotEqual(operand1,operand2));
                    break;
                case "=":
                    stack.Push(Expression.Equal(operand1,operand2));
                break;
              }

          }
      }
      //Console.WriteLine(stack.Count());
      Expression result = stack.Pop();
      //Console.WriteLine(result.ToString());
      Expression<Func<string,string,bool>> e = Expression.Lambda<Func<string,string,bool>>(result,jobcode,centro);
      Func<string,string,bool> f = e.Compile();
      return f;
      }


      public Func<string,string,bool> getTree (string regla){
          
          List<string> postfijo = regla.Split(',').ToList();
        Stack<Expression> stack = new Stack<Expression>();
        int i=0;
          foreach (string item in postfijo)
          {
              
            if (!operators.Contains(item))
                if (Int32.TryParse(item,out i)) 
                  stack.Push(Expression.Constant(item));
              else if (item.Equals("x"))
                   stack.Push(jobcode);
                else
                    stack.Push(centro);
            else
                {
                     Expression operand1 = stack.Pop();
                    Expression operand2 = stack.Pop();
                    switch (item)
                {
                    case "|":
                        stack.Push(Expression.OrElse(operand1,operand2));
                        break;
                    case "&":
                        stack.Push(Expression.AndAlso(operand1,operand2));
                        break;
                    case ">":
                        stack.Push(Expression.NotEqual(operand1,operand2));
                        break;
                    case "=":
                        stack.Push(Expression.Equal(operand1,operand2));
                    break;
                }
                    
                }

          }

          Expression result = stack.Pop();
          Expression<Func<string,string,bool>> exp = Expression.Lambda<Func<string,string,bool>>(result,jobcode,centro);
          return exp.Compile();
      }

      
        

    }
}
