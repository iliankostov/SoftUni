define(['notyLib'], function (noty) {
    return (function () {

        function display(type, text, time) {
            noty({
                text: text,
                type: type,
                dismissQueue: true,
                layout: 'bottomCenter',
                theme: 'defaultTheme',
                maxVisible: 10,
                timeout: time
            });
        }

        function success(text) {
            display('success', text, 1500);
        }

        function error(text) {
            display('error', text, 1500);
        }

        return {
            success: success,
            error: error
        }
    }());
});
