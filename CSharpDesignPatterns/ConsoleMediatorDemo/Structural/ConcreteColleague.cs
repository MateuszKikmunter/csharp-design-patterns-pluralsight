using System;

namespace ConsoleMediatorDemo.Structural
{
    public class ConcreteColleague : Colleague
    {
        public ConcreteColleague(Mediator mediator) : base(mediator)
        {
        }

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Conrecte colleague receives notification: { message }");
        }
    }
}
