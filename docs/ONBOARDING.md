# Guia de Onboarding — Projeto BOSS

Bem-vindo(a) ao projeto **BOSS - BigOpen Source Sibling**! Este guia tem como objetivo te ajudar a dar os primeiros passos como contribuidor(a) deste projeto de código aberto, explicando como configurar o ambiente, entender o fluxo de trabalho e fazer sua primeira contribuição com segurança.

---

## Sobre o Projeto

O **BOSS** é um jogo desenvolvido com Unity como plataforma de aprendizado prático para a disciplina de **Gerência de Configuração e Evolução de Software**. Aqui, você vai colocar em prática conceitos como:

- Controle de versão com **Git**
- Estratégias de branching (como **Git Flow**)
- Integração Contínua (**CI**) e Entrega Contínua (**CD**)
- Rastreabilidade de mudanças e versionamento

Além disso, o BOSS também é um espaço inclusivo e colaborativo, construído em parceria com a iniciativa **BigOpen Source Sibling**, voltado a ampliar a diversidade na comunidade de software livre.

---

## Tecnologias Utilizadas

- **Unity Engine**
- **C#**
- **Git / GitHub**
- **CI/CD (GitHub Actions)**
- **Design 2D e UI/UX**

---

## Pré-requisitos

Antes de começar, você precisará ter instalado no seu computador:

| Ferramenta              | Versão mínima recomendada |
| ----------------------- | ------------------------- |
| Unity                   | 2022.x ou superior        |
| Git                     | 2.30+                     |
| Visual Studio / VS Code | Qualquer com suporte a C# |
| Conta no GitHub         | (gratuita)                |

---

## hecklist de Configuração

1. [ ] Faça um fork deste repositório em sua conta GitHub
2. [ ] Clone seu fork localmente
   ```bash
   git clone https://github.com/seu-usuario/Jogo-Unity-BOSS.git
   ```
3. [ ] Abra o projeto no **Unity Hub**
4. [ ] Verifique se a versão do Unity é compatível
5. [ ] Abra a solução com o Visual Studio / VS Code
6. [ ] Execute a cena principal e verifique se está tudo rodando bem

---

## Fluxo de Contribuição

Nosso projeto segue uma estrutura baseada em Git Flow. Veja como contribuir:

1. **Escolha uma issue** (preferencialmente com o selo `good first issue` se for seu primeiro PR)
2. Crie uma **branch** descritiva a partir da `main`:
   ```bash
   git checkout -b feat/nome-da-feature
   ```
3. Faça suas alterações
4. Commit suas mudanças seguindo o padrão:
   ```
   git commit -m "feat: adiciona nova funcionalidade X"
   ```
5. Suba sua branch:
   ```bash
   git push origin feat/nome-da-feature
   ```
6. Abra um **Pull Request** e descreva o que você fez

---

## Padrões e Boas Práticas

- Use nomes de branch e commits claros e consistentes (`feat:`, `fix:`, `docs:` etc.)
- Evite enviar PRs muito grandes
- Siga as diretrizes de design e estrutura de código do projeto
- Seja respeitoso(a) nas interações — veja nosso [Código de Conduta](./CODE_OF_CONDUCT.md)

---

## Recursos Úteis

- [Documentação Oficial do Unity](https://docs.unity3d.com/)
- [Guia de Git Flow (em português)](https://danielkummer.github.io/git-flow-cheatsheet/index.pt_BR.html)
- [GitHub Docs](https://docs.github.com/)

---

## Comunicação e Suporte

Caso tenha dúvidas ou precise de ajuda:

- Abra uma issue com a tag `question`
- Entre em contato com mentores e mantenedores via comentários no GitHub

---

## Código de Conduta

Nos comprometemos com um ambiente respeitoso e acolhedor para todos os colaboradores. Leia nosso [Código de Conduta](CODE_OF_CONDUCT.md) antes de contribuir.

---

## Comece por aqui

Se for sua **primeira contribuição**, recomendamos:

- Ler este `ONBOARDING.md`
- Ler o `README.md`
- Escolher uma issue com o selo `good first issue`
- Abrir um PR com uma pequena contribuição (documentação, correção simples ou melhoria visual)

---

**Bem-vindo(a) à equipe BOSS!** 🚀  
Sua colaboração faz toda a diferença 💙

## Histórico de versão

| Data       | Versão | Descrição                                | Autores                                                                                          |
| ---------- | ------ | ---------------------------------------- | ------------------------------------------------------------------------------------------------ |
| 03/07/2025 | 1.0    | Adicionando versão inicial do Onboarding | [Júlio Cesar](https://github.com/Julio1099), [Maciel Júnior](https://github.com/macieljuniormax) |
