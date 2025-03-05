// Ćwiczenie 5: Niestandardowe asercje i zaawansowane przypadki
public class CustomAssertionsExercise
{
    [Fact]
    public void TestWithCustomComparer()
    {
        Person expected = new Person(1, "Jan", "Kowalski", 30);
        Person actual = GetPerson();

        // Użycie własnego komparatora do porównania obiektów
        Assert.Equal(expected, actual, new PersonComparer());

        // TODO: Napisz asercję używającą niestandardowego komparatora do porównania dwóch obiektów Product
        Product product1 = new Product(1, "Product 1 White", 105, 80, "P1");
        Product product2 = new Product(2, "Product 1 Black", 100, 80, "P1");
        Assert.Equal(product1, product2, new ProductComparer());
    }

    [Fact]
    public void TestPropertyValues()
    {
        User user = GetUser();

        // Sprawdzanie wielu właściwości obiektu
        Assert.Multiple(
            () => Assert.Equal("john.doe@example.com", user.Email),
            () => Assert.True(user.IsActive),
            () => Assert.InRange(user.Person.Age, 18, 100));

        // TODO: Utwórz metodę pomocniczą AssertValidUser i użyj jej do sprawdzenia właściwości obiektu user
        User user2 = GetUser() with { Person = GetPerson() };
        AssertValidUser(user2);
    }

    // Metody i klasy pomocnicze do testów
    private Person GetPerson() => new Person(1, "Jan", "Kowalski", 30);
    private User GetUser() => new User("john.doe@example.com", true, GetPerson());

    private record Person(int Id, string FirstName, string LastName, int Age);

    private record User(string Email, bool IsActive, Person Person);

    private record Product(int Id, string Name, decimal SellPrice, decimal BuyPrice, string Code);

    private class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName && x.Age == y.Age;
        }

        public int GetHashCode(Person obj) => obj.Id.GetHashCode();
    }

    private class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.Code == y.Code && x.BuyPrice == y.BuyPrice;
        }

        public int GetHashCode(Product obj) => obj.Id.GetHashCode();
    }

    private void AssertValidUser(User user)
    {
        Assert.NotNull(user);
        Assert.True(user.IsActive);
        Assert.NotNull(user.Person);
        Assert.NotNull(user.Person.FirstName);
        Assert.NotEmpty(user.Person.FirstName);
        Assert.NotNull(user.Person.LastName);
        Assert.NotEmpty(user.Person.LastName);
    }
}