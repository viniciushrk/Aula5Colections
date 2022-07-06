namespace AppLibrary;

public class Contexto
{
    private string diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    public List<Professor> Professores { get; set; }
    public List<Aluno> Alunos { get; set; }

    public Contexto()
    {
        Professores = new List<Professor>();
        Alunos = new List<Aluno>();
    }

    public void Seed()
    {
        Professores.Add(new Professor("111", "Lilo")
        {
            Email = "lilo@mail.com",
            Telefone = "99221-2121",
            Titulo = "Mestre"
        });

        Professores.Add(new Professor("222", "Sara")
        {
            Email = "sara@mail.com",
            Telefone = "99221-2121",
            Titulo = "Mestre"
        });

        Professores.Add(new Professor("333", "Saulo")
        {
            Email = "saulo@mail.com",
            Telefone = "99221-2121",
            Titulo = "Especialista"
        });

        Alunos.Add(new Aluno("333", "Jandira")
        {
            Email = "saulo@mail.com",
            Telefone = "99221-2121",
            Matricula = "11111"
        });
    }

    public void SaveToText()
    {
        SaveProfessorToText();
        SaveAlunoToText();
    }

    public void RestoreFromText()
    {
        RestoreProfessorFromText();
        RestoreAlunoFromText();
    }

    public void SaveProfessorToText()
    {
        var textToSave = string.Empty;
        if (Professores.Count != 0)
        {
            foreach (var professor in Professores)
            {
                textToSave += professor.ToText() + "\n";
            }
            textToSave = textToSave[..^1];
            File.WriteAllText(Path.Combine(diretorio, "Professor.txt"), textToSave);
        }
    }

    public void RestoreProfessorFromText()
    {
        if (File.Exists(Path.Combine(diretorio, "Professor.txt")))
        {
            var savedText = string.Empty;
            using (var sr = new StreamReader(Path.Combine(diretorio, "Professor.txt")))
            {
                savedText = sr.ReadToEnd();
            }
            string[]? savedTexts = savedText.Split("\n");
            foreach (var text in savedTexts)
            {
                var professor = Professor.ToObject(text);
                Professores.Add(professor);
            }
        }
    }

    public void SaveAlunoToText()
    {
        var textToSave = string.Empty;
        if (Alunos.Count != 0)
        {
            foreach (var aluno in Alunos)
            {
                textToSave += aluno.ToText() + "\n";
            }
            textToSave = textToSave[..^1];
            File.WriteAllText(Path.Combine(diretorio, "Aluno.txt"), textToSave);
        }

    }

    public void RestoreAlunoFromText()
    {
        if (File.Exists(Path.Combine(diretorio, "Aluno.txt")))
        {
            var savedText = string.Empty;
            using (var sr = new StreamReader(Path.Combine(diretorio, "Aluno.txt")))
            {
                savedText = sr.ReadToEnd();
            }
            string[]? savedTexts = savedText.Split("\n");
            foreach (var text in savedTexts)
            {
                var aluno = Aluno.ToObject(text);
                Alunos.Add(aluno);
            }
        }
    }
}
