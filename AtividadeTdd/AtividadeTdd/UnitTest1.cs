using AtividadeTdd;
using NUnit.Framework;

[TestFixture]
public class PessoaTests
{
    [Test]
    public void Teste_SeValidaNumeroCPFCorreto()
    {
        // Arrange
        var pessoa = new Pessoa();
        long cpfValido = 16305833087; // Exemplo de CPF válido

        // Act
        bool resultado = pessoa.ValidaNumeroCPF(cpfValido);

        // Assert
        Assert.IsTrue(resultado);
    }

    [Test]
    public void Teste_SeValidaNumeroCPFIncorreto()
    {
        // Arrange
        var pessoa = new Pessoa();
        long cpfInvalido = 123; // Exemplo de CPF inválido

        // Act
        bool resultado = pessoa.ValidaNumeroCPF(cpfInvalido);

        // Assert
        Assert.IsFalse(resultado);
    }

    [Test]
    public void Teste_SeValidaSeDataNascimentoMenorIgualHoje()
    {
        // Arrange
        var pessoa = new Pessoa();
        DateTime dataNascimentoValida = DateTime.Today;

        // Act
        bool resultado = pessoa.ValidaDataNascimento(dataNascimentoValida);

        // Assert
        Assert.IsTrue(resultado);
    }

    [Test]
    public void Teste_SeValidaFormatoDoCelular()
    {
        // Arrange
        var pessoa = new Pessoa();
        string celularValido = "(65) 91234-5678"; // Exemplo de celular válido

        // Act
        bool resultado = pessoa.ValidaFormatoCelular(celularValido);

        // Assert
        Assert.IsTrue(resultado);
    }
}