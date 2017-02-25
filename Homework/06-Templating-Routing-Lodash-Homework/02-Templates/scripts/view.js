define(['mustache'], function (Mustache) {
    return (function() {
        function OutputView(selector, data) {
            $.get('templates/output.tpl', function (template) {
                var output = Mustache.render(template, data);
                $(selector).html(output);
            })
        }
        
        return {
            load: function (selector, data) {
                return new OutputView(selector, data);
            }
        }
    })();
});