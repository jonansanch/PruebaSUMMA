using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            var calculadora = new Calcular();
            var numeros = new List<double> { 10, 20, 30, 40, 50, 60, 10, 20,40 };

            double media = calculadora.CalcularMedia(numeros);
            Console.WriteLine($"La media de la lista de números es: {media}");

            double mediaArmonica = calculadora.CalcularMediaArmonica(numeros);
            Console.WriteLine($"La media armónica de la lista de números es: {mediaArmonica}");

            double mediana = calculadora.CalcularMediana(numeros);
            Console.WriteLine($"La mediana de la lista de números es: {mediana}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

public class Calcular
{
    public double CalcularMedia(List<double> numeros)
    {
        if (numeros == null || numeros.Count == 0)
        {
            throw new ArgumentException("La lista de números no puede ser nula o vacía.");
        }

        double suma = 0;

        foreach (var numero in numeros)
        {
            suma += numero;
        }

        return Math.Round(suma / numeros.Count, 2);
    }

    public double CalcularMediaArmonica(List<double> numeros)
    {
        if (numeros == null || numeros.Count == 0)
        {
            throw new ArgumentException("La lista de números no puede ser nula o vacía.");
        }

        double sumaInversos = 0;

        foreach (var numero in numeros)
        {
            if (numero == 0)
            {
                throw new ArgumentException("Los números en la lista no pueden ser cero para calcular la media armónica.");
            }

            sumaInversos += 1.0 / numero;
        }

        return Math.Round(numeros.Count / sumaInversos, 2);
    }


    public double CalcularMediana(List<double> numeros)
    {
        if (numeros == null || numeros.Count == 0)
        {
            throw new ArgumentException("La lista de números no puede ser nula o vacía.");
        }

        // Ordenar la lista de números
        var numerosOrdenados = numeros.OrderBy(x => x).ToList();

        int n = numerosOrdenados.Count;

        // Calcular la mediana según la paridad de la cantidad de elementos
        if (n % 2 == 0)
        {
            // Si hay un número par de elementos, la mediana es el promedio de los dos números centrales.
            return Math.Round((numerosOrdenados[(n / 2) - 1] + numerosOrdenados[n / 2]) / 2.0, 2);
        }
        else
        {
            // Si hay un número impar de elementos, la mediana es el número central.
            return Math.Round(numerosOrdenados[n / 2], 2);
        }
    }
}