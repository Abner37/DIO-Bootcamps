using System;
using System.Globalization;

namespace aumento_de_salario
{
    class minhaClasse
    {
        static void Main(string[] args)
        {
            double salario= 0;
            double novoSalario = 0;
            double reajuste = 0;
            double percentual = 0;

            salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (salario < 0)
                return;

            else if (salario <= 400)
                percentual = 15;

            else if (salario <= 800)
                percentual = 12;

            else if (salario <= 1200)
                percentual = 10;

            else if (salario <= 2000)
                percentual = 7;

            else
                percentual = 4;


            reajuste = salario * ((double)percentual / 100);
            novoSalario = salario + reajuste;

            Console.WriteLine("Novo salario: {0}", novoSalario.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Reajuste ganho: {0}", reajuste.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Em percentual: {0} %", percentual);
        }
    }
}