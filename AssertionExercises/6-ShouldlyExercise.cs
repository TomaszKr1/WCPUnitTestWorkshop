using Shouldly;

// Ćwiczenie 6: Asercje z użyciem Shouldly
public class ShouldlyExercise
{
    [Fact]
    public void TestShouldly()
    {
        string actual = "Hello World";
        actual.ShouldSatisfyAllConditions(
            a => a.ShouldStartWith("Hello"),
            a => a.ShouldEndWith("World"),
            a => a.ShouldContain(" "));

        int number = 42;
        number.ShouldBeGreaterThan(40);
        number.ShouldBeLessThan(50);

        // TODO: Napisz asercję używającą Shouldly do sprawdzenia, czy lista zwrócona przez GetUsers zawiera dokładnie 3 elementy i zawiera użytkownika o id równym 2
        User[] users = GetUsers();
        users.ShouldNotBeNull();
        users.Length.ShouldBe(3);
        users.ShouldContain(u => u.Id == 2);
    }

    private record struct User(int Id, string Name);
    private User[] GetUsers() => [
        new User { Id = 1, Name = "Alice" },
        new User { Id = 2, Name = "Bob" },
        new User { Id = 3, Name = "Charlie" }
    ];
}