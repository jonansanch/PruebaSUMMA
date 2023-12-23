using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Seleccione que funcionalidad desea ver:");
            Console.WriteLine("1. Funcionalidad 1");
            Console.WriteLine("2. Funcionalidad 2");

            string opcion = Console.ReadLine();
            int opcionInt = opcion == string.Empty || int.TryParse(opcion, out _) == false ? 0 : int.Parse(opcion);

            switch (opcionInt)
            {
                case 1:
                    Funcionalidad1();
                    break;
                case 2:
                    Funcionalidad2();
                    break;
                default:
                    Console.WriteLine("Este numero de funcionalidad no existe, vuelva a intentarlo mas tarde.");
                    break;
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void Funcionalidad1()
    {
        try
        {
            var calculos = new Calcular();
            var numeros = new List<double> { 10, 20, 30, 40, 50, 60, 10, 20, 40, 25 };

            double media = calculos.CalcularMedia(numeros);
            Console.WriteLine($"La media de la lista de números es: {media}");

            double mediaArmonica = calculos.CalcularMediaArmonica(numeros);
            Console.WriteLine($"La media armónica de la lista de números es: {mediaArmonica}");

            double mediana = calculos.CalcularMediana(numeros);
            Console.WriteLine($"La mediana de la lista de números es: {mediana}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void Funcionalidad2()
    {
        try
        {
            Console.WriteLine($"Soy la funcionalidad 2");
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

        double suma = numeros.Sum(x => x);

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

        var numerosOrdenados = numeros.OrderBy(x => x).ToList();

        int cantidadNumeros = numerosOrdenados.Count;

        if (cantidadNumeros % 2 == 0)
        {
            return Math.Round((numerosOrdenados[(cantidadNumeros / 2) - 1] + numerosOrdenados[cantidadNumeros / 2]) / 2.0, 2);
        }
        else
        {
            return Math.Round(numerosOrdenados[cantidadNumeros / 2], 2);
        }
    }
}