using Avalonia;
using Avalonia.Input;

namespace Estragonia;

/// <summary>Contains extensions methods for <see cref="AppBuilder" /> related to Godot.</summary>
public static class AppBuilderExtensions
{
	public static AppBuilder UseGodot(this AppBuilder builder) =>
		builder
			.UseStandardRuntimePlatformSubsystem()
			.UseSkia()
			.UseWindowingSubsystem(GdPlatform.Initialize)
			.AfterSetup(_ =>
				AvaloniaLocator.CurrentMutable
					.Bind<IKeyboardNavigationHandler>().ToTransient<GdKeyboardNavigationHandler>()
			);
}
