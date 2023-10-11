using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransacaoFinanceira.Dominio.DTO;
using TransacaoFinanceira.Service;

namespace TransacaoFinanceira
{
    public class Program
    {

        static void Main(string[] args)
        {
            var TRANSACOES = new List<Transacao> {
                                     new Transacao(1, 938485762, 2147483649, 150),
                                     new Transacao (2, 2147483649, 210385733, 149),
                                     new Transacao(3, 347586970, 238596054, 1100),
                                     new Transacao (4, 675869708, 210385733, 5300),
                                     new Transacao(5, 238596054, 674038564, 1489),
                                     new Transacao(6, 573659065, 563856300, 49),
                                     new Transacao(7, 938485762, 2147483649, 44),
                                     new Transacao(8, 573659065, 675869708, 150)
            };

            ExecutarTransacaoFinanceiraService executor = new();
            Parallel.ForEach(TRANSACOES, item =>
            {
                executor.Transferir(item.TransacaoId, item.ContaOrigem, item.ContaDestino, item.Valor);
            });

        }
    }
}
