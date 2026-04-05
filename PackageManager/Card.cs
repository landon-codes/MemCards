namespace MemCardsPackageManager;

public class Card
{
    public Card(string term, string definition, string? imagePath)
    {
        this.term = term;
        this.definition = definition;
        this.imagePath = imagePath;
    }

    public string term { get; set; }
    public string definition { get; set; }
    public string? imagePath { get; set; } // Tells where to find an image for the card
}