using CommunityToolkit.Mvvm.ComponentModel;

namespace Game.UI;

public sealed partial class UiOptions : ObservableObject
{
	[ObservableProperty] private bool _fullscreen;
	[ObservableProperty] private bool _showFps = true;
	[ObservableProperty] private double _uiScale = 1.0;
	[ObservableProperty] private bool _vSync = true;
}
