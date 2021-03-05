using System; 

class URI
{
    static void Main(string[] args)
    {
        string numero = Console.ReadLine();
        string invertidos = "";

        int contagemInversa = numero.Length;
        for (int contagem = 0; contagem < numero.Length; contagem++)
        {
            invertidos += numero[contagemInversa - 1];
            contagemInversa--;
        }

        Console.WriteLine(invertidos);
    }
}