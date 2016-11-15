using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix(2,2);
            int n=2;
            m.input();
            m.info();
            Matrix x = new Matrix(n,1);
            Matrix x1 = new Matrix(n,1);
            x1=m.GAUSS(x);
            x1.info();
            //Console.WriteLine("arr[0,2]="+m[0,2]);
            //Console.WriteLine("Enter num:");
            //double n = double.Parse(Console.ReadLine());
            //m[0,2]=n;
            //Console.WriteLine("arr[0,2]="+m[0,2]);
            /*Console.WriteLine("M TRANSPON:");
            m=m.trans();
            m.info();
            Matrix n=new Matrix(3);
            Matrix s;
            s = m + 3;
            Console.WriteLine("S=M+3:");
            s.info();
            Console.WriteLine("S=S+M:");
            s = s + m;
            s.info();
            Console.WriteLine("M+=8:");
            m += 8;
            m.info();
            Console.WriteLine("M-=7:");
            m -= 7;
            m.info();
            Console.WriteLine(m<s);*/
            Console.ReadKey();
        }
    }
}
