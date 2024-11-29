public class DocumentFactory : IFactory<Document> {
    public Document CreateLightTheme() {
        return new Document("White", "Black");
    }

    public Document CreateDarkTheme() {
        return new Document("Black", "White");
    }
}
