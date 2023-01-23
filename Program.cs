using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        zoo.Start();
    }
}

class Zoo
{
    private List<Aviary> _aviaries = new List<Aviary>();

    public Zoo()
    {
        AddAviaries();
    }

    public void Start()
    {
        const string CommandWalk = "walk";
        const string CommandExit = "exit";
        bool isExit = false;

        while (isExit == false)
        {
            Console.WriteLine("Для того, чтобы пройти к вольеру, введите  " + CommandWalk + ", чтобы выйти из зоопарка - " + CommandExit);
            string userChoice = Console.ReadLine();

            if (userChoice == CommandWalk)
            {
                _aviaries[ChooseNumberAviary()].ShowDescription();
            }
            else if (userChoice == CommandExit)
            {
                isExit = true;
            }
        }
    }

    private int ChooseNumberAviary()
    {
        int firstIndex = 1;
        Console.WriteLine("Для осмотра одного из вольеров, введите любую цифру от " + firstIndex + " до " + _aviaries.Capacity);         
        return GetNumber(_aviaries.Capacity) - 1;
    }

    private int GetNumber(int listCapacity)
    {
        bool isParse = false;
        int numberForReturn = 0;

        while (isParse == false)
        {
            string userNumber = Console.ReadLine();
            int.TryParse(userNumber, out numberForReturn);

            if (numberForReturn <= 0 || numberForReturn > listCapacity)
            {
                Console.WriteLine("Вводи одну из предложенных цифр, а не из космоса =_=");
            }
            else
            {
                isParse = true;
            }
        }

        return numberForReturn;
    }

    private void AddAviaries()
    {
        _aviaries.Add(AddSpeciesBirds());
        _aviaries.Add(AddSpeciesRedPanda());
        _aviaries.Add(AddSpeciesCrocodile());
        _aviaries.Add(AddSpeciesZebra());
    }

    private Aviary AddSpeciesBirds()
    {
        List<Animal> speciesBirds = new List<Animal>();

        speciesBirds.Add(new Animal("Черноголовый трагопан", "Пацан", "Ой бой"));
        speciesBirds.Add(new Animal("Бульверова лофура", "Не совсем пацан", "Лоуфрэс прэс трэс"));
        speciesBirds.Add(new Animal("Глазчатая индейка", "Точно не пацан", "Курлык бурлык"));
        speciesBirds.Add(new Animal("Гималайский монал", "Жёнщина", "Того рот монал"));
        speciesBirds.Add(new Animal("Такахе", "Самка", "молчу и точка"));

        Aviary birds = new Aviary("это птицы, они здесь жрут и срут", speciesBirds);

        return birds;
    }

    private Aviary AddSpeciesRedPanda()
    {
        List<Animal> speciesPandas = new List<Animal>();

        speciesPandas.Add(new Animal("Красная панда", "самец", "Кушат"));
        speciesPandas.Add(new Animal("Красная панда", "самка", "Играт"));
        speciesPandas.Add(new Animal("Красная панда", "самец", "Кушат"));
        speciesPandas.Add(new Animal("Красная панда", "самец", "Играт"));
        speciesPandas.Add(new Animal("Красная панда", "самка", "Кушат"));

        Aviary redPandas = new Aviary("Милые красные пандочки", speciesPandas);

        return redPandas;
    }

    private Aviary AddSpeciesCrocodile()
    {
        List<Animal> speciesCrocodile = new List<Animal>();

        speciesCrocodile.Add(new Animal("Гребнистый", "самец", "сожру тебя"));
        speciesCrocodile.Add(new Animal("Нильский", "самец", "добрый, но сожру тебя"));
        speciesCrocodile.Add(new Animal("Болотный", "самка", "люблю плавать"));
        speciesCrocodile.Add(new Animal("Острорылый", "самка", "буль буль"));
        speciesCrocodile.Add(new Animal("Африканский", "самец", "короткие лапки, но как остры зубы"));

        Aviary crocodiles = new Aviary("Разные виды крок одилов, позже расширим вольер и добавим еще виды", speciesCrocodile);

        return crocodiles;
    }

    private Aviary AddSpeciesZebra()
    {
        List<Animal> speciesZebra = new List<Animal>();

        speciesZebra.Add(new Animal("Греви", "самка", "тыгыдык, тыгыдык"));
        speciesZebra.Add(new Animal("Горная", "самка", "игого бл"));
        speciesZebra.Add(new Animal("Капская", "самец", "я не Марти"));
        speciesZebra.Add(new Animal("Саванная", "самец", "я Марти"));
        speciesZebra.Add(new Animal("Сулусская", "самка", "и я Марти"));

        Aviary zebras = new Aviary("Зебры, все они не Марти", speciesZebra);

        return zebras;
    }
}

class Aviary
{
    private List<Animal> _animals = new List<Animal>();

    public Aviary(string description,List<Animal> animals)
    {
        Description = description;
        _animals = animals;
    }

    public string Description { get; private set; }

    public virtual void ShowDescription()
    {
        Console.Clear();

        Console.Write("В данном вольере обитает " + _animals.Count + " особей. ");
        Console.WriteLine(Description);

        foreach (Animal species in _animals)
        {
            Console.WriteLine(species.Name + ", " + species.Gender + ", издает звук: " + species.Sound);
        }

        Console.ReadKey();
        Console.Clear();
    }
}

class Animal
{
    public Animal(string name, string gender, string sound)
    {
        Name = name;
        Gender = gender;
        Sound = sound;
    }

    public string Name { get; private set; }
    public string Gender { get; private set; }
    public string Sound { get; private set; }
}
