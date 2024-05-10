using System;
using Dnn.Appointment.Debug.DnnAppointmentDebug.Models;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Services
{
    public interface IAppointmentBookingManager
    {
        AppointmentData[] GetAppointmentData();
        AppointmentData FindAppointmentByID(int AppointmentID);

        AppointmentData[] FindAppointmentsByUser(
            int UserID
            );

        AppointmentBookingAppointment CreateAppointment(
            AppointmentBookingAppointment appointment
            );

        void CancelAppointment(
            int AppointmentID
            );

        AppointmentBookingDate CreateDate(
            AppointmentBookingDate appointmentBookingDate
            );

        AppointmentBookingUser CreateUser(
            AppointmentBookingUser appointmentBookingUser
            );
    }
}
