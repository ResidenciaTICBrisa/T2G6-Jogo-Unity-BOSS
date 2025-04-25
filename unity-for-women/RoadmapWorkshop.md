# Objetivo

Familiarizar o público com o uso da Unity.
# Decisões

Gênero: jogo de plataforma
Asset: 
[Free Platform Game Assets - Bayat Games](https://assetstore.unity.com/packages/2d/environments/free-platform-game-assets-85838)
[Sound FX - Retro Pack](https://assetstore.unity.com/packages/audio/sound-fx/sound-fx-retro-pack-121743)

Repositório: https://github.com/Duerno/unity-for-women-at-unb
Instrutores:
matheus.faria@wildlifestudios.com
felipe.almeida@wildlifestudios.com

# Agenda do Workshop

## Apresentar a Unity (15 min)

- O que é uma engine?

- O que ela facilita no desenvolvimento?

- Qual a linguagem de programação?

- Qual a IDE? (Visual Code)

## Parte I: hands on (45 min)

- Conceito de objetos

- Criação de um "objeto empty" para o chão

- Conceito de componentes

- Adição de um Sprite renderer ao chão

- Adição de um Sprite ao chão

- O componente Transform

- Navegação na Unity (Hand, Move, Rotate, Scale tools)

- Movimentação de objetos na cena

- Uso da câmera e diferença entre ortográfica e perspectiva

- Criação de um player usando "objeto Sprite"

- Adição de rigid body ao player

- Adição de colliders

- Melhoria do collider do player: adição de Edge Radius

- Melhoria do rigid body: adição de freeze rotation para o player não girar

- Movimentação in-game

- Scripts

- O que é o componente script

- Criação de scripts

- Dinâmica de trabalhar com Unity + editor

- O que é o monobehaviour

- Manipulando o Transform para movimentação

- Usando variáveis públicas para controlar a velocidade

- Input horizontal

- Input Manager

- O módulo/sistema Input

- Implementando input horizontal

- Um pouco de física: usando o Time.deltaTime

- Manipulando o RigidBody2D

## Parte II: first gameplay (45 min)
- Adição de background

- Adição de uma plataforma + collider

- Conserto movimentação na lateral da plataforma

- Criação de Physics Material 2D para o chão

- Remoção da fricção do material

- Identificação de todos os colliders da cena (t:collider2d)

- Adição do material em todos os colliders do chão

- Adição de obstáculo (2 degraus)

- Adição de collider ao obstáculo maior

- Pulo

- Leitura do input "Jump"

- Manipulação do RigidBody2D para pular

- Pular apenas caso o player não esteja pulando ainda

- Usar collider para pular apenas caso o player esteja tocando o chão

- Fazer um Debug.Log da colisão

- Incluir checagem da normal com o UP

- Aumento da cena

- Manipulação da câmera: fazer a câmera seguir o player

- Fazer câmera seguir o player no eixo X

- Criar limites para a câmera seguir o player no início e fim da fase

- Criação de bordas para a fase

- Conceito de fim de jogo

- Criação de linha de chegada/fim de fase

- Adição de collider que triga o fim de jogo

- Mostrar o clássico "you win" no terminal usando o Debug.Log

- Reiniciar posição do player e eixo X da câmera

## Parte III: complete gameplay (45 min)
- Adição de um inimigo estático

- GameObject vazio

- Adiciona SpriteRenderer

- Colocar sprite do bloco com espinhos sem olho

- Colocar BoxCollider2D

- Criar script de movimentação de inimigo

- Primeira movimentação com a transform direto

- Fazer a direção inverter assim que chegar no ponto final (bug)

- Trocar para checagem de distância (bug)

- Adicionar multiplicador de distancia

- Criar vários inimigos

- Mostrar que é meio chato trocar a sprite de todo mundo

- Criar um prefab

- Reposicioná-los

- Trocar a sprite deles

- UI: canvas e texto

- Adicionar canvas

- Adicionar texto de HP

- Criar script para o player controlar o texto

- Linkar texto ao script no editor (mostrar que isso é possível)

- Atualizar número de acordo com as colisões com os inimigos

- Introduzir o conceito de tags

- Mostrar que o texto tem que ser atualizado a cada dano

- Troca de cenas

- Criar menu com botão de Play

- Colocar fundo

- Explicar ordem da hierarquia

- Importar fonte

- Mudar fonte do texto

- Criar script de troca de cena

- Colocar no botão

- Mostrar erro porque a cena não está no Build Settings

- Colocar cenas no Build Settings

- Mostrar Funcionando

- Implementação de fim de jogo com derrota

- Modificar script para mostrar um texto de vitória

- Mostrar botão para trocar de cena

- Usar mesma lógica no player health para derrota

- Parar de mover o player



## Parte IV: new assets and build (45 min)

- Animações

- Fazer sprite ser multiplo (mostrar que a opção não esta disponivel 
para single)

- Fazer slice da sprite (automatic) e dar apply

- Criar animação

- Mostrar que um animator é criado junto, mas deletar ele

- Criar outra animação

- Criar um animator

- Mostrar em ação

- Adicionar parametro no Animator

- Configurar transições

- Fazer o setup do player pra aceitar a animação


- Mostrar como setar parametros no código

- Fazer o player virar para ambas direções

- Criar gameobject filho para colocar a UI

- Espelhar o scale do x

- Som

- Explicar audio Listner da camera

- Adicionar Audio Source na camera

- Adicionar musica de fundo

- Adicionar audio Source no player

- Tocar musica com script na hora do pulo

- Explicar o Play On Awake

- Build

# Asset Store

- Importação/uso de assets

- Demais Fontes de Conteudo

- Conteudo/Assets:

- Assets Store

Mixamo

Fonts Google

Video:

Brackeys

Unity Learn

Infallible Code

Awsome Coders:

FreyaHolmer

Joyce (minionsart)

LotteMakesStuff

Lenna (kuraine)

Heidy Mota

Amora B (thief)

Livro Women In Gamming



# Desafios

Animação de Pulo

Física: adicionar rampas ao jogo

Salvar maior pontuação do jogador (quando ele fechar e entrar no jogo 
ele deve ver a maior pontuação)

Adicionar moedas para coletar

Adicionar som de andar

Adicionar mais inimigos com outros padrões

Quando você passa embaixo ele cai

Quando você cai no buraco você morre

Adicionar animação nos inimigos



