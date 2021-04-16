using System;

namespace ProjectCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Alunos[] alunos = new Alunos[5];
            string opcaoUsuario = Menu();
            int indiceAluno = 0;

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Digite o nome do aluno:");
                        Alunos aluno = new Alunos();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("informe a nota:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("informe um valor decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                        
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNOS: {a.Nome}, NOTAS: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAluno = 0;
                        decimal mediaGeral = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAluno++;
                            }
                            mediaGeral = notaTotal / nrAluno;
                        }
                        Console.WriteLine($"MEDIA GERAL: {mediaGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = Menu();
            }
        }

        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- registre um alumo");
            Console.WriteLine("2- listar alunos(so se tiver registrado algum)");
            Console.WriteLine("3- media dos alunos(so se tiver registrado algum)");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
