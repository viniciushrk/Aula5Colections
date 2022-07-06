using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary;

public class Aluno : Pessoa
{
    public string? Matricula { get; set; }
    public Aluno(string cpf, string nome) : base(cpf, nome)
    {

    }
    public string ToText()
    {
        return $"{Cpf};{Nome};{Email};{Telefone};{Matricula}";
    }

    public static Aluno ToObject(string text)
    {
        string[] campos = text.Split(";");
        Aluno aluno = new Aluno(campos[0], campos[1])
        {
            Email = campos[2],
            Telefone = campos[3],
            Matricula = campos[4]
        };
        return aluno;
    }
}
