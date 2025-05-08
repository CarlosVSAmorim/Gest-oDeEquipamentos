namespace GestãoDeEquipamentos
{
    public class ChamadoManutencao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Equipamento Equipamento { get; set; }
        public DateTime DataAbertura { get; set; }

        // Propriedade que calcula os dias desde a abertura
        public int DiasAberto => (DateTime.Now - DataAbertura).Days;

        // Construtor para garantir que o chamado seja criado com dados válidos
        public ChamadoManutencao(int id, string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("O título do chamado não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição do chamado não pode ser vazia.");
            if (equipamento == null)
                throw new ArgumentException("O equipamento associado ao chamado não pode ser nulo.");
            
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
        }

        // Método ToString para exibir os detalhes do chamado
        public override string ToString()
        {
            return $"ID: {Id}, Título: {Titulo}, Equipamento: {Equipamento.Nome}, Abertura: {DataAbertura:dd/MM/yyyy}, Dias aberto: {DiasAberto}";
        }
    }
}