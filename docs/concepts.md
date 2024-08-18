# Conceitos e definições importantes

## Histórico de versão

|Data|Versão|Descrição|Autores|
|--|--|--|--|
|11/04/2024|0.1|Adicionando conceitos|Júlia Yoshida|
|16/04/2024|0.2|Adicionando conceito de NPC e tiles|Júlia Yoshida|
|18/08/2024|0.3|Adicionando conceito de game object, game design e level design|Júlia Yoshida|

<p style="text-indent: 50px;text-align: justify;"> Essa seção é dedicada a conceitos e definições importantes relacionados ao nosso projeto que serão utilizados por toda a documentação. </p>

## 1. Pixel Art

<p style="text-indent: 50px;text-align: justify;"> O pixel é a menor unidade de uma imagem na qual é possível aplicar cor, tendo formato quadrado. Pixel Art, por sua vez, consiste na criação de arte utilizando esses pixels visíveis. Surgiu junto aos primeiros consoles de videogame, tais como Atari e Super Nintendo, devido às limitações de resolução e armazenamento características daquela época. </p>

### 1.1 Por que usar pixel art?

<p style="text-indent: 50px;text-align: justify;"> A criação de jogos com Pixel Art é mais acessível do que com gráficos em 3D, devido à facilidade de manipulação dos detalhes e à menor demanda por definição. Além disso, a existência de softwares intuitivos e gratuitos, como o Unity, facilita a programação nesse estilo, sendo uma excelente opção para iniciantes no desenvolvimento de jogos. </p>

<p style="text-indent: 50px;text-align: justify;"> As possibilidades criativas com Pixel Art são vastas, permitindo uma personalização ampla e uma curva de aprendizado mais rápida. Isso possibilita a criação de cenários e personagens diversificados, com variedade na jogabilidade. </p>

<p style="text-indent: 50px;text-align: justify;"> Os jogos em Pixel Art tendem a ser mais leves devido à sua resolução menor, o que os torna ideais para dispositivos móveis. Além disso, a estética retrô da Pixel Art evoca nostalgia nos jogadores, pois muitos dos jogos clássicos, como Super Mario Bros., Chrono Trigger e Sonic, foram criados nesse estilo. </p>

## 3. Sprite

<p style="text-indent: 50px;text-align: justify;"> Sprite em um jogo é uma representação gráfica bidimensional de um personagem, objeto ou elemento do cenário. Sprites são essenciais para dar vida ao jogo, permitindo que os personagens realizem uma variedade de ações, como caminhar, correr, pular e muito mais. Para cada uma dessas ações, é necessário criar diferentes variações do sprite, representando cada movimento de forma detalhada. Imagine que você está construindo a movimentação de um personagem em seu jogo. Você precisaria desenhar cada frame de animação para cada movimento que o personagem realizará, como caminhar ou pular. Isso se assemelha ao processo de criação de uma animação tradicional, onde uma sequência de desenhos à mão é utilizada para criar movimento. </p>

## 4. Unity

<p style="text-indent: 50px;text-align: justify;"> O Unity é uma plataforma de criação e operação de conteúdo interativo 3D, sendo uma game engine que centraliza e simplifica o desenvolvimento de jogos eletrônicos. Assim, o Unity torna possível que os desenvolvedores otimizem tempo na produção de jogos por não precisarem densenvolver tudo do zero. O Unity oferece suporte para a linguagem de programçaõ C#, que é a que estamos utilizando no nosso projeto. </p>

<p style="text-indent: 50px;text-align: justify;"> O Unity fornece vários elementos que compõe um jogo, como: </p>

- Motor gráfico para renderização de gráficos 2D e 3D;
- Motor de física que simula interações entre objetos;
- Sistema de iluminação;
- Texturas;
- Animações;
- Sons;
- Programação de inteligência artificial;
- Simulação de partículas.

## 5. Tile, Tileset e Tilemap

<p style="text-indent: 50px;text-align: justify;"> Um tileset é a coleção de pequenas imagens ou texturas(tile) que representam diferentes partes do ambiente do jogo, como pisos, paredes, objetos, e assim por diante. Essas texturas são organizadas em uma única imagem, geralmente em uma grade, onde cada célula da grade é um "tile". Essa organização facilita o processo de design do jogo, pois permite que os desenvolvedores criem cenários complexos combinando esses tiles de forma modular. Então, um tileset fornece os elementos visuais necessários para construir os diferentes aspectos do mundo do jogo, enquanto o tilemap dita como esses elementos devem ser dispostos no espaço do jogo. </p>

## 6. NPC

