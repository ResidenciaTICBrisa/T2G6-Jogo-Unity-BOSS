# Release 03 (07/07/2025)

## Histórico de Versão

| Data       | Versão | Descrição                                 | Autores                                                                                       |
| ---------- | ------ | ----------------------------------------- | --------------------------------------------------------------------------------------------- |
| 07/07/2025 | 0.1    | Planejamento de contribuições e qualidade | [Carlos Henrique](https://github.com/carlinn1), [Vinicius Castelo](https://github.com/Vini47) |

### Contexto

Para o terceiro ciclo de entregas do projeto **BOSS**, nosso foco foi estruturar o fluxo de contribuição, garantir qualidade de código e facilitar o onboarding de novos membros. Para isso, definimos:

- Geração de artefato instalável (APK) para testes internos e externos;
- Integração de análise estática (SonarQube, ESLint);
- Documentação de boas‑práticas e processos;
- Automação de build e deploy (Docker, CI/CD);
- Criação de issues “good first issue” para receber contribuições.

### Desafios

- Produzir um APK estável e fácil de instalar pela turma de teste.
- Configurar e integrar ferramentas de qualidade (SonarQube e ESLint) num projeto Unity + Web.
- Mapear e documentar o fluxo de contribuição de modo claro para novos desenvolvedores.
- Identificar e corrigir links quebras e elementos visuais inúteis na GitPages/Landing Page.
- Adaptar pipelines de CI/CD para um repositório que mistura código Unity e web.
- Gerar issues iniciais de fácil resolução para engajar os “primeiros contribuidores”.

### Soluções

- Definimos scripts de build no Unity para exportar o APK e publicá‑lo em repositórios internos.
- Implantamos SonarQube (via container) para análise de qualidade e adicionamos ESLint no front-end.
- Criamos `CONTRIBUTING.MD`, `CHANGELOG.md` e revisamos o `README.md` com orientações de software livre.
- Refatoramos a GitPages: corrigimos links quebrados e removemos componentes visuais obsoletos.
- Elaboramos um container Docker para facilitar setup local em Unity e demos exemplos de jogos.
- Configuramos GitHub Actions para CI/CD (build automático e deploy do site e do APK).
- Escrevemos templates de issues e levantamos várias “good first issue” para espalhar pelo repositório.

### Resultados

- APK disponível para toda a turma, facilitando testes manuais.
- Primeiro relatório de qualidade de código com métricas do SonarQube e ESLint.
- Documentação unificada e clara para onboarding de novos contribuidores.
- Landing Page funcional e atualizada no GitHub Pages.
- Pipelines de CI/CD rodando nightly builds e deploys automáticos.
- Conjunto inicial de issues simples para estimular pull requests de iniciantes.

## Tecnologias Escolhidas

- **Engine de Jogo:** Unity
- **Análise de Código:** SonarQube (container) e ESLint
- **Containerização:** Docker
- **CI/CD:** GitHub Actions
- **Documentação:** MkDocs (GitHub Pages)
- **Controle de Versão:** Git com GitFlow
- **Edição de Código:** Visual Studio, VS Code

## Produtos a Serem Entregues

1. Disponibilizar um APK (para a turma) — **Matheus, João e Arthur**
2. Aplicar técnicas de qualidade de software: SonarQube e ESLint — **Arthur, Matheus e João**
3. Criar um planejamento de onboarding de novos contribuidores — **Maciel e Julio**
4. Organizar GitPages e Landing Page (corrigir links quebrados e remover elementos inúteis) — **Carlos e Vinicius**
5. Criar `CONTRIBUTING.MD`, guia de boas práticas, revisar `README.md`, adicionar licença de software livre e gerar `CHANGELOG.md` — **Maciel e Julio**
6. Criar Dockerfile para Unity (se possível, para jogos) — **Arthur e Vinicius**
7. Configurar pipeline de CI/CD (preferencialmente com build de jogos) — **Vinicius e Carlos**
8. Criar issues de contribuição no estilo **good first issue** — **Todos**

## Regras de Versionamento do Projeto

- **Commits:** Convenção [Semantic Commits](https://www.conventionalcommits.org/)
- **Tags:** SemVer (ex.: v0.2.0)
- **Fluxo de Branches:** GitFlow (branches `feature/`, `release/`, `hotfix/`)
