using Avalonia;
using Estragonia;
using Godot;

namespace Game.UI;

public sealed partial class AvLoader : Node
{
	public override void _Ready() =>
		AppBuilder
			.Configure<App>()
			.UseGodot()
			.LogToTrace()
			.SetupWithoutStarting();
}
