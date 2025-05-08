namespace GestãoDeEquipamentos
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime DataFabricacao { get; set; }
        public string Fabricante { get; set; }

        // Construtor para inicializar o equipamento com os parâmetros
        public Equipamento(int id, string nome, decimal preco, string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 6)
                throw new ArgumentException("Nome deve ter pelo menos 6 caracteres.");
            
            if (preco < 0)
                throw new ArgumentException("Preço não pode ser negativo.");
            
            if (string.IsNullOrWhiteSpace(numeroSerie))
                throw new ArgumentException("Número de série não pode ser vazio.");
            
            if (string.IsNullOrWhiteSpace(fabricante))
                throw new ArgumentException("Fabricante não pode ser vazio.");
            
            Id = id;
            Nome = nome;
            Preco = preco;
            NumeroSerie = numeroSerie;
            DataFabricacao = dataFabricacao;
            Fabricante = fabricante;
        }

        // Método ToString para exibir os detalhes do equipamento de forma legível
        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Preço: R${Preco:F2}, Fabricante: {Fabricante}, Fabricação: {DataFabricacao:dd/MM/yyyy}";
        }
    }
}