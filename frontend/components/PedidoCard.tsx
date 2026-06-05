import React from "react";
import {
  Calendar,
  User,
  UtensilsCrossed,
  FileText,
} from "lucide-react";

interface Pedido {
  pedidoID: number;
  descricao: string;
  datapedido: string;
  status: boolean;
  clienteID: number;
  clienteNome: string;
  mesaID: number;
}

interface PedidoCardProps {
  pedido: Pedido;
}

export function PedidoCard({ pedido }: PedidoCardProps) {
  // Formata a data do pedido
  const formatarData = (dataString: string) => {
    const data = new Date(dataString);
    return new Intl.DateTimeFormat("pt-BR", {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
      hour: "2-digit",
      minute: "2-digit",
    }).format(data);
  };

  return (
    <div className="bg-white rounded-lg shadow-md hover:shadow-xl transition-shadow duration-300 overflow-hidden border border-gray-100">
      {/* Cabeçalho do Card */}
      <div className="bg-gradient-to-r from-blue-600 to-indigo-600 px-6 py-4">
        <div className="flex items-center justify-between text-white">
          <span className="text-sm opacity-90">
            Pedido #{pedido.pedidoID}
          </span>
          <UtensilsCrossed className="w-5 h-5" />
        </div>
      </div>

      {/* Conteúdo do Card */}
      <div className="p-6 space-y-4">
        {/* Descrição */}
        <div className="flex gap-3">
          <FileText className="w-5 h-5 text-gray-400 flex-shrink-0 mt-0.5" />
          <div className="flex-1">
            <p className="text-xs text-gray-500 mb-1">
              Descrição
            </p>
            <p className="text-gray-700 leading-relaxed">
              {pedido.descricao}
            </p>
          </div>
        </div>

        {/* Mesa */}
        <div className="flex gap-3 items-start">
          <UtensilsCrossed className="w-5 h-5 text-gray-400 flex-shrink-0" />
          <div>
            <p className="text-xs text-gray-500 mb-1">Mesa</p>
            <p className="text-gray-800">{pedido.mesaID}</p>
          </div>
        </div>

        {/* Cliente */}
        <div className="flex gap-3 items-start">
          <User className="w-5 h-5 text-gray-400 flex-shrink-0" />
          <div>
            <p className="text-xs text-gray-500 mb-1">
              Cliente
            </p>
            <p className="text-gray-800">
              {pedido.clienteNome}
            </p>
          </div>
        </div>

        {/* Data do Pedido */}
        <div className="flex gap-3 items-start pt-2 border-t border-gray-100">
          <Calendar className="w-5 h-5 text-gray-400 flex-shrink-0" />
          <div>
            <p className="text-xs text-gray-500 mb-1">
              Data do Pedido
            </p>
            <p className="text-gray-800">
              {formatarData(pedido.datapedido)}
            </p>
          </div>
        </div>
      </div>

      {/* Rodapé com ações (opcional) */}
      <div className="px-6 py-3 bg-gray-50 border-t border-gray-100">
        <div className="flex gap-2">
          <button className="flex-1 px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 transition-colors text-sm">
            Ver Detalhes
          </button>
          <button className="px-4 py-2 border border-gray-300 text-gray-700 rounded-md hover:bg-gray-100 transition-colors text-sm">
            Atualizar
          </button>
        </div>
      </div>
    </div>
  );
}