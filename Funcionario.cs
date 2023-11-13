using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FuncionarioAbstrato
{
    public abstract class Funcionario
    {
        public List<Dependente> vetDependente { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }
        public Funcionario(int c, string n, double s)
        {
            this.Codigo = c;
            this.Nome = n;
            this.Salario = s;
            vetDependente = new List<Dependente>();
        }
        
        public virtual void ExibeDados() // método concreto, que possuii lógica
        {
            Console.WriteLine($"Código: {Codigo} \tNome: {Nome} \tSalario: {Salario:C2}");
        }
        public abstract double CalcularSalario(int diasUteis);
        public int CalcularTotalDependente()
        {
            return vetDependente.Count;
        }
        public void AdicionarDependente(Dependente novoDep)
        {
            vetDependente.Add(novoDep);
        }
        public void RemoverDependenteMaiorIdade(int codigo)
        {
            foreach (Dependente dep in vetDependente)
            {
                if(dep.Codigo == codigo) {
                    if (dep.VerificarMaiorIdade()) {
                        vetDependente.Remove(dep);
                        Console.WriteLine("\n\tDependente removido com sucesso.");
                        Console.WriteLine("");
                        break;
                    } else {
                        Console.WriteLine("\n\tNão é possível remover dependentes menores que 18 anos.");
                        Console.WriteLine("");
                        break;
                    }
                }
            }
        }
        public void ListarDependentes()
        {
            Console.WriteLine("Dependentes do " + Nome + ":");
            foreach (Dependente dep in vetDependente)
            {
                Console.WriteLine($"Codigo: {dep.Codigo} | Nome: {dep.Nome} | Idade: {dep.Idade}");
            }
        }
    }
}