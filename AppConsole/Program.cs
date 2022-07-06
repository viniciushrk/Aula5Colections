using static System.Console;
using AppLibrary;
//using Sapiens.Core;

var ctx = new Contexto();
ctx.RestoreFromText();
//ctx.Seed();
ctx.SaveToText();
App();

void App()
{
    Menu.DesenhaTitulo("ACADÊMICO");
    WriteLine("[1] - Alunos");
    WriteLine("[2] - Professores");
    WriteLine("[3] - Disciplinas");
    WriteLine("\n[Enter] para sair");

    var opcao = ReadLine();

    switch (opcao)
    {
        case "1": DoAlunos(); break;
        case "2": DoProfessores(); break;
            //case "3": DoDisciplinas();break;
    }
}

void DoAlunos()
{
    Clear();
    Menu.DesenhaTitulo("ALUNOS");
    WriteLine("[1] - Cadastrar");
    WriteLine("[2] - Listar");
    WriteLine("[3] - Consultar");
    WriteLine("[4] - Excluir");

    var opcao = ReadLine();

    switch (opcao)
    {
        case "1": DoCadastrarAluno(); break;
        case "2": DoListarAluno(); break;
        case "3": DoConsultarAluno(); break;
        case "4": DoExcluirAluno(); break;
    }
}

void DoProfessores()
{
    Clear();
    Menu.DesenhaTitulo("PROFESSORES");
    WriteLine("[1] - Cadastrar");
    WriteLine("[2] - Listar");
    WriteLine("[3] - Consultar");
    WriteLine("[4] - Excluir");

    var opcao = ReadLine();

    switch (opcao)
    {
        case "1": DoCadastrarProfessor(); break;
        case "2": DoListarProfessor(); break;
        case "3": DoConsultarProfessor(); break;
        case "4": DoExcluirProfessor(); break;
    }
}

//void DoDisciplinas()
//{
//    Clear();
//    Menu.DesenhaTitulo("DISCIPLINAS");
//    WriteLine("[1] - Cadastrar");
//    WriteLine("[2] - Listar");
//    WriteLine("[3] - Consultar");
//    WriteLine("[4] - Excluir");

//    var opcao = ReadLine();

//    switch (opcao)
//    {
//        case "1": DoCadastrarDisciplina(); break;
//        case "2": DoListarDisciplinas(); break;
//        case "3": DoConsultarDisciplina(); break;
//        case "4": DoExcluirDisciplina(); break;
//    }
//}

void DoCadastrarAluno()
{
    Clear();
    Menu.DesenhaTitulo("CADASTRO DE ALUNO");
    Write("Nome:      ");
    var nome = ReadLine();
    Write("Cpf:       ");
    var cpf = ReadLine();
    Write("Email:     ");
    var email = ReadLine();
    Write("Telefone:  ");
    var telefone = ReadLine();
    Write("Matricula:  ");
    var matricula = ReadLine();

    ctx.Alunos.Add(new Aluno(cpf!, nome!)
    {
        Email = email,
        Telefone = telefone,
        Matricula = matricula
    });

    ctx.SaveAlunoToText();
    WriteLine("Aluno cadastrado com sucesso");
    ReadLine();
    DoAlunos();
}

void DoListarAluno()
{
    Clear();
    Menu.DesenhaTitulo("LISTA DE ALUNOS");
    foreach (var aluno in ctx.Alunos.OrderBy(p => p.Nome))
    {
        WriteLine(aluno);
    }
    ReadLine();

    DoAlunos();
}

//void DoCadastrarDisciplina()
//{
//    Clear();
//    Menu.DesenhaTitulo("CADASTRO DE DISCIPLINA");
//    Write("Nome:        ");
//    var nome = ReadLine();
//    Write("Area:        ");
//    var area = ReadLine();
//    Write("Carga Horaria:");
//    var carga = ReadLine();
//    Write("CPF professor:");
//    var professorCpf = ReadLine();
//    var professor = ctx.Professores.FirstOrDefault(p => p.Cpf == professorCpf);

//    ctx.Disciplinas.Add(new Disciplina(nome!, area!, Convert.ToInt32(carga), professor!));
//    WriteLine("Disciplina criada com sucesso");
//    ReadLine();
//    DoDisciplinas();
//}

//void DoListarDisciplinas(){
//    Clear();
//    Menu.DesenhaTitulo("LISTA DE DISCIPLINAS");
//    foreach (var disciplina in ctx.Disciplinas.OrderBy(p => p.Nome))
//    {
//        WriteLine(disciplina);
//    }
//    ReadLine();
//    DoDisciplinas();
//}

