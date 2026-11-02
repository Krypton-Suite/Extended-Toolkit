# Standard Toolkit submodule

Dev and main builds compile against [Standard Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit) checked out at `Standard-Toolkit/` in this repository. The superproject stores a gitlink (one commit SHA). NuGet channel builds keep their `PackageReference` versions and do not read this pin.

## Layout

- Submodule path: `Standard-Toolkit/`
- URL: `https://github.com/Krypton-Suite/Standard-Toolkit.git`
- Module projects: `..\..\..\Standard-Toolkit\Source\Krypton Components\...`
- Solutions under `Source/Krypton Toolkit/`: `..\..\Standard-Toolkit\Source\Krypton Components\...`

`.gitmodules` stores `path` and `url` only. There is no `branch` key, so `git submodule update --remote` is not part of the workflow.

## Populate

```powershell
git clone --recurse-submodules https://github.com/Krypton-Suite/Extended-Toolkit.git
```

Or, after a clone that left `Standard-Toolkit/` empty:

```powershell
.\Scripts\CI\Checkout-StandardToolkit.ps1
```

That script runs `git submodule update --init --depth 1 -- Standard-Toolkit`. CI uses the same command so the submodule stays a shallow checkout of the recorded SHA.

## Move the pin

Fetch the commit you want, detach the submodule there, then commit the gitlink in Extended Toolkit:

```powershell
git -C Standard-Toolkit fetch --depth 1 origin <sha>
git -C Standard-Toolkit checkout --detach <sha>
git add -- Standard-Toolkit
```

Do not edit Standard Toolkit files from an Extended change. If Extended needs a new Standard API, land that API in Standard Toolkit first, then bump this pin.

## Channel branches

Extended and Standard Toolkit use the same channel branch names. The gitlink on an Extended branch must be a commit from the Standard Toolkit branch of that name:

| Extended branch | Standard Toolkit branch |
| --- | --- |
| `alpha` | `alpha` |
| `canary` | `canary` |
| `master` | `master` |
| `gold` | `gold` |
| `V105-LTS` | `V105-LTS` |

CI checks out the SHA stored on the Extended branch it is building. This change pins Standard Toolkit `alpha` at `7232f2ebda081e9fb61b7da1ec862b17b1da9e99`. Landing the submodule on `canary`, `master`, `gold`, or `V105-LTS` must retarget the gitlink to that Standard branch's tip in the same merge. Leaving the `alpha` SHA in place would build those channels against Standard `alpha`.

```powershell
git -C Standard-Toolkit fetch --depth 1 origin canary
git -C Standard-Toolkit checkout --detach FETCH_HEAD
git add -- Standard-Toolkit
```

Replace `canary` with `master`, `gold`, or `V105-LTS` on those branches. A later update on a channel is the same commands plus a commit of the gitlink.
