using System;
using Godot;

namespace Estragonia;

/// <summary>Factory for creating the appropriate platform graphics implementation.</summary>
internal static class GdPlatformGraphicsFactory
{
	/// <summary>Creates the appropriate platform graphics implementation based on the current renderer.</summary>
	/// <returns>A Vulkan or Metal platform graphics implementation.</returns>
	public static IGdPlatformGraphics Create()
	{
		_ = RenderingServer.GetRenderingDevice() ??
		    throw new NotSupportedException("Estragonia requires Forward+ or Mobile renderer");

		if (ShouldUseMetal())
			return new GdMtlPlatformGraphics();

		return new GdVkPlatformGraphics();
	}

	/// <summary>Determines whether to use the Metal backend.</summary>
	private static bool ShouldUseMetal()
	{
		// Only use Metal on macOS/iOS
		if (!OperatingSystem.IsMacOS() && !OperatingSystem.IsIOS())
			return false;

		// Check if user explicitly requested Vulkan via project settings
		var settings = ProjectSettings.Singleton;
		if (!settings.HasSetting("rendering/rendering_device/driver.macos"))
			return true;

		var macosDriver = settings.GetSetting("rendering/rendering_device/driver.macos").AsString();
		// True: Default to Metal on Apple platforms
		// False: User explicitly wants Vulkan (via MoltenVK)
		return macosDriver != "vulkan";
	}
}
