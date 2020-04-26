using System;

namespace State_Design_Pattern.Logic
{
    public class BookedState : BookingState
    {
        public override void Cancel(BookingContext booking)
        {
            throw new NotImplementedException();
        }

        public override void DatePassed(BookingContext booking)
        {
            throw new NotImplementedException();
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            throw new NotImplementedException();
        }

        public override void EnterState(BookingContext booking)
        {
            throw new NotImplementedException();
        }
    }
}
