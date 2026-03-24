using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Game.UI;

public sealed partial class OptionsViewModel(UiOptions uiOptions) : ViewModel
{
	[ObservableProperty] private bool _fullscreen = uiOptions.Fullscreen;
	[ObservableProperty] private bool _showFps = uiOptions.ShowFps;
	[ObservableProperty] private double _uiScale = uiOptions.UiScale;
	[ObservableProperty] private bool _vSync = uiOptions.VSync;

	public bool CanApply =>
		VSync != uiOptions.VSync
		|| Fullscreen != uiOptions.Fullscreen
		|| ShowFps != uiOptions.ShowFps
		// ReSharper disable once CompareOfFloatsByEqualityOperator
		|| UiScale != uiOptions.UiScale;

	protected override void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		base.OnPropertyChanged(e);

		if (e.PropertyName is nameof(VSync) or nameof(Fullscreen) or nameof(ShowFps) or nameof(UiScale))
			ApplyCommand.NotifyCanExecuteChanged();
	}

	protected override Task LoadAsync() => Task.CompletedTask;

	[RelayCommand(CanExecute = nameof(CanApply))]
	private void Apply()
	{
		uiOptions.VSync = VSync;
		uiOptions.Fullscreen = Fullscreen;
		uiOptions.ShowFps = ShowFps;
		uiOptions.UiScale = UiScale;
		ApplyCommand.NotifyCanExecuteChanged();
	}
}
