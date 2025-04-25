# Conceitos e definições importantes

## Histórico de versão

| Data       | Versão | Descrição             | Autores                                                                 |
|------------|--------|-----------------------|-------------------------------------------------------------------------|
| 22/04/2025 | 0.1    | Adicionando conceitos | [Júlio Cesar](https://github.com/Julio1099), [Maciel Júnior](https://github.com/macieljuniormax) |

---

<p style="text-indent: 50px;text-align: justify;"> Essa seção é dedicada a conceitos e definições importantes relacionados ao nosso projeto que serão utilizados por toda a documentação. </p>

## 1. Unity
**Definição**:  
O Unity é uma poderosa ferramenta de criação de jogos que permite desenvolver experiências interativas em 2D e 3D. Ele oferece muitos recursos prontos, como sistemas de iluminação, física, animações e inteligência artificial, além de usar a linguagem C#.

**Aplicação**:  
Facilita o processo de desenvolvimento, permitindo que os programadores se concentrem mais na criação do conteúdo e menos na construção de recursos do zero.



## 2. Game Design
**Definição**:  
O design de jogos é o processo criativo e técnico de definir como um jogo será jogado. Ele abrange desde as regras, os objetivos e a progressão até a história, os personagens e a forma como o jogador interage com o universo do jogo.

**Aplicação**:  
Cria uma experiência envolvente para o jogador, equilibrando a diversão, desafio e fluidez do jogo, além de garantir que a jogabilidade seja agradável e intuitiva.



## 3. Sprite
**Definição**:  
Sprites são imagens em 2D usadas para representar personagens, objetos ou partes do cenário em um jogo. Cada ação de um personagem – como andar, correr ou atacar – é feita com diferentes quadros de animação, criando a sensação de movimento.

**Aplicação**:  
Usado para dar vida aos personagens e objetos do jogo, criando uma animação fluida para representar as ações de um personagem.



## 4. Cena
**Definição**:  
Dentro do Unity, uma cena representa uma parte do jogo, como uma fase ou tela específica. É nela que o desenvolvedor monta os elementos visuais e interativos do jogo, como cenários, personagens e objetos.

**Aplicação**:  
Permite dividir o jogo em seções ou fases distintas, facilitando a organização e o desenvolvimento do jogo, além de permitir a criação de diferentes ambientes e estágios.



## 5. NPC (Personagem Não Jogável)
**Definição**:  
NPCs são os personagens dentro do jogo que não são controlados por jogadores. Eles podem ter diversos papéis, como dar missões, vender itens ou interagir com o jogador de forma dinâmica.

**Aplicação**:  
São essenciais para enriquecer a narrativa e a interação no jogo, permitindo que o jogador tenha objetivos, diálogos e experiências que não dependem apenas de outros jogadores.



## 6. Game Object
**Definição**:  
No Unity, qualquer item que exista dentro da cena é um GameObject. Ele pode ter componentes como imagens, colisores, scripts e sons.

**Aplicação**:  
Os GameObjects formam a base de qualquer elemento do jogo, e sua flexibilidade permite a criação de quase qualquer tipo de item ou ação no jogo, como inimigos, itens e elementos do cenário.



## 7. Pixel Art
**Definição**:  
Pixel Art é uma técnica de criação de arte visual que usa blocos quadrados (pixels) visíveis para formar imagens. Foi amplamente usada em jogos antigos devido às limitações técnicas dos gráficos, mas hoje é valorizada pelo seu estilo nostálgico.

**Aplicação**:  
É ideal para jogos indie e plataformas móveis, pois exige menos recursos e pode ser criada de maneira acessível, especialmente para desenvolvedores iniciantes.



## 8. Level Design
**Definição**:  
O design de níveis cuida da criação dos ambientes e fases do jogo. Ele envolve a definição de obstáculos, estrutura e distribuição dos elementos do cenário.

**Aplicação**:  
Cria um ambiente onde o jogador interage, sendo responsável por guiar o jogador pela experiência do jogo, equilibrando a dificuldade e garantindo uma jogabilidade divertida.



## 9. Tile, Tileset e Tilemap
**Definição**:  
Um tile é uma pequena peça gráfica usada para construir mapas e ambientes. O tileset é o conjunto dessas peças, e o tilemap é a disposição delas no mundo do jogo.

**Aplicação**:  
Essa técnica permite criar cenários de forma modular e eficiente, facilitando a criação de grandes ambientes e reduzindo o tempo de desenvolvimento.



## 10. Collider
**Definição**:  
Componente que define a área física de um GameObject, usada para detectar colisões com outros objetos. Pode ser de diferentes formas: caixa (BoxCollider2D), círculo (CircleCollider2D), etc.

**Aplicação**:  
Permite que o personagem colida com paredes, pegue itens, interaja com NPCs, entre outras interações físicas no jogo.



## 11. Rigidbody (Rigidbody2D)
**Definição**:  
Componente que aplica física ao GameObject. Controla velocidade, gravidade, massa e permite interações físicas realistas, como pular ou cair.

**Aplicação**:  
Se o jogador ou um inimigo precisa se mover com física (pular, cair, ser empurrado), é necessário adicionar um Rigidbody2D ao GameObject.



## 12. Animações (Animator / Animation)
**Definição**:  
Sistema que permite trocar sprites em sequência para simular movimento (ex: andar, atacar, pular).

**Aplicação**:  
O Unity usa um componente chamado Animator, junto de Animation Clips, para controlar quando e como as animações acontecem com base em parâmetros (ex: está correndo, está no chão, etc.).



## 13. Prefabs
**Definição**:  
Modelo reutilizável de um GameObject. Um Prefab é como um molde que pode ser instanciado várias vezes no jogo com o mesmo comportamento.

**Aplicação**:  
Útil para criar múltiplos inimigos, itens ou NPCs com as mesmas características. Ao editar o prefab, todos os clones instanciados são automaticamente atualizados.



## 14. HUD (Heads-Up Display)
**Definição**:  
Elementos gráficos da interface que ficam na tela mostrando informações importantes ao jogador, como vida, pontuação, tempo, inventário, etc.

**Aplicação**:  
Usado para manter o jogador informado sobre seu progresso no jogo, criando uma interface visual que pode ser atualizada por scripts durante o jogo.



## 15. Interação
**Definição**:  
É a forma como o jogador se comunica com o mundo do jogo. Pode incluir falar com NPCs, pegar itens, abrir portas, entre outras ações.

**Aplicação**:  
Normalmente envolve detectar colisões e interações com objetos ou NPCs. Scripts são usados para executar ações como mostrar um diálogo ou iniciar uma missão quando o jogador interage com algo.



## 16. ScriptableObject
**Definição**:  
Tipo especial de asset no Unity usado para armazenar dados reutilizáveis e organizados, separados da lógica do jogo.

**Aplicação**:  
Ideal para guardar informações como estatísticas de inimigos, itens, feitiços, ou qualquer dado que precise ser reaproveitado entre objetos diferentes, sem a necessidade de duplicar informações.

---

## Referências gerais
1. [Unity - O que é e como funciona?](https://www.alura.com.br/artigos/o-que-e-unity)
2. [Game Design - Tudo o que você precisa saber](https://www.cursouniversitario.com.br/o-que-e-game-design/)
3. [O que é Sprite e como usá-lo nos seus jogos](https://www.gamasutra.com/blogs/joseignacio/20180706/318401/O_que_e_sprite_e_como_usalo_nos_seus_jogos.php)
4. [Unity - Manual: Scenes](https://docs.unity3d.com/Manual/CreatingScenes.html)
5. [O que é NPC?](https://canaltech.com.br/games/o-que-e-npc/)
6. [Unity - Manual: Game Object](https://docs.unity3d.com/Manual/class-GameObject.html)
7. [O que é pixel art e qual é a sua utilização no mundo dos games?](https://blog.saibala.com.br/o-que-e-pixel-art-e-qual-e-a-sua-utilizacao-no-universo-dos-games/)
8. [Level Design: O que é e como aplicar?](https://www.thedesigninspiration.com/articles/level-design-o-que-e-como-aplicar/)
9. [O que são tileset e tilemap no desenvolvimento de jogos](https://www.domestika.org/pt/blog/6985-o-que-e-tileset-e-tilemap-no-desenvolvimento-de-games)
10. [Unity - Manual: Colliders](https://docs.unity3d.com/Manual/Colliders.html)
11. [Unity - Manual: Rigidbody](https://docs.unity3d.com/Manual/class-Rigidbody.html)
12. [Unity - Manual: Animation](https://docs.unity3d.com/Manual/AnimationSection.html)
13. [Unity - Manual: Prefabs](https://docs.unity3d.com/Manual/Prefabs.html)
14. [Unity - Manual: UI](https://docs.unity3d.com/Manual/UISystem.html)
15. [Unity - Manual: Physics Interactions](https://docs.unity3d.com/Manual/PhysicsOverview.html)
16. [Unity - Manual: ScriptableObject](https://docs.unity3d.com/Manual/class-ScriptableObject.html)
