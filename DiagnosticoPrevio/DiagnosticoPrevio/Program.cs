using System;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Decora("=");
            Console.Write(" Diagnóstico Prévio ");
            Decora("=");
        }
        public static void Decora(string sinal)
        {
            Console.Write("\t");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("=");
            }
            Console.Write("\t");
        }
    }
}
