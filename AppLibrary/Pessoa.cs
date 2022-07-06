namespace AppLibrary;

public abstract class Pessoa
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }

    public Pessoa(string cpf, string nome)
    {
        Cpf = cpf;
        Nome = nome;
    }

    public override string ToString()
    {
        return $"{Cpf} - {Nome}";
    }
}
