namespace GestãoDeEquipamentos
{
    public class Fabricante : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Fabricante(string nome, string email, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do fabricante não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O email do fabricante não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(telefone))
                throw new ArgumentException("O telefone do fabricante não pode ser vazio.");

            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Email: {Email}, Telefone: {Telefone}";
        }
    }
}