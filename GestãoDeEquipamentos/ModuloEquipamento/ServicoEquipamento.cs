namespace GestãoDeEquipamentos
{
    public class ServicoEquipamento
    {
        private readonly RepositorioEquipamento repositorio = new();

        public void AdicionarEquipamento(Equipamento equipamento)
        {
            repositorio.Adicionar(equipamento);
        }

        public List<Equipamento> ObterTodos() => repositorio.ListarTodos();

        public Equipamento? ObterPorId(int id) => repositorio.ObterPorId(id);

        public bool AtualizarEquipamento(int id, Equipamento atualizado)
        {
            var existente = repositorio.ObterPorId(id);
            if (existente == null) return false;

            atualizado.Id = id;
            repositorio.Editar(id, atualizado);
            return true;
        }

        public bool RemoverEquipamento(int id)
        {
            if (repositorio.ObterPorId(id) == null) return false;
            repositorio.Excluir(id);
            return true;
        }
    }
}