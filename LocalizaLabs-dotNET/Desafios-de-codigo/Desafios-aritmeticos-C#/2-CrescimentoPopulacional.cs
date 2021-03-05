using System; 

class minhaClasse
{
    static void Main(string[] args)
    { 
        int qtdeTestes = Convert.ToInt32(Console.ReadLine());
        double[] arrayList = new double[4];
        int populacaoA, populacaoB;
        double crescimentoA, crescimentoB;
        int anos;

        for (int i = 0; i < qtdeTestes; i++)
        {
            anos = 0;
            string[] valores = Console.ReadLine().Split();
            populacaoA = int.Parse(valores[0]);
            populacaoB = int.Parse(valores[1]);

            //declare as variaveis corretamente
            crescimentoA = double.Parse(valores[2]);
            crescimentoB = double.Parse(valores[3]);

            while (populacaoA <= populacaoB)
            {
                //complete o while
                populacaoA += Convert.ToInt32(Math.Floor(populacaoA * (crescimentoA / 100)));
                populacaoB += Convert.ToInt32(Math.Floor(populacaoB * (crescimentoB / 100)));
                anos += 1;

                if (anos > 100)
                {
                    Console.WriteLine("Mais de 1 seculo.");
                    break;
                }
            }

            if (anos <= 100)
            {
                Console.WriteLine(anos + " anos.");
            }
        }
    }
}