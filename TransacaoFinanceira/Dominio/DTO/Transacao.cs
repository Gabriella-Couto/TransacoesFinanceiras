namespace TransacaoFinanceira.Dominio.DTO
{
    public class Transacao
    {
        public int TransacaoId { get; set; }
        public long ContaOrigem { get; set; }
        public long ContaDestino { get; set; }
        public decimal Valor { get; set; }

        public Transacao(int transacaoId, long contaOrigem, long contaDestino, decimal valor)
        {
            TransacaoId = transacaoId;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }
    }
}
