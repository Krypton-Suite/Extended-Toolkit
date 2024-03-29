# Development Workflow for the Extended Toolkit

This document is intended to assist development of the standard toolkit. The repository has **3** main branches. They are:-

* **alpha** - This branch contains active development code.
	- All `Nightly` NuGet builds are built from this branch, or from a branch with an `alpha-` prefix.
	- These builds tend to be released almost daily, and are the least stable.
* **canary** - Contains test code to be used by developers before the final release.
	- All `Canary` NuGet builds are built from this branch. 
	- These builds are released a few times per month.
* **main** - The final public release code. 
	- These builds are released **once** per year, and are intended for production ready applications/code.