using System;
using Dnn.Appointment.Debug.DnnAppointmentDebug.Models;
using DotNetNuke.Entities.Users;
using DotNetNuke.UI.UserControls;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Services
{
    public class AppointmentData
    {
        public int AppointmentID => Appointment.AppointmentID;

        public int StartTime => Appointment.DateID;

        public AppointmentBookingAppointment Appointment {get;}

        public AppointmentBookingDate Date { get;}

        public AppointmentBookingUser User { get; internal set; }

        public UserInfo UserInfo {  get; internal set; }

        internal AppointmentData(
            AppointmentBookingAppointment appointment,
            AppointmentBookingDate date,
            AppointmentBookingUser user
        ) {
            Appointment = appointment
            ?? throw new ArgumentNullException(nameof(appointment));

            Date = date
                ?? throw new ArgumentNullException(nameof(date));

            User = user
                ?? throw new ArgumentNullException(nameof(user));
        }
        


    }
}