//void DoConsultarDisciplina()
//{
//    Clear();
//    Menu.DesenhaTitulo("CONSULTA DE DISCIPLINA");
//    Write("Informe o nome: ");
//    var nome = ReadLine();
//    var disciplina = ctx.Disciplinas.FirstOrDefault(p => p.Nome == nome);
//    WriteLine($"NOME     : {disciplina?.Nome}");
//    WriteLine($"CARGA H  : {disciplina?.CargaHoraria}");
//    WriteLine($"AREA     : {disciplina?.Area}");
//    WriteLine($"PROFESSOR: {disciplina?.Professor.Nome}");
//    ReadLine();
//    DoDisciplinas();
//}

//void DoExcluirDisciplina()
//{
//    Clear();
//    Menu.DesenhaTitulo("EXCLUIR DISCIPLINA");
//    Write("Informe o nome para exclusão: ");
//    var nome = ReadLine();
//    var disciplina = ctx.Disciplinas.FirstOrDefault(p => p.Nome == nome);
//    if (disciplina != null)
//    {
//        ctx.Disciplinas.Remove(disciplina);
//    }
//    WriteLine("disciplina excluída.");
//    ReadLine();
//    DoDisciplinas();
//}

void DoConsultarAluno()
{
    Clear();
    Menu.DesenhaTitulo("CONSULTA DE ALUNOS");
    Write("Informe o CPF: ");
    var cpf = ReadLine();
    var aluno = ctx.Alunos.FirstOrDefault(p => p.Cpf == cpf);
    WriteLine($"Nome     : {aluno?.Nome}");
    WriteLine($"Email    : {aluno?.Email}");
    WriteLine($"Telefone : {aluno?.Telefone}");
    WriteLine($"Matrícula: {aluno?.Matricula}");
    ReadLine();
    DoAlunos();
}

void DoExcluirAluno()
{
    Clear();
    Menu.DesenhaTitulo("EXCLUIR ALUNO");
    Write("Informe o CPF para exclusão: ");
    var cpf = ReadLine();
    var aluno = ctx.Alunos.FirstOrDefault(p => p.Cpf == cpf);
    if (aluno != null)
    {
        ctx.Alunos.Remove(aluno);
    }
    WriteLine("Aluno excluído");
    ReadLine();
    DoAlunos();
}

void DoCadastrarProfessor()
{
    Clear();
    Menu.DesenhaTitulo("CADASTRO DE PROFESSOR");
    Write("Nome:      ");
    var nome = ReadLine();
    Write("Cpf:       ");
    var cpf = ReadLine();
    Write("Email:     ");
    var email = ReadLine();
    Write("Telefone:  ");
    var telefone = ReadLine();
    Write("Título:    ");
    var titulo = ReadLine();

    ctx.Professores.Add(new Professor(cpf!, nome!)
    {
        Email = email,
        Telefone = telefone,
        Titulo = titulo
    });
    ctx.SaveProfessorToText();

    WriteLine("Professor cadastrado com sucesso");
    ReadLine();
    DoProfessores();
}

void DoListarProfessor()
{
    Clear();
    Menu.DesenhaTitulo("LISTA DE PROFESSORES");
    foreach (var professor in ctx.Professores.OrderBy(p => p.Nome))
    {
        WriteLine(professor);
    }
    ReadLine();
    DoProfessores();
}

void DoConsultarProfessor()
{
    Clear();
    Menu.DesenhaTitulo("CONSULTA DE PROFESSORES");
    Write("Informe o CPF: ");
    var cpf = ReadLine();
    var professor = ctx.Professores.FirstOrDefault(p => p.Cpf == cpf);
    WriteLine($"Nome    : {professor?.Nome}");
    WriteLine($"Email   : {professor?.Email}");
    WriteLine($"Telefone: {professor?.Telefone}");
    WriteLine($"Titulo  : {professor?.Titulo}");
    ReadLine();
    DoProfessores();
}

void DoExcluirProfessor()
{
    Clear();
    Menu.DesenhaTitulo("EXCLUIR PROFESSORE");
    Write("Informe o CPF para exclusão: ");
    var cpf = ReadLine();
    var professor = ctx.Professores.FirstOrDefault(p => p.Cpf == cpf);
    if (professor != null)
    {
        ctx.Professores.Remove(professor);
    }
    WriteLine("Professor excluído");
    ReadLine();
    DoProfessores();
}

