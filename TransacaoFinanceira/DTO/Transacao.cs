namespace TransacaoFinanceira.DTO
{
    public class Transacao
    {
        public int TransacaoId { get; set; }
        public int ContaOrigem { get; set; } 
        public int ContaDestino { get; set; }
        public decimal Valor { get; set; }

        public Transacao(int transacaoId, int contaOrigem, int contaDestino, decimal valor)
        {
            TransacaoId = transacaoId;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }
    }
}
