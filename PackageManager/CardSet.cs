namespace MemCardsPackageManager;

using JsonStorage;

public class CardSet
{
    public CardSet(string setTitle, List<Card> setCards, string? setDescription, string? setAuthors)
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