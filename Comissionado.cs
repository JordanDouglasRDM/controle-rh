using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuncionarioAbstrato
{
    public class Comissionado : Funcionario
    {
        public double Porcentagem { get; set; }
        public Comissionado(int c, string n, double s, double p) : base (c,n,s)
        {
            this.Porcentagem = p;
        }
        public override void ExibeDados()
        {
            base.ExibeDados();
            Console.WriteLine($"Porcentagem: {Porcentagem}");
        }
        public override double CalcularSalario(int diasUteis)
        {
            return Salario / 30 * diasUteis * Porcentagem / 100 + Salario;
        }
    }
}