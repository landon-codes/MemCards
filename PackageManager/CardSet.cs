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
            Directory.CreateDirectory(setPath);

        StorageDictionary<string, JsonElement?> set = new(filePath);

        // Convert simple fields
        set.container["title"]       = JsonSerializer.SerializeToElement(this.title);
        set.container["description"] = JsonSerializer.SerializeToElement(this.description);
        set.container["authors"]     = JsonSerializer.SerializeToElement(this.authors);

        // Build cards array
        var cardArray = new List<object>();

        foreach (var card in this.cards)
        {
            cardArray.Add(new[]
            {
                card.term,
                card.definition,
                card.imagePath
            });
        }

        // Convert cards list → JsonElement
        set.container["cards"] = JsonSerializer.SerializeToElement(cardArray);

        set.Save();
    }
}