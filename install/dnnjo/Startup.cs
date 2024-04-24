using Dnn.Appointment.Debug.DnnAppointmentDebug.Services;
using DotNetNuke.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnn.Appointment.DNN.Appointment
{
    public class Startup : IDnnStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAppointmentBookingManager, AppointmentBookingManager>();
        }
    }
}
