using System;
using System.Linq;

namespace GestãoDeEquipamentos
{
    public class MenuEquipamentos
    {
        private ServicoEquipamento servicoEquipamento = new();

        public void ExibirMenu()
        {
            Console.WriteLine("\n1. Cadastrar\n2. Listar\n3. Editar\n4. Excluir\n0. Voltar");
            switch (Console.ReadLine())
            {
                case "1": Cadastrar(); break;
                case "2": Listar(); break;
                case "3": Editar(); break;
                case "4": Excluir(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }

        private void Cadastrar()
        {
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
        }

        private void Listar()
        {
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
        }

        private void Editar()
        {
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
        }

        private void Excluir()
        {
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
        }
    }
}
