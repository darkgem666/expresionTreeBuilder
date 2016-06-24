using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {


/*( Comcodpuesto Equal to 003049 OR Comcodpuesto Equal to 003050 OR Comcodpuesto Equal to 003051 OR Comcodpuesto Equal to 003052 OR Comcodpuesto Equal to Ext001 OR Comcodpuesto Equal to 003020 OR Comcodpuesto Equal to 003023 OR Comcodpuesto Equal to 003024 OR ( Comcodpuesto Equal to 003231 ) OR Comcodpuesto Equal to 005973 OR Comcodpuesto Equal to 003133 OR Comcodpuesto Equal to 003134 OR ( Comcodpuesto Equal to 003057 AND Comcodcentrocoste Equal to 2144 ) OR Comcodpuesto Equal to 003128 OR Comcodpuesto Equal to 003176 OR Comcodpuesto Equal to 003177 OR Comcodpuesto Equal to 003180 OR Comcodpuesto Equal to 003181 OR Comcodpuesto Equal to 003182 OR Comcodpuesto Equal to 006100 OR Comcodpuesto Equal to 006830 OR Comcodpuesto Equal to 007223 OR Comcodpuesto Equal to 007287 OR ( Comcodpuesto Equal to 003259 AND Comcodcentrocoste Equal to 7340 ) OR Comcodpuesto Equal to 007288 OR ( Comcodpuesto Equal to 006797 AND Comcodcentrocoste Equal to 7336 ) OR Comcodpuesto Equal to 007928 OR ( Comcodpuesto Equal to 006797 AND Comcodcentrocoste Equal to 7340 ) OR ( Comcodpuesto Equal to 003202 AND NO Comcodcentrocoste Equal to 7370 ) OR Comcodpuesto Equal to 007310 OR Comcodpuesto Equal to 007558 OR ( Comcodpuesto Equal to 007380 AND Comcodcentrocoste Equal to 7616 ) OR ( Comcodpuesto Equal to 003251 AND Comcodcentrocoste Equal to 7616 ) OR ( Comcodpuesto Equal to 003253 AND Comcodcentrocoste Equal to 7616 ) OR ( Comcodpuesto Equal to 003254 AND Comcodcentrocoste Equal to 7616 ) OR Comcodpuesto Equal to Bm0001 OR Comcodpuesto Equal to Bm0002 OR Comcodpuesto Equal to Bm0003 OR Comcodpuesto Equal to Bm0004 OR Comcodpuesto Equal to 007304 OR ( Comcodpuesto Equal to 006262 AND Comcodcentrocoste Equal to 7655 ) OR ( Comcodpuesto Equal to 007698 AND ( Comcodcentrocoste Equal to 7656 OR Comcodcentrocoste Equal to 7655 OR Comcodcentrocoste Equal to 7616 )) OR ( Comcodpuesto Equal to 007699 AND Comcodcentrocoste Equal to 7656 ) OR ( Comcodpuesto Equal to 007700 AND Comcodcentrocoste Equal to 7656 ) OR ( Comcodpuesto Equal to 007703 AND ( Comcodcentrocoste Equal to 7655 OR Comcodcentrocoste Equal to 7656 ))) AND NO ( Rule Equal to Jobcodes-Role-10 )*/


            	ExpressionTree exp = new ExpressionTree();
                string function = "x,003049,=,x,003050,=,|,x,003051,=,|,x,003052,=,|,x,Ext001,=,"
               +"|,x,003020,=,|,x,003023,=,|,x,003024,=,|,x,003231,=,|,x,005973,=,|,x,003133,=,|,"
                +"x,003134,=,|,x,003057,=,y,2144,=,&,|,x,003128,=,|,x,003176,=,|,x,003177,=,|,x,003180,=,"
                +"|,x,003181,=,|,x,003182,=,|,x,006100,=,|,x,006830,=,|,x,007223,=,|,x,007287,=,|,x,003259,=,"
                +"y,7340,=,&,|,x,007288,=,|,x,006797,=,y,7336,=,&,|,x,007928,=,|,x,006797,=,y,7340,=,&,|,x,003202,=,"
                +"y,7370,=,>,|,x,007310,=,|,x,007558,=,|,x,007380,=,y,7616,=,&,|,x,003251,=,y,7616,=,&,|,x,003253,=,"
                +"y,7616,=,&,|,x,003254,=,y,7616,=,&,|,x,Bm0001,=,|,x,Bm0002,=,|,x,Bm0003,=,|,x,Bm0004,=,|,x,007304,=,"
                +"|,x,006262,=,y,7655,=,&,|,x,007698,=,y,7656,=,y,7655,=,|,y,7616,=,|,&,|,x,007699,=,y,7656,=,&,|,"
                +"x,007700,=,y,7656,=,&,|,x,007703,=,y,7655,=,y,7656,=,|,&,|";
                
                
                /*,x,003020,=,|,x,003023,=,|,x,003024,=,|,x,003231,=,|,x,005973,=,|,x,003133,=,|,x,003134,=,|,x,003057,=,y,2144,=,&,|,x,003128,=,|,x,003176,=,|,x,003177,=,|,x,003180,=,|,x,003181,=,|,x,003182,=,|,x,006100,=,|,x,006830,=,|,x,007223,=,|,x,007287,=,|,x,003259,=,y,7340,=,&,|,x,007288,=,|,x,006797,=,y,7336,=,&,|,x,007928,=,|,x,006797,=,y,7340,=,&,|,x,003202,=,y,7370,=,>,|,x,007310,=,|,x,007558,=,|,x,007380,=,y,7616,=,&,|,x,003251,=,y,7616,=,&,|,x,003253,=,y,7616,=,&,|,x,003254,=,y,7616,=,&,|,x,Bm0001,=,|,x,Bm0002,=,|,x,Bm0003,=,|,x,Bm0004,=,|,x,007304,=,|,x,006262,=,y,7655,=,&,|,x,007698,=,y,7656,=,y,7655,=,|,y,7616,=,|,&,|,x,007699,=,y,7656,=,&,|,x,007700,=,y,7656,=,&,|,x,007703,=,y,7655,=,y,7656,=,|,&,|";*/

                //Func<string,string,bool> e = exp.ContructFunction(function);
                Func<string,string,bool> e =exp.getTree(function);
                Func<string,string,bool> b =exp.ContructFunction(function);
                
                
                Console.WriteLine(e("007699","7656") + "     " +b("007699","7656"));


        }
    }
}
