# Contributing to WJoe39's projects'

<!--toc-start-->
* [Branches](#b)
  * [Branch name format](#b-1)
  * [Pull requests](#b-2)
* [Commits](#c)
  * [Commit message format](#c-1)
  * [Pushed commits](#c-2)
* [Other](#o)
<!--toc-end-->

This guideline applies for WJoe39's personal projects'.

## <a name="b"></a>Branches

### <a name="b-1"></a>Branch Name Format

#### `<type>/name`

##### Type
Allowed types are defined on the project/repository level:

* feature/
* bugfix/
* hotfix/
* release/

##### Name
Use snake_case or lisp-case.

### <a name="b-2"></a>Pull Requests
* Have you adapted tests covering new and/or changed functionality?
* Have you adjusted [CHANGELOG.MD](CHANGELOG.md) before creating the pull request?
* Don't forget to remove branch on merge.

## <a name="c"></a>Commits

### <a name="c-1"></a>Commit Message Format

#### `<subject>`
Try to keep the first line of the commit message short within reason.
Atomic commits: You should aim to split your commits so that each one is small in size and does only one thing.

If a commit is too big you may find it difficult to describe the `<subject>` to assign to it and that's an indication that you should split it into more commits. Same applies for a long `<subject>` but it is allowed to expand a little bit on the following lines if you want to.

##### Subject
The subject contains succinct description of the change:

* use the imperative, present tense: "change" not "changed" nor "changes"
* capitalize first letter
* no dot (.) at the end

### <a name="c-2"></a>Pushed Commits
Do not delete commits that have already been pushed.