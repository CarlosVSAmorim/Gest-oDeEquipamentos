namespace GestãoDeEquipamentos
{
    public class ChamadoManutencao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Equipamento Equipamento { get; set; }
        public DateTime DataAbertura { get; set; }

        public int DiasAberto => (DateTime.Now - DataAbertura).Days;

        public override string ToString()
        {
            return $"ID: {Id}, Título: {Titulo}, Equipamento: {Equipamento.Nome}, Abertura: {DataAbertura:dd/MM/yyyy}, Dias aberto: {DiasAberto}";
        }
    }
}