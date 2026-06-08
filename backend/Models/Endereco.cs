namespace backend.Models
{
    public class Endereco
    {
        public int EnderecoID { get; set; }
        public string Logradouro { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string CEP { get; set; } = null!;

        public string EnderecoCompleto => Logradouro + ", " + Numero
    + (string.IsNullOrWhiteSpace(Complemento) ? "" : ", " + Complemento)
    + ", " + Bairro + ", " + Cidade + " - " + CEP;


        public int PedidosID { get; set; }
        public Pedidos Pedidos { get; set; } = null!;
    }

}