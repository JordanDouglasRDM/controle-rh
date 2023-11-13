using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FuncionarioAbstrato
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<Funcionario> vetFuncionario { get; set; }
        public Departamento(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            vetFuncionario = new List<Funcionario>();
        }
        //aqui ocorre o que chamamos de generalização, por exemplo,
        //eu posso admitir um Assalariado ou um Comissionado, 
        //mas eu não preciso informar qual, somente um funcionário, pois um assalariado e um commissionado é de fato um funcioário.

        public void Admitir(Funcionario f)
        {
            vetFuncionario.Add(f);
        }
        public void ListarFuncionario()
        {
            Console.WriteLine("\n\nLista de funcionário do departamento - " + this.Nome);
            foreach (Funcionario meuFunc in vetFuncionario)
            {
                meuFunc.ExibeDados();
            }
            Console.WriteLine("");
        }
        public void DemitirFuncionario(int codigoFunc)
        {
            foreach (Funcionario fun in vetFuncionario)
            {
                if (fun.Codigo == codigoFunc) {
                    vetFuncionario.Remove(fun);
                    break;
                }
            }
        }
        public double CalcularFolha(int diasUteis)
        {
            double folha = 0;
            foreach (Funcionario fun in vetFuncionario)
            {
                folha += fun.CalcularSalario(diasUteis);
            }
            return folha;
        }
        public void MostrarQtdeDependentesFuncionario()
        {
            Console.WriteLine("Funcionários e Dependentes: ");
            foreach(Funcionario fun in vetFuncionario)
            {
                    Console.WriteLine($"Nome: {fun.Nome} | Quantidade de Dependentes: {fun.CalcularTotalDependente()}");
            }
        }
    }
}