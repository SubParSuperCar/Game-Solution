#!/usr/bin/env bash

for name in godot godot4; do
    CMD="$(command -v "$name" 2>/dev/null)"
    if [ -n "$CMD" ]; then
        exec "$CMD" "$@"
    fi
done

SCRIPT_DIR="$(cd -- "$(dirname -- "$0")" && pwd)"
if [ -x "$SCRIPT_DIR/bin/godot" ]; then
    exec "$SCRIPT_DIR/bin/godot" "$@"
fi

echo "Godot not found." >&2
exit 1
