# Repository Guidelines

This file is the Extended Toolkit counterpart of [Standard-Toolkit `AGENTS.md`](https://github.com/Krypton-Suite/Standard-Toolkit/blob/alpha/AGENTS.md). Keep the same agent workflow (smallest correct change, TestForm validation, changelog, PR body file) but use the paths, license, language level, and module layout of **this** repository. Do not copy Standard-Toolkit palette-catalog, BSD-header, C# 7.3, or Standard-Toolkit-Demos rules into Extended work.

## Recent Tooling Mistakes To Avoid

These are recurring issues observed when using AI coding agents and shell wrappers. Follow these guidelines even if the commands appear syntactically correct.

- Do not combine `cmd.exe` variable assignment and use in the same command line. `%VAR%` is expanded before `set` takes effect, which created a stash named `"%STASH_MSG%"`. Correct example: `git stash push -m "443-followup" -- .`
- Do not pass complex PowerShell through `cmd.exe` with unescaped `$variables`; `cmd.exe` can strip or alter the command before PowerShell sees it. Correct example: run PowerShell directly with `$path = Join-Path (Get-Location) 'AGENTS.md'; Get-Content -LiteralPath $path -Raw`.
- Do not build long `git commit -m` commands when the body contains tokens such as `--check`; argument parsing can treat body text as options. Correct example: write the message to a temp file and run `git commit -F <message-file>`.
- Do not rely on shell quotes for `gh` arguments with spaces when the wrapper has already mishandled them. Correct example: use a JSON input file with `gh api ... --input <json-file>` or a PowerShell argument array.
- Do not try to rename an existing stash with `git stash store -m`; stash display names may still come from the original stash commit. Correct example: re-apply the stash, then create a fresh `git stash push -m "443-followup" -- .` if the label matters.
- Do not over-escape regex patterns for `rg`. A pattern like `msbuild\\.exe` can search for the wrong text. Correct example in PowerShell: `$pattern = 'msbuild\.exe'; $root = 'Scripts'; rg -n $pattern $root --glob '*.cmd'`.
- Do not use `findstr` quoted path experiments for ordinary file reads or searches. Correct example: `$path = 'Scripts\VS2022\build-nightly.cmd'; Select-String -LiteralPath $path -Pattern 'nightly.proj'`.

## Always

Before considering a task complete:

- Build the affected project if instructed.
- Fix any compiler or analyzer warnings introduced by the change; treat new warnings as part of the build (do not leave them for later). Prefer fixing pre-existing warnings in files you already touch when the fix is small and local; do not expand into a repo-wide warning cleanup unless asked.
- Check files you create or edit for UTF-8 BOM encoding issues and fix them (see **Coding Style & Naming Conventions**). Do not leave UTF-8-without-BOM or wrong-encoding files when the repo expects UTF-8 with BOM; do not expand into a repo-wide encoding cleanup unless asked.
- Update TestForm when adding a feature (see **TestForm Demos**).
- Update `Documents/Examples/Examples.md` when a feature has consumer-facing usage worth documenting.
- Update `Documents/Help/Changelog.md` for completed features and bug fixes.
- Add developer documentation for substantial new features (see **Feature Developer Documentation**). Keep new `Documents/Development/` files **out of pull requests**.
- Write a PR description in `Documents/PR/` for completed features and bug fixes, and use that file as the GitHub PR body. Do **not** include the per-change PR description file in the pull request (see **Pull Request Descriptions**).
- When UI behaviour is verified with ad-hoc PowerShell / UI Automation (mouse synthesise, screenshots, hosted `TestForm` demos), keep those scripts under `Scripts/UnitTests/` instead of leaving them only under `Bin/` or deleting them after the session. Create that folder if it does not exist yet.

## Shell Guidelines

- Prefer PowerShell for shell commands.
- Use cmd.exe only when reproducing Windows batch behavior.
- Use PowerShell cmdlets instead of findstr where possible.
- Avoid relying on cmd.exe variable expansion for complex commands.
- For complex Git operations, prefer temporary files or PowerShell arrays over long quoted command lines.

## Environment

- OS: Windows (required for .NET Framework and WinForms `-windows` TFMs)
- Tools: Visual Studio 2022 (v17) or later, and .NET SDKs covering the TFMs in root `Directory.Build.props` (currently `net472` through `net11.0-windows`)
- Build scripts are Windows `.cmd` files under `Scripts/`; do not run channel pack/CI scripts unless explicitly instructed (see **Build, Test, and Development Commands**)
- [Standard-Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit) must exist as a **sibling** clone at `..\Standard-Toolkit` for Dev/main solution `ProjectReference`s. Clone it there if missing (see **Standard-Toolkit Dependency**). Do not copy Standard-Toolkit sources into this repository.

## Project Structure & Module Organization

- `Source/Krypton Toolkit`: Extended modules (`Krypton.Toolkit.Suite.Extended.*`), meta-packages (`Ultimate`, `Ultimate.Lite`), and solutions:
  - `Krypton Toolkit Suite Extended 2022 - VS2022 - Dev.sln` — development; `ProjectReference`s Standard-Toolkit
  - `Krypton Toolkit Suite Extended 2022 - VS2022.sln` — main solution
  - `Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln` / `.slnx` — consumes Standard-Toolkit (and channel packages) via `PackageReference` when `$(SolutionName)` ends with `NuGet`
- `Source/Krypton Toolkit/TestForm`: WinForms sample app used to validate changes; add or extend demos here when features or bugs are completed (see **TestForm Demos**)
- `Source/Krypton Toolkit/Krypton.Toolkit.Suite.Extended.*.Tests`: xUnit projects for modules that already have automated tests (e.g. BottomSheet, Card). Add a sibling `*.Tests` project when introducing comparable logic-heavy modules.
- `Scripts/`: Build and packaging scripts; `run.cmd` (root) launches an interactive menu; toolset wrappers live under `Scripts/VS2022/` and `Scripts/Current/` (VS 2026); shared MSBuild lives under `Scripts/Build/` (`debug.proj`, `nightly.proj`, `canary.proj`, `build.proj`, `Extended.Orchestration.targets`); helpers under `Scripts/Common/` and `Scripts/CI/`
- `Bin/`: Build outputs by configuration (e.g. `Bin/Debug`); NuGet packages under `Bin/NuGet Packages/<Channel>/`; TestForm under `Bin/TestForm/`
- `Documents/`, `Assets/`, `Logs/`: Docs, images, and build logs
- `Documents/Help/Changelog.md`: User-facing release notes for completed bugs and features
- `Documents/Examples/Examples.md`: Consumer-facing usage notes and screenshots for Extended controls
- `Documents/Development/`: In-depth developer guides; **do not include new files from this folder in pull requests**
- `Documents/PR/`: One Markdown PR description per completed bug fix or feature, drafted locally and used as the GitHub PR body; **do not include that per-change description file in pull requests** (see **Pull Request Descriptions**)

There is **no** sibling Extended demos repository. `TestForm` is the interactive validation app; `Documents/Examples/Examples.md` is the consumer-facing example index.

## Architecture

- Extended Toolkit is a **suite of optional modules**, not a single control library. Each `Krypton.Toolkit.Suite.Extended.<Name>` project is a separately packable assembly.
- Modules depend on [Standard-Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit) (`Krypton.Toolkit`, and `Krypton.Ribbon` / `Krypton.Navigator` / `Krypton.Docking` / `Krypton.Interop` / `Krypton.Toolkit.Utilities` when needed). They must not fork or duplicate Standard-Toolkit types.
- Shared Extended helpers live in projects such as `Krypton.Toolkit.Suite.Extended.Common`, `Shared`, `Core`, `Resources`, and `Global.Utilities`. Prefer those over copying utilities into a new module.
- `Krypton.Toolkit.Suite.Extended.Ultimate` and `Ultimate.Lite` are meta-packages that **bundle** module assemblies (`PrivateAssets="all"` on project references). Do not reintroduce module packages as NuGet dependencies of Ultimate. Keep native binaries (e.g. `libSkiaSharp`) out of `lib/`.
- New controls should integrate with the Standard-Toolkit palette and renderer abstractions rather than hardcoding appearance.
- Designer support (smart tags, toolbox bitmaps, `*.Designer.cs`) belongs in the owning module.

## Standard-Toolkit Dependency

Dev and main solutions `ProjectReference` Standard-Toolkit as a sibling:

```
<parent>\Extended-Toolkit\          # this repository
<parent>\Standard-Toolkit\          # separate repository (clone here if missing)
```

Look only in the parent of this repository for a folder named `Standard-Toolkit`. Do **not** look under `Source\` in this repo, do **not** search other drives, and do **not** copy Standard-Toolkit projects into Extended-Toolkit.

If the sibling clone is missing:

```powershell
$extendedRoot = (Get-Location)   # Extended-Toolkit repo root
$parentDir = Split-Path $extendedRoot -Parent
$toolkitRoot = Join-Path $parentDir 'Standard-Toolkit'
.\Scripts\CI\Checkout-StandardToolkit.ps1 -Destination $toolkitRoot
```

`Scripts/CI/Checkout-StandardToolkit.ps1` clones `Krypton-Suite/Standard-Toolkit` on the matching channel branch (`alpha`, `canary`, `master`; `main` maps to `master`) and falls back to `alpha`.

- **Dev/main solutions:** `ProjectReference` `..\..\..\..\Standard-Toolkit\Source\Krypton Components\…`
- **NuGet solution:** `PackageReference` `Krypton.Standard.Toolkit`, `.Canary`, or `.Nightly` according to configuration
- Do not change Standard-Toolkit as part of an Extended feature unless the user explicitly asks. If an Extended change requires a Standard API, say so rather than patching the sibling tree by default.

## New Modules

When adding a new shipped module (not a one-off harness):

1. Create `Source/Krypton Toolkit/Krypton.Toolkit.Suite.Extended.<Name>/` with an SDK-style WinForms class-library csproj. Match a neighbour (Card or BottomSheet for recent patterns; an older `* 2022.csproj` if joining that naming).
2. Inherit TFMs from `$(ActiveExtendedToolkitTFMs)` in root `Directory.Build.props`. Use `LangVersion` preview, `<Nullable>enable</Nullable>`, `<UseWindowsForms>true</UseWindowsForms>`.
3. Use the current MIT header (copyright year through 2026). Add `Globals/GlobalDeclarations.cs` **or** a project-root `GlobalUsings.cs` (newer modules use the latter). Do not scatter new `using` directives across source files.
4. Dual references: Dev arms `ProjectReference` Standard-Toolkit; NuGet arms use `$(SolutionName.EndsWith('NuGet'))` `PackageReference`s like neighbouring projects.
5. Add the project to the **Dev**, **main**, and **NuGet** solutions.
6. If the module is part of the Ultimate bundle, add it to `Ultimate` and `Ultimate.Lite` with the same `PrivateAssets="all"` pattern as existing module refs.
7. Add a TestForm project reference, demo form, and `StartScreen.AddButtons()` registration (see **TestForm Demos**).
8. Changelog, Examples.md, and a `Documents/Development/` guide when the surface is substantial. Add a `*.Tests` project when the module has non-trivial logic (follow BottomSheet/Card).

## Editing Philosophy

- Make the smallest change that correctly solves the task.
- Keep code clean, simple, and maintainable.
- Preserve existing formatting and coding style.
- Do not refactor unrelated code.
- Do not rename identifiers unless requested.
- When adding or changing public/protected API, include scoped documentation per **Code Documentation Guidelines**; do not turn a feature or bug fix into a repo-wide documentation pass unless asked.
- Keep accompanying artefacts (changelog, developer guide, PR description, TestForm demo, Examples.md) consistent with the implementation; do not leave placeholder text from templates.

## Public API

### Compatibility

- New code must remain compatible with `net472` unless the project is Lite-only (Lite configurations exclude `net472`).
- Do not use BCL APIs that are absent on the oldest TFM of the project unless they are `#if` / TFM-guarded.
- Projects use `LangVersion` preview / latest. Language features already common here (file-scoped namespaces, nullable annotations, collection expressions, switch expressions) are allowed in new and changed code. Do not introduce syntax that the surrounding project does not already compile. Do not apply Standard-Toolkit’s C# 7.3 ceiling to this repo.

### Stability

- Preserve binary compatibility unless explicitly instructed otherwise.
- Avoid changing public or protected member signatures unless explicitly requested.
- Do not rename public types or namespaces.
- Preserve designer serialization compatibility.

## Performance

- Avoid unnecessary allocations in paint paths.
- Avoid creating disposable GDI objects inside tight rendering loops.
- Reuse existing rendering infrastructure whenever possible.

## Build, Test, and Development Commands

- Script/CI builds use phased orchestration (`Scripts/Build/Extended.Orchestration.targets`).
- Build TestForm (Debug, default TFM `net8.0-windows`):
  - `dotnet build ".\Source\Krypton Toolkit\TestForm\TestForm.csproj" -c Debug`
- Run sample app:
  - `.\run-testform.cmd` (optional TFM argument, default `net8.0-windows`)
  - `dotnet run --project ".\Source\Krypton Toolkit\TestForm\TestForm.csproj" -c Debug -f net8.0-windows`
- Debug build of the toolkit:
  - `dotnet build ".\Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022 - Dev.sln" -c Debug`
- Channel builds (only when explicitly instructed):
  - `.\run.cmd` launches the interactive menu and lets you choose `Scripts\VS2022` or `Scripts\Current` (VS 2026).
  - Direct VS2022 presets: `.\Scripts\VS2022\debug.cmd`, `.\Scripts\VS2022\build-stable.cmd`, `.\Scripts\VS2022\build-canary.cmd`, `.\Scripts\VS2022\build-nightly.cmd`.
  - Direct VS2026 presets: `.\Scripts\Current\debug.cmd`, `.\Scripts\Current\build-stable.cmd`, `.\Scripts\Current\build-canary.cmd`, `.\Scripts\Current\build-nightly.cmd`.
  - Build scripts locate MSBuild via `Scripts\Common\find-msbuild.cmd` (`vswhere.exe`, then standard install paths). Override with `MSBUILDPATH` or `MSBUILD_PATH`.
- Configurations (root `Directory.Build.props`): `Debug`; `Release` / `Canary` / `Nightly` (full TFMs including `net472`); `ReleaseLite` / `CanaryLite` / `NightlyLite` (excludes `net472`); `*All` variants build full+lite via helper scripts.
- Outputs land under `Bin\<Configuration>\` by default; packages under `Bin\NuGet Packages\<Channel>\`.
- New files must use the current MIT license header (`#region MIT License` … `Copyright (c) 2017 - 2026 Krypton Suite`). Do not add a ComponentFactory / Standard Toolkit BSD header.

## Coding Style & Naming Conventions

- Line endings/encoding: CRLF, UTF-8 with BOM
- Always verify and fix UTF-8 BOM on files you create or edit. Source and text files in this repo use UTF-8 **with** BOM; if a tool or edit strips the BOM (or writes UTF-8 without BOM), restore it before finishing. Prefer fixing encoding on files already in scope; do not expand into a repo-wide BOM pass unless asked. In PowerShell, rewrite with BOM when needed, e.g. `$utf8Bom = New-Object System.Text.UTF8Encoding $true; [System.IO.File]::WriteAllText($path, $content, $utf8Bom)`.
- Follow `Source/.editorconfig` and `Source/Krypton Toolkit/.editorconfig`
- Indentation: 4 spaces; line endings: CRLF
- Add new `using` / `global using` entries to the project’s `Globals/GlobalDeclarations.cs` or `GlobalUsings.cs` (see `Documents/Development/How to Manage Using Statements.md`). Do not add redundant usings in other files.
- Before adding new variables check for existing ones
- No variable aliasing
- New files must use only the current MIT header.

## C# Rules

- Preserve the existing nullable reference type annotations and context (`<Nullable>enable</Nullable>` is set on current projects).
- Do not enable or disable nullable in individual files unless requested.
- No unneeded `try/catch` blocks if there's no catch handling
- Idioms: use null-propagation and object/collection initializers where consistent
- Prefer [switch expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression) for simple value/type dispatch that only returns (or assigns) a value. Keep `switch` statements for complex control flow, multiple statements per arm, or side effects. Prefer a discard arm (`_ => ...`) when exhaustiveness matters. Apply to new and changed code; do not mass-convert unrelated existing code unless asked.
- Prefer the conditional (ternary) operator (`condition ? whenTrue : whenFalse`) for simple value selection in place of an `if`/`else` that only assigns or returns. Keep `if`/`else` when either branch has multiple statements, side effects beyond the assigned value, or when nesting ternaries would hurt readability. Apply to new and changed code; do not mass-convert unrelated existing code unless asked.
- Follow `.editorconfig` for expression-bodied members: properties, indexers, accessors, and lambdas may be expression-bodied; **methods, constructors, operators, and local functions stay block-bodied** (`csharp_style_expression_bodied_methods = false`). Do not mass-convert unrelated existing code unless asked.
- WinForms: `UseWindowsForms=true`; prefer designer-friendly patterns and keep partial classes tidy
- New WinForms forms, controls, and components should follow the standard Visual Studio partial-class pattern with separate `.cs`, `.Designer.cs`, and `.resx` files where appropriate. Prefer designer-backed types over single-file implementations unless explicitly requested otherwise.
- Do not place designer-generated initialization code in the main source file. Keep UI initialization in `InitializeComponent()` within the corresponding `.Designer.cs` file.
- WinForms designer: keep object declarations at file bottom; initialize in `*.Designer.cs` `InitializeComponent()`
- Do not manually edit generated `*.Designer.cs` files unless the task specifically requires it.
- Constraint: do not use `yield return` inside `catch` blocks

## Code Documentation Guidelines

Prefer **scoped meticulous documentation**: thorough XML and maintainer notes on the public/protected surface and on non-obvious implementation, without narrating boilerplate or rewriting unrelated files.

When asked to review or document code — or when adding/changing public API — document to this standard for the types and members in scope. Do not expand into large blocks of unchanged legacy code unrelated to the task (see **Editing Philosophy**).

### What to document

- **Public and protected API** — full `///` XML on types and members you add or change: `<summary>`, and `<param>` / `<returns>` / `<exception>` / `<remarks>` when they add real information (behavior, constraints, nullability contracts, thread affinity, designer impact). Prefer `<see cref="..."/>` and `<c>...</c>` for related types and values.
- **Class-level summaries** for every non-trivial type in scope, especially those in a larger model (composite trees, state machines, store/restore flows, dialog hosts). Name sibling types and the role of the class in the hierarchy. Thin subclasses and adapters may use a one-line summary that points at the base or owning type.
- **Inline comments** at decision points for:
  - Multi-step algorithms (filter/sort application, layout shrink, animation ticks)
  - State machines and message-filter / focus edge cases
  - Designer serialization quirks
  - Geometry or ordering that is not obvious from property names (z-order, hot vs draw rects, RTL placement)
- **Brief region comments** above enum groups that act as a catalog for a subsystem.
- **Internal / private helpers** — document with `///` or a short `//` only when the name alone does not convey contracts, ordering requirements, or side effects.

### What not to document

- Obvious boilerplate (`// This constructor creates an instance of X`, `// Return the result`, restating parameter names or type names).
- Members whose existing XML already accurately describes intent; extend or correct rather than rewrite wholesale (see **Comment Style** and **Documentation Stability**).
- **Event Args**, **Resources**, **Designer** / **`.Designer.cs`**, and other thin property-bag or generated files unless logic is non-trivial (then document only that logic).
- Large blocks of unchanged legacy code unrelated to the task — do not “document the world” in a feature or bug PR unless the user explicitly requests a documentation pass.

### Comment Style

- Use `///` XML documentation for public and protected types and members.
- Use `//` comments for implementation notes, algorithms, and non-obvious decisions.
- Do not use C-style block comments (`/* ... */`) or banner comments (`/** ... */` / `/*** ... ***/`) for documentation unless matching existing surrounding code. The MIT license header region is the exception.
- Keep comments close to the code they describe.
- Prefer several short `//` comments over large comment blocks.
- Comments should explain *why* code exists or *why* an approach was chosen, not simply restate what the code does.
- Keep comments **clear and concise** — one or two sentences for inline notes; XML may be slightly longer when describing contracts or edge cases. Prefer plain language over jargon.
- Match surrounding voice.
- For preservation, idempotence, and when to stop editing, follow **Documentation Stability**.

Prefer:

```csharp
// Restore orphaned pages before rebuilding the hierarchy.
// This ensures page references remain valid during layout reconstruction.
```

Avoid:

```csharp
/******************************************************************************
 * This method walks the docking tree and restores orphaned pages.
 ******************************************************************************/
```

And avoid restating the obvious (`// Increment the index.` before `index++;`). Prefer intent (`// Iterate in reverse because removing children invalidates forward indices.`).

### Documentation Stability

Documentation should be **deterministic** and converge toward a stable, maintainable state. Identical wording across every agent is not guaranteed; the objective is **substantively equivalent**, convergent documentation — stability over novelty.

For equivalent code, repeated documentation passes should produce the same or substantively equivalent documentation. Documentation passes should:

- Preserve accurate existing comments and XML documentation.
- Correct inaccurate or obsolete documentation.
- Improve incomplete documentation.
- Never reduce the accuracy or usefulness of existing documentation.
- Avoid stylistic rewrites when the existing documentation already satisfies these guidelines.

Documentation updates should be **idempotent**: running another documentation pass over already-compliant code should result in little or no change.

Do not rewrite documentation solely to change wording, sentence structure, or writing style. Only modify documentation when doing one or more of the following:

- Correcting inaccuracies
- Improving clarity where the existing text is unclear or ambiguous
- Documenting new behavior
- Removing obsolete information
- Completing missing contracts (`<param>`, `<returns>`, `<exception>`, nullability, threading, designer impact, and similar)

Preserve existing comments and XML documentation whenever they remain accurate and useful. Extend, clarify, or correct them surgically rather than replacing them wholesale. Remove or rewrite comments only when they are inaccurate, misleading, obsolete, or substantially incomplete — never rewrite solely for style. Historical and architectural notes in this codebase are often valuable; do not erase them casually.

When updating comments or XML documentation, ensure they remain consistent with the implementation after every change. Documentation is part of the code, not an afterthought. Remove or correct comments that are inaccurate, outdated, or misleading; do not leave documentation that contradicts the implementation.

Prefer improving existing documentation over inventing entirely new wording for the same facts.

Each documentation pass should converge toward a stable result. Once documentation satisfies these guidelines, future passes should make few or no changes unless the code changes.

Documentation is considered **complete** when it:

- Accurately describes current behavior
- Explains non-obvious design decisions
- Matches the implementation
- Follows repository conventions in this file
- Contains no redundant or contradictory information

Stop editing documentation that already meets this bar.

### Prioritization (large modules)

For substantial packages (e.g. Outlook Grid, TreeGridView, AdvancedDataGridView) or an explicit documentation pass, work in this order:

1. Root orchestrator and base abstractions (manager, element base, definitions/enums).
2. Core implementation layers (primary controls).
3. Specialized flows (filter/sort, persistence, designer).
4. Thin subclasses and adapters last — often a one-line class summary is enough.

Validate documentation-only changes with a targeted `dotnet build` of the affected project when practical.

## Feature Developer Documentation

When a **new feature** is completed (not bug fixes or refactors unless they introduce a substantial new capability), add a **comprehensive developer guide** as a Markdown file under `Documents/Development/`.

### When to write

- New public APIs, components, designer support, build/packaging features, or user-facing subsystems.
- Skip for trivial fixes, comment-only changes, and internal refactors with no new surface area.

### What to include

Each guide should be **in-depth** and **maintainer-focused**, covering as applicable:

- **Overview** — problem solved, scope, and which package(s) own the feature.
- **Architecture** — key types, relationships, and data/control flow (diagrams welcome).
- **Public API** — classes, interfaces, enums, events, and extension points with signatures and behavior.
- **Usage** — minimal code or designer steps; common integration patterns.
- **Configuration / persistence** — settings, XML, flags, or MSBuild properties if relevant.
- **Edge cases** — threading, TFM differences, breaking changes, migration notes.
- **Validation** — how to exercise the feature in `TestForm` (link to the demo form registered in `StartScreen`).

### TestForm demo

When the feature warrants user-visible validation, add or update a demo per **TestForm Demos** and reference it here. Also update `Documents/Examples/Examples.md` when the feature is consumer-facing.

### File conventions

- Location: `Documents/Development/`
- Name: descriptive kebab or Pascal-style title, e.g. `Krypton-BottomSheet-Developer-Guide.md`.
- One feature (or cohesive subsystem) per file; cross-link related guides when helpful.
- CRLF, UTF-8 with BOM; match tone and structure of existing repo docs.
- These guides are **local working files**. Do not include **new** developer guides in pull requests (see **Do not include in pull requests** below). Existing committed files such as `Development-Workflow.md` may be updated when the task is to change that shared workflow.

### Do not list in these files

- **Do not** add changelog entries or release notes for these guides in `Documents/Help/Changelog.md`.

Changelog stays focused on user-facing release history. Developer guides are discovered via `Documents/Development/` and code cross-references only.

### Do not include in pull requests

Write **new** developer guides under `Documents/Development/` as local working files. Do **not** stage, commit, or push them as part of a new or existing pull request. If an existing PR already contains new `Documents/Development/` files that were meant to stay local, remove those paths from the PR so they are no longer in the diff.

## Changelog

When a **bug fix** or **feature** is completed, add an entry to `Documents/Help/Changelog.md` in the same change set (or immediately before merge).

### When to update

- **Resolved** — bug fixes, regressions, and defect corrections tied to an issue.
- **Implemented** — new features, enhancements, and new public capability.
- Skip changelog updates for comment-only work, internal refactors with no user-visible effect, and `Documents/Development/` guide files (those are separate from release notes).

### Where to add

- Append to the **current in-progress release** section at the top of the file (the first `##` heading after the table of contents), e.g. `## 2026-11-xx - Build 2611 - November 2026`.
- Add new bullets **after** the section heading, before older entries in that section (newest first within the section).
- If no suitable section exists yet, follow the heading pattern used by adjacent releases.

### Entry format

Match existing style:

```markdown
* Resolved [#443](https://github.com/Krypton-Suite/Extended-Toolkit/issues/443), Short user-facing summary of the fix.
* Implemented [#494](https://github.com/Krypton-Suite/Extended-Toolkit/issues/494), Short user-facing summary of the feature.
  - Extra consumer-facing detail as nested bullets when needed
* Implemented [#9012](https://github.com/Krypton-Suite/Extended-Toolkit/issues/9012), **[Breaking Change]** Summary of what broke and what consumers must update.
```

- Prefix with `Resolved` or `Implemented` (same verbs as existing entries), or `New \`Krypton.Toolkit.Suite.Extended.<Name>\` module` when introducing a package.
- Link the GitHub issue when one exists (`[#NNNN](https://github.com/Krypton-Suite/Extended-Toolkit/issues/NNNN)`).
- If the change is **breaking** for consumers (API removal/rename, behavior change requiring migration, assembly/namespace moves), insert `**[Breaking Change]**` immediately after the issue link comma and before the summary.
- One line per item; use indented sub-bullets only when extra user-facing detail is needed (see existing entries).
- Write for **consumers** of the toolkit (what changed and why it matters), not implementation detail—that belongs in `Documents/Development/` or code comments.

### Do not add to the changelog

- Entries for developer guides under `Documents/Development/`.
- References to build-script internals unless the change is user-facing.

## TestForm Demos

`Source/Krypton Toolkit/TestForm` (`TestForm.csproj`) is the primary interactive validation app. When a **feature** is completed, add a **comprehensive demo** or **append to an existing demo** (do not overwrite) so maintainers and reviewers can exercise the capability without reading source first.

### When to add or update

- **Features** — new controls, APIs, designer behavior, dialogs, or subsystems: add or expand a demo.
- **Existing demo** — if a TestForm demo already exists for that control or feature, **do not overwrite or replace it**. Keep the current form, instructions, and scenarios; **append** (new section, tab, control, or case) so the new capability can be exercised alongside what is already there.
- **Bug fixes** — add a minimal repro when none exists; append to an existing demo when the fix changes observable behavior worth regression-testing.
- Skip demos for comment-only work, pure refactors, or changes with no UI/API surface.

### Registration

- Register every new form in `StartScreen.AddButtons()` via `CreateButton<TForm>(heading, description)`.
- Heading: short title (often includes issue number for bug demos).
- Description: what to try, expected outcome, and which scenarios are covered.
- Follow existing naming: `BugNNNNShortName` for issue repros; `FeatureNameExample` or `FeatureNameTest` for broader showcases (see `BottomSheetExample`, `CardExample`, `AdvancedDataGridViewFilterSortExample`).

### Demo content

A good demo is **comprehensive** for its scope:

- Exercises the main API paths, properties, events, and theme/palette switches relevant to the change.
- Includes short on-form instructions (labels or a read-only text block) so manual steps are obvious.
- Uses `KryptonForm` and Krypton / Extended controls for the host unless the scenario requires otherwise.
- Keeps designer-friendly structure: logic in `*.cs`, layout in `*.Designer.cs` `InitializeComponent()`.

### Krypton vs standard WinForms

Where the feature is a **Krypton or Extended replacement or wrapper** for a built-in control (or parity/behavior is the point), provide a **side-by-side comparison** when practical:

- Place native WinForms control(s) and Krypton/Extended control(s) in the same form (e.g. split columns in a `TableLayoutPanel`), matching size, text, and interaction where possible.
- Label each side clearly (e.g. “Native TextBox” / “KryptonTextBox”).
- Document what should match and what is intentionally different.

Skip the comparison when there is no meaningful WinForms equivalent.

### Project conventions

- Add new `.cs` / `.Designer.cs` / `.resx` files; SDK-style `TestForm.csproj` picks up compiles automatically, but add `ProjectReference`s for any new Extended module.
- If the demo needs a new Extended namespace, add a `global using` in `TestForm/GlobalUsings.cs`.
- Run: `.\run-testform.cmd` or `dotnet run --project ".\Source\Krypton Toolkit\TestForm\TestForm.csproj" -c Debug -f net8.0-windows`
- TestForm TFMs are `net8.0-windows` (default) and `net481`. net4x builds need preserialized `.resx` resources (MSB3823) — already configured via `Source/Krypton Toolkit/Directory.Build.props`.
- Also update `Documents/Examples/Examples.md` for consumer-facing features.

## Testing Guidelines

- Automated tests exist for some modules (`Krypton.Toolkit.Suite.Extended.BottomSheet.Tests`, `Krypton.Toolkit.Suite.Extended.Card.Tests`, xUnit). Run those when the owning module changes. There is no repo-wide unit-test suite.
- Validate UI changes via `TestForm` scenarios (see **TestForm Demos**)
- When fixing a bug, add/adjust a minimal repro in `TestForm` and describe manual steps in the PR
- When completing a **feature**, add or append a comprehensive demo in `TestForm` per **TestForm Demos** (include Krypton vs WinForms comparison where appropriate; do not overwrite an existing demo)
- When completing a bug fix or feature, update `Documents/Help/Changelog.md` per **Changelog** in this file

## Unit Test Scripts

If you create PowerShell scripts that drive or inspect a Debug `TestForm` build (host a demo form, synthesise mouse input, capture screenshots), keep them under `Scripts/UnitTests/` rather than `Bin/`. Create the folder if needed. These complement manual `TestForm` checks; they are not a substitute for a demo and are not run by CI unless explicitly wired later.

### When to create or update

- Creating throwaway `.ps1` files under `Bin/` during a bug investigation is fine for the session, but **before the work is finished**, move or rewrite the keepers into `Scripts/UnitTests/` with clear names and brief `.SYNOPSIS` / `.DESCRIPTION` help.
- Prefer extending an existing unit-test script over adding a near-duplicate.
- Do not check in screenshots or `Bin/` output produced by these scripts.

## Commit & Pull Request Guidelines

- Commits: short, imperative subject; reference issues/PRs (e.g. `Fix TreeGridView expand performance (#411)` or `443 AdvancedDataGridView filter sort`)
- PRs: clear description, linked issues, screenshots/gifs for UI changes, notes on breaking changes/TFM impact
- If a pull request is opened or created, it must be compared with `alpha`, not `master`, `canary`, or `main`. When using `gh pr create`, set the base branch to `alpha` (for example `--base alpha`).
- Branches (see `Documents/Development/Development-Workflow.md`): `alpha` (nightly / active development), `canary` (beta), `master` (stable annual release; some docs say `main` — treat `master` as the stable default).
- Completed bugs and features: update `Documents/Help/Changelog.md` (see **Changelog** above); add or append a `TestForm` demo for features (see **TestForm Demos**; do not overwrite an existing demo); update `Documents/Examples/Examples.md` when consumer-facing; write a `Documents/Development/` guide when the feature warrants in-depth maintainer docs, and a PR description in `Documents/PR/` (see **Pull Request Descriptions** below). **Do not include** new `Documents/Development/` files or the per-change `Documents/PR/` description file in the pull request (new or existing). Use the PR description file as the GitHub PR body (`gh pr create --base alpha --body-file Documents/PR/<file>.md`).
- Do not add routine validation noise to commit messages or PR descriptions. Mention checks only when they are essential context, unusual, failed, or specifically requested.

## Pull Request Descriptions

When a **bug fix** or **feature** is completed, create a **PR description** as a Markdown file in the `Documents/PR/` folder **before** the pull request is opened. The file is the reviewer-facing record: use it **as the GitHub PR body** (`gh pr create --base alpha --body-file Documents/PR/<file>.md`), and do **not** include that file in the pull request. When the pull request is opened or created, compare it with `alpha`, not `master`, `canary`, or `main` (see **Commit & Pull Request Guidelines**).

### When to add

- **Resolved** — bug fixes, regressions, and defect corrections.
- **Implemented** — new features, enhancements, and new public capability.
- Skip for comment-only work and internal refactors with no user-visible effect (same policy as **Changelog**).

### File conventions

- Location: `Documents/PR/`
- Copy `Documents/PR/TEMPLATE.md` to `Documents/PR/<issue-or-branch>-<short-title>.md`, e.g. `Documents/PR/443-adgv-filter-sort.md`. Use the issue number when one exists.
- One file per bug fix or feature (or the cohesive set of changes going into a single PR).
- CRLF, UTF-8 with BOM; match the tone and structure of existing repo docs.
- Keep the per-change file **local**: do not stage, commit, or push it as part of the pull request.

### Opening the pull request

- Use this file **as** the GitHub PR description. Do not write a second body.
- Prefer `gh pr create --base alpha --body-file Documents/PR/<file>.md` (or the equivalent `--body-file` when updating). On Windows PowerShell, pass the path as a single argument; do not rely on shell quotes around a pasted body (see **Recent Tooling Mistakes To Avoid**).
- Do not include this per-change file, or any **new** file under `Documents/Development/`, in the commits that make up a new or existing PR.

### What to include

Fill in every applicable section of `Documents/PR/TEMPLATE.md` (delete those that do not apply):

- **Summary** — consumer-facing description of what changed and why it matters.
- **Related issues** — `Closes #NNNN` when an issue exists.
- **Type of change** — bug fix / feature / breaking change / docs.
- **Changes** — notable changes grouped by area or project.
- **Affected packages & target frameworks** — only those touched/verified.
- **Validation** — `TestForm` demo name, manual steps, and the build command used.
- **Screenshots / GIFs** — for any UI change.
- **Changelog** — the matching `Documents/Help/Changelog.md` entry.
- **Breaking changes & migration** — what consumers must update, if anything.
- **Developer documentation** — link to the `Documents/Development/` guide for substantial features.

### Do not

- Do not add changelog entries or release notes inside `Documents/PR/` files — those belong in `Documents/Help/Changelog.md`.
- Do **not** include the per-change PR description file (`Documents/PR/<issue-or-branch>-<short-title>.md`) in a new or existing pull request. Write it locally, use it as the GitHub PR body, and leave it untracked (or unstaged) relative to the PR. Leave `TEMPLATE.md` and `README.md` in this folder alone unless the task is to update those shared files.
- Do **not** include **new** files under `Documents/Development/` in a new or existing pull request. If an existing PR already contains those files or the per-change PR description, remove them from the PR so they are no longer in the diff.

## Security & Configuration Tips

- Windows long paths must be enabled to build locally. Build on Windows for `-windows` TFMs and .NET Framework.
- Do not commit secrets, `.snk` usage notes beyond existing project paths, or machine-specific MSBuild paths.
