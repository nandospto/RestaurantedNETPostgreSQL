import React, { useState, useEffect } from "react";
import { PedidoCard } from "../components/PedidoCard"; // Ajuste o caminho se a pasta for diferente

// Interface idêntica à do seu banco/card para o TypeScript não reclamar
interface Pedido {
  pedidoID: number;
  descricao: string;
  datapedido: string;
  status: boolean;
  clienteID: number;
  clienteNome: string;
  mesaID: number;
}

export default function App() {
  const [pedidos, setPedidos] = useState<Pedido[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  // Busca os dados da API C# local
  const fetchPedidos = async () => {
    try {
      setLoading(true);
      const response = await fetch("http://localhost:5105/pedido");
      
      if (!response.ok) {
        throw new Error(`Erro no servidor: ${response.status}`);
      }

      const data = await response.json();
      setPedidos(data);
      setError(null);
    } catch (err) {
      setError("Não foi possível carregar os pedidos da API.");
      console.error("Erro no fetch:", err);
    } finally {
      setLoading(false);
    }
  };

  // Executa a busca assim que a tela abre
  useEffect(() => {
    fetchPedidos();
  }, []);

  if (loading) {
    return (
      <div className="flex justify-center items-center h-screen bg-gray-50">
        <p className="text-lg font-semibold text-gray-600">Carregando pedidos...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="flex justify-center items-center h-screen bg-gray-50">
        <p className="text-lg font-semibold text-red-500">{error}</p>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <header className="mb-8">
          <h1 className="text-3xl font-bold text-gray-900">Painel de Pedidos</h1>
          <p className="text-gray-500 text-sm mt-1">Gerenciamento em tempo real</p>
        </header>

        {pedidos.length === 0 ? (
          <p className="text-gray-500">Nenhum pedido encontrado no banco de dados.</p>
        ) : (
          /* Grid que organiza os cards do Figma de forma responsiva */
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            {pedidos.map((pedido) => (
              <PedidoCard key={pedido.pedidoID} pedido={pedido} />
            ))}
          </div>
        )}
      </div>
    </div>
  );
}