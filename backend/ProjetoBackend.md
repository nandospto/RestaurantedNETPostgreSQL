## Modelagem do Banco de Dados (7 Tabelas)

### 1. `clientes`
* **Atributos:** `id_cliente` (PK), `nome`, `telefone`, `email`, `ativo` (Boolean).
* **Relações:** **1:N** com `pedidos`.

### 2. `mesas`
* **Atributos:** `id_mesa` (PK), `capacidade`, `disponibilidade` (Boolean).
* **Relações:** **1:N** com `pedidos`.

### 3. `itens_menu`
* **Atributos:** `id_item` (PK), `nome`, `descricao`, `preco`, `ativo` (Boolean).
* **Relações:** **1:N** com `pedidos_itens_menu`.

### 4. `pedidos`
* **Atributos:** `id_pedido` (PK), `id_cliente` (FK, Nullable), `id_mesa` (FK, Nullable), `data_pedido`, `status_pedido`, `tipo_pedido` ('Delivery', 'Balcao', 'Mesa'), `valor_total`.
* **Relações:** **N:1** com `clientes`, **N:1** com `mesas`, **1:N** com `pedidos_itens_menu`, **1:1** com `enderecos_entrega`, **1:1** com `pagamentos`.

### 5. `pedidos_itens_menu` (Tabela Pivô)
* **Atributos:** `id_pedido` (FK/Composite PK), `id_item` (FK/Composite PK), `quantidade`, `preco_historico`.
* **Relações:** **N:1** com `pedidos`, **N:1** com `itens_menu`.

### 6. `enderecos_entrega`
* **Atributos:** `id_endereco` (PK), `id_pedido` (FK), `logradouro`, `numero`, `bairro`, `cidade`, `cep`.
* **Relações:** **N:1** com `pedidos`.

### 7. `pagamentos`
* **Atributos:** `id_pagamento` (PK), `id_pedido` (FK), `metodo_pagamento`, `status_pagamento`, `data_pagamento`.
* **Relações:** **1:1** com `pedidos`.

---

## Estrutura de Endpoints da API e DTOs Necessários

### 📦 Pedidos (`/api/pedidos`)

* **`GET /api/pedidos`**
  * **DTO de Saída Necessário (`PedidoMinificadoDTO`):** Evita trazer dados pesados na listagem. Retorna apenas `id_pedido`, `nome_cliente` (resolvido via JOIN), `data_pedido`, `status_pedido`, `tipo_pedido` e `valor_total` para renderizar as tabelas/cards no React.

* **`GET /api/pedidos/{id}`**
  * **DTO de Saída Necessário (`PedidoDetalhadoDTO`):** Objeto completo agregando os dados do cliente, os dados do endereço (se for Delivery) e uma lista interna de itens (`ItemPedidoDTO`) contendo nome do item, quantidade e preço histórico.

* **`POST /api/pedidos`**
  * **DTO de Entrada Necessário (`CriarPedidoDTO`):** Envia dados do payload do front-end. Deve conter `id_cliente` (opcional), `id_mesa` (opcional), `tipo_pedido`, os dados do endereço de entrega (caso seja Delivery) e uma lista de objetos contendo `id_item` e `quantidade`. O C# usará isso para calcular o `valor_total` no servidor e salvar nas tabelas corretas.

* **`PATCH /api/pedidos/{id}/status`**
  * **DTO de Entrada Necessário (`AtualizarStatusPedidoDTO`):** Payload contendo apenas a string/enum do novo `status_pedido`.

* **`PATCH /api/pedidos/{id}/cancelar`**
  * **Não precisa de DTO:** A rota já identifica o recurso pelo ID na URL. O corpo da requisição pode ir vazio.

### 🍔 Itens do Menu (`/api/itens-menu`)

* **`GET /api/itens-menu`**
  * **DTO de Saída Recomendado (`ItemMenuDTO`):** Retorna `id_item`, `nome`, `descricao` e `preco`. Omite o campo de controle do banco `ativo`.

* **`POST /api/itens-menu`**
  * **DTO de Entrada Necessário (`CriarItemMenuDTO`):** Contém `nome`, `descricao` e `preco`. Não envia o campo `ativo` (que assume `true` por padrão no banco).

* **`PUT /api/itens-menu/{id}`**
  * **DTO de Entrada Necessário (`AtualizarItemMenuDTO`):** Mesma estrutura do DTO de criação, usado para atualizar os campos do item mapeado pelo ID.

* **`DELETE /api/itens-menu/{id}`**
  * **Não precisa de DTO.**

### 👥 Clientes (`/api/clientes`)

* **`GET /api/clientes`**
  * **DTO de Saída Recomendado (`ClienteListaDTO`):** Retorna apenas `id_cliente` e `nome` para componentes de autocomplete/busca rápida no front-end.

* **`POST /api/clientes`**
  * **DTO de Entrada Necessário (`CriarClienteDTO`):** Contém `nome`, `telefone` e `email`.

### 💳 Pagamentos (`/api/pedidos/{id}/pagamento`)

* **`POST /api/pedidos/{id}/pagamento`**
  * **DTO de Entrada Necessário (`RegistrarPagamentoDTO`):** Contem `metodo_pagamento`. O ID do pedido vem da URL e os campos `status_pagamento` e `data_pagamento` são gerados pelo backend no momento da validação.