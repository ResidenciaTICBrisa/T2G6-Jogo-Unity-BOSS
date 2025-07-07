# Documentação dos Scripts - Diários de Sofia

Esta documentação descreve o funcionamento de cada script C# do projeto Unity "Diários de Sofia".

## 📁 Estrutura dos Scripts

O projeto está organizado da seguinte forma:
```
Assets/Scripts/
├── Player/
│   └── PlayerMoveScript.cs
├── BookScripts.cs
├── Boy2Script.cs
├── DiaryScript.cs
├── EnemyMovement.cs
├── ExitButtonScript.cs
├── FlipPage.cs
├── Loading.cs
├── MenuScripts.cs
├── NPCScript.cs
├── OldManScript.cs
├── OldWomanScript.cs
├── PlayerAttackScript.cs
├── PlayerAwareness.cs
├── RedMovement.cs
├── SalvarPosic.cs
├── SceneTransition.cs
├── SignScript.cs
├── SpawnPoints.cs
└── StoreScripts.cs
```

## 📋 Índice
- [🎮 Scripts do Jogador](#-scripts-do-jogador)
- [🤖 Scripts de NPCs](#-scripts-de-npcs)
- [👹 Scripts de Inimigos](#-scripts-de-inimigos)
- [⚔️ Scripts de Combate](#️-scripts-de-combate)
- [🖥️ Scripts de Interface](#️-scripts-de-interface)
- [🔧 Scripts de Sistema](#-scripts-de-sistema)
- [📚 Scripts de Menu e Navegação](#-scripts-de-menu-e-navegação)

---

## 🎮 Scripts do Jogador

### PlayerMoveScript.cs (PlayerController)
**Localização:** `Assets/Scripts/Player/PlayerMoveScript.cs`  
**Classe Principal:** `PlayerController`

**Descrição:** Script principal que controla todo o comportamento do jogador, incluindo movimento, combate e sistema de vida.

**Funcionalidades:**
- **🕹️ Sistema de Movimento:** Controle via joystick virtual com movimentação suave em 2D
- **⚔️ Sistema de Combate:** Ataques direcionais com animações específicas para cada direção
- **❤️ Sistema de Vida:** Gerenciamento de HP com 4 estados visuais (100, 66, 33, 0)
- **🎭 Controle de Animações:** Sincronização entre movimento e animações do personagem
- **🔄 Persistência de Estado:** Mantém estado do jogador entre cenas

**Componentes Requeridos:**
- `Joystick` para controle de movimento
- `Animator` para animações
- `Rigidbody2D` para física
- `Button` para ataques (UI)

**Variáveis Principais:**
```csharp
[SerializeField] private Joystick movementJoystick;     // Controle de movimento
[SerializeField] private float playerSpeed = 5f;       // Velocidade do jogador  
[SerializeField] private int maxHealth = 100;          // Vida máxima
[SerializeField] private float attackDuration = 0.5f;  // Duração do ataque
```

**Métodos Importantes:**
- `HandleMovement()`: Processa input do joystick e atualiza posição
- `HandleCombat()`: Gerencia sistema de ataques direcionais
- `TakeDamage(int damage)`: Reduz HP e atualiza interface visual
- `UpdateAnimations()`: Sincroniza parâmetros de animação
- `SavePlayerState()`: Salva estado atual do jogador

---

## 🤖 Scripts de NPCs

### NPCScript.cs
**Localização:** `Assets/Scripts/NPCScript.cs`  
**Tipo:** Classe base abstrata para todos os NPCs

**Descrição:** Classe base que implementa o sistema de diálogo comum a todos os NPCs do jogo.

**Funcionalidades:**
- **💬 Sistema de Diálogo:** Interface completa com efeito de digitação
- **📸 Exibição de Retratos:** Mostra foto do NPC durante conversas
- **🔊 Áudio Integrado:** Reprodução de sons durante diálogos
- **🎯 Detecção de Proximidade:** Detecta quando jogador está próximo
- **⌨️ Controles de Navegação:** Avançar, pular e fechar diálogos

**Componentes de UI:**
```csharp
[SerializeField] public GameObject dialoguePanel;    // Painel principal do diálogo
[SerializeField] public Text dialogueText;          // Texto da conversa
[SerializeField] public Text nameText;              // Nome do NPC
[SerializeField] public GameObject photoPanel;      // Painel da foto
```

**Dados do NPC:**
```csharp
[SerializeField] public string[] dialogues;         // Array de falas
[SerializeField] public string npcName;             // Nome do personagem
[SerializeField] public Sprite photo;               // Retrato do NPC
[SerializeField] public float wordSpeed = 0.05f;    // Velocidade de digitação
```

**Métodos Virtuais (podem ser sobrescritos):**
- `HandleDialogueInput()`: Gerencia input do jogador para diálogos
- `StartDialogue()`: Inicia conversa com o NPC
- `DisplayNextLine()`: Avança para próxima linha
- `EndDialogue()`: Finaliza conversa

### Boy2Script.cs
**Localização:** `Assets/Scripts/Boy2Script.cs`  
**Herda de:** `NPCScript`

**Descrição:** NPC jovem com comportamento de patrulhamento aleatório.

**Funcionalidades Adicionais:**
- **🚶 Patrulhamento Inteligente:** Movimento aleatório dentro de área delimitada
- **⏸️ Pausa durante Diálogo:** Interrompe movimento quando jogador interage
- **🎲 Comportamento Variado:** Alterna entre caminhar e pausar com tempos aleatórios
- **🧭 Navegação 4-Direções:** Move-se em direções cardinais

**Configuração de Patrulhamento:**
```csharp
[SerializeField] private float leftPatrolX;     // Limite esquerdo
[SerializeField] private float rightPatrolX;    // Limite direito  
[SerializeField] private float upPatrolY;       // Limite superior
[SerializeField] private float bottomPatrolY;   // Limite inferior
[SerializeField] private float minWalkTime;     // Tempo mínimo de caminhada
[SerializeField] private float maxWalkTime;     // Tempo máximo de caminhada
```

### OldManScript.cs
**Localização:** `Assets/Scripts/OldManScript.cs`  
**Herda de:** `NPCScript`

**Descrição:** NPC idoso que se move entre dois pontos fixos predefinidos.

**Funcionalidades Específicas:**
- **🔄 Movimento Pendular:** Vai e volta entre dois pontos (A ↔ B)
- **⏳ Pausa nos Destinos:** Para por alguns segundos ao chegar em cada ponto
- **🛑 Parada para Diálogo:** Congela movimento durante interações

**Configuração de Movimento:**
```csharp
[SerializeField] private GameObject pointA;     // Primeiro ponto de destino
[SerializeField] private GameObject pointB;     // Segundo ponto de destino  
[SerializeField] private float speed;           // Velocidade de movimento
[SerializeField] private float pauseTime;       // Tempo de pausa nos pontos
```

### OldWomanScript.cs
**Localização:** `Assets/Scripts/OldWomanScript.cs`  
**Herda de:** `NPCScript`

**Descrição:** NPC estático que oferece apenas funcionalidades básicas de diálogo.

**Características:**
- **🏠 Comportamento Estático:** Permanece em posição fixa
- **💬 Diálogo Simples:** Utiliza apenas sistema base de conversação
- **🎯 Foco na Narrativa:** Ideal para NPCs informativos ou storytelling

---

## 👹 Scripts de Inimigos

### EnemyMovement.cs (EnemyController)
**Localização:** `Assets/Scripts/EnemyMovement.cs`  
**Classe Principal:** `EnemyController`

**Descrição:** Controlador principal de IA para inimigos com sistema completo de combate e saúde.

**Funcionalidades:**
- **🎯 Sistema de Detecção:** Detecta jogador dentro do alcance
- **🏃 Perseguição Inteligente:** Move-se em direção ao jogador detectado
- **⚔️ Sistema de Combate:** Ataca quando próximo suficiente do alvo
- **❤️ Gerenciamento de Vida:** Sistema de HP com estados visuais
- **💀 Sistema de Morte:** Animações de morte e destruição do objeto

**Configuração de Combate:**
```csharp
[SerializeField] private float movementSpeed = 3f;    // Velocidade de movimento
[SerializeField] private float attackDuration = 3f;   // Duração do ataque
[SerializeField] private float attackRange = 2f;      // Alcance de ataque
[SerializeField] private int maxHealth = 100;         // Vida máxima
```

**Estados de Saúde:**
- **100 HP:** Estado saudável (verde)
- **66 HP:** Estado ferido (amarelo)  
- **33 HP:** Estado crítico (vermelho)
- **0 HP:** Morte (destruição após 2s)

### RedMovement.cs
**Localização:** `Assets/Scripts/RedMovement.cs`

**Descrição:** Controlador especializado para inimigo tipo "Robot Vermelho" com mecânicas únicas.

**Funcionalidades Especiais:**
- **🤖 Comportamento Específico:** Adaptado para o robot vermelho
- **⚔️ Sistema de Ataque Único:** Mecânicas diferentes do inimigo padrão
- **🎨 Animações Customizadas:** Conjunto específico de animações
- **🔧 Configuração Independente:** Não herda do EnemyController padrão

---

## ⚔️ Scripts de Combate

### PlayerAttackScript.cs
**Localização:** `Assets/Scripts/PlayerAttackScript.cs`

**Descrição:** Gerencia detecção de colisões e aplicação de dano dos ataques do jogador.

**Funcionalidades:**
- **💥 Detecção de Colisão:** Detecta quando ataques atingem inimigos
- **⚡ Sistema de Dano:** Aplica dano baseado no tipo de inimigo
- **🌪️ Efeito Knockback:** Empurra inimigos para trás ao serem atingidos
- **⏱️ Cooldown de Ataque:** Previne spam e garante gameplay balanceado

**Métodos de Colisão:**
```csharp
OnTriggerEnter2D()    // Detecta início do ataque
OnTriggerStay2D()     // Aplica força contínua durante ataque  
OnTriggerExit2D()     // Remove efeitos ao fim do ataque
```

### PlayerAwareness.cs
**Localização:** `Assets/Scripts/PlayerAwareness.cs`

**Descrição:** Sistema de detecção e consciência espacial para inimigos localizarem o jogador.

**Funcionalidades:**
- **📡 Detecção de Distância:** Calcula distância em tempo real entre inimigo e jogador
- **🧭 Direcionamento:** Fornece vetor normalizado apontando para o jogador
- **🚨 Estado de Alerta:** Flag booleana indicando se jogador está no alcance
- **⚙️ Configuração Flexível:** Distância de detecção ajustável por inimigo

**Propriedades Públicas:**
```csharp
public bool AwareOfPlayer { get; }           // Jogador está no alcance?
public Vector2 DirectionToPlayer { get; }    // Direção para o jogador
```

---

## 🖥️ Scripts de Interface

### SignScript.cs
**Localização:** `Assets/Scripts/SignScript.cs`

**Descrição:** Controla placas e sinais informativos interativos espalhados pelo mundo do jogo.

**Funcionalidades:**
- **📝 Exibição de Texto:** Mostra informações quando jogador se aproxima
- **🔤 Ajuste Automático de Fonte:** Redimensiona texto baseado no comprimento
- **⌨️ Interação com Tecla E:** Toggle de visibilidade via input do jogador
- **🎯 Detecção de Proximidade:** Ativa/desativa baseado na distância do jogador

### FlipPage.cs
**Localização:** `Assets/Scripts/FlipPage.cs`

**Descrição:** Sistema de navegação para livros e diários com múltiplas páginas.

**Funcionalidades:**
- **📖 Navegação de Páginas:** Botões para avançar/retroceder
- **🚫 Controle de Limites:** Desabilita botões nos extremos do livro
- **🎬 Animações de Transição:** Efeitos visuais ao virar páginas
- **❌ Fechamento de Livro:** Opção para sair da visualização

**Configuração:**
```csharp
[SerializeField] private int maxIndex;           // Número total de páginas
[SerializeField] private Button forwardButton;   // Botão próxima página
[SerializeField] private Button backButton;      // Botão página anterior
```

### ExitButtonScript.cs
**Localização:** `Assets/Scripts/ExitButtonScript.cs`

**Descrição:** Script simples para botão de saída que retorna ao menu principal.

**Funcionalidade:**
- **🏠 Retorno ao Menu:** Carrega cena do menu principal do jogo

---

## 🔧 Scripts de Sistema

### SpawnPoints.cs
**Localização:** `Assets/Scripts/SpawnPoints.cs`

**Descrição:** Sistema central de gerenciamento de pontos de spawn e posicionamento do jogador entre cenas.

**Funcionalidades:**
- **🗺️ Mapeamento de Posições:** Define coordenadas de spawn para cada local
- **💾 Persistência de Estado:** Mantém posição do jogador entre mudanças de cena
- **🎵 Controle de Áudio:** Gerencia música de fundo baseada na localização
- **🎨 Gerenciamento de UI:** Controla interface contextual por cena

**Estruturas de Dados:**
```csharp
public struct cityMap {
    public Vector3 X { get; set; }
}

public enum currentPosition { 
    none, library, house, shop, houseBed, grove 
}
```

### SalvarPosic.cs
**Localização:** `Assets/Scripts/SalvarPosic.cs`

**Descrição:** Sistema de salvamento automático da posição do jogador.

**Funcionalidades:**
- **💾 Salvamento Automático:** Salva posição ao mudar de cena
- **📂 PlayerPrefs Integration:** Utiliza sistema de preferências do Unity
- **🔄 Carregamento Automático:** Restaura posição salva ao entrar em nova cena

### SceneTransition.cs
**Localização:** `Assets/Scripts/SceneTransition.cs`

**Descrição:** Gerencia transições suaves e elegantes entre diferentes cenas do jogo.

**Funcionalidades:**
- **❓ Interface de Confirmação:** Pergunta ao jogador antes de mudar cena
- **🌅 Efeito Fade:** Animação de fade out/in durante transição
- **❌ Cancelamento:** Permite abortar mudança de cena
- **⏳ Transição Assíncrona:** Carregamento não-bloqueante de cenas

### Loading.cs
**Localização:** `Assets/Scripts/Loading.cs`

**Descrição:** Sistema de carregamento de cenas com interação direta do jogador.

**Funcionalidades:**
- **⌨️ Interação com E:** Carrega nova cena ao pressionar tecla
- **💾 Salvamento Pré-Carregamento:** Salva estado antes da transição
- **💬 Feedback Visual:** Exibe prompt de interação na tela

### DiaryScript.cs
**Localização:** `Assets/Scripts/DiaryScript.cs`

**Descrição:** Controla sistema de abertura e visualização de diários do jogo.

**Funcionalidades:**
- **📚 Carregamento Aditivo:** Carrega cena do diário sobre a atual
- **🏷️ Identificação de Diários:** Ativa diário correto baseado no nome
- **📍 Detecção de Proximidade:** Detecta quando jogador pode abrir diário
- **🔄 Gerenciamento de Estado:** Controla exibição/ocultação de diários

---

## 📚 Scripts de Menu e Navegação

### MenuScripts.cs
**Localização:** `Assets/Scripts/MenuScripts.cs`

**Descrição:** Controla todas as funcionalidades do menu principal do jogo.

**Funcionalidades:**
- **▶️ Iniciar Jogo:** Carrega primeira cena (SofiaHouse)
- **❌ Sair do Jogo:** Fecha a aplicação
- **⚙️ Configurações:** (Se implementado) Acesso a opções do jogo

### StoreScripts.cs
**Localização:** `Assets/Scripts/StoreScripts.cs`

**Descrição:** Gerencia navegação para a cena da loja no jogo.

**Funcionalidades:**
- **🏪 Acesso à Loja:** Transição para cena "Store"
- **🛒 Preparação de Estado:** Configura contexto antes de entrar na loja

### BookScripts.cs
**Localização:** `Assets/Scripts/BookScripts.cs`

**Descrição:** Controla interações sonoras com livros espalhados pelo mundo.

**Funcionalidades:**
- **🔊 Reprodução de Som:** Toca áudio quando livro é interagido
- **🐛 Sistema de Debug:** Verifica estado de reprodução de áudio
- **📖 Feedback Auditivo:** Fornece resposta sonora à interação do jogador

---

## 🏗️ Arquitetura e Padrões de Design

### 📐 Estrutura de Herança
```
MonoBehaviour (Unity Base Class)
├── 🎮 PlayerController (Controle do jogador)
├── 🤖 NPCScript (Classe base para NPCs)
│   ├── 🚶 Boy2Script (NPC com patrulhamento)
│   ├── 👴 OldManScript (NPC com movimento linear)
│   └── 👵 OldWomanScript (NPC estático)
├── 👹 EnemyController (IA de inimigos)
├── 🤖 RedMovement (Inimigo especial)
└── 🔧 [Scripts de Sistema Independentes]
```

### 🎯 Sistemas Principais

1. **💬 Sistema de Diálogo**
   - Centralizado em `NPCScript` com herança
   - Efeito de digitação e navegação
   - Integração com áudio e imagens

2. **🕹️ Sistema de Movimento**  
   - Jogador: `PlayerController` com joystick virtual
   - Inimigos: `EnemyController` com IA de perseguição
   - NPCs: Patrulhamento e movimento linear

3. **⚔️ Sistema de Combate**
   - Detecção: `PlayerAttackScript` e `PlayerAwareness`
   - Dano e knockback integrados
   - Estados de vida com feedback visual

4. **🌍 Sistema de Cenas**
   - Transições: `SceneTransition` e `Loading`
   - Persistência: `SpawnPoints` e `SalvarPosic`
   - Estado global mantido entre cenas

5. **🖥️ Sistema de Interface**
   - Elementos interativos: `SignScript`, `FlipPage`
   - Navegação: `MenuScripts`, `ExitButtonScript`
   - Feedback visual consistente

### 🛠️ Padrões de Design Utilizados

- **🔗 Component Pattern:** Scripts como componentes Unity modulares
- **👨‍👩‍👧‍👦 Inheritance Pattern:** NPCScript como classe base reutilizável  
- **👁️ Observer Pattern:** Eventos de trigger para detecção de colisões
- **🎭 State Pattern:** Estados de movimento, ataque e vida
- **🏭 Singleton Pattern:** Gerenciadores de sistema únicos (implícito)

### 🔌 Dependências Unity

- **🎮 UnityEngine:** Funcionalidades core do Unity
- **🖥️ UnityEngine.UI:** Sistema de interface gráfica
- **🌍 UnityEngine.SceneManagement:** Gerenciamento de cenas
- **⏱️ System.Collections:** Para Coroutines e estruturas de dados
- **🎵 UnityEngine.Audio:** Sistema de áudio integrado

### 📊 Métricas do Projeto

- **📁 Total de Scripts:** 20 arquivos C#
- **🎯 Classes Principais:** 7 controladores core
- **👥 NPCs Implementados:** 3 tipos diferentes
- **👹 Sistemas de IA:** 2 tipos de inimigos
- **🖥️ Componentes UI:** 5 scripts de interface
- **🔧 Scripts de Sistema:** 8 utilitários

### 🎓 Conceitos de Game Development

**🎮 Gameplay Programming:**
- Input handling com joystick virtual
- State machines para personagens
- Physics integration com Rigidbody2D

**🎨 UI/UX Programming:**
- Sistema de diálogo com typewriter effect
- Responsive interface elements
- Scene transition animations

**🤖 AI Programming:**
- Pathfinding básico para inimigos
- Behavior trees para NPCs
- Player awareness systems

**🔧 Systems Programming:**
- Save/load system com PlayerPrefs
- Scene management e persistence
- Audio management integrado

---

## 📚 Guia de Contribuição para Scripts

### 🆕 Adicionando Novos Scripts

1. **📁 Organização:** Coloque scripts na pasta apropriada
2. **📝 Nomenclatura:** Use nomes descritivos em PascalCase
3. **📖 Documentação:** Adicione XML comments nos métodos públicos
4. **🔗 Herança:** Use classes base quando apropriado (ex: NPCScript)

### ✏️ Modificando Scripts Existentes

1. **⚠️ Backup:** Sempre teste mudanças em branch separada
2. **🔍 Compatibilidade:** Verifique impacto em outros sistemas
3. **📝 Changelog:** Documente alterações significativas
4. **🧪 Testes:** Teste todas as funcionalidades afetadas

### 🎯 Boas Práticas

- **🔒 Encapsulamento:** Use [SerializeField] ao invés de public
- **⚡ Performance:** Evite chamadas custosas em Update()
- **🏷️ Organização:** Agrupe variáveis com [Header("Nome")]
- **🚫 Null Checks:** Sempre verifique referências antes de usar
- **📱 Mobile-Friendly:** Considere performance em dispositivos móveis

---

*Documentação atualizada em {{date}} - Projeto Diários de Sofia*
