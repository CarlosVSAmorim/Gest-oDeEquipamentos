# Gestão de Equipamentos

Este é um sistema de **Gestão de Equipamentos**, onde é possível registrar, editar, listar e excluir equipamentos e chamados de manutenção associados a esses equipamentos. O projeto foi desenvolvido utilizando **C#** com conceitos de Programação Orientada a Objetos (POO) para gerenciar as operações relacionadas a equipamentos e manutenção.

## Funcionalidades

- **Cadastro de Equipamentos**: Permite adicionar novos equipamentos ao sistema, com informações como nome, preço, número de série, data de fabricação e fabricante.
- **Listagem de Equipamentos**: Exibe todos os equipamentos cadastrados no sistema.
- **Edição de Equipamentos**: Permite editar as informações de um equipamento existente, como nome, preço, número de série, data de fabricação e fabricante.
- **Exclusão de Equipamentos**: Permite remover um equipamento do sistema com base no ID.
- **Cadastro de Chamados de Manutenção**: Permite registrar chamados de manutenção relacionados a equipamentos, incluindo título, descrição e equipamento associado.
- **Listagem de Chamados**: Exibe todos os chamados de manutenção registrados no sistema.
- **Edição de Chamados**: Permite editar os chamados de manutenção existentes, alterando o título, a descrição e o equipamento associado.
- **Exclusão de Chamados**: Permite excluir chamados de manutenção existentes no sistema.
- 
## Estrutura do Projeto

O projeto é dividido em várias classes, cada uma responsável por uma parte específica do sistema:

- **Equipamento**: Representa um equipamento com propriedades como nome, preço, número de série, data de fabricação e fabricante.
- **ChamadoManutencao**: Representa um chamado de manutenção, associado a um equipamento específico.
- **ServicoEquipamento**: Gerencia as operações de adicionar, editar, excluir e listar equipamentos.
- **ServicoChamado**: Gerencia as operações de adicionar, editar, excluir e listar chamados de manutenção.
- **Menu**: Interface do console para interação com o usuário, permitindo o acesso às funcionalidades de cadastro, edição, listagem e exclusão de equipamentos e chamados.

![Projeto](https://i.imgur.com/bA0PDXl.gif)
