class AppointmentProxy {
    constructor(moduleID, serviceName) {
        this.serviceName = serviceName;
        var sf = $.ServicesFramework(moduleID);
        this.baseUrl = sf.getServiceRoot(serviceName);
    }

    invoke(method, url, data, callback) {
        $.ajax({
            url: url,
            type: method,
            data: data,
            cache: false,
            success: function (response) {
                callback(true, response);
            }
        })
            .fail(function (xhr) {
                var json = xhr.responseJSON ? xhr.responseJSON : null;
                var jsonError = json && json.error ? json.error : null;

                var message = jsonError
                    || `Request from ${url} failed with status: ${xhr.status}`;

                callback(false, message);
            });
    }

    post(url, data, callback) {
        this.invoke('POST', url, data, callback);
    }

    cancel(appointmentID, callback) {
        this.post(
            this.baseUrl + 'Appointment/CancelAppointment', {
            AppointmentID: appointmentID
        },
            callback
        )
    }

    create(dateId, userId, callback) {
        this.post(
            this.baseUrl + 'Appointment/CreateAppointment', {
            DateId: dateId,
            UserId: userId
        },
            callback
        )
    }
    createDate(dateTime, startTime, endTime, callback) {
        this.post(
            this.baseUrl + 'Appointment/CreateDate', {
            DateTime: dateTime,
            StartTime: startTime,
            EndTime: endTime
        },
            callback
        )
    }

    createUser(firstName, lastName, email, phoneNumber, carType, carYear, callback) {
        this.post(
            this.baseUrl + 'Appointment/CreateUser', {
            FirstName: firstName,
            LastName: lastName,
            Email: email,
            PhoneNumber: phoneNumber,
            CarType: carType,
            CarYear: carYear
        },
            callback
        )
    }
}