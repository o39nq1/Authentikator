class Proxy {
    constructor(moduleID, servicenName) {
        this.servicenName = servicenName;
        var sf = $.ServiceFramework(moduleID);
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
            this.baseUrl + 'Appointment/Cancel', {
                AppointmentID: appointmentID
        },
            callback
        )
    }

    create(dateId, userId, callback) {
        this.post(
            this.baseUrl + 'Appointment/Create', {
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

    createUser(firstName, lastName, email,phoneNumber,carType,carYear, callback) {
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

class AppointmentsGrid {
    /*constructor($row) {
        this.changedCallback = null;
        this.$row = $row;
        this.attach();
        this.refresh();
    }

    attach() {
        this.$role = this.$row.find('select[name="PassengerRole"]');
        this.$passenger = this.$row.find('input[name="PassengerName"]');
        this.$license = this.$row.find('input[name="PilotLicense"]');

        var that = this;
        this.$role.change(function (e) { that.onTypeChanged(); })
    }
    refresh() {
        var role = this.$role.val();
        this.$passenger.prop('disabled', !role);
        this.$license.prop('disabled', role != 'pilot');
    }

    setVisiblity(visible) {
        if (visible) {
            this.$row.show();
        } else {
            this.$row.hide();
        }
    }

    clearErrors() {
        this.$row.find('.dnnFormError').remove();
    }

    errorFor($element, message) {
        var $error = $element.next('.dnnFormError');
        if (!$error.length) {
            $error = $('<span></span>', {
                'class': 'dnnFormError'
            });
            $element.after($error);

        }

        $error.html(message);
    }

    getData() {
        return {
            role: this.$role.val(),
            name: this.$passenger.val(),
            license: this.$license.val()
        }
    }

    isEmpty() {
        var data = this.getData();
        return !data.role && !data.name && !data.license;
    }

    validate() {
        this.clearErrors();

        if (this.isEmpty())
            return true;

        var result = true;
        var data = this.getData();
        if (!data.role) {
            this.errorFor(this.$role, 'Please select passenger role.');
            result = false;
        }

        if (!data.name) {
            this.errorFor(this.$passenger, 'Please enter passenger name.');
            result = false;
        }

        if (data.role == 'pilot' && !/([a-zA-Z\d]{3})-(\d{5})-(\d{3})-(\d{4})-[sSmMlLcC]/gm.test(data.license)) {
            this.errorFor(this.$license, 'Please enter pilot license (The AAA-00000-000-0000-X formatted code).');
            result = false;

        }

        return result;
    }

    onTypeChanged() {
        this.refresh();

        if (this.changedCallback) {
            this.changedCallback();
        }
    }*/
}