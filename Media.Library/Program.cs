using System;
using Media.Library.Classes;
using Media.Library;

namespace Media.Library
{
    class Program
    {
        static MediaRepositorio repositorio = new MediaRepositorio();
        static void Main(string[] args)
        {
            int tipoRegistro;
            string media;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {   
                switch(opcaoUsuario)
                {
                    case "0":
                        ListarMedias();
                        break;
                    case "1":
                        media = "Filme";
                        tipoRegistro = 1;
                        Direcionamento(media,tipoRegistro);
                        break;
                    case "2":
                        media = "Série";
                        tipoRegistro = 2;
                        Direcionamento(media,tipoRegistro);
                        break;
                    case "3":
                        media = "Documentário";
                        tipoRegistro = 3;
                        Direcionamento(media,tipoRegistro);
                        break;
                    case "4":
                        media = "Notícia";
                        tipoRegistro = 4;
                        Direcionamento(media,tipoRegistro);
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\t-------------------------------");
            Console.WriteLine("\t|Media Library inicializado!!!|");
            Console.WriteLine("\t-------------------------------");                
            Console.WriteLine("\tInforme a opção desejada:");
            Console.WriteLine("\t0- Listar todos");
            Console.WriteLine("\t1- Filmes");
            Console.WriteLine("\t2- Séries");
            Console.WriteLine("\t3- Documentários");
            Console.WriteLine("\t4- Notícias");
            Console.WriteLine("\tC- Limpar tela");
            Console.WriteLine("\tX - Sair");
            Console.Write("\t-------------------------------\n\t");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void Direcionamento(string media, int TipoRegistro)
        {
            Console.WriteLine("\t-------------------------------");
            Console.WriteLine("\t*Opções de acesso*");
            Console.WriteLine("\t1- Listar {0}s", media);
            Console.WriteLine("\t2- Inserir novo cadastro - {0}", media);
            Console.WriteLine("\t3- Atualizar {0}",media);
            Console.WriteLine("\t4- Excluir {0}",media);
            Console.WriteLine("\t5- Visualizar {0}",media);
            Console.WriteLine("\tC- Limpar Tela");
            Console.WriteLine("\tX- Voltar");
			Console.Write("\t-------------------------------\n\t");
            string opcaoUsuario = Console.ReadLine().ToUpper();

            switch (opcaoUsuario)
                {
                    case "1":
                        ListarMedia(TipoRegistro);
                        break;
                    case "2":
                        InserirMedia(TipoRegistro, media);
                        break;
                    case "3":
                        AtualizarMedia(TipoRegistro, media);
                        break;
                    case "4":
                        ExcluirMedia();
                        break;
                    case "5":
                        VisualizarMedia();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();                
                }
        }
        private static void ListarMedias()
        {
            Console.WriteLine("\t----Listar----");

            var lista = repositorio.Lista();

            if (lista.Count != 0)
            {
                foreach (var media in lista)
                {
                    var excluido = media.retornaExcluido();

                        Console.WriteLine("\t#ID {0}: - {1} {2}", media.retornaId(), media.retornaTitulo(), (excluido ? "|Excluído|" : ""));
                }
            }
            else
            {
                Console.WriteLine("\tNenhum cadastro.");
                Console.WriteLine();
            }
        }
        private static void ListarMedia(int TipoReg)
        {
            Console.WriteLine();
            Console.WriteLine("\t----Listar----");

            var lista = repositorio.Lista();

            if (lista.Count != 0)
            {
                int i = 0;
                foreach (var media in lista)
                {
                    var excluido = media.retornaExcluido();

                    if (media.retornaTipo() == TipoReg)
                    {
                        i += 1;
                        Console.WriteLine("\t#ID {0}: - {1} {2}", media.retornaId(), media.retornaTitulo(), (excluido ? "|Excluído|" : ""));
                    }
                }
                if (i == 0)
                    {
                        Console.WriteLine("\tNenhum Cadastro.");
                    }
            }
            else
            {
                Console.WriteLine("\tNenhum cadastro.");
            }
            Console.WriteLine();
        }
        private static void InserirMedia(int tipoReg, string media)
        {
            string letra = aOUo(media);
            Console.WriteLine("\n\t-------------------------------");
            Console.WriteLine("\t*Inserir nov{0} {1}*", letra, media);

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("\t{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.Write("\tDigite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("\tDigite o Título d{0} {1}: ", letra, media);
            string entradaTitulo = Console.ReadLine();

            Console.Write("\tDigite o Ano de Início d{0} {1}: ", letra, media);
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("\tDigite a Descrição d{0} {1}: ", letra, media);
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine("\t-------------------------------\n");

            Media novaMedia = new Media(id: repositorio.proximoID(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        tipo: tipoReg);
            
            repositorio.insere(novaMedia);
        }
        private static void AtualizarMedia(int TipoReg, string media)
        {
            string letra = aOUo(media);
            Console.WriteLine("\n\t-------------------------------");
            Console.Write("\tDigite o id d{0} {1}: ", letra, media);
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("\t{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("\n\tDigite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("\tDigite o Título d{0} {1}: ", letra, media);
            string entradaTitulo = Console.ReadLine();

            Console.Write("\tDigite o Ano de Início d{0} {1}: ", letra, media);
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("\tDigite a Descrição d{0} {1}: ", letra, media);
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine("\t-------------------------------\n");

            Media atualizaSerie = new Media(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        tipo:TipoReg);

            repositorio.atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirMedia()
        {
            Console.WriteLine("\n\t-------------------------------");
            Console.Write("\tDigite o id da mídia registrada: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.Write("\tVocê deseja excluir esse registro? (S/N)\n\t");
            string decisao = Console.ReadLine();
            if (decisao == "S" || decisao == "s")
            {
                repositorio.exclui(indiceSerie);
                Console.WriteLine("\t---Exclusão Concluída---");
            }
            else
            {
                Console.WriteLine("\t---Exclusão interrompida---");
            }
            Console.WriteLine("\t-------------------------------\n");
        }
        private static void VisualizarMedia()
        {
            Console.WriteLine("\n\t-------------------------------");
            Console.Write("\tDigite o id da mídia registrada: ");
            int indiceMedia = int.Parse(Console.ReadLine());

            var media = repositorio.retornaPorID(indiceMedia);

            Console.WriteLine("\t{0}",media);
            Console.WriteLine("\t-------------------------------\n");
        }
        private static string aOUo(string media)
        {
            string letra;
            if (media == "Filme" || media == "Documentário")
            {
                letra = "o";
            }
            else 
            {
                letra = "a";
            }
            return letra;
        }
    }

}
