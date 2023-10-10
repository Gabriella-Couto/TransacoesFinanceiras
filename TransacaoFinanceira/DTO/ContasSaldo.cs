namespace TransacaoFinanceira.DTO
{
    public class ContasSaldo
    {
        public int Conta { get; set; }
        public decimal Saldo { get; set; }

        public ContasSaldo(int conta, decimal saldo)
        {
            this.Conta = conta;
            this.Saldo = saldo;
        }
    }
}
