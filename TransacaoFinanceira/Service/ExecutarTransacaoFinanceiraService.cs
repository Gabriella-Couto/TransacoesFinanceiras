using System;
using TransacaoFinanceira.Dominio.Entidades;
using TransacaoFinanceira.Infraestrutura.Repositorios;

namespace TransacaoFinanceira.Service
{
    public class ExecutarTransacaoFinanceiraService : AcessoDadosRepositorio
    {
        public void Transferir(int transacaoId, long contaOrigem, long contaDestino, decimal valor)
        {
            ContasSaldo contaSaldoOrigem = GetSaldo<ContasSaldo>(contaOrigem);
            
            if (contaSaldoOrigem.Saldo < valor)
                Console.WriteLine("Transacao numero {0} foi cancelada por falta de saldo", transacaoId);
            else
            {
                ContasSaldo contaSaldoDestino = GetSaldo<ContasSaldo>(contaDestino);

                Atualizar(new ContasSaldo(contaOrigem, contaSaldoOrigem.Saldo - valor));
                Atualizar(new ContasSaldo(contaDestino, contaSaldoDestino.Saldo + valor));

                var mensagem = string.Format("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", transacaoId, contaSaldoOrigem.Saldo - valor, contaSaldoDestino.Saldo + valor);

                Console.WriteLine(mensagem);
            }
        }
    }
}
