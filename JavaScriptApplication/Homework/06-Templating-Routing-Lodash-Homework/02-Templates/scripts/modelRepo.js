define([], function () {
    return (function() {
        function ModelRepo() {
            this.data = {
                data: [
                    {name: 'Garry Finch', jobTitle: 'Front End Technical Lead', website: 'http://website.com'},
                    {name: 'Bob McFray', jobTitle: 'Photographer', website: 'http://goo.gle'},
                    {name: 'Jenny O\'Sullivan', jobTitle: 'LEGO Geek', website: 'http://stackoverflow.com'}
                ]
            }
        }

        return {
            load: function () {
                return new ModelRepo();
            }
        }
    })();
});
