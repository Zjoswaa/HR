namespace W07._1._2O01_UnitTests;

[TestClass]
public class FactoryPatternTest {
    [TestMethod]
    public void CreateLightTheme_Document() {
        // Create a new DocumentFactory object and and create a document with a light theme
        DocumentFactory documentFactory = new();
        Document document = documentFactory.CreateLightTheme();
        // Assert that both the document BackGroundColor and FontColor contain the expected values for this theme.
        Assert.AreEqual(document.BackGroundColor, "White");
        Assert.AreEqual(document.FontColor, "Black");
    }

    [TestMethod]
    public void CreateDarkTheme_Document() {
        // Create a new DocumentFactory object and and create a document with a dark theme
        DocumentFactory documentFactory = new();
        Document document = documentFactory.CreateDarkTheme();
        // Assert that both the document BackGroundColor and FontColor contain the expected values for this theme.
        Assert.AreEqual(document.BackGroundColor, "Black");
        Assert.AreEqual(document.FontColor, "White");
    }

    [TestMethod]
    public void CreateLightTheme_IDE() {
        // Create a new IDEFactory object and create an ide with a light theme
        IDEFactory ideFactory = new();
        IDE ide = ideFactory.CreateLightTheme();
        // Assert that both the document BackGroundColor, FontColor and ButtonColor contain the expected values for this theme.
        Assert.AreEqual(ide.BackGroundColor, "White");
        Assert.AreEqual(ide.FontColor, "Black");
        Assert.AreEqual(ide.ButtonColor, "Light blue");
    }

    [TestMethod]
    public void CreateDarkTheme_IDE() {
        // Create a new IDEFactory object and and create an ide with a dark theme
        IDEFactory ideFactory = new();
        IDE ide = ideFactory.CreateDarkTheme();
        // Assert that both the document BackGroundColor, FontColor and ButtonColor contain the expected values for this theme.
        Assert.AreEqual(ide.BackGroundColor, "Black");
        Assert.AreEqual(ide.FontColor, "White");
        Assert.AreEqual(ide.ButtonColor, "Light yellow");
    }
}
