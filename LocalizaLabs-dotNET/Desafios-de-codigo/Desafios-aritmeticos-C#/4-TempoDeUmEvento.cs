using System;

class minhaClasse
{
    static void Main(string[] args)
    {
        DateTime dataIni, dataFin;

        string[] diaInicio = Console.ReadLine().Split();
        string[] hmsIni = Console.ReadLine().Replace(" ", "").Split(':');
        dataIni = new DateTime(2021, 4, Convert.ToInt32(diaInicio[1]), Convert.ToInt32(hmsIni[0]), Convert.ToInt32(hmsIni[1]), Convert.ToInt32(hmsIni[2]));

        string[] diaFinal = Console.ReadLine().Split();
        string[] hmsFin = Console.ReadLine().Replace(" ", "").Split(':');
        dataFin = new DateTime(2021, 4, Convert.ToInt32(diaFinal[1]), Convert.ToInt32(hmsFin[0]), Convert.ToInt32(hmsFin[1]), Convert.ToInt32(hmsFin[2]));

        var diferenca = dataFin - dataIni;

        Console.WriteLine("{0} dia(s)", diferenca.Days);
        Console.WriteLine("{0} hora(s)", diferenca.Hours);
        Console.WriteLine("{0} minuto(s)", diferenca.Minutes);
        Console.WriteLine("{0} segundo(s)", diferenca.Seconds);
    }
}