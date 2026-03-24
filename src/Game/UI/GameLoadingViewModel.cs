using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Godot;

namespace Game.UI;

public sealed partial class GameLoadingViewModel(INavigator navigator) : ViewModel
{
	// We're loading an almost empty scene: it's nearly instantaneous.
	// For demo purposes (we want to show the loading screen), set the real loading to be 50% of the total loading,
	// and simulate the rest by waiting.
	private const double RealProgressRatio = 1f / 8f;

	[ObservableProperty] private bool _isLoading = true;

	[ObservableProperty] private double _loadingProgress;

	// Tracks each component independently so that a late real-progress report
	// can never move the bar backward past what the simulated progress already showed.
	private double _realProgress;
	private double _simulatedProgress;

	private void UpdateLoadingProgress()
		=> LoadingProgress = Math.Max(
			_realProgress * RealProgressRatio,
			RealProgressRatio + _simulatedProgress * (1.0 - RealProgressRatio)
		);

	protected override async Task LoadAsync()
	{
		await Task.Delay(TimeSpan.FromSeconds(0.4));

		var gameScene = await AsyncGdResourceLoader.LoadAsync<PackedScene>(
			"res://scenes/game.tscn",
			ResourceLoader.CacheMode.Ignore,
			new SceneLoadProgress(this)
		);

		var gameNode = gameScene.Instantiate();

		await SimulateProgressAsync();

		LoadingProgress = 1.0;
		await Task.Delay(TimeSpan.FromSeconds(0.1));

		navigator.NavigateTo(new GameViewModel { GameNode = gameNode });
		await TryCloseAsync();
		IsLoading = false;
	}

	private async Task SimulateProgressAsync()
	{
		var delayInMs = (double)Random.Shared.Next(2000, 3000);
		var stopwatch = Stopwatch.StartNew();

		while (_simulatedProgress < 1.0)
		{
			await Task.Delay(TimeSpan.FromSeconds(0.1));
			_simulatedProgress = Math.Min(1.0, stopwatch.ElapsedMilliseconds / delayInMs);
			UpdateLoadingProgress();
		}
	}

	private sealed class SceneLoadProgress(GameLoadingViewModel owner) : IProgress<double>
	{
		public void Report(double value)
		{
			owner._realProgress = value;
			owner.UpdateLoadingProgress();
		}
	}
}
