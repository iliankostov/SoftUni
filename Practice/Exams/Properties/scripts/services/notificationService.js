define(['noty'], function (noty) {
    var notificationService = {};

    function display(type, text, time) {
        noty({
            text: text,
            type: type,
            dismissQueue: true,
            layout: 'bottomCenter',
            theme: 'relax',
            maxVisible: 10,
            closeWith: ['click'],
            timeout: time
        });
    }

    notificationService.showSuccess = function (text) {
        display('success', text, 2000);
    };

    notificationService.showError = function (text) {
        display('error', text, 2000);
    };

    return notificationService;
});
