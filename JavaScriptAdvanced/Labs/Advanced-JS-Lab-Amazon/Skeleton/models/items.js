var models = models || {};

(function(scope) {
    function Item(title, description, price){
        this.title = title;
        this.description = description;
        this.price = price;
        this._customerReviews = [];
    }

    Item.prototype.addCustomerReview = function addCustomerReview(customerReview) {
        this._customerReviews.push(customerReview);
    };

    Item.prototype.getCustomerReview = function getCustomerReview() {
        return this._customerReviews;
    };

    function UsedItem(title, description, price, condition) {
        Item.apply(this, arguments);
        this.condition = condition;
    }

    UsedItem.extends(Item);

    scope.getItem = function(title, description, price) {
        return new Item(title, description, price);
    };
    scope.getUsedItem = function(title, description, price, condition) {
        return new UsedItem(title, description, price, condition);
    };
})(models);