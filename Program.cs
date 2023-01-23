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
                _aviaries[ChooseAviary()].ShowDescription();
            }
            else if (userChoice == CommandExit)
            {
                isExit = true;
            }
        }
    }

    private int ChooseAviary()
    {
        int firstIndex = 1;
        Console.WriteLine("Для осмотра одного из вольеров, введите любую цифру от " + firstIndex + " до " + _aviaries.Capacity);
        int index = GetNumber(_aviaries.Capacity) - 1;
        return index;
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
        Aviary birds = new Aviary("это птицы, они здесь жрут и срут");

        birds.AddAnimal(new Animal("Черноголовый трагопан", "Пацан", "Ой бой"));
        birds.AddAnimal(new Animal("Бульверова лофура", "Не совсем пацан", "Лоуфрэс прэс трэс"));
        birds.AddAnimal(new Animal("Глазчатая индейка", "Точно не пацан", "Курлык бурлык"));
        birds.AddAnimal(new Animal("Гималайский монал", "Жёнщина", "Того рот монал"));
        birds.AddAnimal(new Animal("Такахе", "Самка", "молчу и точка"));

        return birds;
    }

    private Aviary AddSpeciesRedPanda()
    {
        Aviary redPandas = new Aviary("Милые красные пандочки");

        redPandas.AddAnimal(new Animal("Красная панда", "самец", "Кушат"));
        redPandas.AddAnimal(new Animal("Красная панда", "самка", "Играт"));
        redPandas.AddAnimal(new Animal("Красная панда", "самец", "Кушат"));
        redPandas.AddAnimal(new Animal("Красная панда", "самец", "Играт"));
        redPandas.AddAnimal(new Animal("Красная панда", "самка", "Кушат"));

        return redPandas;
    }

    private Aviary AddSpeciesCrocodile()
    {
        Aviary crocodiles = new Aviary("Разные виды крокодилов, позже расширим вольер и добавим еще виды");

        crocodiles.AddAnimal(new Animal("Гребнистый", "самец", "сожру тебя"));
        crocodiles.AddAnimal(new Animal("Нильский", "самец", "добрый, но сожру тебя"));
        crocodiles.AddAnimal(new Animal("Болотный", "самка", "люблю плавать"));
        crocodiles.AddAnimal(new Animal("Острорылый", "самка", "буль буль"));
        crocodiles.AddAnimal(new Animal("Африканский", "самец", "короткие лапки, но как остры зубы"));

        return crocodiles;
    }

    private Aviary AddSpeciesZebra()
    {
        Aviary zebras = new Aviary("Зебры, все они не Марти");

        zebras.AddAnimal(new Animal("Греви", "самка", "тыгыдык, тыгыдык"));
        zebras.AddAnimal(new Animal("Горная", "самка", "игого бл"));
        zebras.AddAnimal(new Animal("Капская", "самец", "я не Марти"));
        zebras.AddAnimal(new Animal("Саванная", "самец", "я Марти"));
        zebras.AddAnimal(new Animal("Сулусская", "самка", "и я Марти"));

        return zebras;
    }
}

class Aviary
{
    private List<Animal> _animals = new List<Animal>();

    public Aviary(string description)
    {
        Description = description;
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

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
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
