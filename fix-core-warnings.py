#!/usr/bin/env python3
"""Bulk-fix common nullable/XML patterns in Extended.Core project."""
import re
import os
from pathlib import Path

CORE = Path(r"z:\Development\Krypton\Extended-Toolkit\Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Core")

def fix_file(path: Path, replacements: list[tuple[str, str]]) -> bool:
    text = path.read_text(encoding='utf-8-sig')
    original = text
    for old, new in replacements:
        text = text.replace(old, new)
    if text != original:
        path.write_text(text, encoding='utf-8-sig')
        return True
    return False

def fix_equals_overrides(text: str) -> str:
    text = re.sub(
        r'public override bool Equals\(object obj\)',
        'public override bool Equals(object? obj)',
        text
    )
    text = re.sub(
        r'public bool Equals\((\w+) other\)',
        r'public bool Equals(\1? other)',
        text
    )
    return text

def fix_event_handlers(text: str) -> str:
    # object sender -> object? sender (but not object? sender)
    text = re.sub(r'\bobject sender\b(?!\?)', 'object? sender', text)
    return text

def process_cs_file(path: Path) -> bool:
    text = path.read_text(encoding='utf-8-sig')
    original = text
    text = fix_equals_overrides(text)
    text = fix_event_handlers(text)
    if text != original:
        path.write_text(text, encoding='utf-8-sig')
        return True
    return False

def main():
    changed = []
    for cs in CORE.rglob('*.cs'):
        if process_cs_file(cs):
            changed.append(str(cs.relative_to(CORE)))
    print(f"Auto-fixed {len(changed)} files for Equals/event handlers")
    for f in changed:
        print(f"  {f}")

if __name__ == '__main__':
    main()
