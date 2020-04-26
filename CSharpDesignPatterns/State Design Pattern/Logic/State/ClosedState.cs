namespace State_Design_Pattern.Logic
{
    public class ClosedState : BookingState
    {
        private string _reasonClosed;

        public ClosedState(string reason)
        {
            _reasonClosed = reason;
        }

        public override void Cancel(BookingContext booking)
        {
            booking.View.ShowError("Cannot cancel closed booking!", "Closed Booking Error");
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.View.ShowError("Invalid action for this case", "Closed Booking Error");
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid action for this case", "Closed Booking Error");
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Closed");
            booking.View.ShowStatusPage(_reasonClosed);
        }
    }
}
