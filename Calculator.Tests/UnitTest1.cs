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
    public void TwoSummands(string value)
    {
        // Given
        int a = int.Parse(value.Split(',')[0]);
        int b = int.Parse(value.Split(',')[1]);
        
        // When
        int result = _calculator.Add(value);

        // Then
        Assert.That(result, Is.EqualTo(a + b));
    }

    [Test]
    public void ManySummandsTest()
    {
        // Given
        string numbers = "1,2,3,4,5,6";

        // When
        int result = _calculator.Add(numbers);

        // Then
        Assert.That(result, Is.EqualTo(21));
    }

    [Test]
    public void SingleSummandTest()
    {
        // Given
        string numbers = "33";

        // When
        int result = _calculator.Add(numbers);

        // Then
        Assert.That(result, Is.EqualTo(33));
    }

    [Test]
    public void EmptyStringTest()
    {
        // Given
        string numbers = "";

        // When
        int result = _calculator.Add(numbers);

        // Then
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void NewlineAsSeparatorTest()
    {
        // Given
        string numbers = "4\n9,6";

        // When
        int result = _calculator.Add(numbers);

        // Then
        Assert.That(result, Is.EqualTo(19));
        

    }

    [Test]
    public void CustomSeparatorTest()
    {
        // Given
        string numbers = "//;;\n1;;2;;3";

        // When
        int result = _calculator.Add(numbers);

        // Then
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void OneNegativeTest()
    {
        // Given
        string numbers = "-1,2,3";

        // When
        // Then
        var exc = Assert.Throws<NegativeArgumentsException>(() => _calculator.Add(numbers));
        Assert.That(exc.Message, Is.EqualTo("Negative arguments provided: -1"));
    }

    [Test]
    public void MultipleNegativesTest()
    {
        // Given
        string numbers = "-1,2,13,-48,0,-2";

        // When
        // Then
        var exc = Assert.Throws<NegativeArgumentsException>(() => _calculator.Add(numbers));
        Assert.That(exc.Message, Is.EqualTo("Negative arguments provided: -1 -48 -2"));
    }

    [Test]
    public void MultipleNegativesAndCustomDelimiterTest()
    {
        // Given
        string numbers = "//;;\n7;;2;;-13;;-1111;;0;;-0";

        // When
        // Then
        var exc = Assert.Throws<NegativeArgumentsException>(() => _calculator.Add(numbers));
        Assert.That(exc.Message, Is.EqualTo("Negative arguments provided: -13 -1111"));
    }

    [Test]
    public void MultipleCustomDelimitersTest()
    {
        // Given
        string numbers = "//[*][;;][$]\n7;;2$1;;2*0*4$1";

        // When
        int result = _calculator.Add(numbers);

        // Then
        Assert.That(result, Is.EqualTo(17));
    }

    [Test]
    public void NumbersOver1000WithMultipleCustomDelimitersTest()
    {
        // Given
        string numbers = "//[(][delim]\n7(2(1delim1001delim999(4delim1";

        // When
        int result = _calculator.Add(numbers);

        // Then
        Assert.That(result, Is.EqualTo(1014));
    }

    [Test]
    public void SingleNumberOver1000Test()
    {
        // Given
        string numbers = "1001";

        // When
        int result = _calculator.Add(numbers);

        // Then
        Assert.That(result, Is.EqualTo(0));
    }
}