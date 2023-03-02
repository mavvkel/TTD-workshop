namespace Calculator.Tests;

public class Tests
{
    Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }


    [TestCase("1,2")]
    [TestCase("2,3")]
    public void Test1(string value)
    {
        // Given
        int a = int.Parse(value.Split(',')[0]);
        int b = int.Parse(value.Split(',')[1]);
        
        // When
        int result = _calculator.Add(value);

        // Then
        Assert.That(result, Is.EqualTo(a + b));
    }

    [TestCase("1")]
    [TestCase("123546")]
    public void Test2(string value)
    {
        // Given
        int a = int.Parse(value);
        
        // When
        int result = _calculator.Add(value);

        // Then
        Assert.That(result, Is.EqualTo(a));
    }
}