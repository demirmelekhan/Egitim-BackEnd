using System;
using System.Collections.Generic;


namespace arayuzler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Focus focus= new Focus();
            Console.WriteLine(focus.HangiMarkanınAraci().ToString());
            Console.WriteLine(focus.KacTekerlektenOlusur());
            Console.WriteLine(focus.StandartRengiNe().ToString());

            Civic civic= new Civic();
            Console.WriteLine(civic.HangiMarkanınAraci().ToString());
            Console.WriteLine(civic.KacTekerlektenOlusur());
            Console.WriteLine(civic.StandartRengiNe().ToString());

            Corolla corolla= new Corolla();
            Console.WriteLine(corolla.HangiMarkanınAraci().ToString());
            Console.WriteLine(corolla.KacTekerlektenOlusur());
            Console.WriteLine(corolla.StandartRengiNe().ToString());
        }

    }
}
