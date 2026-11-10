using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

class MainClass{
    private const string rutaCsv = "acb2526.csv";
    public static void Main(string [] args)
    {
        Datos datos = new Datos();
        bool salir = false;
        while (salir != true)
        {
            Console.WriteLine("\nEXÁMEN - FICHEROS DE TEXTO Y CSV\n");
            Console.WriteLine("¿Qué quieres hacer?\n");
            Console.WriteLine("1. Visualizar datos de un equipo.\n");
            Console.WriteLine("2. Visualizar datos de una jornada concreta.\n");
            Console.WriteLine("3. Visualizar top 3 de los MVPs.\n");
            Console.WriteLine("4. Visualizar clasificación.\n");
            Console.WriteLine("5. Guardar todos los datos en ficheros únicos para los diferentes equipos.\n");
            Console.WriteLine("6. Salir de la aplicación.\n");
            Console.WriteLine("Pulse un número del 1 al 6:\n");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    datos.VisualizarEquipo(rutaCsv);
                    break;
                case "2":
                    datos.VisualizarJornada(rutaCsv);
                    break;
                case "3":
                    datos.VisualizarTop(rutaCsv);
                    break;
                case "4":
                    datos.VisualizarClasificacion(rutaCsv);
                    break;
                case "5":
                    datos.GuardarFicheros(rutaCsv);
                    break;
                case "6":
                    salir = true;
                    datos.CerrarAplicacion();
                    break;
                default:
                    Console.WriteLine("Opción no válida, prueba otra vez o sal usando el 3");
                    break;
            }
        }
    }
}