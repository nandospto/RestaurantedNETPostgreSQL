import React, { useState, useEffect } from "react";
import { PedidoCard } from "./components/PedidoCard"; // Ajuste o caminho do import

// 1. Defina a interface do Pedido idêntica à do Card
interface Pedido {
  pedidoID: number;
  descricao: string;
  datapedido: string;
  status: boolean;
  clienteID: number;
  clientenome: string;
  mesaID: "Mesa ${pedido.mesaID}";
}

export default function ListaPedidos() {
  const [pedidos, setPedidos] = useState<Pedido[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  // 2. Sua função Fetch apontando para a API local C#
  const fetchPedidos = async () => {
    try {
      setLoading(true);
      const response = await fetch("http://localhost:5105/pedido");
      
      if (!response.ok) {
        throw new Error(`Erro: ${response.status}`);
      }

      const data = await response.json();
      setPedidos(data);
      setError(null);
    } catch (err) {
      setError("Erro ao carregar pedidos. Tente novamente.");
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchPedidos();
  }, []);

  if (loading) return <div className="p-6 text-center">Carregando pedidos...</div>;
  if (error) return <div className="p-6 text-center text-red-500">{error}</div>;

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-6 text-gray-800">Painel de Pedidos</h1>
      
      {/* 3. Renderização dinâmica dos Cards usando o retorno da API */}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {pedidos.map((pedido) => (
          <PedidoCard key={pedido.pedidoID} pedido={pedido} />
        ))}
      </div>
    </div>
  );
}

/* 
INTEGRAÇÃO COM SUA API C# EFC:

1. Substitua a chamada mock pela sua API real:
   const response = await fetch('https://sua-api.com/api/pedidos', {
     headers: {
       'Authorization': 'Bearer YOUR_TOKEN_HERE',
       'Content-Type': 'application/json'
     }
   });
   const data = await response.json();
   setPedidos(data);

2. Exemplo de Controller C# EFC que retorna pedidos:
   
   [ApiController]
   [Route("api/[controller]")]
   public class PedidosController : ControllerBase
   {
       private readonly ApplicationDbContext _context;
       
       public PedidosController(ApplicationDbContext context)
       {
           _context = context;
       }
       
       [HttpGet]
       public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
       {
           return await _context.Pedidos
               .OrderByDescending(p => p.DataPedido)
               .ToListAsync();
       }
   }

3. Certifique-se de que sua API retorna JSON no formato:
   [
     {
       "id": 1,
       "descricao": "descrição do pedido",
       "mesa": "Mesa 5",
       "cliente": "Nome do Cliente",
       "dataPedido": "2026-06-05T14:30:00"
     }
   ]
*/