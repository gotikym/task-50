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
                ShowInfo();
            }
            else if (userChoice == CommandExit)
            {
                isExit = true;
            }
        }
    }

    private void ShowInfo()
    {
        int defoltIndex = 1;
        int adjustIndex = -1;
        Console.WriteLine("Для осмотра одного из вольеров, введите любую цифру от " + defoltIndex + " до " + _aviaries.Capacity);
        adjustIndex += GetNumber(_aviaries.Capacity);

        _aviaries[adjustIndex].ShowDescription();
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
        Aviary Birds = new Aviary("это птицы, они здесь жрут и срут");

        Birds.AddAnimal(new Animal("Черноголовый трагопан", "Пацан", "Ой бой"));
        Birds.AddAnimal(new Animal("Бульверова лофура", "Не совсем пацан", "Лоуфрэс прэс трэс"));
        Birds.AddAnimal(new Animal("Глазчатая индейка", "Точно не пацан", "Курлык бурлык"));
        Birds.AddAnimal(new Animal("Гималайский монал", "Жёнщина", "Того рот монал"));
        Birds.AddAnimal(new Animal("Такахе", "Самка", "молчу и точка"));

        return Birds;
    }

    private Aviary AddSpeciesRedPanda()
    {
        Aviary RedPandas = new Aviary("Милые красные пандочки");

        RedPandas.AddAnimal(new Animal("Красная панда", "самец", "Кушат"));
        RedPandas.AddAnimal(new Animal("Красная панда", "самка", "Играт"));
        RedPandas.AddAnimal(new Animal("Красная панда", "самец", "Кушат"));
        RedPandas.AddAnimal(new Animal("Красная панда", "самец", "Играт"));
        RedPandas.AddAnimal(new Animal("Красная панда", "самка", "Кушат"));

        return RedPandas;
    }

    private Aviary AddSpeciesCrocodile()
    {
        Aviary Crocodiles = new Aviary("Разные виды крокодилов, позже расширим вольер и добавим еще виды");

        Crocodiles.AddAnimal(new Animal("Гребнистый", "самец", "сожру тебя"));
        Crocodiles.AddAnimal(new Animal("Нильский", "самец", "добрый, но сожру тебя"));
        Crocodiles.AddAnimal(new Animal("Болотный", "самка", "люблю плавать"));
        Crocodiles.AddAnimal(new Animal("Острорылый", "самка", "буль буль"));
        Crocodiles.AddAnimal(new Animal("Африканский", "самец", "короткие лапки, но как остры зубы"));

        return Crocodiles;
    }

    private Aviary AddSpeciesZebra()
    {
        Aviary Zebras = new Aviary("Зебры, все они не Марти");

        Zebras.AddAnimal(new Animal("Греви", "самка", "тыгыдык, тыгыдык"));
        Zebras.AddAnimal(new Animal("Горная", "самка", "игого бл"));
        Zebras.AddAnimal(new Animal("Капская", "самец", "я не Марти"));
        Zebras.AddAnimal(new Animal("Саванная", "самец", "я Марти"));
        Zebras.AddAnimal(new Animal("Сулусская", "самка", "и я Марти"));

        return Zebras;
    }
}

class Aviary
{
    public string Description { get; private set; }
    private List<Animal> _animals = new List<Animal>();

    public Aviary(string description)
    {
        Description = description;
    }

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

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }
}

class Animal
{
    public string Name { get; private set; }
    public string Gender { get; private set; }
    public string Sound { get; private set; }

    public Animal(string name, string gender, string sound)
    {
        Name = name;
        Gender = gender;
        Sound = sound;
    }
}
