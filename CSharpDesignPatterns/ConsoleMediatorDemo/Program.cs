using ConsoleMediatorDemo.Structural;

namespace ConsoleMediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConcreteMediator();
            var c1 = new ConcreteColleague(mediator);
            var c2 = new SecondConreteColleage(mediator);

            mediator.Colleague1 = c1;
            mediator.Colleague2 = c2;

            c1.Send("hello from colleague 1");
            c2.Send("hello from colleague 2");
        }
    }
}
