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
        }

        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Index()
        {
            InitPopup();
            var currentUser = UserController.GetCurrentUserInfo();
            if (currentUser.UserID > 0)
            {
                var anon = false;
                ViewBag.Anon = anon;
            }
            else
            {
                var anon = true;
                ViewBag.Anon = anon;
            }
            if (currentUser.IsSuperUser)
            {
                var IsSuperUser = true;
                ViewBag.IsSuperUser = IsSuperUser;
                var appointments = AppointManager.GetAppointmentData();
                ViewBag.Appointments = appointments;
            }
            else
            {
                var IsSuperUser = false;
                ViewBag.IsSuperUser = IsSuperUser;
                var appointments = AppointManager.FindAppointmentsByUser(User.UserID);
                ViewBag.Appointments = appointments;
            }
            return View();
        }

        [DnnAuthorize]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Create()
        {
            InitPopup();

            ViewBag.CarTypes = new SelectList(new[]
            {					
                new SelectListItem() {Text = "Válasszon egy típust", Value = null},
                new SelectListItem() {Text = "356", Value = "356"},
                new SelectListItem() {Text = "911", Value = "911"},
                new SelectListItem() {Text = "914", Value = "914"},
                new SelectListItem() {Text = "928", Value = "928"},
                new SelectListItem() {Text = "944", Value = "944"},
                new SelectListItem() {Text = "964", Value = "964"},
                new SelectListItem() {Text = "991", Value = "991"},
                new SelectListItem() {Text = "992", Value = "992"},
                new SelectListItem() {Text = "993", Value = "993"},
                new SelectListItem() {Text = "996", Value = "996"},
                new SelectListItem() {Text = "997", Value = "997"},
                new SelectListItem() {Text = "Boxster", Value = "Boxster"},
                new SelectListItem() {Text = "Cayenne", Value = "Cayenne"},
                new SelectListItem() {Text = "Cayman", Value = "Cayman"},
                new SelectListItem() {Text = "GT3", Value="GT3"},
                new SelectListItem() {Text = "Macan", Value = "Macan"},
                new SelectListItem() {Text = "Panamera", Value = "Panamera"}
            }, nameof(SelectListItem.Value), nameof(SelectListItem.Text));

            return PartialView("Create");
        }

        [DnnAuthorize]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Detail(int AppointmentID)
        {
            InitPopup();

            var appointment = AppointManager.FindAppointmentByID(AppointmentID);
            ViewBag.Appointment = appointment;
            return PartialView("Detail");
        }
    }
}