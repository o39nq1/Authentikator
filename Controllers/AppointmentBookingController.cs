using Dnn.Appointment.Debug.DnnAppointmentDebug.Services;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Framework;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dnn.Appointment.Debug.DnnAppointmentDebug.Models;
using DotNetNuke.Entities.Users;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Controllers
{
    [DnnHandleError]
    public class AppointmentBookingController : DnnController
    {
        private IAppointmentBookingManager AppointManager { get; }

        public AppointmentBookingController(IAppointmentBookingManager appointManager)
        {
            AppointManager = appointManager
                ?? throw new ArgumentNullException(nameof(appointManager));
        }

        public void InitPopup()
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.jQuery);
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            ServicesFramework.Instance.RequestAjaxScriptSupport();
            ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
        }

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Index()
        {
            var appointments = AppointManager.FindAppointmentsByUser(User.UserID);
            ViewBag.Appointments = appointments;
            return View();
        }

        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Create()
        {
            ViewBag.CarTypes = new SelectList(new[]
            {
                new SelectListItem() {Text = "Select car type", Value=null, Selected=true},
                new SelectListItem() {Text = "911", Value="911"},
                new SelectListItem() {Text = "GT3", Value="gt3"},
                new SelectListItem() {Text = "991", Value = "991"}
            }, nameof(SelectListItem.Value), nameof(SelectListItem.Text));

            if(User.IsAdmin) 
            {
                InitPopup();
            }
            return PartialView("Create");
        }

        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Detail(int AppointmentID)
        {
            InitPopup();

            var appointment = AppointManager.FindAppointmentByID(AppointmentID);
            return PartialView(appointment);
        }
    }
}