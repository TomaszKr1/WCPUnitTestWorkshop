// Ćwiczenie 3: Asercje dla wyjątków
public class ExceptionAssertionsExercise
{
    [Fact]
    public void TestExceptionThrown()
    {
        // Sprawdzanie czy metoda rzuca określony wyjątek
        var exception = Assert.Throws<ArgumentNullException>(() => ProcessData(null));

        // Sprawdzanie właściwości wyjątku
        Assert.Equal("data", exception.ParamName);

        // TODO: Napisz asercję sprawdzającą, czy metoda ValidateAge rzuca ArgumentOutOfRangeException dla wieku -5
    }

    [Fact]
    public async Task TestAsyncExceptionThrown()
    {
        // Sprawdzanie wyjątków w metodach asynchronicznych
        await Assert.ThrowsAsync<InvalidOperationException>(() => ProcessDataAsync(0));

        // TODO: Napisz asercję sprawdzającą, czy asynchroniczna metoda FetchUserDataAsync rzuca TimeoutException po upływie czasu oczekiwania
    }

    // Metody pomocnicze do testów
    private void ProcessData(string data)
    {
        if (data == null)
            throw new ArgumentNullException("data");
    }

    private bool ValidateAge(int age)
    {
        if (age < 0)
            throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be negative");
        return true;
    }

    private async Task ProcessDataAsync(int value)
    {
        await Task.Delay(10); // Symulacja asynchronicznej operacji
        if (value == 0)
            throw new InvalidOperationException("Value cannot be zero");
    }

    private async Task<bool> FetchUserDataAsync(int value)
    {
        var goodTask = Task.Delay(value); // Symulacja asynchronicznej operacji 
        var timeoutTask = Task.Delay(100);
        if (await Task.WhenAny(goodTask, timeoutTask) == timeoutTask)
        {
            throw new TimeoutException("Operation timed out");
        }

        return true;
    }
}