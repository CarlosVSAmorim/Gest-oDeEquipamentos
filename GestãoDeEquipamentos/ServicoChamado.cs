using GestãoDeEquipamentos;

namespace GestãoDeEquipamentos
{
    public class ServicoChamado
    {
        private readonly List<ChamadoManutencao> chamados = new();
        private int proximoId = 1;

        public void AdicionarChamado(ChamadoManutencao chamado)
        {
            chamado.Id = proximoId++;
            chamado.DataAbertura = DateTime.Now;
            chamados.Add(chamado);
        }

        public List<ChamadoManutencao> ObterTodos() => chamados;

        public ChamadoManutencao? ObterPorId(int id) => chamados.FirstOrDefault(c => c.Id == id);

        public bool AtualizarChamado(int id, ChamadoManutencao atualizado)
        {
            var chamado = ObterPorId(id);
            if (chamado == null) return false;

            chamado.Titulo = atualizado.Titulo;
            chamado.Descricao = atualizado.Descricao;
            chamado.Equipamento = atualizado.Equipamento;
            return true;
        }

        public bool RemoverChamado(int id)
        {
            var chamado = ObterPorId(id);
            if (chamado == null) return false;
            chamados.Remove(chamado);
            return true;
        }
    }
}