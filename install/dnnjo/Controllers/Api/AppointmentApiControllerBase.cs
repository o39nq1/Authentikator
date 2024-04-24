using System;
using Dnn.Appointment.Debug.DnnAppointmentDebug.Services;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Controllers.Api
{
    public class AppointmentApiControllerBase : RestApiController
    {
       protected IAppointmentBookingManager AppointmentBooking { get; }

       public AppointmentApiControllerBase(
           IAppointmentBookingManager appointmentBooking
           )
        {
            AppointmentBooking = appointmentBooking
                ?? throw new ArgumentNullException(nameof(appointmentBooking));
        }
    }
}
