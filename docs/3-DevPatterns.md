# Padrões de Desenvolvimento
Para melhor organização do projeto, uma série de padrões foram adotadas, como padrão de commit, template de issues, template de pull requests, padrão de ATAS e padrões de código.

## Padrões de Commit
Para padronizar os commits do projeto, este artefato foi criado tendo [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) como inspiração.

O padrão básico consiste em:<br>

"tipo"<br>
"issue"<br>
"mensagem"<br> 
"contribuidores"<br>


- Tipo: que é o tipo do commit, como **docs** para documentação, **fix** para correção de conteúdo, ou mesmo **feat** para commits de novas funcionalidades;
- Issue: este commit corrige qual das issues abertas no momento?
- Mensagem: a mensagem precisa ser curta, mas eficaz, transmitindo uma pequena ideia do conteúdo do commit;
- Contribuidores: se houver um coautor no commit, você deve incluí-lo no final;

O estilo deve se parecer com algo assim:

```bash
<Tipo> #(Issue): <Mensagem> Co-autoria: <Contribuidor> <E-mail do Contribuidor>
```

## Template de Issue
Para padronizar as issues do projeto, foi criado o seguinte template:

    ## Task Description

    Describe what needs to be done here.

    ## Acceptance Criteria

    - [ ] Criterion 1
    - [ ] Criterion 2
    - [ ] ...

    ## Requirements
    Which requirements of the project does this issue refers to?
    - []()
    - []()

    ## Additional Information

    Add any additional information that may be helpful.

## Template de PR
Para padronizar as PRs do projeto, foi criado o seguinte template:

    ## Description

    Please include a summary of the change and which issue is fixed. Please also include relevant motivation and context. List any dependencies that are required for this change.

    Fixes # (issue)

    ## Type of change

    Please delete options that are not relevant.

    - [ ] Bug fix (non-breaking change which fixes an issue)
    - [ ] New feature (non-breaking change which adds functionality)
    - [ ] Breaking change (fix or feature that would cause existing functionality to not work as expected)
    - [ ] Documentation update

    ## Checklist:

    - [ ] My code follows the style guidelines of this project
    - [ ] I have performed a self-review of my own code
    - [ ] I have commented my code, particularly in hard-to-understand areas
    - [ ] I have made corresponding changes to the documentation
    - [ ] My changes generate no new warnings

