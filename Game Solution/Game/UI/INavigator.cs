namespace Game.UI;

public interface INavigator
{
	void NavigateTo(ViewModel viewModel);

	void Quit();
}