<p style="text-indent: 50px;text-align: justify;">Os NPCs(Non-Player Characters), ou personagens não jogáveis, são como os habitantes virtuais que povoam os mundos dos jogos. Eles são todos aqueles que não estão sob o domínio direto do jogador, desde os figurantes que vagueiam pelas ruas até os personagens com um propósito mais substancial na narrativa. Embora muitos desses personagens sigam rotinas pré-estabelecidas, alguns podem responder às ações do jogador de maneiras diversas. Por exemplo, podem se defender se atacados ou oferecer tarefas e informações que influenciam diretamente a experiência do jogo. </p>

## 7. Cena
<p style="text-indent: 50px;text-align: justify;">As cenas são o local onde você trabalha com o conteúdo no Unity. Elas são ativos que contêm parte ou a totalidade de um jogo ou aplicação. Por exemplo, em um jogo simples, você pode construir tudo em uma única cena, enquanto que em um jogo mais complexo, pode ser necessário usar uma cena para cada nível, cada uma contendo seus próprios ambientes, personagens, obstáculos, decorações e interfaces. Você pode criar quantas cenas quiser em um projeto. Ao criar um novo projeto e abri-lo pela primeira vez, o Unity carrega uma cena de amostra contendo apenas uma Câmera e uma Luz.</p>

## 8. Game Object
<p style="text-indent: 50px;text-align: justify;"> A classe GameObject do Unity representa qualquer coisa que pode existir em uma Cena. GameObjects são os blocos de construção das cenas no Unity, funcionando como contêineres para componentes funcionais que determinam como o GameObject aparece e o que ele faz. Na programação, a classe GameObject oferece uma série de métodos que permitem trabalhar com esses objetos no código, como localizar, criar conexões, enviar mensagens entre GameObjects, adicionar ou remover componentes ligados ao GameObject e ajustar valores relacionados ao seu estado dentro da cena. </p>

## 9. Game Design
<p style="text-indent: 50px;text-align: justify;">Game design é o processo de criar a mecânica, estrutura e experiências interativas de um jogo. Envolve a definição das regras, objetivos, narrativa, personagens, níveis e interações do jogador com o ambiente. O game design combina elementos técnicos e criativos para proporcionar uma experiência divertida, desafiadora e envolvente ao jogador. O designer de jogos também pensa na progressão, nas recompensas e no equilíbrio entre dificuldade e jogabilidade, visando criar um jogo coeso e interessante.</p>

## 10. Level Design
<p style="text-indent: 50px;text-align: justify;">O level design é uma área do desenvolvimento de jogos que se concentra na criação dos ambientes onde o jogo ocorre, como fases, missões ou cenários. Esse processo envolve tanto aspectos técnicos quanto artísticos, pois é necessário construir esses ambientes digitais de forma que sejam funcionais e visualmente atraentes. O processo de criação de um nível começa com a fase conceitual, onde são feitos esboços e modelos físicos ou digitais do cenário. </p>
<p style="text-indent: 50px;text-align: justify;">O level design é uma subárea do game design que se concentra especificamente na criação dos ambientes ou níveis dentro do jogo, onde os jogadores irão interagir e enfrentar os desafios propostos. Podemos dizer que o game design é o planejamento macro do jogo como um todo, enquanto level design lida com o planejamento e criação dos espaços específicos onde o jogo acontece.</p>

## Referências

- [1] [O que é pixel art e qual é a sua utilização no mundo dos games?](https://blog.saibala.com.br/
o-que-e-pixel-art-e-qual-e-a-sua-utilizacao-no-universo-dos-games/)

- [2] [O que é um sprite e como ele funciona em jogos 2D?](https://www.alura.com.br/artigos/sprite-como-funciona-em-jogos-2d)

- [3] [O que é um desenvolvedor Unity e como se tornar um?](https://ebaconline.com.br/blog/o-que-e-um-desenvolvedor-unity-e-como-se-tornar-um)

- [4] [O que é tileset e tilemap no desenvolvimento de games?](https://www.domestika.org/pt/blog/6985-o-que-e-tileset-e-tilemap-no-desenvolvimento-de-games)

- [5] [O que é NPC?](https://canaltech.com.br/games/o-que-e-npc/)

- [6] [Unity - Manual: Scenes](https://docs.unity3d.com/Manual/CreatingScenes.html)

- [7] [Unity - Manual: Game Object](https://docs.unity3d.com/Manual/class-GameObject.html)

- [8] [What is Game Design? Everything you need to know](https://www.karagamedesign.com/post/what-is-game-design-guide)

- [9] [Level design](https://www.techopedia.com/definition/88/level-design)