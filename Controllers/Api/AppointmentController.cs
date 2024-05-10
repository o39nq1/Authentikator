using Dnn.Appointment.Debug.DnnAppointmentDebug.Services;
using System;
using System.Net.Http;
using System.Web.Http;
using Dnn.Appointment.Debug.DnnAppointmentDebug.Models;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Framework;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using System.Web.Helpers;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Controllers.Api
{
    public class AppointmentController : AppointmentApiControllerBase
    {
        public AppointmentController(
            IAppointmentBookingManager appointmentManager): base(appointmentManager) { }

        [HttpGet]
        public HttpResponseMessage GetAllAppointments()
        {
            try
            {
                var allappointments = AppointmentBooking.GetAppointmentData();
                return Json(new { allappointments });
            }
            catch (Exception ex)
            {

                return JsonException(ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAppointmentById(int id)
        {
            try
            {
                var appointment = AppointmentBooking.FindAppointmentByID(id);
                return Json(new {appointment});
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAppointmentByUser(int userId)
        {
            try
            {
                var appointment = AppointmentBooking.FindAppointmentsByUser(userId);
                return Json(new {appointment});
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnModuleAuthorize]
        public HttpResponseMessage CreateDate([FromBody] AppointmentBookingDate args)
        {
            try
            {
                var date = new AppointmentBookingDate()
                {
                    DateTime = args.DateTime,
                    StartTime = args.StartTime,
                    EndTime = args.EndTime
                };

                date = AppointmentBooking.CreateDate(date);
                return Json(date);
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnModuleAuthorize]
        public HttpResponseMessage CreateUser([FromBody] AppointmentBookingUser args)
        {
            try
            {
                var user = new AppointmentBookingUser()
                {
                    FirstName = args.FirstName,
                    LastName = args.LastName,
                    Email = args.Email,
                    PhoneNumber = args.PhoneNumber,
                    CarType = args.CarType,
                    CarYear = args.CarYear,
                };

                user = AppointmentBooking.CreateUser(user);
                return Json(user);
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnModuleAuthorize]
        public HttpResponseMessage CreateAppointment([FromBody] CreateAppointment args)
        {
            try
            {
                var appointment = new AppointmentBookingAppointment()
                {
                    UserID = args.UserID,
                    DateID = args.DateID,
                };

                appointment = AppointmentBooking.CreateAppointment(appointment);
                return Json(appointment);
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnModuleAuthorize]
        public HttpResponseMessage CancelAppointment([FromBody] CancelAppointment args)
        {
            try
            {
                AppointmentBooking.CancelAppointment(args.AppointmentID);
                return JsonOk();
            }
            catch(Exception ex)
            {
                return JsonException(ex);
            }
        }
    }
}
