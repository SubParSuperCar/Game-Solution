#!/usr/bin/env sh

echo "Runtime context: POSIX Shell"

PATH_CANDIDATES="godot godot4"

for name in $PATH_CANDIDATES; do
    path="$(command -v "$name" 2>/dev/null)"
    if [ -n "$path" ]; then
        echo "Found via PATH ($name): $path"
        exec "$path" "$@"
    fi
done

SCRIPT_DIR="$(cd -- "$(dirname -- "$0")" && pwd)"
GODOT_PATH="$SCRIPT_DIR/bin/godot"

if [ -x "$GODOT_PATH" ]; then
    echo "Found via local bin: $GODOT_PATH"
    exec "$GODOT_PATH" "$@"
fi

echo "Godot not found via PATH or local bin." >&2
exit 1
