// TODO: Implement popup function constructors
var poppy = poppy || {};

Object.prototype.extends = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

var Popup = (function () {
    // define function constructor Popup
    var Popup;
    Popup = function (title, message) {
        this._popupData = {};
        this._popupData.title = title;
        this._popupData.message = message;
    };
    return Popup;
})();

var Success = (function () {
    // define function constructor Success
    var Success;
    Success = function (title, message) {
        Popup.call(this, title, message);
        this._popupData.type = 'success';
        this._popupData.position = 'bottomLeft';
    };
    // extend base
    Success.extends(Popup);
    return Success;
})();

var Info = (function () {
    // define function constructor Success
    var Info;
    Info = function (title, message) {
        Popup.call(this, title, message);
        this._popupData.type = 'info';
        this._popupData.position = 'topLeft';
        this._popupData.closeButton = true;
        this._popupData.autoHide = true;
        this._popupData.timeout = 3000;
    };
    // extend base
    Info.extends(Popup);
    return Info;
})();

var Error = (function () {
    // define function constructor Success
    var Error;
    Error = function (title, message) {
        Popup.call(this, title, message);
        this._popupData.type = 'error';
        this._popupData.position = 'topRight';
        this._popupData.autoHide = true;
        this._popupData.timeout = 3000;
    };
    // extend base
    Error.extends(Popup);
    return Error;
})();

var Warning = (function () {
    // define function constructor Success
    var Warning;
    Warning = function (title, message, callback) {
        Popup.call(this, title, message);
        this._popupData.type = 'warning';
        this._popupData.position = 'bottomRight';
        this._popupData.callback = callback;
    };
    // extend base
    Warning.extends(Popup);
    return Warning;
})();