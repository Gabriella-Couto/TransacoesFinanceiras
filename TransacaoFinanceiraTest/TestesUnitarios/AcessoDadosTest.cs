using FluentAssertions;
using TransacaoFinanceira.DAO;
using TransacaoFinanceira.DTO;
using Xunit;

namespace TransacaoFinanceiraTest.TestesUnitarios
{
    public class AcessoDadosTest
    {
        [Fact]
        public void GetSaldoTest_ContaExistente()
        {
            var acessoDados = new AcessoDados();
            var saldo = acessoDados.GetSaldo<ContasSaldo>(210385733);

            saldo.Should().NotBeNull();
            saldo.Saldo.Should().Be(10);
        }

        [Fact]
        public void GetSaldoTest_ContaInexistente()
        {
            var acessoDados = new AcessoDados();
            var saldo = acessoDados.GetSaldo<ContasSaldo>(11162000);

            saldo.Should().BeNull();
        }

        [Fact]
        public void Atualizar_Sucesso()
        {
            var acessoDados = new AcessoDados();
            var conta = new ContasSaldo(675869708, 6450);
            var resultadoAtualizacao = acessoDados.Atualizar(conta);

            resultadoAtualizacao.Should().BeTrue();
        }

    }
}
