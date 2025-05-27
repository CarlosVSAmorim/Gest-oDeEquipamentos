namespace GestãoDeEquipamentos
{
    public class MenuEquipamentos : TelaBase
    {
        private ServicoEquipamento servicoEquipamento = new();

        public MenuEquipamentos() : base("Equipamentos") { }

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