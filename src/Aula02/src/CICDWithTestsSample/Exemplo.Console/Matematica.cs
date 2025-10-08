namespace Exemplo.Console;


public static class Matematica
{

    public static int Somar(int a, int b) => a + b;

    public static int Subtrair(int a, int b) => a - b;


    public static double FormulaBaskara(int a, int b, int c)
    {
        var delta = Math.Sqrt(b * b - 4 * a * c);
        var resultado = (-b - delta) / (2 * a);
        return resultado;
    }
}