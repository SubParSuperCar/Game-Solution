using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Game.UI;

public sealed partial class OptionsViewModel(UiOptions uiOptions) : ViewModel
{
	private bool _canApply;

	[ObservableProperty] private bool _fullscreen = uiOptions.Fullscreen;

	[ObservableProperty] private bool _showFps = uiOptions.ShowFps;

	[ObservableProperty]
	[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Name required for correct property generation")]
	private double _UIScale = uiOptions.UIScale;

	[ObservableProperty] private bool _vSync = uiOptions.VSync;

	public bool CanApply
	{
		get => _canApply;
		private set
		{
			if (SetProperty(ref _canApply, value))
				ApplyCommand.NotifyCanExecuteChanged();
		}
	}

	protected override void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		base.OnPropertyChanged(e);

		if (e.PropertyName is nameof(VSync) or nameof(Fullscreen) or nameof(ShowFps) or nameof(UIScale))
			CanApply = true;
	}

	protected override Task LoadAsync()
	{
		return Task.CompletedTask;
	}

	[RelayCommand(CanExecute = nameof(CanApply))]
	private void Apply()
	{
		uiOptions.VSync = VSync;
		uiOptions.Fullscreen = Fullscreen;
		uiOptions.ShowFps = ShowFps;
		uiOptions.UIScale = UIScale;
		CanApply = false;
	}
}
