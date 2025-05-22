using System;
using System.Linq;

namespace GestãoDeEquipamentos
{
    public class MenuChamados
    {
        private ServicoChamado servicoChamado = new();
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
        }

        private void Listar()
        {
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
        }

        private void Editar()
        {
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
        }

        private void Excluir()
        {
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
        }
    }
}
