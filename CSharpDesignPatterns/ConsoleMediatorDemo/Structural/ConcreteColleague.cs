using System;

namespace ConsoleMediatorDemo.Structural
{
    public class ConcreteColleague : Colleague
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Conrecte colleague receives notification: { message }");
        }
    }
}
