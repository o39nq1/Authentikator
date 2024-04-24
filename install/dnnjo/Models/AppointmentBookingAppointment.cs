using System;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Models
{
    [TableName("AppointmentBookingAppointment")]
    [PrimaryKey(nameof(AppointmentID), AutoIncrement = true)]
    public class AppointmentBookingAppointment
    {
        public int AppointmentID { get; set; }

        public int UserID { get; set; }

        public int DateID { get; set; }

        public int CreatedByUserId {  get; set; }

        public DateTime CreatedOnDate { get; set; }
    }
}
