var models = models || {};

(function(scope) {
    function Category(name){
        this.name = name;
        this._categories = [];
        this._items = [];
    }

    Category.prototype.addCategory = function addCategory(categoryName) {
        this._categories.push(categoryName);
    };

    Category.prototype.getCategory = function getCategory() {
        return this._categories;
    };
    
    Category.prototype.addItem = function addItem(itemName) {
        this._items.push(itemName);
    };

    Category.prototype.getItems = function getItem() {
        return this._items;
    };

    scope.getCategory = function(name) {
        return new Category(name);
    }
})(models);