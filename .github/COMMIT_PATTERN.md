# Commit Pattern
To standardize the commits of the project, this artifact was made having the [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) as inspiration.

The basic pattern consists of "type", "issue", "message" and "contributors".
- Type: which is the type of the commit, such as docs for documentation, or fix for fixing content, or even feat for feature commits;
- Issue: this commit fixes which of the current open issues?
- Message: the message needs to be short but effective, so it passes a small idea of the content of the commit;
- Contributors: if you have a co-author on the commit, you should put it in the end;

The style should look something similar to this:

```bash
<Type> #(Issue): <Message> Co-authored-by: <Contributor> <Contributor email>
```
