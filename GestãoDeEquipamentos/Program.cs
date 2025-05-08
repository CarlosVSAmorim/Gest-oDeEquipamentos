using GestãoDeEquipamentos;

var servicoEquipamento = new ServicoEquipamento();
var servicoChamado = new ServicoChamado();

while (true)
{
    Console.WriteLine("\n1. Equipamentos\n2. Chamados\n0. Sair");
    switch (Console.ReadLine())
    {
        case "1": MenuEquipamentos(); break;
        case "2": MenuChamados(); break;
        case "0": return;
        default: Console.WriteLine("Opção inválida."); break;
    }
}

void MenuEquipamentos()
{
    Console.WriteLine("\n1. Cadastrar\n2. Listar\n3. Editar\n4. Excluir\n0. Voltar");
    switch (Console.ReadLine())
    {
        case "1":
            var eq = new Equipamento();
            Console.Write("Nome: "); eq.Nome = Console.ReadLine()!;
            if (eq.Nome.Length < 6) { Console.WriteLine("Nome inválido."); return; }
            Console.Write("Preço: "); eq.Preco = decimal.Parse(Console.ReadLine()!);
            Console.Write("Nº Série: "); eq.NumeroSerie = Console.ReadLine()!;
            Console.Write("Data fabricação: "); eq.DataFabricacao = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Fabricante: "); eq.Fabricante = Console.ReadLine()!;
            servicoEquipamento.AdicionarEquipamento(eq);
            Console.WriteLine("Equipamento cadastrado.");
            break;
        case "2":
            foreach (var e in servicoEquipamento.ObterTodos()) Console.WriteLine(e);
            break;
        case "3":
            Console.Write("ID: ");
            var idEditar = int.Parse(Console.ReadLine()!);
            var edit = new Equipamento();
            Console.Write("Novo nome: "); edit.Nome = Console.ReadLine()!;
            if (edit.Nome.Length < 6) return;
            Console.Write("Preço: "); edit.Preco = decimal.Parse(Console.ReadLine()!);
            Console.Write("Nº Série: "); edit.NumeroSerie = Console.ReadLine()!;
            Console.Write("Data fabricação: "); edit.DataFabricacao = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Fabricante: "); edit.Fabricante = Console.ReadLine()!;
            if (!servicoEquipamento.AtualizarEquipamento(idEditar, edit)) Console.WriteLine("Erro ao editar.");
            break;
        case "4":
            Console.Write("ID: ");
            if (!servicoEquipamento.RemoverEquipamento(int.Parse(Console.ReadLine()!))) Console.WriteLine("Erro ao excluir.");
            break;
    }
}

void MenuChamados()
{
    Console.WriteLine("\n1. Cadastrar\n2. Listar\n3. Editar\n4. Excluir\n0. Voltar");
    switch (Console.ReadLine())
    {
        case "1":
            var chamado = new ChamadoManutencao();
            Console.Write("Título: "); chamado.Titulo = Console.ReadLine()!;
            Console.Write("Descrição: "); chamado.Descricao = Console.ReadLine()!;
            Console.WriteLine("Equipamentos disponíveis:");
            foreach (var e in servicoEquipamento.ObterTodos()) Console.WriteLine(e);
            Console.Write("ID do Equipamento: ");
            chamado.Equipamento = servicoEquipamento.ObterPorId(int.Parse(Console.ReadLine()!))!;
            servicoChamado.AdicionarChamado(chamado);
            break;
        case "2":
            foreach (var c in servicoChamado.ObterTodos()) Console.WriteLine(c);
            break;
        case "3":
            Console.Write("ID: ");
            var id = int.Parse(Console.ReadLine()!);
            var update = new ChamadoManutencao();
            Console.Write("Novo título: "); update.Titulo = Console.ReadLine()!;
            Console.Write("Nova descrição: "); update.Descricao = Console.ReadLine()!;
            Console.Write("ID do novo equipamento: ");
            update.Equipamento = servicoEquipamento.ObterPorId(int.Parse(Console.ReadLine()!))!;
            if (!servicoChamado.AtualizarChamado(id, update)) Console.WriteLine("Erro ao editar.");
            break;
        case "4":
            Console.Write("ID: ");
            if (!servicoChamado.RemoverChamado(int.Parse(Console.ReadLine()!))) Console.WriteLine("Erro ao excluir.");
            break;
    }
}