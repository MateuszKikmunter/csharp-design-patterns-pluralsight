namespace State_Design_Pattern.Logic
{
    public class BookedState : BookingState
    {
        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking cancelled: Expect Refund"));
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("We hope you enjoyed the event!"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid action for this case", "Closed Booking Error");
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Booked");
            booking.View.ShowStatusPage("Enjoy the event!");
        }
    }
}
