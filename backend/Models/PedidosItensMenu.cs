using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    [PrimaryKey(nameof(PedidoID), nameof(ItensMenuID))]
    public class PedidosItensMenu
    {
        public int Quantidade { get; set; }
        public int PrecoUnit { get; set; }

        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; } = null!;

        public int ItensMenuID { get; set; }
        public ItensMenu ItensMenu { get; set; } = null!;
    


    }
}