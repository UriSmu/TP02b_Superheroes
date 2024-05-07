namespace TP02b__Superheroes__Smucler;

class Program
{
    static void Main(string[] args)
    {
        Superheroe superheroe1 = new Superheroe();
        Superheroe superheroe2 = new Superheroe();

        int eleccion = -1;
        bool esEntero = false;
        int cant_superheroes = 0;

        do
        {
            Console.WriteLine("1. Cargar Datos Superhéroe 1");
            Console.WriteLine("2. Cargar Datos Superhéroe 2");
            Console.WriteLine("3. Competir!");
            Console.WriteLine("4. Ver Superheroe");
            Console.WriteLine("5. Modificar atributos");
            Console.WriteLine("6. Salir");
            while (!esEntero || eleccion < 1 || eleccion > 6)
            {
                esEntero = int.TryParse(Console.ReadLine(), out eleccion);
            }

            switch (eleccion)
            {
                case 1:
                    if(superheroe1.Peso == 0)
                    {
                        superheroe1 = CargarSuperheroe();
                        Console.WriteLine("Se ha creado el superhéroe " + superheroe1.Nombre);
                        cant_superheroes++;
                    }
                    else
                    {
                        Console.WriteLine("Ya se creó el superheroe 1");
                    }
                    break;
                
                case 2:
                    if(superheroe2.Peso == 0)
                    {
                        superheroe2 = CargarSuperheroe();
                        Console.WriteLine("Se ha creado el superhéroe " + superheroe2.Nombre);
                        cant_superheroes++;
                    }
                    else
                    {
                        Console.WriteLine("Ya se creó el superheroe 2");
                    }
                    break;

                case 3:
                    if(cant_superheroes != 2)
                    {
                        Console.WriteLine("Se deben cargar los 2 superheroes");
                    }
                    else
                    {
                        Pelea(superheroe1, superheroe2);
                    }
                    break;
                
                case 4:
                    bool esInt = false;
                    int super;
                    
                    do
                    {
                        Console.WriteLine("Elija superheroe (1 o 2)");
                        esInt = int.TryParse(Console.ReadLine(), out super);
                    }while(!esInt || super > 2 || super < 1);
                    if(super == 1 && superheroe1.Peso != 0) VerSuperheroe(superheroe1);
                    else if(superheroe2.Peso != 0) VerSuperheroe(superheroe2);
                    else Console.WriteLine("No se puede ver las características de un superhéroe inexistente");
                    break;

                case 5:
                    do
                    {
                        Console.WriteLine("Elija superheroe (1 o 2)");
                        esInt = int.TryParse(Console.ReadLine(), out super);
                    }while(!esInt || super > 2 || super < 1);
                    if (super == 1 && superheroe1.Peso != 0) superheroe1 = superheroe1.CambiarSkill();
                    else if (super == 2 && superheroe2.Peso != 0) superheroe2 = superheroe2.CambiarSkill();
                    else Console.WriteLine("No existe el superheroe");
                    break;
            }

            if (eleccion != 6) eleccion = -1;
        }while(eleccion != 6);
    }

    static Superheroe CargarSuperheroe()
    {
        string nombre;
        string ciudad;
        double peso;
        double velocidad = 0;
        double fuerza = 0;
        double inteligencia;
        int respuesta = 0;
        bool esVacio = false;
        bool esDouble = false;
        Superheroe c = new Superheroe();
        do
        {
            Console.WriteLine("Ingrese nombre");
            nombre = Console.ReadLine();
            if (nombre == "") esVacio = true;
        }while (esVacio);
        
        esVacio = false;
        do
        {
            Console.WriteLine("Ingrese ciudad");
            ciudad = Console.ReadLine();
            if (ciudad == "") esVacio = true;
        }while (esVacio);

        do
        {
            Console.WriteLine("Ingrese peso");
            esDouble = double.TryParse(Console.ReadLine(), out peso);
        }while(!esDouble || peso <= 0);

        esDouble = false;
        do
        {
            Console.WriteLine("Ingrese la opcion que desea para el ingreso de velocidad y fuerza");
            Console.WriteLine("1. Manual");
            Console.WriteLine("2. Aleatorio");
            int.TryParse(Console.ReadLine(), out respuesta);
        }while(respuesta != 1 && respuesta != 2);
        switch (respuesta)
        {
            case 1:
                do
                {
                    Console.WriteLine("Ingrese velocidad");
                    esDouble = double.TryParse(Console.ReadLine(), out velocidad);
                }while(!esDouble || velocidad < 1 || velocidad > 100);

                esDouble = false;
                do
                {
                    Console.WriteLine("Ingrese fuerza");
                    esDouble = double.TryParse(Console.ReadLine(), out fuerza);
                }while(!esDouble || fuerza < 1 || fuerza > 100);

                esDouble = false;

                do
                {
                    Console.WriteLine("Ingrese inteligencia");
                    esDouble = double.TryParse(Console.ReadLine(), out inteligencia);
                }while(!esDouble || inteligencia < 1 || inteligencia > 100);

                Superheroe a = new Superheroe(nombre, ciudad, peso, fuerza, velocidad, inteligencia);
                c = a;
                break;
            
            case 2:
                do
                {
                    Console.WriteLine("Ingrese inteligencia");
                    esDouble = double.TryParse(Console.ReadLine(), out inteligencia);
                }while(!esDouble || inteligencia < 1 || inteligencia > 100);
                Superheroe b = new Superheroe(nombre, ciudad, peso, inteligencia);
                c = b;
                break;
        }
        
        return c; 
    }

    static void Pelea(Superheroe superheroe1, Superheroe superheroe2)
    {
        double skill1;
        double skill2;
        double diferencia;
        string nombreGanador;

        do
        {
            skill1 = superheroe1.ObtenerSkill();
            skill2 = superheroe2.ObtenerSkill();
        }while(skill1 == skill2);

        if (skill1 > skill2)
        {
            diferencia = skill1 - skill2;
            nombreGanador = superheroe1.Nombre;
        }
        else
        {
            diferencia = skill2 - skill1;
            nombreGanador = superheroe2.Nombre;
        }

        if(diferencia >= 30)
        {
            Console.WriteLine("Ganó " + nombreGanador + " por amplia diferencia");
        }
        else if(diferencia >= 10)
        {
            Console.WriteLine("Ganó " + nombreGanador + ". ¡Fue muy parejo!");
        }
        else
        {
            Console.WriteLine("Ganó " + nombreGanador + ". ¡No le sobró nada!");
        }
    }


    static void VerSuperheroe(Superheroe superheroe)
    {
        Console.WriteLine("Nombre: " + superheroe.Nombre);
        Console.WriteLine("Ciudad: " + superheroe.Ciudad);
        Console.WriteLine("Peso: " + superheroe.Peso);
        Console.WriteLine("Velocidad: " + superheroe.Velocidad);
        Console.WriteLine("Fuerza: " + superheroe.Fuerza);
        Console.WriteLine("Inteligencia: " + superheroe.Inteligencia);
    }
}
