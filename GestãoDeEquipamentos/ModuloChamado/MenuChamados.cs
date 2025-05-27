namespace GestãoDeEquipamentos
{
    public class MenuChamados : TelaBase
    {
        private ServicoChamado servicoChamado = new();
        private ServicoEquipamento servicoEquipamento = new();

        public MenuChamados() : base("Chamados de Manutenção") { }

        public void ExibirMenu()
        {
            ExibirMenuBase();

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

        public override void Cadastrar()
        {
        }

        public override void Listar()
        {
        }

        public override void Editar()
        {
        }

        public override void Excluir()
        {
        }
    }
}