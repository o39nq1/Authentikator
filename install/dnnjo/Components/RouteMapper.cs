using DotNetNuke.Web.Api;
using System.Diagnostics;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Components
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                "AppointmentBookingAppointment",
                "default",
                "{controller}/{action}",
                new string[] { "Dnn.Appointment.Debug.DnnAppointmentDebug.Controllers.Api" });
        }
    }
}
