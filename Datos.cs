using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public class Datos
{
    //Carpeta donde se almacenarán los ficheros .txt
    private string carpeta = "ficheros";
    // Metodo para ver los datos de un equipo en concreto que indique el usuario
    public void VisualizarEquipo(string rutaCsv)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Introduce el nombre del equipo el cual quieres visualizar: ");
            string equipo = Console.ReadLine();

            //Comprobamos que los datos que ha metido el usuario están bien y existen
            if (!File.Exists(rutaCsv))
            {
                Console.WriteLine("La ruta del CSV no es correcta, por favor arreglela y vuelva a intentarlo.");
                return;
            } 
            if (string.IsNullOrWhiteSpace(equipo))
            {
                Console.WriteLine("No se ha introducido un nombre de equipo válido, no puede estar vacío.");
                return;
            }
            //Leemos todas las lineas del fichero csv y las almacenamos en una array de string
            string [] lineas = File.ReadAllLines(rutaCsv);
            List <string> resultados = new List<string>();
            //Variable para el equipo que estamos buscando, quitamos espacios con trim() y lo pasamos a minusculas para evitar errores
            string equipoBuscado = equipo.Trim().ToLower();

            foreach (string linea in lineas)
            {
                //Comprobamos si hay lineas vacias y las ignoramos para que no nos den errores
                if (string.IsNullOrWhiteSpace(linea))
                {
                    continue;
                }
                //Separamos los campos por los , como separadores
                string [] campos = linea.Split(',');
                string equipoLocal = campos[1].Trim().ToLower();
                string equipoVisitante = campos[2].Trim().ToLower();
                //Comprobamos si coincide con el equipo local o visitante
                if (equipoLocal == equipoBuscado || equipoVisitante == equipoBuscado)
                {
                    resultados.Add(linea);
                    Console.WriteLine(linea);
                }
            }
            if (resultados.Count == 0)
            {
                Console.WriteLine("No se han encontrado partidos de este equipo.");
                return;
            } else
            {
                //Le pedimos al usuario un nombre para nuestro archivo si hay más de 0 registros y creamos un directorio.
                Console.WriteLine("\nIntroduce un nombre para guardar el archivo .txt (Si no quieres guardarlos pulsa q):");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre del archivo no puede estar en vacío o tener espacios en blanco");
                    return;
                }
                // Si pulsa 'q' o 'Q', salimos sin guardar y volvemos al menú
                if (nombre.Trim().ToLower() == "q")
                {
                    Console.WriteLine("No se guardará el archivo, volviendo al menú...");
                    return;
                }
                Directory.CreateDirectory(carpeta);
                string rutaTxt = Path.Combine(carpeta, nombre);
                File.WriteAllLines(rutaTxt, resultados);
                Console.WriteLine($"Se ha guardado correctamente el archivo .txt en: {rutaTxt}");
            }
        } catch (Exception ex)
        {
            Console.WriteLine($"Ha habido un fallo al procesar los datos: {ex.Message}");
        }
    }
    // Este método se encarga de enseñarnos los datos de los resultados de una jornada en concreto
    public void VisualizarJornada(string rutaCsv)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Introduce 'Jornada' y el número de la jornada que quieres visualizar: ");
            string jornada = Console.ReadLine();

            //Comprobamos que los datos que ha metido el usuario están bien y existen
            if (!File.Exists(rutaCsv))
            {
                Console.WriteLine("La ruta del CSV no es correcta, por favor arreglela y vuelva a intentarlo.");
                return;
            } 
            if (string.IsNullOrWhiteSpace(jornada))
            {
                Console.WriteLine("No se ha introducido un nombre de jornada válido, no puede estar vacío ni tener espacio en blanco.");
                return;
            }
            //Leemos todas las lineas del fichero csv y las almacenamos en una array de string
            string [] lineas = File.ReadAllLines(rutaCsv);
            List<string> resultadoJornada = new List<string>();
            //Variable para la jornada que estamos buscando, quitamos espacios con trim() y lo pasamos a minusculas para evitar errores. 
            string jornadaBuscada = jornada.Trim().ToLower();

            foreach (string linea in lineas)
            {
                //Comprobamos si hay lineas vacias y las ignoramos para que no nos den errores
                if (string.IsNullOrWhiteSpace(linea))
                {
                    continue;
                }
                //Separamos los campos por los , como separadores
                string [] campos = linea.Split(',');
                //El campo 0 tiene la jornada
                string jornadaCampo = campos[0].Trim().ToLower();
                //Comprobamos si coincide con el la jornadaBuscada y la jornadaCampo
                if (jornadaCampo == jornadaBuscada)
                {
                    resultadoJornada.Add(linea);
                    Console.WriteLine(linea);
                }
            }
            if (resultadoJornada.Count == 0)
            {
                Console.WriteLine("No se han encontrado jornadas disponibles.");
                return;
            } else
            {
                //Le pedimos al usuario un nombre para nuestro archivo si hay más de 0 registros y creamos un directorio.
                Console.WriteLine("\nIntroduce un nombre para guardar el archivo .txt (Si no quieres guardarlos pulsa q):");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre del archivo no puede estar en vacío o tener espacios en blanco");
                    return;
                }
                // Si pulsa 'q' o 'Q', salimos sin guardar y volvemos al menú
                if (nombre.Trim().ToLower() == "q")
                {
                    Console.WriteLine("No se guardará el archivo, volviendo al menú...");
                    return;
                }
                Directory.CreateDirectory(carpeta);
                string rutaTxt = Path.Combine(carpeta, nombre);
                File.WriteAllLines(rutaTxt, resultadoJornada);
                Console.WriteLine($"Se ha guardado correctamente el archivo .txt en: {rutaTxt}");
            }
        } catch (Exception ex)
        {
            Console.WriteLine($"Fallo al visualizar la jornada: {ex.Message}");
        }
    }
    public void VisualizarTop(string rutaCsv)
    {
        try
        {
            Console.Clear();
            //Comprobamos que los datos que ha metido el usuario están bien y existen
            if (!File.Exists(rutaCsv))
            {
                Console.WriteLine("La ruta del CSV no es correcta, por favor arreglela y vuelva a intentarlo.");
                return;
            } 
            //Leemos todas las lineas del fichero csv y las almacenamos en una array de string
            string [] lineas = File.ReadAllLines(rutaCsv);
            //Creamos 2 listas para guardar los nombres de los MVPs y las veces que se repiten
            List<string> nombresMvps = new List<string>();
            List<int> cont = new List<int>();
            //Empezamos en 1 para saltarnos la cabecera del csv y recorremos las lineas
            for (int i = 1; i < lineas.Length; i++)
            {
                string linea = lineas[i];
            
                // Comprobamos si hay líneas vacías y las ignoramos para que no nos den errores
                if (string.IsNullOrWhiteSpace(linea))
                {
                    continue;
                }
                string [] campos = linea.Split(',');
                // El nombre del jugador MVP se encuentra en la columna índice 4 (`mvp_partido`)
                if (campos.Length > 4)
                {
                    string mvp = campos[4].Trim();

                    if (!string.IsNullOrWhiteSpace(mvp))
                    {
                        // Buscamos si el jugador ya está registrado en la lista de nombres
                        int indice = nombresMvps.IndexOf(mvp);
                        //Con el IndexOf conseguimos la posicion de los jugadores que encuentra, si no encuentra devuelve -1, asique sería la primera vez que lo registramos pero si no devuelve -1 le sumamos 1 al contador porque ya estaba registrado.
                        if (indice != -1)
                        {
                            // Si ya existe, incrementamos el contador en 1 
                            cont[indice]++;
                        }
                        else
                        {
                            // Si no existe, lo añadimos por primera vez con un contador de 1
                            nombresMvps.Add(mvp);
                            cont.Add(1);
                        }
                    }
                }
            }
            if (nombresMvps.Count == 0)
            {
                Console.WriteLine("No se han encontrado datos de MVPs disponibles.");
                return;
            }
            List<string> lineasTop = new List<string>();
            lineasTop.Add("TOP 3 MVPs");         
            int total = 3;
            if (nombresMvps.Count < 3)
            {
                total = nombresMvps.Count;
            }   
            //Hacemos un bucle para sacar los 3 puestos y mirar en que posicion va cada uno 
            for (int i = 0; i < total; i++)
            {
                int max = 0;

                // Buscamos en la lista cuál es la posición del jugador con el número más alto de mvps 
                for (int j = 1; j < cont.Count; j++)
                {
                    if (cont[j] > cont[max])
                    {
                        max = j;
                    }
                }
                //Le ponemos + 1 para que no salga 0 de primera posicion
                int puesto = i + 1;
                string texto = $"{puesto}º MVP: {nombresMvps[max]} — {cont[max]} veces";
                Console.WriteLine(texto);
                lineasTop.Add(texto);

                // Ponemos el contador a -1 para que en la siguiente vuelta del bucle 'i' busque al segundo mejor jugador y no al primero
                cont[max] = -1;
            }
            // Le pedimos al usuario un nombre para nuestro archivo si hay más de 0 registros y creamos un directorio
            Console.WriteLine("\nIntroduce un nombre para guardar el archivo .txt (Si no quieres guardarlos pulsa q):");
            string nombre = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre del archivo no puede estar en vacío o tener espacios en blanco");
                return;
            }

            // Si pulsa 'q' o 'Q', salimos sin guardar y volvemos al menú
            if (nombre.Trim().ToLower() == "q")
            {
                Console.WriteLine("No se guardará el archivo, volviendo al menú...");
                return;
            }

            Directory.CreateDirectory(carpeta);
            string rutaTxt = Path.Combine(carpeta, nombre);
            File.WriteAllLines(rutaTxt, lineasTop);
            Console.WriteLine($"Se ha guardado correctamente el archivo .txt en: {rutaTxt}");
        } catch (Exception ex)
        {
            Console.WriteLine($"Ha habido un problema al calcular el top de MVPs: {ex.Message}");
        }
    }

    public void VisualizarClasificacion(string rutaCsv)
    {
        try
        {
            Console.Clear();
            // Comprobamos que el fichero CSV existe
            if (!File.Exists(rutaCsv))
            {
                Console.WriteLine("La ruta del CSV no es correcta, por favor arréglela y vuelva a intentarlo.");
                return;
            }
            // Leemos todas las líneas del CSV
            string[] lineas = File.ReadAllLines(rutaCsv);
            // Listas paralelas para guardar los nombres de los equipos y sus puntos
            List<string> nombresEquipos = new List<string>();
            List<int> puntosEquipos = new List<int>();

            //Empezamos en 1 para saltarnos la cabecera del csv y recorremos las lineas
            for (int i = 1; i < lineas.Length; i++)
            {
                string linea = lineas[i];

                if (string.IsNullOrWhiteSpace(linea))
                {
                    continue;
                }

                string[] campos = linea.Split(',');

                if (campos.Length > 3)
                {
                    string equipoLocal = campos[1].Trim();
                    string equipoVisitante = campos[2].Trim();
                    string resultado = campos[3].Trim();
                    //Separamos el resultado por el - y lo guardamos en el array
                    string [] partes = resultado.Split('-');
                    if (partes.Length == 2)
                    {
                        int puntosLocal = int.Parse(partes[0].Trim());
                        int puntosVisitante = int.Parse(partes[1].Trim());
                        //Asignamos los puntos (1 si gana, 0 si pierde)
                        int ptsLocal = 0;
                        int ptsVisitante = 0;

                        if (puntosLocal > puntosVisitante)
                        {
                            ptsLocal = 1;
                        }
                        else if (puntosLocal < puntosVisitante)
                        {
                            ptsVisitante = 1;
                        }
                        
                        //Declaramos una variable para buscar la posición del equipo local dentro de la lista
                        int posLocal = -1;
                        // Recorremos la lista de equipos existentes para comprobar si el equipo local ya está registrado
                        for (int j = 0; j < nombresEquipos.Count; j++)
                        {
                            // Comparamos el nombre almacenado con el equipo local actual (pasando ambos a minusculas para evitar fallos de mayusculas)
                            if (nombresEquipos[j].ToLower() == equipoLocal.ToLower())
                            {
                                // Si lo encontramos, guardamos su posición
                                posLocal = j;
                                // Rompemos el bucle porque ya hemos encontrado al equipo
                                break;
                            }
                        }
                        // Comprobamos si el equipo local ya estaba registrado 
                        if (posLocal != -1)
                        {
                            // Si ya existía, sumamos los nuevos puntos obtenidos en este partido a su acumulador actual
                            puntosEquipos[posLocal] += ptsLocal;
                        }
                        else
                        {
                            // Si no existía (-1), lo añadimos por primera vez a la lista de nombres de equipos y añadimos sus puntos correspondientes en la misma posición exacta
                            nombresEquipos.Add(equipoLocal);
                            puntosEquipos.Add(ptsLocal);
                        }
                        // Declaramos una variable para buscar la posición del equipo visitante dentro de la lista 
                        int posVisitante = -1;

                        // Recorremos de nuevo la lista de equipos para buscar al equipo visitante
                        for (int j = 0; j < nombresEquipos.Count; j++)
                        {
                            // Comparamos el nombre registrado con el equipo visitante actual en minusculas
                            if (nombresEquipos[j].ToLower() == equipoVisitante.ToLower())
                            {
                                // Si lo encontramos, guardamos su posicion 
                                posVisitante = j;
                                // Rompemos el bucle porque ya lo habriamos encontrado
                                break;
                            }
                        }
                        // Comprobamos si el equipo visitante ya estaba registrado previamente
                        if (posVisitante != -1)
                        {
                            // Si ya existía, sumamos los puntos de este partido a su acumulador de victorias
                            puntosEquipos[posVisitante] += ptsVisitante;
                        }
                        else
                        {
                            // Si es la primera vez que aparece, lo registramos añadiendo su nombre a la lista
                            nombresEquipos.Add(equipoVisitante);
                            // Y añadimos sus puntos iniciales
                            puntosEquipos.Add(ptsVisitante);
                        }
                    }
                }
            }
            if (nombresEquipos.Count == 0)
            {
                Console.WriteLine("No se han encontrado datos para calcular la clasificación.");
                return;
            }

            // Hamos varios bucles para ordenarlos
            for (int a = 0; a < nombresEquipos.Count - 1; a++)
            {
                // Iniciamos el segundo bucle anidado para comparar con b (ponemos b = a + 1 para no comparar un valor que puede ser el mismo, y asi pasamos directamente al siguiente elemento)
                for (int b = a + 1; b < nombresEquipos.Count; b++)
                {
                    if (puntosEquipos[b] > puntosEquipos[a])
                    {
                        int auxPts = puntosEquipos[a];
                        puntosEquipos[a] = puntosEquipos[b];
                        puntosEquipos[b] = auxPts;

                        string auxNom = nombresEquipos[a];
                        nombresEquipos[a] = nombresEquipos[b];
                        nombresEquipos[b] = auxNom;
                    }
                }
            }
            List<string> clasificacion = new List<string>();
            // Iniciamos un bucle para recorrer todos los equipos ya ordenados y mostrarlos por pantalla
            for (int equipos = 0; equipos < nombresEquipos.Count; equipos++)
            {
                // +1 para que empiece en la posicion 1 y no en 0
                int posicion = equipos + 1;
                string texto = $"{posicion}º - {nombresEquipos[equipos]} : {puntosEquipos[equipos]} victorias";
                Console.WriteLine(texto);
                clasificacion.Add(texto);
            }
            Console.WriteLine("\nIntroduce un nombre para guardar el archivo .txt (Si no quieres guardarlos pulsa q):");
            string nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre del archivo no puede estar vacío.");
                return;
            }
            if (nombre.Trim().ToLower() == "q")
            {
                Console.WriteLine("No se guardará el archivo, volviendo al menú...");
                return;
            }
            Directory.CreateDirectory(carpeta);
            string rutaTxt = Path.Combine(carpeta, nombre);
            File.WriteAllLines(rutaTxt, clasificacion);

            Console.WriteLine($"Se ha guardado correctamente el archivo .txt en: {rutaTxt}");
        } catch (Exception ex)
        {
            Console.WriteLine($"Ha habido un problema al calcular la clasificación: {ex.Message}");
        }
    }
    public void GuardarFicheros(string rutaCsv)
    {
        try
        {
            Console.Clear();
            if (!File.Exists(rutaCsv))
            {
                Console.WriteLine("La ruta del CSV no es correcta, por favor arréglela y vuelva a intentarlo.");
                return;
            }
            string[] lineas = File.ReadAllLines(rutaCsv);
            List<string> equiposUnicos = new List<string>();
            foreach (string linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea))
                {
                    continue;
                }
                string[] campos = linea.Split(',');
                if (campos.Length > 2)
                {
                    string local = campos[1].Trim();
                    string visitante = campos[2].Trim();
                    //Comprobamos si ya existen los equipos locales y visitantes y los añadimos 
                    bool existeLocal = false;
                    foreach (string equipo in equiposUnicos)
                    {
                        if (equipo.ToLower() == local.ToLower())
                        {
                            existeLocal = true;
                            break;
                        }
                    }
                    if (!existeLocal)
                    {
                        equiposUnicos.Add(local);
                    }
                    bool existeVisitante = false;
                    foreach (string equipo in equiposUnicos)
                    {
                        if (equipo.ToLower() == visitante.ToLower())
                        {
                            existeVisitante = true;
                            break;
                        }
                    }
                    if (!existeVisitante)
                    {
                        equiposUnicos.Add(visitante);
                    }
                }
            }
            if (equiposUnicos.Count == 0)
            {
                Console.WriteLine("No se han encontrado equipos en el fichero CSV.");
                return;
            }

            Directory.CreateDirectory(carpeta);
            //Recorremos cada equipo único para generar su archivo individual
            foreach (string equipoActual in equiposUnicos)
            {
                List<string> partidosEquipo = new List<string>();
                partidosEquipo.Add($"{equipoActual.ToUpper()}");
                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea))
                    {
                        continue;
                    }
                    string[] campos = linea.Split(',');
                    if (campos.Length > 2)
                    {
                        string local = campos[1].Trim();
                        string visitante = campos[2].Trim();
                        //Si el equipo participa como local o visitante, añadimos la línea
                        if (local.ToLower() == equipoActual.ToLower() || visitante.ToLower() == equipoActual.ToLower())
                        {
                            partidosEquipo.Add(linea);
                        }
                    }
                }
                //Generamos el nombre del archivo reemplazando espacios por guiones bajos
                string nombreArchivo = equipoActual.Replace(" ", "_") + ".txt";
                string rutaTxt = Path.Combine(carpeta, nombreArchivo);
                
                File.WriteAllLines(rutaTxt, partidosEquipo);
                Console.WriteLine($"Generado fichero: {nombreArchivo}");
            }
            Console.WriteLine($"\n¡Todos los ficheros de los equipos se han guardado correctamente en la carpeta '{carpeta}'!");
        } catch (Exception ex)
        {
            Console.WriteLine($"Ha habido un problema al guardar los ficheros por equipo: {ex.Message}");        
        }
    }
    // Este método se encarga de mandar un mensaje por consola antes de cerrar la aplicación
    public void CerrarAplicacion()
    {
        Console.WriteLine("Gracias por usar la aplicación.");
    }
}