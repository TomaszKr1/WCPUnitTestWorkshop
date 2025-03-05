// Æwiczenie 1: Podstawowe asercje wartoœci
public class BasicAssertionsExercise
{
    [Fact]
    public void TestEqualityAssertions()
    {
        // Przygotowanie danych testowych
        int expectedValue = 42;
        int actualValue = CalculateAnswer();
        string expectedName = "John";
        string actualName = GetUserName();

        // Asercje
        Assert.Equal(expectedValue, actualValue);
        Assert.Equal(expectedName, actualName);

        // TODO: Napisz asercjê sprawdzaj¹c¹, czy dwie zmienne typu double s¹ sobie równe z dok³adnoœci¹ do 0.001
    }

    [Fact]
    public void TestBooleanAssertions()
    {
        bool isValid = ValidateInput("correctInput");

        Assert.True(isValid);

        // TODO: Napisz asercjê sprawdzaj¹c¹, czy ValidateInput zwraca false dla niepoprawnych danych
    }

    [Fact]
    public void TestNullAssertions()
    {
        object obj1 = null;
        object obj2 = new object();

        Assert.Null(obj1);
        Assert.NotNull(obj2);

        // TODO: Napisz asercjê sprawdzaj¹c¹, czy metoda CreateUserIfAuthorized zwraca null dla nieautoryzowanego dostêpu
    }

    // Metody pomocnicze do testów
    private int CalculateAnswer() => 42;
    private string GetUserName() => "John";
    private bool ValidateInput(string input) => input == "correctInput";
    private string? CreateUserIfAuthorized(string currentUser, string newUser)
        => currentUser == "admin" && !string.IsNullOrEmpty(newUser) ? newUser : null;
}