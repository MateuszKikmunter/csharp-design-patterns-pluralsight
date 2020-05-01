namespace ConsoleMediatorDemo.Structural
{
    public class ConcreteMediator : Mediator
    {
        public ConcreteColleague Colleague1 { get; set; }

        public SecondConreteColleage Colleague2 { get; set; }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == Colleague1)
            {
                Colleague1.HandleNotification(message);
            }
            else
            {
                Colleague2.HandleNotification(message);
            }
        }
    }
}
