define(['outputView'], function (outputView) {
    return (function() {
        function Controller(model) {
        }

        Controller.prototype.getOutput = function (selector, model) {
            outputView.load(selector, model);
        };

        return {
            load: function (model) {
                return new Controller(model);
            }
        }
    })();
});
