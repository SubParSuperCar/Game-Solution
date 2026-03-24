using Avalonia;
using Avalonia.Markup.Xaml;

namespace Game.UI;

public class App : Application
{
	public override void Initialize() => AvaloniaXamlLoader.Load(this);
}
