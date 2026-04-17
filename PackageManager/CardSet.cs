namespace MemCardsPackageManager;
using System.Text.Json;
using System.IO;
using JsonStorage;

public class CardSet
{   public CardSet()
    {
        title = "None";
        description = null;
        authors = null;
        cards = new List<Card>();
    }
    public CardSet(string filePath) : this()
    {
        // Load the file
        var importedSet = new StorageDictionary<string, JsonElement?>(filePath);
        importedSet.Load();

        var container = importedSet.container;

        // Helper: safely check for missing or null JSON values
        bool IsNull(string key)
        {
            if (!container.TryGetValue(key, out JsonElement? value))
                return true;

            // If the value is null → treat as null
            if (value is null)
                return true;

            return value.Value.ValueKind == JsonValueKind.Null;
        }

        // --- Required fields ---

        if (IsNull("title"))
            throw new InvalidDataException("Set does not have a title.");

        title = container["title"].ToString()!;

        // Optional fields
        description = IsNull("description") ? null : container["description"]!.ToString();
        authors     = IsNull("authors")     ? null : container["authors"]!.ToString();

        // --- Cards ---

        if (IsNull("cards"))
            throw new InvalidDataException("Set has no cards.");

        JsonElement cardsElement = container["cards"]!.Value;

        if (cardsElement.ValueKind != JsonValueKind.Array)
            throw new InvalidDataException("The 'cards' field must be a JSON array.");

        cards = new List<Card>();

        foreach (var cardElement in cardsElement.EnumerateArray())
        {
            if (cardElement.ValueKind != JsonValueKind.Array)
                throw new InvalidDataException("Each card must be an array.");

            var arr = cardElement.EnumerateArray().ToArray();

            if (arr.Length < 3)
                throw new InvalidDataException("Each card must contain at least 3 elements.");

            cards.Add(new Card(
                arr[0].ToString(),
                arr[1].ToString(),
                arr[2].ToString()
            ));
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
        string? setPath = Path.GetDirectoryName(filePath);
        if (setPath != null)
        {
            Directory.CreateDirectory(setPath);
        }

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