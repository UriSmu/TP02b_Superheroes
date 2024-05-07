class Superheroe
{
    public string Nombre {get; set;}
    public string Ciudad {get; set;}
    public double Peso {get; set;}
    public double Fuerza {get; set;}
    public double Velocidad {get; set;}
    public double Inteligencia{get; set;}


    public Superheroe () {}

    public Superheroe (string nombre, string ciudad, double peso, double fuerza, double velocidad, double inteligencia)
    {
        Nombre = nombre;
        Ciudad = ciudad;
        Peso = peso;
        Velocidad = velocidad;
        Fuerza = fuerza;
        Inteligencia = inteligencia;
    }

    public Superheroe (string nombre, string ciudad, double peso, double inteligencia)
    {
        Nombre = nombre;
        Ciudad = ciudad;
        Peso = peso;
        Velocidad = Aleatorio();
        Fuerza = Aleatorio();
        Inteligencia = inteligencia;
    }

    public double ObtenerSkill()
    {
        double puntos = 0;
        puntos+= Velocidad*0.6;
        puntos+= Fuerza*0.8;
        puntos+=Inteligencia*0.25;
        Random rnd = new Random();
        int random = rnd.Next (1, 11);
        puntos+=random;
        return puntos;
    }

    public Superheroe CambiarSkill()
    {
        double velocidad, fuerza;
        bool esDouble = false;
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

        Superheroe a = new Superheroe(Nombre, Ciudad, Peso, fuerza, velocidad, Inteligencia);

        return a;
    }

    public double Aleatorio()
    {
        Random rnd = new Random();
        double random = rnd.Next (1, 100);
        return random;
    }
}

