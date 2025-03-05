// Ćwiczenie 4: Asercje dla typów i referencji
public class TypeAssertionsExercise
{
    [Fact]
    public void TestTypeAssertions()
    {
        object result = GetValue();

        Assert.IsType<string>(result);

        // Sprawdzenie, czy obiekt jest określonego typu lub jego pochodną
        object animal = new Dog();
        Assert.IsAssignableFrom<Animal>(animal);

        // TODO: Napisz asercję sprawdzającą, czy metoda CreateAnimal zwraca obiekt typu Cat dla argumentu "cat"
    }

    [Fact]
    public void TestReferenceAssertions()
    {
        object obj1 = new object();
        object obj2 = obj1;
        object obj3 = new object();

        Assert.Same(obj1, obj2);  // Te same referencje
        Assert.NotSame(obj1, obj3);  // Różne referencje

        // TODO: Napisz asercję sprawdzającą, czy dwa wywołania metody GetSingletonInstance zwracają tę samą instancję
    }

    // Klasy pomocnicze do testów
    private object GetValue() => "test";

    private Animal CreateAnimal(string type) => type switch
    {
        "dog" => new Dog(),
        "cat" => new Cat(),
        _ => throw new ArgumentException("Unknown animal type")
    };

    private record Animal();
    private record Dog() : Animal;
    private record Cat() : Animal;

    private class Singleton
    {
        private static Singleton instance;
        private Singleton() { }
        public static Singleton GetSingletonInstance()
        {
            return instance ??= new Singleton();
        }
    }
}