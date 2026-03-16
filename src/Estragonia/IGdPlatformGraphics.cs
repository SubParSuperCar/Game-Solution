using System;
using Avalonia.Platform;

namespace Estragonia;

/// <summary>Interface for Godot platform graphics implementations.</summary>
internal interface IGdPlatformGraphics : IPlatformGraphics, IDisposable
{
	/// <summary>Gets the shared GPU context.</summary>
	/// <returns>The shared GPU context.</returns>
	new IGdSkiaGpu GetSharedContext();

	/// <summary>Adds a reference to this platform graphics instance.</summary>
	void AddRef();

	/// <summary>Releases a reference to this platform graphics instance.</summary>
	void Release();
}
