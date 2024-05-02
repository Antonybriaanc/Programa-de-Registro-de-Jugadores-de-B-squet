using System;

// Definición de la estructura Estudiante
struct Estudiante
{
    public string nombre;
    public decimal estatura;
}

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            // Mostrar mensaje de instrucción al usuario
            Console.WriteLine("Por favor, ingrese los datos de los estudiantes.");
            Console.WriteLine("Recuerde que la estatura debe escribirse con coma decimal.");

            // Solicitar al usuario la cantidad de estudiantes
            int cantidadEstudiantes = SolicitarNumero("Ingrese la cantidad de estudiantes: ");

            // Declarar un arreglo de estudiantes
            Estudiante[] estudiantes = new Estudiante[cantidadEstudiantes];

            // Variables para el atleta más alto y el total de estaturas
            string atletaMasAlto = "";
            decimal estaturaMaxima = decimal.MinValue;
            decimal totalEstaturas = 0;

            // Solicitar los datos de cada estudiante
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.WriteLine($"\nIngrese los datos del estudiante {i + 1}:");
                string nombre = "";

                // Validar el nombre del estudiante
                do
                {
                    nombre = SolicitarTexto("Nombre: ");
                    if (nombre.Length < 2)
                    {
                        Console.WriteLine("El nombre debe tener al menos 2 caracteres.");
                    }
                } while (nombre.Length < 2);

                decimal estatura = 0;

                // Validar la estatura del estudiante
                do
                {
                    estatura = SolicitarEstatura("Estatura (en metros): ");
                    if (estatura <= 0 || estatura > 2.50m)
                    {
                        Console.WriteLine("La estatura debe estar en el rango de 0 a 2.50 metros.");
                    }
                } while (estatura <= 0 || estatura > 2.50m);

                // Guardar los datos en el arreglo de estudiantes
                estudiantes[i].nombre = nombre;
                estudiantes[i].estatura = estatura;

                // Actualizar el atleta más alto
                if (estatura > estaturaMaxima)
                {
                    atletaMasAlto = nombre;
                    estaturaMaxima = estatura;
                }

                // Sumar la estatura al total
                totalEstaturas += estatura;
            }

            // Calcular el promedio de las estaturas
            decimal promedioEstaturas = totalEstaturas / cantidadEstudiantes;

            // Mostrar la información
            Console.WriteLine($"\nAtleta de mayor estatura: {atletaMasAlto} ({EstaturaEnMetrosYCentimetros(estaturaMaxima)})");
            Console.WriteLine($"Promedio de estaturas: {EstaturaEnMetrosYCentimetros(promedioEstaturas)}");

            Console.WriteLine("\nPresione una tecla para realizar otro cálculo o un número para salir.");
            ConsoleKeyInfo key = Console.ReadKey();
            if (!char.IsDigit(key.KeyChar))
            {
                Console.Clear(); // Limpiar la consola antes de realizar otro cálculo
            }
            else
            {
                continuar = false; // Salir del bucle
            }
        }
    }

    // Función para validar y solicitar la estatura del estudiante
    static decimal SolicitarEstatura(string mensaje)
    {
        decimal estatura = 0; // Inicializar la variable estatura
        bool esEstaturaValida;
        do
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();

            // Verificar si la entrada es nula o vacía
            if (string.IsNullOrEmpty(entrada))
            {
                Console.WriteLine("Por favor, ingrese un valor para la estatura.");
                esEstaturaValida = false;
                continue;
            }

            // Intentar convertir la entrada a un número
            if (!decimal.TryParse(entrada.Replace('.', ','), out estatura))
            {
                Console.WriteLine("Por favor, ingrese un valor numérico para la estatura.");
                esEstaturaValida = false;
                continue;
            }

            // Verificar si la estatura está en el rango válido
            if (estatura <= 0 || estatura > 2.50m)
            {
                Console.WriteLine("La estatura debe estar en el rango de 0 a 2.50 metros.");
                esEstaturaValida = false;
                continue;
            }

            esEstaturaValida = true;

        } while (!esEstaturaValida);

        return estatura;
    }

    // Función para convertir la estatura de metros a metros y centímetros
    static string EstaturaEnMetrosYCentimetros(decimal estaturaEnMetros)
    {
        int metros = (int)estaturaEnMetros;
        int centimetros = (int)((estaturaEnMetros - metros) * 100);
        return $"{metros} metros {centimetros} centímetros";
    }

    // Función para solicitar un texto al usuario
    static string SolicitarTexto(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine();
    }

    // Función para solicitar un número al usuario con validación
    static int SolicitarNumero(string mensaje)
    {
        int numero;
        bool esNumero;
        do
        {
            Console.Write(mensaje);
            esNumero = int.TryParse(Console.ReadLine(), out numero);
            if (!esNumero || numero <= 0)
            {
                Console.WriteLine("Por favor, ingrese un valor numérico entero mayor que cero.");
            }
        } while (!esNumero || numero <= 0);
        return numero;
    }
}
