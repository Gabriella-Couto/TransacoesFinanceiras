using System;
using System.Collections.Generic;
using TransacaoFinanceira.DTO;

namespace TransacaoFinanceira.DAO
{
    public class AcessoDados
    {
        private Dictionary<int, decimal> SALDOS { get; set; }
        private List<ContasSaldo> TABELA_SALDOS;

        public AcessoDados()
        {
            TABELA_SALDOS = new List<ContasSaldo>
            {
                new ContasSaldo(938485762, 180),
                new ContasSaldo(347586970, 1200),
                new ContasSaldo(unchecked((int)2147483649), 0),
                new ContasSaldo(675869708, 4900),
                new ContasSaldo(238596054, 478),
                new ContasSaldo(573659065, 787),
                new ContasSaldo(210385733, 10),
                new ContasSaldo(674038564, 400),
                new ContasSaldo(563856300, 1200)
            };

            SALDOS = new Dictionary<int, decimal>();
            SALDOS.Add(938485762, 180);
        }

        public T GetSaldo<T>(int id)
        {
            return (T)Convert.ChangeType(TABELA_SALDOS.Find(x => x.Conta == id), typeof(T));
        }

        public bool Atualizar<T>(T dado)
        {
            try
            {
                ContasSaldo item = (dado as ContasSaldo);
                TABELA_SALDOS.RemoveAll(x => x.Conta == item.Conta);
                TABELA_SALDOS.Add(dado as ContasSaldo);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}
