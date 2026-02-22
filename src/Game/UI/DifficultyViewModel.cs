using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Game.UI;

public sealed partial class DifficultyViewModel(INavigator navigator) : ViewModel
{
	[ObservableProperty] private GameDifficulty _selectedDifficulty = GameDifficulty.Normal;

	public ObservableCollection<GameDifficulty> Difficulties { get; } = new(Enum.GetValues<GameDifficulty>());

	protected override Task LoadAsync() => Task.CompletedTask;

	[RelayCommand]
	private async Task StartGameAsync()
	{
		navigator.NavigateTo(new GameLoadingViewModel(navigator));
		await TryCloseAsync();
	}
}
