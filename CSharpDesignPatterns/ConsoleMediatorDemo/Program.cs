using ConsoleMediatorDemo.ChatApp;
using ConsoleMediatorDemo.Structural;
using System;

namespace ConsoleMediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamChat = new TeamChatroom();

            var steve = new Developer("Steve");
            var justin = new Developer("Justin");
            var jenna = new Developer("Jenna");
            var kim = new Tester("Kim");
            var julia = new Tester("Julia");

            teamChat.RegisterMembers(steve, justin, jenna, kim, julia);

            steve.Send("Hey everyone we're going to be deploying at 2pm today.");
            kim.Send("OK, thanks for letting us know.");

            Console.WriteLine();
            steve.SendTo<Developer>("Make sure to execute your unit tests before checking in.");
        }



        private static void StructuralExample()
        {
            var mediator = new ConcreteMediator();
            var c1 = mediator.CreateColleague<ConcreteColleague>();
            var c2 = mediator.CreateColleague<SecondConreteColleage>();

            c1.Send("hello from colleague 1");
            c2.Send("hello from colleague 2");
        }
    }
}
