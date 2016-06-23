
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class ExpressionTree
{
    private string  infix,postfix = "";
    private StringBuilder constant;
    private ParameterExpression jobcode = Expression.Parameter(typeof(string),"jobcode");
    private ParameterExpression centro = Expression.Parameter(typeof(string),"centro");
    private string operators = "=!&|";

    public Func<string,bool> ContructFunction(string function){
       string postfix = "x,003049,=,x,003050,=,|,x,003051,=,|,x,003052,=,|,x,Ext001,=,|,x,003020,=,|,x,003023,=,|,x,003024,=,|,x,003231,=,|,x,005973,=,|,x,003133,=,|,x,003134,=,|,x,003057,=,y,2144,=,&,|,x,003128,=,|,x,003176,=,|,x,003177,=,|,x,003180,=,|,x,003181,=,|,x,003182,=,|,x,006100,=,|,x,006830,=,|,x,007223,=,|,x,007287,=,|,x,003259,=,y,7340,=,&,|,x,007288,=,|,x,006797,=,y,7336,=,&,|,x,007928,=,|,x,006797,=,y,7340,=,&,|,x,003202,=,y,7370,=,>,|,x,007310,=,|,x,007558,=,|,x,007380,=,y,7616,=,&,|,x,003251,=,y,7616,=,&,|,x,003253,=,y,7616,=,&,|,x,003254,=,y,7616,=,&,|,x,Bm0001,=,|,x,Bm0002,=,|,x,Bm0003,=,|,x,Bm0004,=,|,x,007304,=,|,x,006262,=,y,7655,=,&,|,x,007698,=,y,7656,=,y,7655,=,|,y,7616,=,|,&,|,x,007699,=,y,7656,=,&,|,x,007700,=,y,7656,=,&,|,x,007703,=,y,7655,=,y,7656,=,|,&,|";
       string[] lista = postfix.Split(',');
        Stack<Expression> stack = new Stack<Expression>();
      
      for (int i = 0; i < lista.Length; i++)
      {
          string pos = lista[i];
          if(!operators.Contains(pos)){
              if (!pos.Equals("jobcode"))
              {
                  string next = lista[i + 1];
                  if (!next.Equals("jobcode") && !operators.Contains(next))
                  {
                      constant.Append(next);
                  }else
                  {
                      stack.Push(Expression.Constant(Convert.ToInt32(constant + next)));
                  }
              }else if (pos.Equals("jobcode"))
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

