using Moq;

namespace MockingExercises.Events;

public class PriceChangedEventArgs : EventArgs
{
    public string Symbol { get; set; }
    public decimal Price { get; set; }
}

public interface IStockTicker
{
    event EventHandler<PriceChangedEventArgs> PriceChanged;
}

public class StockTrader
{
    public decimal LastPrice { get; private set; }
    public void OnPriceChanged(object sender, PriceChangedEventArgs e) => LastPrice = e.Price;
}

public class StockTraderTests
{
    [Fact]
    public void PriceChangedEvent_RaisesAndUpdatesTraderLastPrice()
    {
        // Arrange
        var stockTickerMock = new Mock<IStockTicker>();
        var trader = new StockTrader();
        stockTickerMock.Object.PriceChanged += trader.OnPriceChanged;

        var expectedPrice = 150.25m;

        // Act
        // TODO: Raise the PriceChanged event with the expected price
        stockTickerMock.Raise(ticker => ticker.PriceChanged += null,
            new PriceChangedEventArgs { Symbol = "MSFT", Price = expectedPrice });

        // Assert
        Assert.Equal(expectedPrice, trader.LastPrice);
    }
}