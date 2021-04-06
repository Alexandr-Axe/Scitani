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
            Pocitani Rada = new Pocitani(5, 5);
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
        double sum = 1d; //Součet řady, vždy bude minimálně 1 (plus to odstraní potíže se sčítáním a odčítáním n-tých pozic)
        double cislo = 0d;
        public Pocitani(int x, int n) //konstruktor
        {
            X = x;
            N = n;
        }
        double Factorial(int A) //Definice faktoriálu, užívaná rekurze
        {
            if (A == 1 || A == 0) return 1; //Pokud vložíme faktoriál 0 nebo 1, vrátí se 1
            else return A * Factorial(A - 1); //Násobí čísla o jedno menší mezi sebou, dokud se nedostane na 1 (10! = Vynásobí se 10 s číslem pod ním, až se dostane na 1, vrátí se 1 a výsledek bude 10*9*8*7*6*5*4*3*2*1)
        }
        public double ForCycle() //Cyklus for
        {
            sum = 1d; //Vyresetování součtu, protože všude používám tu samou proměnnou
            for (int i = 1; i <= N; i++) //Začínáme od pozice 1, protože na nulté pozici musí být vždy číslo 1 (opatrně s nulou, protože 0^0 není definovaná, limita je ovšem 1)
            {
                cislo = Math.Pow(X, i) / Factorial(i); //Počítání hodnoty čísla na n-té pozici -> čitatel je číslo x umočněné na n, jmenovatel je n faktoriál
                if (i % 2 == 0) sum -= cislo; //V případě, že jsme na pozici, kde n je sudé číslo, hodnoty se odečítají (u nuly je problém, proto je úplně vyřazená)
                else sum += cislo; //V případě, že je n liché číslo, se čísla přičítají
            }
            return sum; //Vrácení hodnoty
        }
        public double WhileCycle()
        {
            sum = 1d; //Vyresetování součtu, protože všude používám tu samou proměnnou
            int i = 1; //Pozice, na kolikátém zlomku jsme
            while (i <= N) //Dokud bude naše pozice menší než N, program se bude opakovat pořád dokola
            {
                cislo = Math.Pow(X, i) / Factorial(i); //Počítání hodnoty čísla na n-té pozici -> čitatel je číslo x umočněné na n, jmenovatel je n faktoriál
                if (i % 2 == 0) sum -= cislo; //V případě, že jsme na pozici, kde n je sudé číslo, hodnoty se odečítají (u nuly je problém, proto je úplně vyřazená)
                else sum += cislo; //V případě, že je n liché číslo, se čísla přičítají
                i++; //Zvýšení pozice o 1 v případě, že ještě nejsme u konce
            }
            return sum; //Vrácení hodnoty
        }
        public double DoWhileCycle()
        {
            sum = 1d; //Vyresetování součtu, protože všude používám tu samou proměnnou
            return sum;
        }
        public double RekurzeCycle()
        {
            sum = 1d; //Vyresetování součtu, protože všude používám tu samou proměnnou
            return sum;
        }
    }
}
