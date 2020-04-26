using System.Threading;

namespace State_Design_Pattern.Logic
{
    public class PendingState : BookingState
    {
        private CancellationTokenSource _cancellationToken;

        public override void Cancel(BookingContext booking)
        {
            _cancellationToken.Cancel();
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
            _cancellationToken = new CancellationTokenSource();

            booking.ShowState("Pending");
            booking.View.ShowStatusPage("Processing Booking...");

            StaticFunctions.ProcessBooking(booking, ProcessingComplete, _cancellationToken);
        }

        public void ProcessingComplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    booking.View.ShowProcessingError();
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Processing cancelled"));
                    break;
            }
        }
    }
}
