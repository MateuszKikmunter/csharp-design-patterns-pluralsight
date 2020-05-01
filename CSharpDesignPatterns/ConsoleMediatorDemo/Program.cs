using ConsoleMediatorDemo.Structural;

namespace ConsoleMediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConcreteMediator();
            var c1 = new ConcreteColleague();
            var c2 = new SecondConreteColleage();

            mediator.Register(c1);
            mediator.Register(c2);

            c1.Send("hello from colleague 1");
            c2.Send("hello from colleague 2");
        }
    }
}
