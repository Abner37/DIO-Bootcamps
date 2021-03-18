using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            try
            {
                string opcao = ObterOpcaoUsuario();

                while (opcao != "X")
                {
                    Console.Clear();
                    
                    switch (opcao)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Console.WriteLine();
                    Console.Write("Tecle Enter para voltar...");
                    Console.ReadLine();

                    Console.Clear();
                    
                    opcao = ObterOpcaoUsuario();
                }

                Console.WriteLine("Obrigado por utilizar os nossos serviços.");
                Console.Write("Tecle Enter para continuar...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ops!! Algo deu errado. " + ex.Message);
                Console.Write("Tecle Enter para voltar...");
                Console.ReadLine();
            }
        }

        static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
        static Serie ObterSerieUsuario(int id)
        {
            foreach (int g in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", g, Enum.GetName(typeof(Genero), g));
            }
            Console.Write("Informe o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Informe o título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("Informe o ano de início da série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Informe uma descrição para a série: ");
            string descricao = Console.ReadLine();

            return new Serie(id, (Genero)genero, titulo, descricao, ano);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.RetornaTitulo()}");
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            Console.WriteLine();

            Serie serie = ObterSerieUsuario(repositorio.ProximoId());
            repositorio.Insere(serie);

            Console.WriteLine();
            Console.WriteLine("Série inserida com sucesso!");
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série");
            Console.WriteLine();

            Console.Write("Informe o id da série que irá atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(id);
            Console.WriteLine("Atualizando série \"{0}\"...", serie.RetornaTitulo());
            Console.WriteLine();

            Serie serieAtualizada = ObterSerieUsuario(id);
            repositorio.Atualiza(id, serieAtualizada);

            Console.WriteLine();
            Console.WriteLine("Série atualizada com sucesso!");
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir série");
            Console.WriteLine();

            Console.Write("Informe o id da série: ");
            int id = int.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(id);
            Console.Write("Deseja realmente excluir a série \"{0}\"? (S/N) ", serie.RetornaTitulo());
            if (Console.ReadLine().ToUpper() == "S")
            {
                repositorio.Exclui(id);

                Console.WriteLine();
                Console.WriteLine("Série excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série");
            Console.WriteLine();

            Console.Write("Informe o id da série: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var serie = repositorio.RetornaPorId(id);
            Console.WriteLine(serie);
        }
    }
}
