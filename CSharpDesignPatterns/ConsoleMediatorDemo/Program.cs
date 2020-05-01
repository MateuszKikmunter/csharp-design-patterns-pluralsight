using ConsoleMediatorDemo.Structural;

namespace ConsoleMediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {

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
