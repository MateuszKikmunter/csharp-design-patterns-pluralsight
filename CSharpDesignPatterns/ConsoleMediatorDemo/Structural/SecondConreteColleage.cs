using System;

namespace ConsoleMediatorDemo.Structural
{
    public class SecondConreteColleage : Colleague
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Second concrete colleague receives notifiacation: { message }");
        }
    }
}
