# Inimigos e UI

## Inimigos
  Vamos adicionar uma ameaça ao nosso jogo na forma de um inimigo que fica andando de um lado para o outro

  1. Crie um novo objeto e dê o sprite que quiser
  2. Adicione um Collider2D e customize o formato

  ![Inimigo com collider](https://cdn.discordapp.com/attachments/1105270961391030293/1141479279109079193/image.png)

  Queremos que esse inimigo fique andando de um lado para o outro, se movendo até uma posição expecífica e trocando de direção

  3. Crie um novo script de movimentação para seu inimigo
  4. Insira o seguinte código dentro de Update() (e defina a variável speed no início da classe)
  ```C#
  update()
  {
    transform.position += Vector3.right * speed;
  }
  ```
  Sabemos que isso fará o inimigo se deslocar para a direita infinitamente
  5. Para definir os limites do seu movimento, crie as seguintes variáveis no início da classe

  ```C#
  public Vector3 startPosition;
  public Vector3 endPosition;
  private int direction = 1;
  ```

  E adicione este código em Update()
  ```C#
  Update()
  {
    transform.position += Vector3.right * speed * direction;

    if (Vector3.Distance(transform.position, startPosition) <= 0.1f)    // if acontece quando o inimigo está dentro de 0.1 unidades de distância da posição final
    {
      direction = 1;         // Direção = direita
    }
    
    if (Vector3.Distance(transform.position, endPosition) <= 0.1f)    // if acontece quando o inimigo está dentro de 0.1 unidades de distância da posição final
    {
      direction = -1;        // Direção = esquerda
    }
  }
  ```
  
  ⚠ Note que simplesmente fazer "transform.position == endPosition" não vai funcionar devido as posições serem floats, é possível que o inimigo ultrapasse a posição final sem que a condição se torne verdadeira


### Prefabs
  Agora que temos nosso objeto inimigo criado, podemos querer ter varios inimigos idênticos espalhados pela fase, todos com as mesmas propriedades.

  Podemos fazer isso simplesmente copiando e colando o inimigo por ai, mas uma forma muito mais prática é tornar o inimigo em um prefab(pre-fabricated object), um inimigo pronto que podemos adicionar à fase sempre que precisarmos.

  Outra vantagem de prefabs é que alterações ao prefab se aplicam a todas as suas instâncias na fase, ou seja, podemos, por exemplo, mudar o sprite do inimigo alterando somente o prefab, sem ter que achar todos os inimigos no nível e alterar seus sprites individualmente(também é possivel modificar instâncias expecíficas de prefabs).

  1. Para fazer isso, simplesmente arraste seu objeto inimigo da Hierarchy para o local desejado na janela Project

  Se tudo der certo, o inimigo irá aparecer dentre os seus arquivos e o inimigo já existente ficará com texto azul

  ![Criação de prefab](https://cdn.discordapp.com/attachments/1105270961391030293/1141494091641798718/image.png)
  
## Dano
  Precisamos que os inimigos interajam com o jogador de alguma forma, a mais clássica sendo que eles dêem reduzam a vida do jogador

  1. Vamos primeiro adicionar HP ao script do jogador
  ```C#
  public float playerHealth = 100.0f;
  ```

  Agora queremos detectar quando o jogador colide, expecificamente, com um inimigo.
  
  Para isso, precisamos definir o que é um inimigo

  2. No inspector do inimigo, atribua a ele uma tag (pode ser a tag "Enemy" existente ou uma nova)
  ![Seletor de tags](https://media.discordapp.net/attachments/1105270961391030293/1142572597205291078/image.png?width=316&height=360)

  3. No script do jogador, adicione o seguinte código dentro de OnCollisionEnter()
  ```C#
  private void OnCollisionEnter2D(Collision2D other)
  {
      if (other.contacts[0].normal == Vector2.up)
      {
          currentJumps = 0;

          //isJumping = false;
      }

      if (other.gameObject.CompareTag("Enemy"))
      {
          
          playerHealth -= 20;
          Debug.Log("OUCH " + playerHealth);
      }
  }
  ```
  Colidir com o inimigo reduzira a vida do jogador em 20 e escrevera uma mensagem no console com sua vida atual.

## UI
  Não basta apenas exibir a vida do jogador no console, pois essa ferramenta só está disponível para nós desenvolvedores. Para que o player seja capaz de ver sua própria vida, precisamos adicionar um HUD

  1. Crie um novo objeto UI > Canvas.
  2. Dê um clique duplo nesse novo objeto. Este vai ser o lugar onde você ira criar sua UI

  ![Canvas](https://media.discordapp.net/attachments/1105270961391030293/1142578845283799172/image.png?width=648&height=386)

  ⚠ Não se alarme pelo tamanho do canvas, não é necessário reduzí-lo

  3. Dentro do seu objeto canvas, crie um novo objeto UI > Text
  4. Edite o texto como quiser, a posição do texto no canvas equivalerá a sua posição na tela do jogador
  ![texto no canvas](https://media.discordapp.net/attachments/1105270961391030293/1142580437840056490/image.png?width=1013&height=527)

  (Mudar as opções de Overflow vertical e horizontal para "overflow" pode facilitar)

  ![ui no jogo](https://cdn.discordapp.com/attachments/1105270961391030293/1142581361811660860/image.png)


  5. Dentro do script do jogador, nas primeiras linhas, insira o seguinte código
  ```C#
  using UnityEngine.UI;
  ```

  6. Declare a seguinte variável pública
  ```C#
  public Text playerHealtText;
  ```

  (Defina essa variável no editor arrastando o objeto texto até a caixinha no script do jogador)

  7. Dentro de if em OnCollisionEnter(), faça a seguinte alteração (dentro do segundo 'if')
  ```C#
  private void OnCollisionEnter2D(Collision2D other)
  {
      if (other.contacts[0].normal == Vector2.up)
      {
          currentJumps = 0;

          //isJumping = false;
      }

      if (other.gameObject.CompareTag("Enemy"))
      {
          
          playerHealth -= 20;
          Debug.Log("OUCH " + playerHealth);
          playerHealtText.text = ("HP: " + playerHealth);

      }
  }
  ```

  Agora a vida no HUD irá atualizar sempre que o player tomar dano! (mas note que nada a impede de ficar negativa)

  ![GIF inimigos dando dano e HUD](https://cdn.discordapp.com/attachments/1105270961391030293/1142607917581869206/level.gif)

