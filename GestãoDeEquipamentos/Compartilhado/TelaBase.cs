using System;

namespace GestãoDeEquipamentos
{
    public abstract class TelaBase
    {
        protected string NomeEntidade { get; }

        protected TelaBase(string nomeEntidade)
        {
            NomeEntidade = nomeEntidade;
        }

        public void ExibirMenuBase()
        {
            Console.WriteLine($"\n--- Gestão de {NomeEntidade} ---");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Excluir");
            Console.WriteLine("0. Voltar");

            Console.Write("Escolha uma opção: ");
        }

        public abstract void Cadastrar();
        public abstract void Listar();
        public abstract void Editar();
        public abstract void Excluir();
    }
}