using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMediatorDemo.Structural
{
    public class ConcreteMediator : Mediator
    {
        private readonly List<Colleague> _colleagues = new List<Colleague>();

        public override void Send(string message, Colleague colleague)
        {
            if(string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            if(colleague == null)
            {
                throw new ArgumentNullException(nameof(colleague));
            }

            _colleagues.Where(c => c != colleague).ToList().ForEach(c => c.HandleNotification(message));
        }

        public void Register<T>(T colleague) where T : Colleague
        {
            colleague.SetMediator(this);
            _colleagues.Add(colleague);
        }
    }
}
