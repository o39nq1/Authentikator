﻿using System;
using System.Net;
using System.Net.Http;
using DotNetNuke.Web.Api;

namespace Dnn.Appointment.Debug.DnnAppointmentDebug.Controllers.Api
{
    public class RestApiController : DnnApiController
    {
        protected HttpResponseMessage Json(object data)
            => Json(200, data);

        protected HttpResponseMessage Json(HttpStatusCode status, object data)
        {
            var response = Request.CreateResponse(
                status,
                data,
                "application/json"
                );
            return response;
        }

        protected HttpResponseMessage Json(int status, object data)
            => Json((HttpStatusCode)status, data);

        protected HttpResponseMessage JsonOk()
            => Json(new { result = "ok" });

        protected HttpResponseMessage JsonException(Exception ex)
            => Json(
                HttpStatusCode.InternalServerError, new
                {
                    error = ex.Message
                });
    }
}
