using Avalonia.Controls;
using Avalonia.Controls.Embedding;
using Avalonia.Input;

namespace Estragonia;

/// <summary>
///     A <see cref="TopLevel" /> used with Godot.
///     This is implicitly created by <see cref="AvControl" />.
/// </summary>
public sealed class GdTopLevel : EmbeddableControlRoot
{
	static GdTopLevel()
		// TopLevel has Cycle navigation mode, but we want the focus to be able to leave Avalonia to return back to godot: use Continue
	{
		KeyboardNavigation.TabNavigationProperty.OverrideDefaultValue<GdTopLevel>(KeyboardNavigationMode.Continue);
	}

	internal GdTopLevel(GdTopLevelImpl impl)
		: base(impl)
	{
		Impl = impl;
	}

	internal GdTopLevelImpl Impl { get; }
}
