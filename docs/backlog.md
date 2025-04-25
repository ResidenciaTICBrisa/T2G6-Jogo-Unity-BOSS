# Backlog do Produto

## Guia para Revisar Esta Documentação

Este documento descreve os **requisitos funcionais e não funcionais** para o **Diários de Sofia**, incluindo **mecânicas de exploração, sistemas de combate, progressão de personagem e recursos narrativos**. A estrutura segue uma divisão progressiva, começando pelo design de alto nível até histórias de usuário e funcionalidades específicas.

### **Como Usar Esta Documentação**

* **Requisitos Funcionais (RF-00)** – Recursos principais de jogabilidade e mecânicas.
* **Requisitos Não-Funcionais (RNF-00)** – Questões de usabilidade, desempenho e manutenção.
* **Temas (TM-00)** – Principais áreas de jogabilidade agrupadas por tópico.
* **Épicos (EP-00)** – Grandes unidades de funcionalidade dentro de cada tema.
* **Capacidades (C-00)** – Habilidades específicas do sistema necessárias para suportar funcionalidades.
* **Features (F-00)** – Elementos técnicos que compõem as capacidades.
* **User Stories (US-00)** – Interações do jogo sob a perspectiva do jogador.
* **Backlog** – O plano estruturado para desenvolvimento.

Nada neste documento é final; por favor, sugira correções ou melhorias.

***

## **1. Requisitos Funcionais**

| #     | Descrição                                                                 |
| ----- | ------------------------------------------------------------------------- |
| RF-01 | Movimento do personagem, ataque e defesa                                  |
| RF-02 | Sistema de combate dinâmico                                               |
| RF-03 | Progressão de XP e nível do jogador                                       |
| RF-04 | Sistema de inventário e atributos baseados em itens                       |
| RF-05 | Progressão do jogo por fases e aumento de dificuldade                     |
| RF-06 | Menu interativo baseado em mapa                                           |
| RF-07 | Coleta de diários narrativos                                              |
| RF-08 | Interação com NPCs                                                        |
| RF-09 | Nível inicial em um cenário de biblioteca                                 |
| RF-10 | Customização do personagem do jogador                                     |
| RF-11 | Sistema de loja                                                           |

***

## **2. Requisitos Não Funcionais**

| #      | Tipo        | Descrição                                                  |
| ------ | ----------- | ---------------------------------------------------------- |
| RNF-01 | Usabilidade | Estética de Pixel Art / 8-bit para apelo nostálgico         |
| RNF-02 | Disponibilidade | O jogo deve funcionar completamente offline             |
| RNF-03 | Desempenho  | Os níveis do jogo devem carregar em menos de 2 segundos     |
| RNF-04 | Manutenibilidade | Arquitetura modular e limpa no Unity                   |

***

## **3. Temas**

| #     | Tema                     | Descrição                                                   |
| ----- | ------------------------ | ----------------------------------------------------------- |
| TM-01 | Mundo do Jogo & Exploração | Foco no mapa, ambiente e interação                         |
| TM-02 | Combate & Mecânicas       | Sistema de batalha, habilidades do personagem e evolução   |
| TM-03 | Sistemas de Progressão    | XP, níveis, estatísticas de itens e customização de personagem |
| TM-04 | Experiência Narrativa     | Contação de histórias, coleta de diários e integração cultural |

***

## **4. Épicos**

| #     | Épico                     | Descrição                                                           |
| ----- | ------------------------- | ------------------------------------------------------------------- |
| EP-01 | Exploração & Navegação    | Permitir movimento entre fases, menus e locais no mapa             |
| EP-02 | Sistema de Combate        | Combate em tempo real, com mecânicas baseadas em estatísticas e habilidades |
| EP-03 | Progressão & Customização | XP, níveis e itens que modificam estatísticas do personagem         |
| EP-04 | Narrativa & Lore          | Histórias colecionáveis e temas culturais embutidos no mundo        |

***

## **5. Capacidades**

