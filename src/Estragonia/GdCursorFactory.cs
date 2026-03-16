using System;
using Avalonia;
using Avalonia.Input;
using Avalonia.Platform;

namespace Estragonia;

internal sealed class GdCursorFactory : ICursorFactory
{
	public ICursorImpl GetCursor(StandardCursorType cursorType) =>
		new GdStandardCursorImpl(cursorType.ToGodotCursorShape());

	public ICursorImpl CreateCursor(IBitmapImpl cursor, PixelPoint hotSpot) =>
		throw new NotSupportedException("Custom cursors aren't supported");
}
