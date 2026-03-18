#!/usr/bin/env sh

echo "POSIX Shell"

for name in godot godot4; do
    if command -v "$name" >/dev/null 2>&1; then
        exec "$name" "$@"
    fi
done

SCRIPT_DIR="$(cd -- "$(dirname -- "$0")" && pwd)"
if [ -x "$SCRIPT_DIR/bin/godot" ]; then
    exec "$SCRIPT_DIR/bin/godot" "$@"
fi

echo "Godot not found." >&2
exit 1
