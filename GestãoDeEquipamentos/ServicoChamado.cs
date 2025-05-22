namespace GestãoDeEquipamentos
{
    public class ServicoChamado
    {
        private readonly RepositorioChamado repositorio = new();

        public void AdicionarChamado(ChamadoManutencao chamado)
        {
            chamado.DataAbertura = DateTime.Now;
            repositorio.Adicionar(chamado);
        }

        public List<ChamadoManutencao> ObterTodos() => repositorio.ListarTodos();

        public ChamadoManutencao? ObterPorId(int id) => repositorio.ObterPorId(id);

        public bool AtualizarChamado(int id, ChamadoManutencao atualizado)
        {
            var existente = repositorio.ObterPorId(id);
            if (existente == null) return false;

            atualizado.Id = id;
            atualizado.DataAbertura = existente.DataAbertura; // manter a data original
            repositorio.Editar(id, atualizado);
            return true;
        }

        public bool RemoverChamado(int id)
        {
            if (repositorio.ObterPorId(id) == null) return false;
            repositorio.Excluir(id);
            return true;
        }
    }
}