using Dnn.Appointment.Debug.DnnAppointmentDebug.Models;
using Dnn.Appointment.Debug.DnnAppointmentDebug.Services.Implementations;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework;
using DotNetNuke.UI.UserControls;
using DotNetNuke.Web.Api;
using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Services
{
    internal class AppointmentBookingManager : IAppointmentBookingManager
    {
        public AppointmentBookingManager()
            : this(DotNetNuke.Entities.Users.UserController.Instance)
        { }

        public AppointmentBookingManager(
            IUserController userController
            )
        {
            UserController = (UserController)(userController
                ?? throw new ArgumentNullException(nameof(userController)));
        }

        private IUserController UserController { get; }

        public AppointmentData[] GetAppointmentData()
        {
            var currentUser = UserController.GetCurrentUserInfo();
            if (currentUser.IsSuperUser)
            {
                using (var ctx = DataContext.Instance())
                {
                    var r = ctx.GetRepository<AppointmentBookingAppointment>().Get().ToArray();
                    return FetchAppointmentData(ctx, r);
                }
            }
            else
            {
                return null;
            }
        }

        public void CancelAppointment(int AppointmentID)
        {
            using (var ctx = DataContext.Instance())
            {
                var r = ctx.GetRepository<AppointmentBookingAppointment>();
                var appointment = r.GetById(AppointmentID);
                if (appointment !=null)
                {
                    r.Delete(appointment);
                }
            }
        }

        public AppointmentBookingAppointment CreateAppointment(AppointmentBookingAppointment appointment)
        {
            var currentUser = UserController.GetCurrentUserInfo();
            if (currentUser.UserID == Null.NullInteger)
                throw new AppointmentException("Guests can't create bookings.");

            appointment.CreatedByUserId = currentUser.UserID;
            appointment.CreatedOnDate = DateTime.Now;

            using(var ctx = DataContext.Instance())
            {
                var r = ctx.GetRepository<AppointmentBookingAppointment>();
                r.Insert(appointment);
            }
            return appointment;
        }

        public AppointmentData FindAppointmentByID(int AppointmentID)
        {
            using ( var ctx = DataContext.Instance())
            {
                var r = ctx.GetRepository<AppointmentBookingAppointment>();
                var appointment = r.GetById(AppointmentID);
                if (appointment is null)
                    return null;

                var date = ctx.GetRepository<AppointmentBookingDate>().GetById(appointment.DateID);
                var user = ctx.GetRepository<AppointmentBookingUser>().GetById(appointment.UserID);
                return new AppointmentData(appointment, date, user);
            }
        }

        private AppointmentData[] FetchAppointmentData(IDataContext ctx, AppointmentBookingAppointment[] appointments)
        {
            var currentUser = UserController.GetCurrentUserInfo();
            var appointmentIDs = appointments.Select(a => a.AppointmentID).Distinct().ToArray();
            var appoints = appointmentIDs.Length == 0 
                ? new AppointmentBookingAppointment[0] 
                : ctx.GetRepository<AppointmentBookingAppointment>()
                .Find("WHERE AppointmentID in (@0)", appointmentIDs).ToArray();


            var dateIDs = appointments.Select(a => a.DateID).Distinct().ToArray();
            var dates = dateIDs.Length == 0
                ? new AppointmentBookingDate[0]
                : ctx.GetRepository<AppointmentBookingDate>()
                .Find("WHERE DateID in (@0)", dateIDs).ToArray();


            var userIDs = appointments.Select(a => a.UserID).Distinct().ToArray();
            var users = userIDs.Length == 0
                ? new AppointmentBookingUser[0]
                : ctx.GetRepository<AppointmentBookingUser>()
                .Find("WHERE UserID in (@0)", userIDs).ToArray();

            return appointments.Select(a => new AppointmentData(
                    a,
                    dates.FirstOrDefault(d => d.DateID == a.DateID),
                    users.FirstOrDefault(u => u.UserID == a.UserID)
                )
            {
                UserInfo = currentUser.IsAdmin
                        ? UserController.GetUserById(currentUser.PortalID, a.CreatedByUserId)
                        : (a.CreatedByUserId == currentUser.UserID ? currentUser : null)
            }
            ).ToArray();
        }

        public AppointmentData[] FindAppointmentsByUser(int UserID)
        {
            using( var ctx = DataContext.Instance())
            {
                var r = ctx.GetRepository<AppointmentBookingAppointment>().Find("WHERE CreatedByUserId = @0", UserID).ToArray();
                return FetchAppointmentData(ctx,r);
            }
        }
        public AppointmentBookingDate CreateDate(AppointmentBookingDate appointmentBookingDate)
        {
            var currentUser = UserController.GetCurrentUserInfo();
            if (currentUser.UserID == Null.NullInteger)
                throw new AppointmentException("Guests can't create bookings.");

            using (var ctx = DataContext.Instance())
            {
                var r = ctx.GetRepository<AppointmentBookingDate>();
                r.Insert(appointmentBookingDate);
            }
            return appointmentBookingDate;
        }

        public AppointmentBookingUser CreateUser(AppointmentBookingUser appointmentBookingUser) 
        {
            var currentUser = UserController.GetCurrentUserInfo();
            if (currentUser.UserID == Null.NullInteger)
                throw new AppointmentException("Guests can't create bookings.");

            using (var ctx = DataContext.Instance())
            {
                var r = ctx.GetRepository<AppointmentBookingUser>();
                r.Insert(appointmentBookingUser);
            }
            return appointmentBookingUser;
        }
    }
}
