namespace MemCardsPackageManager;
using System.Text.Json;
using System.Text.Json.Nodes;
using JsonStorage;

public class CardSet
{   public CardSet()
    {
        title = "None";
        description = null;
        authors = null;
        cards = new List<Card>();
    }
    public CardSet (string filePath) : this()
    {
        // Read the file
        StorageDictionary<string, dynamic?> importedSet = new(filePath);
        importedSet.Load();

        // Shortens a very long check
        bool IsNull(string key)
        {
            return !importedSet.container.ContainsKey(key) && importedSet.container[key]!.ValueKind != JsonValueKind.Null;
        }

        // Get the set data
        if (!IsNull("title"))
        {
            title = importedSet.container["title"]!.ToString();
        }
        else
        {
            Console.Error.WriteLine("Set does not have a title");
            Environment.Exit(1);
        }
        description = importedSet.container["description"];
        authors = importedSet.container["authors"];
        
        // Get the set cards
        if (!IsNull("cards"))
        {
            try
            {
                cards = new List<Card>();
                int cardCount = importedSet.container["cards"]!.GetArrayLength();
                for (int i = 0; i < cardCount; i++)
                {
                    JsonElement currentCard = importedSet.container["cards"]![i];

                    cards.Add(new Card(
                        currentCard[0]!.ToString(),
                        currentCard[1]!.ToString(),
                        currentCard[2].ToString()
                    ));
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"There was an error reading the cards\n{e}");
                Environment.Exit(1);
            }
        }
        else
        {
            Console.Error.WriteLine("The set has no cards.");
            Environment.Exit(1);
        }
    }
    public CardSet(string setTitle, List<Card> setCards, string? setDescription, string? setAuthors) : this()
    {
        title = setTitle;
        cards = setCards;

        description = setDescription;
        authors = setAuthors;
    }
    

    public string title { get; set; }
    public string? description { get; set; }
    public string? authors { get; set; }
    public List<Card> cards { get; set; }

    public void WriteJson(string filePath)
    {
        StorageDictionary<string, dynamic?> set = new(filePath);

        // Create the metadata
        set.container["title"] = this.title;
        set.container["description"] = this.description;
        set.container["authors"] = this.authors;
        
        // Sets the cards
        int cardCount = this.cards.Count();
        set.container["cards"] = new string[cardCount][];
        for (int i = 0; i < cardCount; i++)
        {
            set.container["cards"]![i] = new string[] {this.cards[i].term, this.cards[i].definition, this.cards[i].imagePath!};
        }

        set.Save();
    }
}