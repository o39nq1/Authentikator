﻿class AppointmentProxy {
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

class AppointmentDialog {
    constructor(
        title,
        description
    ) {
        this.title = title;
        this.description = description;
        this.options = {};
    }

    option(choice, option) {
        this.options[choice] = option;

        return this;
    }

    render() {
        var that = this;

        var $container = $('<div></div>', {
            'class': 'tf-dialog-container dnnFormPopup'
        });
        $container.append($('<h1>' + this.title + '</h1>'));
        $container.append($('<p>' + this.description + '</p>'));
        $container.click(function (e) {
            e.stopPropagation();
        });

        for (const choice in this.options) {
            var option = this.options[choice];
            var cssClass = "dnn" + (option.type || 'Secondary') + "Action";
            var $button = $('<a href="#" class="' + cssClass + ' right tf-dialog-button">' + option.caption + '</a>');
            $button.click(function () { that.onChoiceClick(choice) });
            $container.append($button);
            $container.append('&nbsp;');
        }

        var $overlay = $('<div></div>', {
            'class': 'tf-dialog-overlay'
        });
        $overlay.append($container);
        $overlay.click(function () {
            that.onOverlayClick();
        });


        return $overlay;
    }

    show(callback) {
        if (this.$dialog) {
            var callbacks = this.$dialog.data('callback')
                || [];
            callbacks.push(callback);
            this.$dialog.data('callback', callbacks);
        }

        this.$dialog = this.render();
        this.$dialog.data('callback', [callback]);
        $('body').append(this.$dialog);

    }

    hide(choice) {
        var that = this;
        var callbacks = this.$dialog.data('callback');
        this.$dialog.hide('slow', function () {
            that.$dialog.remove();
            that.$dialog = null;
        })

        if (callbacks) {
            callbacks.forEach(function (item) {
                item(choice);
            });
        }
    }

    onOverlayClick() {
        this.hide('cancel');
    }

    onChoiceClick(choice) {
        this.hide(choice);
    }
}