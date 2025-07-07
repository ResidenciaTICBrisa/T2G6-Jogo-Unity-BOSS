# <div align="center"> 🎮 Diários de Sofia</div>

<div align="center">

### _Jogo educacional mobile open source sobre inclusão no ensino superior_

**Unity · Open Source · Educação · Diversidade · Mobile**

[![Made with Unity](https://img.shields.io/badge/Unity-2022.3.20f1-000000?logo=unity&logoColor=white)](https://unity.com/)
[![Open Source](https://img.shields.io/badge/Open%20Source-%F0%9F%92%96-blue)](./LICENSE)
[![Mobile Ready](https://img.shields.io/badge/Mobile-Android%20%7C%20iOS-green)](./docs/jogo/game.md)
[![Educational](https://img.shields.io/badge/Educational-%F0%9F%93%9A-orange)](./docs/index.md)

[🎮 Jogar](#-como-jogar) • [👩‍💻 Contribuir](#-como-contribuir) • [📚 Documentação](https://fga-gces.github.io/Jogo-Unity-BOSS/) • [🎯 Good First Issues](./docs/jogo/good_issues.md)

</div>

---

## 📖 Sobre o Jogo

Na cidade de Ogama, as mulheres não têm direito ao ensino superior. Sofia, uma jovem inconformada com essa realidade, embarca em uma jornada para questionar as regras estabelecidas e lutar pelo seu direito à educação.

**"Diários de Sofia"** é um jogo narrativo 2D que combina:
- 🎭 Storytelling envolvente sobre inclusão educacional
- 🎮 Gameplay mobile-first com mecânicas acessíveis
- 🎓 Objetivo educacional de promover discussões sobre diversidade
- 🌟 Desenvolvimento aberto e colaborativo

📱 **[Saiba mais sobre o jogo →](./docs/jogo/game.md)**

## 📁 Estrutura da Documentação

```plaintext
docs/
├── index.md                      # 🏠 Landing page da documentação
├── jogo/                         # 🎮 Documentação do jogo
│   ├── game.md                   # Sobre o jogo e requisitos
│   ├── scripts.md                # Arquitetura e sistemas
│   ├── good_issues.md            # First good issues para novos contribuidores
│   ├── backlog.md                # Backlog e funcionalidades
│   └── clean_code.md             # Padrões de código
├── projeto/                      # 📋 Gestão do projeto
│   ├── concepts.md               # Conceitos e metodologia
│   ├── devprocess.md             # Processo de desenvolvimento
│   ├── sprints.md                # Planejamento de sprints
│   └── releases/                 # Documentação das releases
├── tutoriais/                    # 📚 Tutoriais Unity for Women
├── CONTRIBUTING.md               # 🤝 Guia de contribuição
├── CODE_OF_CONDUCT.md            # 📜 Código de conduta
├── ONBOARDING.md                 # 🚀 Onboarding para novos membros
└── checklist_oss.md              # ✅ Checklist open source
```
---

# 🚀 Como rodar a documentação localmente

Siga este passo a passo para rodar a documentação do projeto na sua máquina local usando o [MkDocs](https://www.mkdocs.org/) com o tema [Material for MkDocs](https://squidfunk.github.io/mkdocs-material/).

---

## 🧰 Pré-requisitos

Antes de tudo, você precisa ter o seguinte instalado:

- [Python 3.13.0+](https://www.python.org/downloads/)
- [pip 24.0+](https://pip.pypa.io/en/stable/installation/)
- [MkDocs 1.6.1+](https://www.mkdocs.org/#installation)
- [Material for MkDocs 9.5.49+](https://squidfunk.github.io/mkdocs-material/getting-started/)

Verifique se estão instalados com:

```bash
python3 --version
pip3 --version
mkdocs --version
pip show mkdocs-material
```

---

## 🚀 Rodando localmente

Se for a primeira vez, execute:

```bash
mkdocs build
```

Logo depois, você pode rodar o servidor localmente usando:

```bash
mkdocs serve
```

Ele irá rodar em: http://localhost:8000

> O servidor atualiza automaticamente a documentação sempre que você salva alterações nos arquivos `.md`.


## 🌍 **Sobre Nós**

É uma iniciativa aberta que combina:

- 🎮 **"Diários de Sofia"**: Jogo narrativo 2D
- 🛠️ **Workshop "Unity for Women"**: Tutoriais gratuitos para iniciantes em Unity, com foco em inclusão de mulheres na tecnologia.

---

## 🚀 **Comece Aqui**

| Projeto      | Descrição                                                                                                                                                                                                                                                                       | Links Úteis                                                                                                                                              |
| ------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Jogo**     | Na cidade de Ogama, as coisas são como são e ninguém discorda de nenhuma das regras. A principal delas: mulheres não têm direito ao ensino superior. Para Sofia, isso sempre foi motivo de incômodo, mas nunca viu ninguém ao seu redor lutar para que algo diferente aconteça. | [Documentação](https://fga-gces.github.io/Jogo-Unity-BOSS/)                                                                               |
| **Workshop** | Aprenda Unity do zero criando um jogo 2D passo a passo.                                                                                                                                                                                                                         | [Tutoriais](./unity-for-women/tutoriais/README.md)</br>[Roadmap](./unity-for-women/RoadmapWorkshop.md) </br> [Glossário](./Unity-for-Women/glossario.md) |

---

# 👩‍💻 **Participe**

## Como contribuir com o jogo Diários de Sofia
 > Você pode contribuir com o jogo Diários de Sofia de várias maneiras, como reportando bugs, sugerindo melhorias ou até mesmo contribuindo com código.
 Para começar, você precisará estar em conformidade com os [Guias de Conduta](./docs/patterns.md) e [Contribuição do projeto](./docs/patterns.md). 

## Instalação do Jogo
### 🧰 Pré-requisitos

Certifique-se de ter o seguinte instalado:

- [Unity Hub](https://unity.com/download)

Caso não tenha o Unity Hub instalado, siga as instruções de instalação no site oficial da [Unity](https://unity.com/download).

Após instalar o Unity Hub, você precisará adicionar a versão do Unity que será utilizada no projeto. Para isso, siga os passos abaixo:
1. Abra o Unity Hub.
2. Vá para a aba "Installs" (Instalações).
3. Clique em "Add" (Adicionar) e selecione a versão **2022.3.20f1**.
4. Certifique-se de incluir os módulos necessários, como suporte ao Android e iOS, considerando que o intuito do jogo é rodar em dispositivos mobile. Não se preocupe, você poderá rodar o jogo no computador também.

### Rodando localmente

Para rodar o jogo localmente, siga os seguintes passos:
1. Clone o repositório do jogo:
```bash
git clone https://github.com/FGA-GCES/Jogo-Unity-BOSS.git
```
2. Abra o Unity Hub.
3. Vá para a aba "Projects" (Projetos).
4. Clique em "Add" (Adicionar) e selecione a pasta do repositório clonado.
5. Selecione o diretório "Unity-Project" e clique em "Open" (Abrir).
6. O Unity irá carregar o projeto. Aguarde até que todos os pacotes sejam baixados e o projeto esteja pronto.

### Compilação do Jogo
Para compilar o jogo, siga os seguintes passos:
1. No Unity, vá para o menu "File" (Arquivo).
2. Selecione "Build Settings" (Configurações de Compilação).
3. Selecione a plataforma desejada (Android, iOS, PC, etc.).
4. Clique em "Build" (Compilar) e escolha o local onde deseja salvar o arquivo compilado.
5. Aguarde a compilação ser concluída. O Unity irá gerar o arquivo executável do jogo para a plataforma desejada.

### Informações Adicionais
- Atualmente, o jogo está em desenvolvimento, então cada cena pode conter elementos que ainda não estão finalizados. Sinta-se à vontade para explorar as cenas e contribuir com melhorias, correções de bugs ou novas funcionalidades.
- Erros conhecidos na hora de rodar o jogo localmente podem ser encontrados na [página de Erros Conhecidos](./docs/dificuldades_subir_ambiente.md).
- Se quiser contribuir com o jogo, talvez seja interessante começar por uma ```GoodFirstIssue``` ou uma ```HelpWanted```, que são issues mais fáceis de resolver e podem te ajudar a entender melhor o projeto. Você pode encontrar essas issues na [página de Issues](https://github.com/FGA-GCES/Jogo-Unity-BOSS/issues) do repositório.
- Para acessar as fases (cenas) disponíveis atualmente, você pode navegar até a pasta `Assets/Scenes` dentro do projeto Unity. Lá, você encontrará as cenas disponíveis para jogar e contribuir.
  1. **Menu Principal**: A cena inicial do jogo, onde você pode iniciar a jornada de Sofia e acessar as configurações.
  2. **City Map**: Mapa da cidade, onde poderá interagir com os NPCs e visitar outros locais.
  3. **Library**: A segunda fase do jogo, onde você continua a história de Sofia.
  4. **SofiaHouse**: Fase inicial do jogo, onde você conhece a casa de Sofia.

## 💬 **Fale Conosco**

- [GitHub](https://github.com/BOSS-BigOpenSourceSibling)
- [Youtube](https://www.youtube.com/channel/UCQxKAvq-QLq57dqGYI_TuFw?view_as=subscriber)
- [bigopensourcesister@gmail.com](mailto:bigopensourcesister@gmail.com)

---

<div align="center">  
  <img src="https://img.shields.io/badge/Unity-100000?logo=unity&logoColor=white" />  
  <img src="https://img.shields.io/badge/Open%20Source-%F0%9F%92%96-blue" />  
  <img src="https://img.shields.io/badge/Diversity-%F0%9F%8F%B3%EF%B8%8F%E2%80%8D%F0%9F%8C%88-ff69b4" />  
</div>

---

### ✨ **Créditos**

- Equipe [**T2G6** ](https://fga-gces.github.io/Jogo-Unity-BOSS/)(jogo) • [**BOSS Mentoring**](https://github.com/BOSS-BigOpenSourceSibling) (mentoria) • [**BRISA**](https://github.com/ResidenciaTICBrisa) (apoio educacional).

---

---

### ✨ **Protótipos do Figma**

- Protótipo dos Roadmaps: https://www.figma.com/proto/bJClgWeiEKf9FRT5vYPFCE/GCES-BOSS?node-id=5501-11994&p=f&t=xZvszHu4zbFG1fHr-1&scaling=min-zoom&content-scaling=fixed&page-id=1444%3A5903

---

**Feito com ❤️ para democratizar o desenvolvimento de jogos.**

---

## Licença

Este projeto está licenciado sob os termos da Licença MIT. Veja o arquivo [LICENSE](./LICENSE) para mais detalhes.
