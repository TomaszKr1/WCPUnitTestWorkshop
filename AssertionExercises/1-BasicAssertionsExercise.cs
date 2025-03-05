// �wiczenie 1: Podstawowe asercje warto�ci
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

        // TODO: Napisz asercj� sprawdzaj�c�, czy dwie zmienne typu double s� sobie r�wne z dok�adno�ci� do 0.001
    }

    [Fact]
    public void TestBooleanAssertions()
    {
        bool isValid = ValidateInput("correctInput");

        Assert.True(isValid);

        // TODO: Napisz asercj� sprawdzaj�c�, czy ValidateInput zwraca false dla niepoprawnych danych
    }

    [Fact]
    public void TestNullAssertions()
    {
        object obj1 = null;
        object obj2 = new object();

        Assert.Null(obj1);
        Assert.NotNull(obj2);

        // TODO: Napisz asercj� sprawdzaj�c�, czy metoda CreateUserIfAuthorized zwraca null dla nieautoryzowanego dost�pu
    }

    // Metody pomocnicze do test�w
    private int CalculateAnswer() => 42;
    private string GetUserName() => "John";
    private bool ValidateInput(string input) => input == "correctInput";
    private string? CreateUserIfAuthorized(string currentUser, string newUser)
        => currentUser == "admin" && !string.IsNullOrEmpty(newUser) ? newUser : null;
}