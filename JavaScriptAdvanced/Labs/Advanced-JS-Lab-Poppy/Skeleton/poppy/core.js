var poppy = poppy || {};

(function(scope) {
    function pop(type, title, message, callback) {
        var popup;
        switch (type) {
            // TODO: Implement various popup types
            case 'success':
                popup = new poppy.Success(title, message);
                break;
            case 'info':
                popup = new poppy.Info(title, message);
                break;
            case 'error':
                popup = new poppy.Error(title, message);
                break;
            case 'warning':
                popup = new poppy.Warning(title, message, callback);
                break;
            default:
                throw new Error("Invalid type");
                break;
        }

        // generate view from view factory
        var view = poppy.createPopupView(popup);

        processPopup(view, popup);

        document.body.appendChild(view);
    }

    function processPopup(domView, popup) {
        // TODO: Implement popup logic
        // fade in elements
        fadeIn(domView);

        // close button and fade out
        if (popup._popupData.closeButton) {
            var buttonDiv = domView.getElementsByClassName('poppy-close-button')[0];
            buttonDiv.addEventListener('click', function() {
                fadeOut(domView);
            })
        }

        // fade out elements with auto hide
        if (popup._popupData.autoHide) {
            setTimeout(function () {
                fadeOut(domView)
            }, popup._popupData.timeout);
        }

        // callback
        if (popup._popupData.callback) {
            domView.addEventListener('click', function() {
                popup._popupData.callback();
            })
        }

        function fadeIn(el, display){
            el.style.opacity = 0;
            el.style.display = display || "block";

            (function fade() {
                var val = parseFloat(el.style.opacity);
                if (!((val += .01) > 1)) {
                    el.style.opacity = val;
                    requestAnimationFrame(fade);
                }
            })();
        }

        function fadeOut(el){
            el.style.opacity = 1;

            (function fade() {
                if ((el.style.opacity -= .01) < 0) {
                    el.style.display = "none";
                } else {
                    requestAnimationFrame(fade);
                }
            })();
        }
    }

    scope.pop = pop;
    scope.processPopup = processPopup;
})(poppy);