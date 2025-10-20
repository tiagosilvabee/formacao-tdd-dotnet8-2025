namespace calculator.lib;

public class Calculator : ICalculator
{
    public float Somar(float a, float b)
    {
        return a + b;
    }

    public float Subtrair(float a, float b)
    {
        return a - b;
    }
}