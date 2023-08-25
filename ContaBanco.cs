using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuperBanco
{
    public class ContaBanco
    {
        public string? Numero { get; }
        public string? Dono { get;  }
        public decimal Saldo { get {
                decimal saldo = 0;
                foreach (var item in todasTrancasoes)
                {
                    saldo += item.Valor;
                }
                return saldo;
        } }

        public static int numeroConta = 123456;

        private List<Transacao> todasTrancasoes = new List<Transacao>();

        public ContaBanco(string nome, decimal valor)
        {
            this.Dono = nome;
            numeroConta++;
            this.Numero = numeroConta.ToString();
            Depositar(valor, DateTime.Now, "Saldo Inicial");
        }
    
        public void Depositar(decimal valor, DateTime data, string obs)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Não aceitamos depositos de valor 0 ou negativo!");
            }
            Transacao tras = new Transacao(valor, data, obs);
            todasTrancasoes.Add(tras);
        }
        public void Sacar(decimal valor, DateTime data, string obs)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Não aceitamos saques de valor 0 ou negativo!");
            }
            if (Saldo - valor < 0)
            {
                throw new InvalidOperationException("Essa operação não é permitida!");
            }
            Transacao tras = new Transacao(-valor, data, obs);
            todasTrancasoes.Add(tras);
        }

        public string PegarMovimentacoes()
        {
            var movimentacoes = new StringBuilder();

            movimentacoes.AppendLine("\nData\t\tValor\tObs");
                
            foreach (var item in todasTrancasoes)
            {
                movimentacoes.AppendLine($"{item.Data.ToShortDateString()}\t{item.Valor}\t{item.Obs}");
            }

            return movimentacoes.ToString();
        }
    }
}
