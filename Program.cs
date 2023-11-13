using System.ComponentModel;
using System.Net;
using FuncionarioAbstrato;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<Departamento> vetDepartamento = new List<Departamento>();

        int quantidadeDepartamentos = 0;
        int quantidadeFuncionarios = 0;
        int quantidadeDependentes = 0;

        while (true)
        {
            quantidadeDepartamentos = vetDepartamento.Count();
            int somaFuncionarios = 0;
            int somaDependentes = 0;
            string statusDepart;
            string statusFunc;
            string statusDepen;
            string statusTrue = "__Disponível__";
            string statusFalse = "__Indisponível__";

            if (vetDepartamento != null)
            {
                foreach (Departamento qDep in vetDepartamento)
                {
                    somaFuncionarios += qDep.vetFuncionario.Count();
                    foreach (Funcionario qFunc in qDep.vetFuncionario)
                    {
                        somaDependentes += qFunc.vetDependente.Count();
                    }
                }
            }
            quantidadeFuncionarios = somaFuncionarios;
            quantidadeDependentes = somaDependentes;

            if (quantidadeDepartamentos <= 0)
            {
                statusDepart = statusFalse;
            }
            else
            {
                statusDepart = statusTrue;
            }
            if (quantidadeFuncionarios <= 0)
            {
                statusFunc = statusFalse;
            }
            else
            {
                statusFunc = statusTrue;
            }
            if (quantidadeDependentes <= 0)
            {
                statusDepen = statusFalse;
            }
            else
            {
                statusDepen = statusTrue;
            }

            Console.Clear();
            Console.WriteLine("Departamento ");
            Console.WriteLine($"\t1 - Criar Departamento {statusTrue}");
            Console.WriteLine($"\t2 - Calcular Folha de pagamento {statusFunc}");

            Console.WriteLine("Funcionario");
            Console.WriteLine($"\t3 - Adicionar Funcionário {statusDepart}");
            Console.WriteLine($"\t4 - Listar Funcionários {statusFunc}");
            Console.WriteLine($"\t5 - Demitir Funcionário {statusFunc}");
            Console.WriteLine($"\t6 - Calcular quantidade de dependentes {statusDepen}");

            Console.WriteLine("Dependente");
            Console.WriteLine($"\t7 - Adicionar Dependente {statusFunc}");
            Console.WriteLine($"\t8 - Remover Dependente {statusDepen}");
            Console.WriteLine($"\t9 - Listar Dependentes {statusDepen}");

            Console.WriteLine("99 - Sair");
            Console.Write("\n\tEscolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    try
                    {
                        Console.Clear();
                        Console.Write("Informe o ID do departamento: ");
                        int idDepart = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Informe o nome do departamento: ");
                        string nomeDepartamento = Console.ReadLine();

                        vetDepartamento.Add(new Departamento(idDepart, nomeDepartamento));
                        Console.WriteLine($"\n\tDepartamento '{nomeDepartamento}' criado co sucesso.");
                        Console.WriteLine("");

                        Console.WriteLine("Pressione qualquer tecla para retornar...");
                        Console.ReadKey();
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Erro: {e.Message}");
                        Console.WriteLine("Pressione qualquer tecla para retornar...");
                        Console.ReadKey();
                        break;
                    }

                case "2":
                    try
                    {
                        if (statusFunc == statusTrue)
                        {
                            Console.Clear();

                            Console.Write("Informe os dias úteis do mês atual: ");
                            int diasUteis = Convert.ToInt32(Console.ReadLine());

                            foreach (Departamento departamento in vetDepartamento)
                            {
                                double folha = departamento.CalcularFolha(diasUteis);
                                Console.WriteLine($"Departamento: {departamento.Nome} \tFolha: {folha:C2}");
                            }
                            Console.WriteLine("\nPressione qualquer tecla para retornar...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tOpção indisponível!");
                            Console.WriteLine("\t\t\tAdicione um Funcionario primeiro.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Erro: {e.Message}");
                        Console.WriteLine("Pressione qualquer tecla para retornar...");
                        Console.ReadKey();
                        break;
                    }

                case "3":
                    try
                    {
                        if (statusDepart == statusTrue)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\tDepartamentos existentes:");
                            foreach (Departamento departamento in vetDepartamento)
                            {
                                Console.WriteLine($"\t\t{departamento.Codigo} - {departamento.Nome}");
                            }
                            Console.Write("\nA qual departamento deseja associar este funcionário? ");
                            int depSelecionado = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("1 - Assalariado");
                            Console.WriteLine("2 - Comissionado");

                            Console.Write("Escolha o tipo de funcionário: ");
                            string tipoFuncionario = Console.ReadLine();

                            Console.Write("Informe o ID do funcionário: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Informe o nome do funcionário: ");
                            string nome = Console.ReadLine();
                            Console.Write("Informe o salário do funcionário: ");
                            double salario = Convert.ToDouble(Console.ReadLine());

                            if (tipoFuncionario == "1")
                            {
                                Assalariado assalariado = new Assalariado(id, nome, salario);

                                foreach (Departamento departamento in vetDepartamento)
                                {
                                    if (depSelecionado == departamento.Codigo)
                                    {
                                        departamento.Admitir(assalariado);
                                        break;
                                    }
                                }
                                Console.WriteLine("\n\tAssalariado admitido com sucesso.");
                                Console.WriteLine("");
                            }
                            if (tipoFuncionario == "2")
                            {
                                Console.Write("Informe a comissão do funcionário: ");
                                double comissao = Convert.ToDouble(Console.ReadLine());
                                Comissionado comissionado = new Comissionado(id, nome, salario, comissao);

                                foreach (Departamento departamento in vetDepartamento)
                                {
                                    if (depSelecionado == departamento.Codigo)
                                    {
                                        departamento.Admitir(comissionado);
                                        break;
                                    }
                                }
                                Console.WriteLine("\n\tComissionado admitido com sucesso.");
                                Console.WriteLine("");
                            }
                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tOpção indisponível!");
                            Console.WriteLine("\t\t\tCrie um departamento primeiro.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Erro: {e.Message}");
                        Console.WriteLine("Pressione qualquer tecla para retornar...");
                        Console.ReadKey();
                        break;
                    }

                case "4":
                    try
                    {
                        if ((statusFunc == statusTrue))
                        {
                            Console.Clear();
                            foreach (Departamento departamento in vetDepartamento)
                            {
                                departamento.ListarFuncionario();
                            }
                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tOpção indisponível!");
                            Console.WriteLine("\t\t\tAdicione um Funcionario primeiro.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Erro: {e.Message}");
                        Console.WriteLine("Pressione qualquer tecla para retornar...");
                        Console.ReadKey();
                        break;
                    }
                case "5":
                    try
                    {
                        if ((statusFunc == statusTrue))
                        {
                            Console.Clear();
                            foreach (Departamento departamento in vetDepartamento)
                            {
                                departamento.ListarFuncionario();
                            }

                            Console.Write("Informe o ID do funcionário que deseja remover: ");
                            int funcionarioId = Convert.ToInt32(Console.ReadLine());
                            foreach (Departamento departamento in vetDepartamento)
                            {
                                departamento.DemitirFuncionario(funcionarioId);
                            }
                            Console.WriteLine("Funcionário removido com sucesso.");
                            Console.WriteLine("\nPressione qualquer tecla para retornar...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tOpção indisponível!");
                            Console.WriteLine("\t\t\tAdicione um Funcionario primeiro.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Erro: {e.Message}");
                        Console.WriteLine("Pressione qualquer tecla para retornar...");
                        Console.ReadKey();
                        break;
                    }
                case "6":
                    try
                    {
                        if (statusDepen == statusTrue)
                        {
                            Console.Clear();
                            foreach (Departamento dep in vetDepartamento)
                            {
                                Console.WriteLine($"Departamento: {dep.Nome}");
                                foreach (Funcionario fun in dep.vetFuncionario)
                                {
                                    Console.WriteLine($"Funcionário: {fun.Nome} \t Qtde Dependentes: {fun.CalcularTotalDependente()}");
                                }
                            }
                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tOpção indisponível!");
                            Console.WriteLine("\t\t\tAdicione um Dependente primeiro.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"ERROR: {e.Message}");
                    }
                    break;
                case "7":
                    try
                    {
                        if (statusFunc == statusTrue)
                        {
                            Console.Clear();
                            foreach (Departamento departamento in vetDepartamento)
                            {
                                departamento.ListarFuncionario();
                            }

                            Console.Write("Informe o ID do funcionário: ");
                            int funcionarioId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Informe o ID do dependente: ");
                            int idDependente = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Informe o nome do dependente: ");
                            string nomeDependente = Console.ReadLine();
                            Console.Write("Informe a idade do dependente: ");
                            int idadeDependente = Convert.ToInt32(Console.ReadLine());

                            Dependente dependente = new Dependente(idDependente, nomeDependente, idadeDependente);

                            foreach (Departamento dep in vetDepartamento)
                            {
                                foreach (Funcionario fun in dep.vetFuncionario)
                                {
                                    if (fun.Codigo == funcionarioId)
                                    {
                                        fun.AdicionarDependente(dependente);
                                    }
                                    break;
                                }
                            }
                            Console.WriteLine("\n\tDependente adicionado com sucesso.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tOpção indisponível!");
                            Console.WriteLine("\t\t\tAdicione um Funcionario primeiro.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Erro: {e.Message}");
                        Console.WriteLine("Pressione qualquer tecla para retornar...");
                        Console.ReadKey();
                        break;
                    }

                case "8":
                    try
                    {
                        if (statusDepen == statusTrue)
                        {
                            Console.Clear();
                            foreach (Departamento dep in vetDepartamento)
                            {
                                foreach (Funcionario fun in dep.vetFuncionario)
                                {
                                    fun.ListarDependentes();
                                }
                            }
                            Console.Write("\n\tQual dependente deseja remover? (Informe seu ID): ");
                            int idDependente = Convert.ToInt32(Console.ReadLine());

                            foreach (Departamento depart in vetDepartamento)
                            {
                                foreach (Funcionario fun in depart.vetFuncionario)
                                {
                                    foreach (Dependente depen in fun.vetDependente)
                                    {
                                        if (depen.Codigo == idDependente)
                                        {
                                            fun.RemoverDependenteMaiorIdade(idDependente);
                                            break;
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tOpção indisponível!");
                            Console.WriteLine("\t\t\tAdicione um Dependente primeiro.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"ERROR: {e.Message}");
                    }
                    break;
                case "9":
                    try
                    {
                        if (statusDepen == statusTrue)
                        {
                            Console.Clear();
                            foreach (Departamento dep in vetDepartamento)
                            {
                                Console.WriteLine($"Departamento: {dep.Nome}");
                                foreach (Funcionario fun in dep.vetFuncionario)
                                {
                                    fun.ListarDependentes();
                                }
                            }
                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t\t\tOpção indisponível!");
                            Console.WriteLine("\t\t\tAdicione um Dependente primeiro.");
                            Console.WriteLine("");

                            Console.WriteLine("Pressione qualquer tecla para retornar...");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"ERROR: {e.Message}");
                    }
                    break;
                case "99":
                    Console.WriteLine("\n\tSaindo do programa.");
                    Console.WriteLine("");
                    return;

                default:
                    Console.WriteLine("\n\tOpção inválida. Tente novamente.");
                    Console.WriteLine("");
                    break;
            }
        }
    }
}
