using System;
using TransacaoFinanceira.DAO;
using TransacaoFinanceira.DTO;

namespace TransacaoFinanceira.Service
{
    public class ExecutarTransacaoFinanceiraService : AcessoDados
    {
        public void Transferir(int transacaoId, int contaOrigem, int contaDestino, decimal valor)
        {
            ContasSaldo contaSaldoOrigem = GetSaldo<ContasSaldo>(contaOrigem);
            
            if (contaSaldoOrigem.Saldo < valor)
                Console.WriteLine("Transacao numero {0} foi cancelada por falta de saldo", transacaoId);
            else
            {
                ContasSaldo contaSaldoDestino = GetSaldo<ContasSaldo>(contaDestino);

                Atualizar(new ContasSaldo(contaOrigem, contaSaldoOrigem.Saldo - valor));
                Atualizar(new ContasSaldo(contaDestino, contaSaldoDestino.Saldo + valor));

                ContasSaldo contaSaldoorigemAtualizada = GetSaldo<ContasSaldo>(contaOrigem);
                ContasSaldo contaSaldoDestinoAtualizada = GetSaldo<ContasSaldo>(contaDestino);

                var mensagem = string.Format("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", transacaoId, contaSaldoorigemAtualizada != null? contaSaldoorigemAtualizada!.Saldo : 0000, contaSaldoDestinoAtualizada != null ? contaSaldoDestinoAtualizada.Saldo : 0000);

                Console.WriteLine(mensagem);
            }
        }
    }
}
