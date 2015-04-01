define(['container', 'item', 'section'], function (Container, Item, Section) {
    return {
        getItem: function (title) {
            return new Item(title);
        },
        getSection: function (title) {
            return new Section(title);
        },
        getContainer: function (title) {
            return new Container(title);
        }
    };
});
