# Desenvolvendo um nível
## Expandindo a fase

![Nível maior](https://media.discordapp.net/attachments/1105270961391030293/1138155828591988897/image.png?width=987&height=502)

- Podemos expandir o nível já criado utilizando as ferramentas que já vimos anteriormente.
- Lembre-se de manter a organização dos blocos do chão e dos planos de fundo.

## Movimento da câmera

Como jogadores, ainda não podemos navegar essa fase, pois a câmera não segue o personagem.
Assim como fizemos para movimentar o jogador, podemos adicionar à câmera um script para movimentá-la também, já que a câmera também é um objeto manipulável.

1. Crie um novo script para a câmera, e dê um nome como "CameraMovimentation" ou algo similar

Queremos que a nossa câmera siga o jogador, para isso precisamos saber onde ele está dentro do script

2. Antes de Start() e Update(), crie a seguinte variável pública, que servirá de referência ao jogador:
   ```C#
   public class CameraMovimentation : MonoBehaviour
   {
      public GameObject player;
      .
      .
      .
   }
   ```

3. Salvando o código, volte no editor e arraste o objeto jogador até a caixa correspondente à essa variável no inspetor
   
   ![Linkando um objeto à uma variável pelo editor](https://media.discordapp.net/attachments/1105270961391030293/1138160991784403056/image.png?width=1013&height=411)
  ⚠ Lembre-se desse processo de atribuir componentes/objetos à variáveis públicas pelo editor, não a ilustraremos mais a partir daqui

Agora poderemos acessar propriedades do jogador como sua posição dentro do script da câmera

4. Dentro de Update(), insira o seguinte código:
   ```C#
   void Update()
   {
      transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
   }

   ```


Note que "transform.position" se refere à posição do objeto que possui o script que estamos escrevendo, neste caso a câmera, enquanto "player.transform.position" se refere a posição do jogador

Esse código fará com que a câmera se movimente horizontalmente para seguir o personagem, mas não verticalmente

A câmera continuará se movimentando onde quer que formos, podendo expor as partes que não queremos que o jogador veja

   
   ![GIF bordas da fase](https://cdn.discordapp.com/attachments/1105270961391030293/1138166371155451934/ezgif-5-15d373520c.gif)

5. Para resolver isso, definimos limites ao movimento da câmera, permiindo que ele se mova somente a partir de pontos específicos de x.
   - Nesse caso a câmera só irá mexer quando ela estiver entre a posição 0 e 50 de x.
     
   ```C
   public class CameraMovimentation : MonoBehaviour
   {
      public GameObject player;

      public float minCameraPosition = 0;
      public float maxCameraPosition = 50;
      .
      .
      .
   }
   ```
   ```C#
   void Update()
   {
      if(player.transform.position.x >= minCameraPosition && player.transform.position.x <= maxCameraPosition)
      {
         transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
      }
   }
   ```


   ![GIF camera limitada](https://cdn.discordapp.com/attachments/1105270961391030293/1138169314051117167/ezgif-5-49fbdd9a31.gif)

## Adicionando obstáculos
Com as mecânicas básicas de movimento feitas, agora você pode criar um nível símples como quiser!
1. Adicione plataformas e obstáculos símples, e altere as variáveis de velocidade e pulo do jogador caso ache necessário

⚠ Lembre-se que todos os objetos sólidos precisam ter um collider, você pode addicionar um collider à cada bloco individual de terra/grama caso prefira, para que você possa copiar e colar os objetos à vontade

2. Adicione também um objeto, como uma moeda, para ser o objetivo da fase

   ![Fase com obstáculos e objetivo](https://media.discordapp.net/attachments/1105270961391030293/1138173132260257873/image.png?width=962&height=213)

Você pode ter percebido que ao pular e colidir com o lado de um bloco, o jogador gruda e para de cair, isso é porque os colliders possuem atrito, que por padrão é bem alto


   ![Atrito dos colliders](https://cdn.discordapp.com/attachments/1105270961391030293/1138174800209121400/ezgif-5-893fff0024.gif)

Para mudar o atrito, precisamos atribuir um novo material físico aos colliders

3. No explorer, clique com o botão direito do mouse > create > physics material 2D e dê um nome qualquer
4. Selecione o material recém criado e, no inspector, reduza o atrito para 0 (ou qualquer valor desejado)
5. Na barra de pesquisa da aba de hierarquia, digite "t:collider2D", isso irá destacar na tela todos os objetos que possuem um collider

   ![comando na barra de pesquisa ressaltando objetos com collider](https://cdn.discordapp.com/attachments/1105270961391030293/1138177172549423206/image.png)

6. Selecione todos os objetos ressaltados (com excessão do player) e arraste o material criado até a caixa "Material" no componente Box Collider 2D

   ![Material novo no componente](https://cdn.discordapp.com/attachments/1105270961391030293/1138178002275020930/image.png)
   

## Fim da fase

Para oficializar que o player finalizou a fase, vamos fazer com que tocar na moeda nos dê parabéns pelo console!

1. Adicione um collider 2D à moeda, de qualquer formato que quiser (tente modificar a propriedade "Edge Radius" do box collider para criar um quadrado com cantos redondos)
2. Adicione também um script à moeda, dentro do qual adicionaremos o código que nos dá parabéns por alcançá-la

Para detectar que tocamos na moeda, o Unity possui um método (Assim como Start() e Update()) que é chamado sempre que algo entra em contato com o collider do objeto

3. Adicione o seguinte método ao script:
   ```C#
   public class GameGoalController : MonoBehaviour
   {
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }

      // OnCollisionEnter2D é chamado quando uma colisão com outro objeto se inicia
      void OnCollisionEnter2D(Collision2D other)
      {
         Debug.Log("Parabéns, você me achou!");      // Imprime uma mensagem ao console
      }
   }
   ```
## Modificando o movimento
Até agora, o nosso jogador tem a capacidade de fazer um único pulo... mas poderiamos ter mais possibilidades de design de nível se o jogador tivesse um pulo duplo.
Podemos também, caso desejarmos, impedir que o jogador faça "wall jump", fazendo com que os pulos só resetem quando o jogador pisar no chão.

Antes disso, podemos também impedir que o jogador gire marcando a seguinte caixa em seu RigidBody2D

![Freeze Rotation](https://cdn.discordapp.com/attachments/1105270961391030293/1142611945812414494/image.png)

### Resetar pulo somente no chão
 - Para fazer o reset pelo chão vamos fazer o sequinte código:

```C#
  private void OnCollisionEnter2D(Collision2D other){
      if (other.contacts[0].normal == Vector2.up) //Se tocar no chão reseta pulo
      {
      }
}
```   
- Essa condição diz que quando o player entrar em colisão essa colisão tem que ser do chão (O vetor "up" ocorre por que o Vetor é criado na direção oposta de onde ocorreu o contato)
- Dentro dessa condição botaremos o reset para permitir que o player pule novamente

### Muiltiplos pulos
- Para fazer o player realizar multiplos pulos vamos alterar a variável de condição booleana "isJumping" para 2 variáveis interias
  
  ```C#
   public int multiJump = 0;
   public int maxJump = 3;
  ```
   - "maxJump" define quanto pulos podemos realizar
   - "multiJump" será atulizada a cada pulo dado
   - Agora, iremos alterar a condição if para pular
  
  ```C#
   if (Input.GetButtonDown("Jump") && multiJump < maxJump) // Se barra de espaço foi apertada E pulos disponíveis < pulos máximo
  {
   multiJump += 1;
  }
  ```
   - Assim os multiplos pulos pode acontecer enquanto o multiJump não ultrapassar o limite
   - A cada pulo dado vamos acresentar +1 para multiJump
  
  ```C#
  private void OnCollisionEnter2D(Collision2D other)
  {
     if (other.contacts[0].normal == Vector2.up)
     {
         multiJump = 0;
     }
  }
  ```
 - Assim o player é capaz de dar múltiplos pulos no ar.



