// [==============================================================]
// [======================  notifications ========================]
// [==============================================================]
const $notification = {
    
    alert(type, title, message, delay, icon, timer) {
        return $.notify({
            icon: icon,
            title: title,
            message: message,
        }, {
            type: type,
            delay: delay || 3000,
            timer: timer || 500,
            z_index: 9000,
            allow_dismiss: true,
            newest_on_top: true,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            }
        });
    },
    success(title, message, delay, icon = false, timer = false) {

        return this.alert('success', title, message, delay, icon, timer)
    },
    error(title, message, delay, icon = false, timer = false) {

        return this.alert('danger', title, message, delay, icon, timer)
    },
    info(title, message, delay, icon = false, timer = false) {

        return this.alert('info', title, message, delay, icon, timer)

    },
    warning(title, message, delay, icon = false, timer = false) {

        return this.alert('warning', title, message, delay, icon, timer)
    },
    notify(options) {
        return $.notify(options || {});
    }
}
