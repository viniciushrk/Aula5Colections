namespace AppLibrary;

public class Professor : Pessoa
{
    public string? Titulo { get; set; }
    public Professor(string cpf, string nome) : base(cpf, nome)
    {

    }

    public string ToText()
    {
        return $"{Cpf};{Nome};{Email};{Telefone};{Titulo}";
    }

    public static Professor ToObject(string text)
    {
        string[] campos = text.Split(";");
        Professor professor = new Professor(campos[0], campos[1])
        {
            Email = campos[2],
            Telefone = campos[3],
            Titulo = campos[4]
        };
        return professor;
    }
}