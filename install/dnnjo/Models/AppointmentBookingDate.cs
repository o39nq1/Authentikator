using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Security.Membership;
using System;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Models
{
    [TableName("AppointmentBookingDate")]
    [PrimaryKey(nameof(DateID),AutoIncrement = true)]
    [Scope("ModuleId")]
    public class AppointmentBookingDate
    {
        public int DateID {  get; set; }

        public DateTime DateTime {  get; set; }

        public DateTime StartTime {  get; set; }

        public DateTime EndTime { get; set; }
    }
}
