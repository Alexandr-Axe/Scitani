using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scitani
{
    class Program
    {
        static void Main()
        {
            Pocitani Rada = new Pocitani(0, 0);
            Console.WriteLine(Rada.ForCycle());
            Console.WriteLine(Rada.WhileCycle());
            Console.WriteLine(Rada.DoWhileCycle());
            Console.WriteLine(Rada.RekurzeCycle());
        }
    }
    class Pocitani 
    {
        public int X { get; set; }
        public int N { get; set; }
        int sum = 1;
        public Pocitani(int x, int n) 
        {
            X = x;
            N = n;
        }
        public int ForCycle() 
        {
            return sum;
        }
        public int WhileCycle()
        {
            return sum;
        }
        public int DoWhileCycle()
        {
            return sum;
        }
        public int RekurzeCycle()
        {
            return sum;
        }
    }
}