| #    | Capacidade                 | Descrição                                                             |
| ---- | -------------------------- | --------------------------------------------------------------------- |
| C-01 | Sistema de Movimento       | Permitir que o jogador se mova livremente                            |
| C-02 | Motor de Combate           | Gerenciar ataques, lógica de inimigos e detecção de acertos          |
| C-03 | XP e Progressão de Nível   | Ganhar XP e aumentar atributos ao subir de nível                     |
| C-04 | Gerenciamento de Inventário | Itens que impactam a jogabilidade ao melhorar estatísticas           |
| C-05 | Rastreamento de Progresso Narrativo | Coletar e armazenar entradas de diários                          |
| C-06 | Interação com NPCs         | Permitir diálogo e ativação de missões através de NPCs               |
| C-07 | Menu Interativo de Mapa    | Navegar pelo menu como um mapa físico no jogo                        |

***

## **6. Funcionalidades**

| #    | Funcionalidade              | Descrição                                                          |
| ---- | --------------------------- | ------------------------------------------------------------------ |
| F-01 | Sistema de controle do personagem | Suporte para movimento suave e entrada básica de combate         |
| F-02 | Animação & feedback de combate | Mecânicas visuais de combate em tempo real                       |
| F-03 | Sistema de XP               | Sistema para ganhar XP e subir de nível                           |
| F-04 | Lógica de progressão de atributos | Modificar atributos com base no nível/efeitos de itens          |
| F-05 | Interface de loja e coleta de itens | Loja que vende itens que alteram estatísticas                  |
| F-06 | Gerenciamento de fases      | Manipulação de cenas e ajuste de dificuldade entre fases          |
| F-07 | Cena do nível da biblioteca | Primeiro nível do jogo em uma biblioteca                         |
| F-08 | Menu de navegação por mapa  | Navegação na interface através de um mapa visual                 |
| F-09 | Sistema de diálogo com NPCs | Ativação básica de diálogos e interações                         |
| F-10 | Sistema de inventário de diários | Visualização e rastreamento de colecionáveis de história        |

***

## **7. Histórias de Usuário**

| #     | Descrição                                                                                   |
| ----- | ------------------------------------------------------------------------------------------- |
| US-01 | Como jogador, quero explorar diferentes fases para experimentar o mundo completo do jogo.   |
| US-02 | Como jogador, quero lutar contra inimigos dinamicamente para me sentir imerso na ação.      |
| US-03 | Como jogador, quero ganhar XP e subir de nível para sentir progressão.                      |
| US-04 | Como jogador, quero customizar meu personagem para me sentir único.                         |
| US-05 | Como jogador, quero coletar diários para entender o enredo do jogo.                         |
| US-06 | Como jogador, quero comprar itens que melhorem meus atributos.                              |
| US-07 | Como jogador, quero interagir com NPCs para receber dicas de história ou jogabilidade.      |
| US-08 | Como jogador, quero usar um menu em estilo de mapa para navegar entre áreas.                |

***

## **8. Backlog**

| Tema      | Épico              | Capacidades               | Funcionalidades            | História de Usuário | Descrição                                                  |
| --------- | ------------------ | ------------------------- | -------------------------- | ------------------- | ---------------------------------------------------------- |
| TM-01     | EP-01              | C-01, C-07                | F-01, F-06, F-08, F-07     | US-01, US-08        | Movimento, transições de nível e navegação baseada em mapa |
| TM-02     | EP-02              | C-02                      | F-02                       | US-02               | Sistema de combate em tempo real com interações de inimigos |
| TM-03     | EP-03              | C-03, C-04, C-06          | F-03, F-04, F-05           | US-03, US-04, US-06, US-07 | XP, níveis, coleta de itens e interação com personagens    |
| TM-04     | EP-04              | C-05                      | F-10                       | US-05               | Coleta e visualização de entradas de diários para narrativa |

***

## Histórico de Revisões

| Data       | Versão | Alterações                              | Autores                                                   |
| ---------- | -------| --------------------------------------- | --------------------------------------------------------- |
| 2025-04-25 | 0.1    | Mapeamento inicial do backlog e estrutura | [Mateus Vieira](https://github.com/matix0)               |

[Voltar para a Página Principal](../../index.md)
