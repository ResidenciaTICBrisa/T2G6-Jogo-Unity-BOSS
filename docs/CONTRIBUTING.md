# Como Contribuir

Obrigado por seu interesse em contribuir com o projeto **Jogo Unity B.O.S.S**! Este guia apresenta as diretrizes para colaboração de forma eficiente e organizada.

---

## Pré-requisitos

Antes de começar, verifique se você possui:

- [Unity](https://unity.com/) instalado (versão 3.11.1)
- Git configurado corretamente
- [Microsoft Visual Studio Community 2022](https://visualstudio.microsoft.com/) instalado

Também é importante que você leia o nosso [Código de Conduta](./CODE_OF_CONDUCT.md).

---

## Fluxo de Trabalho

### 1. Faça um Fork do repositório

Crie uma cópia do repositório original para sua conta do GitHub.

### 2. Clone o seu fork e sincronize com a branch principal

```bash
git clone https://github.com/seu-usuario/Jogo-Unity-BOSS.git
cd Jogo-Unity-BOSS
git pull origin main
```

### 3. Crie uma branch descritiva

Utilize o padrão abaixo para nomear sua branch:

```bash
git checkout -b tipo/nome-da-branch
```

**Padrões de nome para branch:**

| Prefixo      | Descrição                                          |
|--------------|----------------------------------------------------|
| `feat/`      | Nova funcionalidade (ex: `feat/inimigo-zumbi`)     |
| `fix/`       | Correção de bugs (ex: `fix/colisao-personagem`)    |
| `docs/`      | Atualizações na documentação (ex: `docs/contributing`) |
| `refactor/`  | Refatorações sem alterar comportamento             |
| `bug/`       | Correção de bugs (ex: `bug/colisao-inimigo`)       |
| `task/`      | Tarefas gerais ou melhorias (ex: `task/ajuste-ui`) |

### 4. Faça commits atômicos e descritivos

```bash
git add ArquivoModificado.cs
git commit -m "fix: corrige bug de colisão com paredes. Fix #5"
```

> Use mensagens curtas e diretas, seguindo o [padrão de commits](./CONTRIBUTING.md#commits-e-pull-requests).

### 5. Envie sua branch para o GitHub

```bash
git push origin tipo/nome-da-branch
```

---

## Criando um Pull Request

1. Acesse o repositório original.
2. Clique em **"New Pull Request"**.
3. Selecione a sua branch.
4. Adicione uma descrição clara explicando:
   - O que foi feito
   - Por que foi feito
5. Clique em **"Create Pull Request"**.

---

## Critérios de Aceitação

- ✅ A PR deve passar em todos os testes automatizados
- ✅ Seguir o [padrão de código](./projeto/patterns.md) do projeto
- ✅ Ter aprovação de pelo menos **um mantenedor**

---

## Reportando Bugs

1. Verifique se o bug já foi reportado na aba [Issues](https://github.com/ResidenciaTICBrisa/T2G6-Jogo-Unity-BOSS/issues).
2. Caso não exista, crie uma nova issue com:
   - Descrição clara do problema
   - Etapas para reproduzir
   - Comportamento esperado
   - Prints ou vídeos, se possível

---

## Sugerindo Melhorias

1. Verifique se a sugestão já está listada nas Issues.
2. Se não estiver, abra uma nova issue explicando:
   - A melhoria proposta
   - O benefício esperado para o projeto

---

Muito obrigado por contribuir com a construção deste jogo! 💙

---

## Histórico de versão

|Data|Versão|Descrição|Autores|
|--|--|--|--|
|03/07/2025|1.0|Adicionando versão inicial do guia de boas práticas |[Júlio Cesar](https://github.com/Julio1099), [Maciel Júnior](https://github.com/macieljuniormax)|