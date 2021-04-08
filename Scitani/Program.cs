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
            while (true)
            {
                Console.Write("Napište hodnotu X : ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Napište, do kolikátého členu se počítá (N) : ");
                int n = Convert.ToInt32(Console.ReadLine());
                Pocitani Rada = new Pocitani(x, n);
                Console.WriteLine("Sčítání řady pomocí různých cyklů");
                Console.WriteLine($"Cyklus for : {Rada.ForCycle()}");
                Console.WriteLine($"Cyklus while : {Rada.WhileCycle()}");
                Console.WriteLine($"Cyklus do while : {Rada.DoWhileCycle()}");
                Console.WriteLine($"Rekurze : {Rada.RekurzeCycle(n)}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    class Pocitani 
    {
        public int X { get; set; }
        public int N { get; set; }
        double sum = 1d; //Součet řady, vždy bude minimálně 1 (plus to odstraní potíže se sčítáním a odčítáním n-tých pozic)
        double cislo = 0d;
        int i = 1; //Pozice, na kolikátém zlomku jsme
        double SoucetRekurze = 1d; //Celkový součet u rekurze -> nutná nová proměnná kvůli znemožnění resetu proměnné
        public Pocitani(int x, int n) //konstruktor, zde si vybíráme naše x a n
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
            i = 1; //Vyresetování pozice, protože všude používám tu samou proměnnou
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
            i = 1; //Vyresetování pozice, protože všude používám tu samou proměnnou
            if (N == 0) return sum; //V případě, že je naše n 0, zůstane nám pouze jednička
            do
            {
                cislo = Math.Pow(X, i) / Factorial(i); //Počítání hodnoty čísla na n-té pozici -> čitatel je číslo x umočněné na n, jmenovatel je n faktoriál
                if (i % 2 == 0) sum -= cislo; //V případě, že jsme na pozici, kde n je sudé číslo, hodnoty se odečítají (u nuly je problém, proto je úplně vyřazená)
                else sum += cislo; //V případě, že je n liché číslo, se čísla přičítají
                i++; //Zvýšení pozice o 1 v případě, že ještě nejsme u konce
            } while (i <= N); //Program se provede v případě, že naše pozice je menší než n
            return sum;
        }
        public double RekurzeCycle(int PoziceRekurze) //Pozice v řadě u rekurze -> nutná nová proměnná kvůli znemožnění resetu proměnné
        {
            if (PoziceRekurze == 0) return SoucetRekurze;
            cislo = Math.Pow(X, PoziceRekurze) / Factorial(PoziceRekurze); //Počítání hodnoty čísla na n-té pozici -> čitatel je číslo x umočněné na n, jmenovatel je n faktoriál
            if (PoziceRekurze % 2 == 0) SoucetRekurze -= cislo; //V případě, že jsme na pozici, kde n je sudé číslo, hodnoty se odečítají (u nuly je problém, proto je úplně vyřazená)
            else SoucetRekurze += cislo; //V případě, že je n liché číslo, se čísla přičítají
            if (PoziceRekurze != N) //Do doby, pokud se nedostaneme na konečnou pozici v řadě, cyklus se bude opakovat
            {
                ++PoziceRekurze; //Zvýšení pozice v rekurzi o 1
                return RekurzeCycle(PoziceRekurze); //Sčítání číselné řady, dokud se nedostaneme k výsledku
            }
            return SoucetRekurze;
        }
    }
}
