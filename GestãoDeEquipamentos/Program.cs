using System;
using System.Linq;
using GestãoDeEquipamentos;

namespace GestãoDeEquipamentos
{
    internal class Program
    {
        private static ServicoEquipamento servicoEquipamento = new();
        private static ServicoChamado servicoChamado = new();

        static void Main(string[] args)
        {
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
        }

        private static void MenuEquipamentos()
        {
            Console.WriteLine("\n1. Cadastrar\n2. Listar\n3. Editar\n4. Excluir\n0. Voltar");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Nome: ");
                    var nome = Console.ReadLine()!;
                    if (nome.Length < 6) { Console.WriteLine("Nome inválido. Deve ter pelo menos 6 caracteres."); return; }

                    Console.Write("Preço: ");
                    if (!decimal.TryParse(Console.ReadLine(), out var preco))
                    {
                        Console.WriteLine("Preço inválido.");
                        return;
                    }

                    Console.Write("Número de Série: ");
                    var numeroSerie = Console.ReadLine()!;

                    Console.Write("Data de Fabricação (dd/MM/yyyy): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out var dataFabricacao))
                    {
                        Console.WriteLine("Data inválida.");
                        return;
                    }

                    Console.Write("Fabricante: ");
                    var fabricante = Console.ReadLine()!;

                    var idEquipamento = servicoEquipamento.ObterTodos().Count + 1;

                    try
                    {
                        var novoEquipamento = new Equipamento(nome, preco, numeroSerie, dataFabricacao, fabricante);
                        servicoEquipamento.AdicionarEquipamento(novoEquipamento);
                        Console.WriteLine("Equipamento cadastrado com sucesso.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                    break;

                case "2":
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

                case "3":
                    Console.Write("Digite o ID do equipamento a ser editado: ");
                    if (!int.TryParse(Console.ReadLine(), out var idEquipamentoEditar))
                    {
                        Console.WriteLine("ID inválido.");
                        return;
                    }

                    var equipamentoEditado = servicoEquipamento.ObterPorId(idEquipamentoEditar);
                    if (equipamentoEditado == null)
                    {
                        Console.WriteLine("Equipamento não encontrado.");
                        return;
                    }

                    Console.WriteLine("Equipamento encontrado:");
                    Console.WriteLine(equipamentoEditado);

                    Console.Write("Novo nome: ");
                    var novoNome = Console.ReadLine()!;
                    if (novoNome.Length < 6)
                    {
                        Console.WriteLine("O nome do equipamento deve ter pelo menos 6 caracteres.");
                        return;
                    }
                    equipamentoEditado.Nome = novoNome;

                    Console.Write("Novo preço: ");
                    if (!decimal.TryParse(Console.ReadLine(), out var novoPreco))
                    {
                        Console.WriteLine("Preço inválido.");
                        return;
                    }
                    equipamentoEditado.Preco = novoPreco;

                    Console.Write("Novo número de série: ");
                    equipamentoEditado.NumeroSerie = Console.ReadLine()!;

                    Console.Write("Nova data de fabricação (dd/MM/yyyy): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out var novaDataFabricacao))
                    {
                        Console.WriteLine("Data inválida.");
                        return;
                    }
                    equipamentoEditado.DataFabricacao = novaDataFabricacao;

                    Console.Write("Novo fabricante: ");
                    equipamentoEditado.Fabricante = Console.ReadLine()!;

                    if (!servicoEquipamento.AtualizarEquipamento(idEquipamentoEditar, equipamentoEditado))
                        Console.WriteLine("Erro ao editar o equipamento.");
                    else
                        Console.WriteLine("Equipamento atualizado com sucesso.");
                    break;

                case "4":
                    Console.Write("Digite o ID do equipamento a ser excluído: ");
                    if (!int.TryParse(Console.ReadLine(), out var idEquipamentoExcluir))
                    {
                        Console.WriteLine("ID inválido.");
                        return;
                    }
                    if (!servicoEquipamento.RemoverEquipamento(idEquipamentoExcluir))
                        Console.WriteLine("Erro ao excluir o equipamento.");
                    else
                        Console.WriteLine("Equipamento excluído com sucesso.");
                    break;

                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        private static void MenuChamados()
        {
            Console.WriteLine("\n1. Cadastrar\n2. Listar\n3. Editar\n4. Excluir\n0. Voltar");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Título do chamado: ");
                    string titulo = Console.ReadLine()!;

                    Console.Write("Descrição do chamado: ");
                    string descricao = Console.ReadLine()!;

                    var equipamentosDisponiveis = servicoEquipamento.ObterTodos();
                    if (!equipamentosDisponiveis.Any())
                    {
                        Console.WriteLine("Nenhum equipamento disponível para associar ao chamado.");
                        return;
                    }

                    Console.WriteLine("Equipamentos disponíveis:");
                    foreach (var e in equipamentosDisponiveis)
                        Console.WriteLine(e);

                    Console.Write("Digite o ID do Equipamento relacionado: ");
                    if (!int.TryParse(Console.ReadLine(), out int idEquipamentoChamado))
                    {
                        Console.WriteLine("ID inválido.");
                        return;
                    }

                    var equipamentoRelacionado = servicoEquipamento.ObterPorId(idEquipamentoChamado);
                    if (equipamentoRelacionado == null)
                    {
                        Console.WriteLine("Equipamento não encontrado.");
                        return;
                    }

                    var idChamado = servicoChamado.ObterTodos().Count + 1;

                    try
                    {
                        var chamado = new ChamadoManutencao(titulo, descricao, equipamentoRelacionado, DateTime.Now);
                        chamado.Id = idChamado;
                        servicoChamado.AdicionarChamado(chamado);
                        Console.WriteLine("Chamado de manutenção registrado com sucesso.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                    break;

                case "2":
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

                case "3":
                    Console.Write("Digite o ID do chamado a ser editado: ");
                    if (!int.TryParse(Console.ReadLine(), out var idChamadoEditar))
                    {
                        Console.WriteLine("ID inválido.");
                        return;
                    }

                    var chamadoExistente = servicoChamado.ObterPorId(idChamadoEditar);
                    if (chamadoExistente == null)
                    {
                        Console.WriteLine("Chamado não encontrado.");
                        return;
                    }

                    Console.Write("Novo título do chamado: ");
                    string novoTitulo = Console.ReadLine()!;

                    Console.Write("Nova descrição do chamado: ");
                    string novaDescricao = Console.ReadLine()!;

                    Console.Write("Novo equipamento relacionado (ID): ");
                    if (!int.TryParse(Console.ReadLine(), out var idNovoEquipamento))
                    {
                        Console.WriteLine("ID inválido.");
                        return;
                    }

                    var novoEquipamento = servicoEquipamento.ObterPorId(idNovoEquipamento);
                    if (novoEquipamento == null)
                    {
                        Console.WriteLine("Equipamento não encontrado.");
                        return;
                    }

                    var chamadoAtualizado = new ChamadoManutencao(novoTitulo, novaDescricao, novoEquipamento, chamadoExistente.DataAbertura);
                    chamadoAtualizado.Id = idChamadoEditar;

                    if (!servicoChamado.AtualizarChamado(idChamadoEditar, chamadoAtualizado))
                        Console.WriteLine("Erro ao editar o chamado.");
                    else
                        Console.WriteLine("Chamado atualizado com sucesso.");
                    break;

                case "4":
                    Console.Write("Digite o ID do chamado a ser excluído: ");
                    if (!int.TryParse(Console.ReadLine(), out var idChamadoExcluir))
                    {
                        Console.WriteLine("ID inválido.");
                        return;
                    }
                    if (!servicoChamado.RemoverChamado(idChamadoExcluir))
                        Console.WriteLine("Erro ao excluir o chamado.");
                    else
                        Console.WriteLine("Chamado excluído com sucesso.");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
