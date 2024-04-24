using System;
using System.Runtime.Serialization;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Services.Implementations
{
    [Serializable]
    internal class AppointmentException : Exception
    {
        public AppointmentException()
        {
        }

        public AppointmentException(string message) :base(message)
        {
        }

        public AppointmentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppointmentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
