using System;

namespace ConsoleMediatorDemo.ChatApp
{
    public class Tester : TeamMember
    {
        public Tester(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{ Name } ({ nameof(Developer) }) has received: { message }");
            base.Receive(from, message);
        }
    }
}
