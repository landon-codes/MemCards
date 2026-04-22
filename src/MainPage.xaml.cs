using System.IO;
using MemCardsPackageManager;

namespace MemCards;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		string cardsRoot = Path.Combine("AppData", "Cards");

		if (!Directory.Exists(cardsRoot))
			Directory.CreateDirectory(cardsRoot);

		// Load each card set folder
		string[] setDirs = Directory.GetDirectories(cardsRoot);

		foreach (string setDir in setDirs)
		{
			try
			{
				// Get JSON files inside this set directory
				string[] jsonFiles = Directory.GetFiles(setDir, "*.json");

				if (jsonFiles.Length == 0)
					continue; // No valid card set here

				// Use the first JSON file
				string jsonPath = jsonFiles[0];

				CardSet importedSet = new CardSet(jsonPath);

				CardList.Children.Add(new Button
				{
					Text = importedSet.title,
					ClassId = jsonPath
				});
			}
			catch (Exception)
			{
				Console.WriteLine("A card set failed to load; it may be corrupted or misconfigured.");
			}
		}
	}

	public async void OnNewSetButtonClicked(Object? _, EventArgs? __)
	{
		await Navigation.PushAsync(new CreateSetPage());
	}
}
