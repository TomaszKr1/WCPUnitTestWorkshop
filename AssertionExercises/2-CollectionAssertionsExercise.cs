// Ćwiczenie 2: Asercje dla kolekcji
public class CollectionAssertionsExercise
{
    [Fact]
    public void TestListContainsAssertions()
    {
        List<string> fruits = new List<string> { "apple", "banana", "orange" };

        Assert.Contains("banana", fruits);
        Assert.DoesNotContain("grape", fruits);

        // TODO: Napisz asercję sprawdzającą, czy lista zawiera element spełniający określony warunek
    }

    [Fact]
    public void TestCollectionEquality()
    {
        int[] expected = [1, 2, 3, 4];
        int[] actual = GetNumbers();

        Assert.Equal(expected, actual);

        int[] expected2 = [2, 4, 3, 1];
        // TODO: Napisz asercję sprawdzającą, czy dwie kolekcje zawierają te same elementy, ale niekoniecznie w tej samej kolejności
    }

    [Fact]
    public void TestCollectionProperties()
    {
        List<string> emptyList = new List<string>();
        List<string> nonEmptyList = new List<string> { "item" };

        Assert.Empty(emptyList);
        Assert.NotEmpty(nonEmptyList);
        Assert.Single(nonEmptyList);

        // TODO: Napisz asercję sprawdzającą, czy kolekcja zwrócona przez GetUsers ma dokładnie 3 elementy
    }

    // Metody pomocnicze do testów
    private int[] GetNumbers() => [1, 2, 3, 4];

    private record struct User(int Id, string Name);
    private User[] GetUsers() =>
    [
        new User { Id = 1, Name = "Alice" },
        new User { Id = 2, Name = "Bob" },
        new User { Id = 3, Name = "Charlie" }
    ];
}