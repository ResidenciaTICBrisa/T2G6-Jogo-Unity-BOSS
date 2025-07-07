# Guia de Boas Práticas - Jogo Unity B.O.S.S

Este guia define padrões, estruturas e práticas recomendadas para garantir a qualidade, organização e consistência no desenvolvimento colaborativo do projeto.

---

## Objetivo

Padronizar e manter a qualidade do código, facilitando a manutenção, testes, documentação e evolução contínua do projeto.

---

## Estrutura de Branches

- `main`: versão estável e pronta para produção.
- `develop`: branch de integração das novas funcionalidades.
- `feature/*`: desenvolvimento de funcionalidades (`feature/menu-inicial`).
- `hotfix/*`: correções urgentes na produção.
- `release/*`: preparação de novas versões estáveis.

---

## Estilo de Código

- Utilize o Visual Studio com `.editorconfig` para padronização automática.
- Nomeação:
  - `camelCase` para variáveis e parâmetros.
  - `PascalCase` para classes, métodos e propriedades públicas.
- Evite métodos longos (mais de 40 linhas). Divida responsabilidades com funções auxiliares.
- Prefira composição a herança sempre que possível.
- Scripts devem ter o mesmo nome da classe principal.

---

## Testes

- Utilize o Unity Test Framework para testes unitários.
- Sempre que adicionar uma nova funcionalidade, inclua testes.
- Nomeie os testes de forma descritiva: `Metodo_DeveFazerAlgo_QuandoCondicao`.
- Toda PR deve passar nos testes antes de ser mergeada.
- Pipelines de CI com GitHub Actions garantirão builds e testes automatizados.

---

## Versionamento

Seguimos o [SemVer](https://semver.org/lang/pt-BR/):  
`vMAJOR.MINOR.PATCH` (ex: `v1.2.0`)

- `MAJOR`: mudanças incompatíveis com versões anteriores.
- `MINOR`: novas funcionalidades compatíveis.
- `PATCH`: correções de bugs.

---

## Deploy Contínuo

- Deploy automático da versão WebGL:
  - GitHub Pages
  - itch.io
- Releases são tagueadas (`v1.0.0`) e registradas no `CHANGELOG.md`.

---

## Estrutura do Projeto

- Organize os arquivos em pastas por funcionalidade (ex: `Inimigos/`, `UI/`, `Player/`).
- Prefira interfaces para serviços reutilizáveis ou testáveis.
- Separe lógica de negócio da interface sempre que possível.

---

## Documentação

- Comente métodos públicos e funções complexas com XML Documentation (`///`).
- Documente scripts `MonoBehaviour` com uma breve descrição da sua função.
- Mantenha os seguintes arquivos/documentos atualizados:
  - `README.md`: instruções de instalação e uso.
  - `CONTRIBUTING.md`: como contribuir com o projeto.
  - `CHANGELOG.md`: histórico de versões.
  - `docs/*`: imagens, diagramas, roadmap e documentação técnica.

---

## Templates

### Issues

- Descrição clara do problema
- Critérios de Aceitação
- Requisitos relacionados
- Informações adicionais relevantes

### Pull Requests

- Descrição da mudança
- Tipo de mudança: `bug`, `feature`, `breaking change`, `docs`
- Checklist de qualidade (ex: passou nos testes? atualizou documentação?)

### Atas de reunião

- [Modelo de Ata (.docx)](https://github.com/ResidenciaTICBrisa/T2G6-Jogo-Unity-BOSS/blob/2eeee920be9a4bb699e7449aa40744d0f6a1408d/docs/ATAS/ATA_TEMPLATE.docx)

---

## Commits e Pull Requests

### Padrão de Commits

Formato:  
`<prefixo>: descrição clara da mudança`

| Prefixo      | Uso                                 |
|--------------|-------------------------------------|
| `feat:`      | Nova funcionalidade                 |
| `fix:`       | Correção de bug                     |
| `docs:`      | Documentação                        |
| `style:`     | Formatação (sem mudança lógica)     |
| `refactor:`  | Refatoração sem alteração funcional |
| `test:`      | Testes                              |
| `chore:`     | Infraestrutura / build              |

**Exemplos:**
```bash
feat: adicionar sistema de inventário
fix: corrigir colisão com paredes
```

### Boas práticas de PRs

- Descreva claramente o que foi feito
- Inclua screenshots ou GIFs para mudanças visuais
- Relacione a issue correspondente (ex: `Closes #12`)
- Se houver coautores, utilize o padrão:
  ```
  Co-authored-by: Nome <email@exemplo.com>
  ```

---

Essas práticas são vivas e podem ser atualizadas conforme a maturidade do projeto.

---

## Histórico de versão

|Data|Versão|Descrição|Autores|
|--|--|--|--|
|03/07/2025|1.0|Adicionando versão inicial do guia de boas práticas |[Júlio Cesar](https://github.com/Julio1099), [Maciel Júnior](https://github.com/macieljuniormax)|