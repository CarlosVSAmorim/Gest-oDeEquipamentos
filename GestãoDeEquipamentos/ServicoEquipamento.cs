using GestãoDeEquipamentos;

namespace GestãoDeEquipamentos
{
    public class ServicoEquipamento
    {
        private readonly List<Equipamento> equipamentos = new();
        private int proximoId = 1;

        public void AdicionarEquipamento(Equipamento eq)
        {
            eq.Id = proximoId++;
            equipamentos.Add(eq);
        }

        public List<Equipamento> ObterTodos() => equipamentos;

        public Equipamento? ObterPorId(int id) => equipamentos.FirstOrDefault(e => e.Id == id);

        public bool AtualizarEquipamento(int id, Equipamento atualizado)
        {
            var eq = ObterPorId(id);
            if (eq == null) return false;

            eq.Nome = atualizado.Nome;
            eq.Preco = atualizado.Preco;
            eq.NumeroSerie = atualizado.NumeroSerie;
            eq.DataFabricacao = atualizado.DataFabricacao;
            eq.Fabricante = atualizado.Fabricante;
            return true;
        }

        public bool RemoverEquipamento(int id)
        {
            var eq = ObterPorId(id);
            if (eq == null) return false;
            equipamentos.Remove(eq);
            return true;
        }
    }
}