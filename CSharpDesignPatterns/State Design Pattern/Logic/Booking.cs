using System;
using System.Threading;
using State_Design_Pattern.UI;

namespace State_Design_Pattern.Logic
{
    public class Booking
    {
        private MainWindow View { get; }

        public string Attendee { get; private set; }

        public int TicketCount { get; private set; }

        public int BookingID { get; set; }

        private CancellationTokenSource _cancelToken;

        private bool _isNew { get; set; }

        private bool _isPending { get; set; }

        private bool _isBooked { get; set; }


        public Booking(MainWindow view)
        {
            _isNew = true;
            View = view;
            BookingID = new Random().Next();
            ShowState("New");
            View.ShowEntryPage();
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            if (_isNew)
            {
                _isNew = false;
                _isPending = true;

                Attendee = attendee;
                TicketCount = ticketCount;

                _cancelToken = new CancellationTokenSource();
                StaticFunctions.ProcessBooking(this, ProcessingComplete, _cancelToken);

                ShowState("Pending");
                View.ShowStatusPage("Processing booking...");
            }
        }

        public void Cancel()
        {
            if (_isNew)
            {
                ShowState("Closed");
                View.ShowStatusPage("Cancelled by user");
                _isNew = false;
            }
            else if (_isPending)
            {
                _cancelToken.Cancel();
            }
            else if (_isBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking cancelled, expect refund.");
                _isBooked = false;
            }
            else
            {
                View.ShowError("Closed booking cannot be cancelled!");
            }
        }

        public void DatePassed()
        {
            if (_isNew)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking expired.");
                _isNew = false;
            }
            else if (_isBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("We hope you enjoyed the event!");
                _isBooked = false;
            }
        }

        public void ProcessingComplete(Booking booking, ProcessingResult result)
        {
            _isPending = false;
            switch (result)
            {
                case ProcessingResult.Sucess:
                    _isBooked = true;
                    ShowState("Booked");
                    View.ShowStatusPage("Enjoy the Event");
                    break;
                case ProcessingResult.Fail:
                    View.ShowProcessingError();
                    Attendee = string.Empty;
                    BookingID = new Random().Next();
                    _isNew = true;
                    ShowState("New");
                    View.ShowEntryPage();
                    break;
                case ProcessingResult.Cancel:
                    ShowState("Closed");
                    View.ShowStatusPage("Processing Canceled");
                    break;
            }
        }

        public void ShowState(string stateName)
        {
            View.grdDetails.Visibility = System.Windows.Visibility.Visible;
            View.lblCurrentState.Content = stateName;
            View.lblTicketCount.Content = TicketCount;
            View.lblAttendee.Content = Attendee;
            View.lblBookingID.Content = BookingID;
        }



    }
}


