
# Padrões de Desenvolvimento

## Histórico de Versão

|Data|Versão|Descrição|Autores|
|--|--|--|--|
|20/04/2025|0.1|Adicionando regras de versionamento|[Júlio Cesar](https://github.com/Julio1099), [Maciel Júnior](https://github.com/macieljuniormax)|

Este documento define as diretrizes de versionamento, estrutura de branches, mensagens de commit, integração contínua e documentação para o projeto **Jogo-Unity-BOSS**. O objetivo é manter a organização, clareza e eficiência no desenvolvimento colaborativo.

---

## Estrutura de Branches

- **`main`**  
  Contém a versão **estável** e pronta para produção do jogo.

- **`develop`**  
  Branch de **integração** de funcionalidades em desenvolvimento.

- **`feature/*`**  
  Utilizamos para o desenvolvimento de **novas funcionalidades**.  
  Exemplo: `feature/sistema-inventario`

- **`hotfix/*`**  
  Destinamos a **correções urgentes** diretamente na produção.  
  Exemplo: `hotfix/erro-login`

- **`release/*`**  
  Usamos para preparar uma **nova versão estável**.  
  Exemplo: `release/v1.1.0`

---

## Versionamento Semântico (SemVer)

Adotamos o padrão [SemVer](https://semver.org/lang/pt-BR/) para nomear versões:

```
vMAJOR.MINOR.PATCH
```

- **MAJOR**: Quebra de compatibilidade com versões anteriores.
- **MINOR**: Novas funcionalidades compatíveis com versões anteriores.
- **PATCH**: Correções de bugs e melhorias retrocompatíveis.

> **Exemplo:** `v1.2.0` representa a segunda versão menor da versão principal `v1`.

---

## Padrão de Mensagens de Commit

- Escrevemos mensagens **claras, objetivas e no imperativo**.
- Incluímos, quando possível, o identificador da issue ou tarefa relacionada.
- **Contribuidores**: se houver um coautor no commit, você deve incluí-lo no final;
- Prefixos que seguimos:

| Prefixo | Finalidade                         |
|--------|------------------------------------|
| `feat:` | Nova funcionalidade                |
| `fix:`  | Correção de bug                   |
| `docs:` | Atualizações na documentação      |
| `style:`| Formatação, identação, etc.       |
| `refactor:` | Refatoração de código         |
| `test:` | Adição ou modificação de testes   |
| `chore:`| Tarefas de build ou configuração  |

**Exemplos:**
```bash
feat: adicionar sistema de inventário
fix: corrigir bug no movimento do personagem
docs: atualizar README com instruções de build
Co-authored-by: Nome do Contribuidor <email@exemplo.com>
```

---

## Testes e Integração Contínua

- Utilizamos o [Unity Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html) para testes automatizados.
- Configuramos **pipelines de CI** com o [GitHub Actions](https://github.com/features/actions) para automação de builds e testes.
- Antes de realizar merge nas branches `main` ou `develop`, garantimos que os testes estão **passando**.

---

## Deploy Contínuo

- Configuramos **deploy automático** da versão WebGL do jogo em:
  - [GitHub Pages](https://pages.github.com/)
  - [itch.io](https://itch.io/)
- Marcamos versões estáveis com tags no Git:
  ```bash
  git tag v1.0.0
  git push origin v1.0.0
  ```
- Registramos todas as versões no `CHANGELOG.md`.

---

## Documentação do Projeto

Mantemos a documentação sempre atualizada:

- **README.md**
  - Instruções para clonar, abrir e rodar o projeto no Unity.
  - Dependências e versões recomendadas.

- **CHANGELOG.md**
  - Histórico detalhado de alterações e versões lançadas.

- **CONTRIBUTING.md**
  - Diretrizes para contribuição: padrões de código, pull requests, etc.

- (Opcional) Documentamos:
  - Arquitetura do projeto.
  - Estrutura de pastas.
  - Convenções de nomenclatura de scripts.

## Template de Issue

<p style="text-indent: 50px;text-align: justify;"> Para padronizar as issues do projeto, foi criado o seguinte template: </p>

    ## Descrição da Tarefa

    Descreva o que precisa ser feito aqui.

    ## Critérios de Aceitação

    - [ ] Critério 1
    - [ ] Critério 2
    - [ ] ...

    ## Requisitos

    A quais requisitos do projeto esta tarefa se refere?
    - []()
    - []()

    ## Informações Adicionais

    Adicione qualquer informação adicional que possa ser útil.


## Template de PR

<p style="text-indent: 50px;text-align: justify;"> Para padronizar as PRs do projeto, foi criado o seguinte template: </p>

    ## Descrição

    Inclua um resumo da mudança e qual problema está sendo corrigido. Inclua também motivação e contexto relevantes. Liste quaisquer dependências necessárias para essa mudança.

    Corrige # (número da issue)

    ## Tipo de Mudança

    Por favor, exclua as opções que não são relevantes.

    - [ ] Correção de bug (mudança que não quebra o sistema e resolve um problema)
    - [ ] Nova funcionalidade (mudança que não quebra o sistema e adiciona uma nova funcionalidade)
    - [ ] Mudança que quebra o sistema (correção ou funcionalidade que pode fazer com que a funcionalidade existente não funcione como esperado)
    - [ ] Atualização de documentação

    ## Checklist:

    - [ ] Meu código segue as diretrizes de estilo deste projeto
    - [ ] Eu revisei meu próprio código
    - [ ] Comentei meu código, especialmente em áreas de difícil compreensão
    - [ ] Fiz mudanças correspondentes na documentação
    - [ ] Minhas mudanças não geram novos avisos

## Template de ata de reunião

<p style="text-indent: 50px;text-align: justify;"> O template de ata de reunião pode ser encontrado <a href="https://github.com/ResidenciaTICBrisa/T2G6-Jogo-Unity-BOSS/blob/2eeee920be9a4bb699e7449aa40744d0f6a1408d/docs/ATAS/ATA_TEMPLATE.docx" target="_blank">aqui</a>.</p>

---

> ⚠️ **Importante:**  
> Essas diretrizes são vivas. Elas podem (e devem) ser aprimoradas conforme a evolução da equipe e do projeto.