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
        AddAviary();
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

    private void AddAviary()
    {
        _aviaries.Add(new Bird());
        _aviaries.Add(new RedPanda());
        _aviaries.Add(new Crocodile());
        _aviaries.Add(new Zebra());
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
}

abstract class Aviary
{
    public string Description { get; protected set; }
    protected List<Animal> Animals = new List<Animal>();

    public Aviary()
    {
        Add();
        AddDescription();
    }

    public virtual void ShowDescription()
    {
        Console.Clear();
        Console.WriteLine(Description);

        foreach (Animal animal in Animals)
        {
            animal.ShowInfo();
        }

        Console.ReadKey();
        Console.Clear();
    }

    protected virtual void AddDescription()
    {
        Description = "Здесь должно быть описание, добавляйте его для каждого вольера";
    }

    protected virtual void Add()
    {
        Console.WriteLine("Здесь добавлять животных, находящихся в вольере");
    }
}

class Bird : Aviary
{
    protected override void AddDescription()
    {
        Description = "Это вольер для птиц, здесь жрут и срут " + Animals.Count + " разных особей: ";
    }

    protected override void Add()
    {
        Animals.Add(new Animal("Черноголовый трагопан", "Пацан", "Ой бой"));
        Animals.Add(new Animal("Бульверова лофура", "Не совсем пацан", "Лоуфрэс прэс трэс"));
        Animals.Add(new Animal("Глазчатая индейка", "Точно не пацан", "Курлык бурлык"));
        Animals.Add(new Animal("Гималайский монал", "Жёнщина", "Того рот монал"));
        Animals.Add(new Animal("Такахе", "Самка", "молчу и точка"));
    }
}

class RedPanda : Aviary
{
    protected override void AddDescription()
    {
        Description = "В данном вольере обитает " + Animals.Count + " милых красных пандочек";
    }

    protected override void Add()
    {
        Animals.Add(new Animal("Красная панда", "самец", "Кушат"));
        Animals.Add(new Animal("Красная панда", "самка", "Играт"));
        Animals.Add(new Animal("Красная панда", "самец", "Кушат"));
        Animals.Add(new Animal("Красная панда", "самец", "Играт"));
        Animals.Add(new Animal("Красная панда", "самка", "Кушат"));
    }
}

class Crocodile : Aviary
{
    protected override void AddDescription()
    {
        Description = "В данном вольере обитает " + Animals.Count + " разных видов крокодилов, позже расширим вольер и добавим еще виды и ";
    }

    protected override void Add()
    {
        Animals.Add(new Animal("Гребнистый", "самец", "сожру тебя"));
        Animals.Add(new Animal("Нильский", "самец", "добрый, но сожру тебя"));
        Animals.Add(new Animal("Болотный", "самка", "люблю плавать"));
        Animals.Add(new Animal("Острорылый", "самка", "буль буль"));
        Animals.Add(new Animal("Африканский", "самец", "короткие лапки, но как остры зубы"));
    }
}

class Zebra : Aviary
{
    protected override void AddDescription()
    {
        Description = "В данном вольере бегают и резвятся " + Animals.Count + " зебр, все они не Марти";
    }

    protected override void Add()
    {
        Animals.Add(new Animal("Греви", "самка", "тыгыдык, тыгыдык"));
        Animals.Add(new Animal("Горная", "самка", "игого бл"));
        Animals.Add(new Animal("Капская", "самец", "я не Марти"));
        Animals.Add(new Animal("Саванная", "самец", "я Марти"));
        Animals.Add(new Animal("Сулусская", "самка", "и я Марти"));
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

    public void ShowInfo()
    {
        Console.WriteLine(Name + ", " + Gender + ", издает звук: " + Sound);
    }
}