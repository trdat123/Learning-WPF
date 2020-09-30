using System;


namespace _03_excercise
{
    interface IAnimal
    {
        DateTime BirthDate();
        void Move();
        void Speak();
    }

    abstract class BaseAnimal : IAnimal
    {
        public DateTime BirthDate()
        {
            var date = DateTime.Now;
            return date;
        }
        public abstract void Move();
        public abstract void Speak();
    }

    class Pet : BaseAnimal
    {
        public override void Move()
        {
            System.Console.WriteLine("Pets are moving...");
        }
        public override void Speak()
        {
            System.Console.WriteLine("Pets are speaking...");
        }
        public string Name { get; }
    }

    class Monkey : BaseAnimal
    {
        public override void Move()
        {
            System.Console.WriteLine("Monkey are moving...");
        }
        public override void Speak()
        {
            System.Console.WriteLine("Monkey are speaking...");
        }
        public void climb()
        {
            System.Console.WriteLine("Climbing...");
        }
    }

    class Dog : Pet
    {
        public string Color()
        {
            return "Blue";
        }
    }

    class Cat : Pet
    {
        public void Jump()
        {
            System.Console.WriteLine("Jumping...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog();
            dog1.Move();
            dog1.Speak();
            Monkey monkey1 = new Monkey();
            monkey1.Move();
            monkey1.Speak();
        }
    }
}