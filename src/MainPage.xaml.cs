using System.IO;
using MemCardsPackageManager;

namespace MemCards;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		if (!Directory.Exists("AppData/Cards"))
		{
			Directory.CreateDirectory("AppData/Cards");
		}

		// Add the cards to the main menu
		// NOTE: If you have a better idea for how to do this, please do!
		string[] setDirs = Directory.GetDirectories("AppData/Cards");
		foreach (string set in setDirs)
		{
			try
			{
				// Sets SHOULD only have **1** json file.
				// If there are more than one, we're going to ignore the rest
				string[] jsonFiles = Directory.GetFiles($"AppData/Cards/{set}", "*.json");
				CardSet importedSet = new CardSet($"AppData/Cards/{set}/{jsonFiles[0]}");
			}
			catch (Exception)
			{
				Console.WriteLine("A card set failed to load; it may be corrupted or misconfigured.");
			}
		} 
	}
}
