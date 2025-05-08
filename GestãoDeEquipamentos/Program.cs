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

// Menu para controlar os Equipamentos
void MenuEquipamentos()
{
    Console.WriteLine("\n1. Cadastrar\n2. Listar\n3. Editar\n4. Excluir\n0. Voltar");
    switch (Console.ReadLine())
    {
        case "1": // Cadastrar Equipamento
            Console.Write("Nome: ");
            var nome = Console.ReadLine()!;
            if (nome.Length < 6) { Console.WriteLine("Nome inválido. Deve ter pelo menos 6 caracteres."); return; }

            Console.Write("Preço: ");
            var preco = decimal.Parse(Console.ReadLine()!);

            Console.Write("Número de Série: ");
            var numeroSerie = Console.ReadLine()!;

            Console.Write("Data de Fabricação (dd/MM/yyyy): ");
            var dataFabricacao = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Fabricante: ");
            var fabricante = Console.ReadLine()!;

            // Gerar o ID automaticamente
            var idEquipamento = servicoEquipamento.ObterTodos().Count + 1; // Supondo que os IDs sejam sequenciais e sem lacunas

            // Criando o novo equipamento com o construtor
            try
            {
                var novoEquipamento = new Equipamento(idEquipamento, nome, preco, numeroSerie, dataFabricacao, fabricante);
                servicoEquipamento.AdicionarEquipamento(novoEquipamento);
                Console.WriteLine("Equipamento cadastrado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            break;

        case "2": // Listar Equipamentos
            var equipamentos = servicoEquipamento.ObterTodos();
            if (equipamentos.Any())
            {
                foreach (var e in equipamentos)
                    Console.WriteLine(e);
            }
            else
            {
                Console.WriteLine("Nenhum equipamento registrado.");
            }
            break;

        case "3": // Editar Equipamento
            Console.Write("Digite o ID do equipamento a ser editado: ");
            var idEquipamentoEditar = int.Parse(Console.ReadLine()!);

            // Buscar o equipamento pelo ID
            var equipamentoEditado = servicoEquipamento.ObterPorId(idEquipamentoEditar);
    
            if (equipamentoEditado == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                break;
            }

            // Exibir dados do equipamento atual
            Console.WriteLine("Equipamento encontrado:");
            Console.WriteLine(equipamentoEditado);

            // Modificar as propriedades do equipamento
            Console.Write("Novo nome: ");
            var novoNome = Console.ReadLine()!;
            if (novoNome.Length < 6)
            {
                Console.WriteLine("O nome do equipamento deve ter pelo menos 6 caracteres.");
                break;
            }
            equipamentoEditado.Nome = novoNome;

            Console.Write("Novo preço: ");
            equipamentoEditado.Preco = decimal.Parse(Console.ReadLine()!);

            Console.Write("Novo número de série: ");
            equipamentoEditado.NumeroSerie = Console.ReadLine()!;

            Console.Write("Nova data de fabricação (dd/MM/yyyy): ");
            equipamentoEditado.DataFabricacao = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Novo fabricante: ");
            equipamentoEditado.Fabricante = Console.ReadLine()!;

            // Atualizar o equipamento no serviço
            if (!servicoEquipamento.AtualizarEquipamento(idEquipamentoEditar, equipamentoEditado))
                Console.WriteLine("Erro ao editar o equipamento.");
            else
                Console.WriteLine("Equipamento atualizado com sucesso.");
            break;


        case "4": // Excluir Equipamento
            Console.Write("Digite o ID do equipamento a ser excluído: ");
            var idEquipamentoExcluir = int.Parse(Console.ReadLine()!);
            if (!servicoEquipamento.RemoverEquipamento(idEquipamentoExcluir))
                Console.WriteLine("Erro ao excluir o equipamento.");
            else
                Console.WriteLine("Equipamento excluído com sucesso.");
            break;

        case "0": // Voltar
            return;
    }
}

// Menu para controlar os Chamados
void MenuChamados()
{
    Console.WriteLine("\n1. Cadastrar\n2. Listar\n3. Editar\n4. Excluir\n0. Voltar");
    switch (Console.ReadLine())
    {
        case "1": // Cadastrar Chamado
            // Solicita os dados necessários para o chamado
            Console.Write("Título do chamado: ");
            string titulo = Console.ReadLine()!;
            
            Console.Write("Descrição do chamado: ");
            string descricao = Console.ReadLine()!;
            
            // Exibe os equipamentos disponíveis
            Console.WriteLine("Equipamentos disponíveis:");
            foreach (var e in servicoEquipamento.ObterTodos()) 
                Console.WriteLine(e);
            
            Console.Write("Digite o ID do Equipamento relacionado: ");
            Equipamento equipamento = servicoEquipamento.ObterPorId(int.Parse(Console.ReadLine()!))!;
            
            // Cria o chamado com os dados fornecidos
            var chamado = new ChamadoManutencao(
                0, // ID gerado automaticamente ou um valor específico
                titulo, 
                descricao, 
                equipamento, 
                DateTime.Now // Data de abertura é a data atual
            );
            
            // Adiciona o chamado
            servicoChamado.AdicionarChamado(chamado);
            Console.WriteLine("Chamado de manutenção registrado com sucesso.");
            break;

        case "2": // Listar Chamados
            var chamados = servicoChamado.ObterTodos();
            if (chamados.Any()) 
            {
                foreach (var c in chamados) 
                    Console.WriteLine(c);
            }
            else 
            {
                Console.WriteLine("Nenhum chamado registrado.");
            }
            break;

        case "3": // Editar Chamado
            Console.Write("Digite o ID do chamado a ser editado: ");
            var idChamadoEditar = int.Parse(Console.ReadLine()!);
            
            // Cria o chamado atualizado
            Console.Write("Novo título do chamado: ");
            string novoTitulo = Console.ReadLine()!;
            
            Console.Write("Nova descrição do chamado: ");
            string novaDescricao = Console.ReadLine()!;
            
            Console.Write("Novo equipamento relacionado (ID): ");
            Equipamento novoEquipamento = servicoEquipamento.ObterPorId(int.Parse(Console.ReadLine()!))!;
            
            var chamadoAtualizado = new ChamadoManutencao(
                idChamadoEditar, // Passa o ID do chamado para edição
                novoTitulo, 
                novaDescricao, 
                novoEquipamento, 
                DateTime.Now // Data de abertura pode ser atualizada ou mantida
            );
            
            // Atualiza o chamado
            if (!servicoChamado.AtualizarChamado(idChamadoEditar, chamadoAtualizado))
                Console.WriteLine("Erro ao editar o chamado.");
            else
                Console.WriteLine("Chamado atualizado com sucesso.");
            break;

        case "4": // Excluir Chamado
            Console.Write("Digite o ID do chamado a ser excluído: ");
            var idChamadoExcluir = int.Parse(Console.ReadLine()!);
            
            // Exclui o chamado
            if (!servicoChamado.RemoverChamado(idChamadoExcluir))
                Console.WriteLine("Erro ao excluir o chamado.");
            else
                Console.WriteLine("Chamado excluído com sucesso.");
            break;

        case "0": // Voltar
            return;
    }
}