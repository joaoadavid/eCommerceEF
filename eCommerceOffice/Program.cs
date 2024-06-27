using eCommerceOffice;
using eCommerceOffice.Models;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceOfficeContext();

#region many-tomany 2x one-to-many
var resultado = db.Setores.Include(a => a.ColaboradoresSetores).ThenInclude(a=>a.Colaborador);

foreach(var setor in resultado)
{
    Console.WriteLine(setor.Nome);
    foreach(var colabSetor in setor.ColaboradoresSetores)
    {
        Console.WriteLine(colabSetor.SetorId + " - " + colabSetor.ColaboradorId);
    }
}
#endregion

var resultadoTurma = db.Colaboradores.Include(a => a.Turmas);

foreach(var colab in resultadoTurma)
{
    Console.WriteLine(colab.Nome);

    foreach(var turma in colab.Turmas)
    {
        Console.WriteLine(" - " + turma.Nome);
    }
}

Console.WriteLine("----------");
var colabVeiculo = db.Colaboradores!.Include(a => a.Veiculos);
foreach(var colab in colabVeiculo)
{
    Console.WriteLine(colab.Nome);
    foreach(var veiculo in colab.Veiculos!)
    {
        Console.WriteLine(veiculo.Nome);
    }
}

var vinculo01 = db.Set<ColaboradorVeiculo>().SingleOrDefault(a=>a.ColaboradorId == 1 && a.VeiculoId == 1);

