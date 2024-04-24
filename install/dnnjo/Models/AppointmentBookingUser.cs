using System;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.UI.UserControls;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Models
{
    [TableName("AppointmentBookingUser")]
    [PrimaryKey(nameof(UserID), AutoIncrement = true)]
    [Scope("ModuleId")]
    public class AppointmentBookingUser
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CarType { get; set; }

        public int CarYear { get; set; }
    }
}
