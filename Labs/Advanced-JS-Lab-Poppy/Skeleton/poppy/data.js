// TODO: Implement popup function constructors
var poppy = poppy || {};

poppy.Popup = (function () {
    // define function constructor Popup
    var Popup;
    Popup = function (title, message) {
        this._popupData = {};
        this._popupData.title = title;
        this._popupData.message = message;
    };
    return Popup;
})();

poppy.Success = (function () {
    // define function constructor Success
    var Success;
    Success = function (title, message) {
        poppy.Popup.call(this, title, message);
        this._popupData.type = 'success';
        this._popupData.position = 'bottomLeft';
    };
    // extend base
    Success.extends(poppy.Popup);
    return Success;
})();

poppy.Info = (function () {
    // define function constructor Success
    var Info;
    Info = function (title, message) {
        poppy.Popup.call(this, title, message);
        this._popupData.type = 'info';
        this._popupData.position = 'topLeft';
        this._popupData.closeButton = true;
        this._popupData.autoHide = true;
        this._popupData.timeout = 3000;
    };
    // extend base
    Info.extends(poppy.Popup);
    return Info;
})();

poppy.Error = (function () {
    // define function constructor Success
    var Error;
    Error = function (title, message) {
        poppy.Popup.call(this, title, message);
        this._popupData.type = 'error';
        this._popupData.position = 'topRight';
        this._popupData.autoHide = true;
        this._popupData.timeout = 3000;
    };
    // extend base
    Error.extends(poppy.Popup);
    return Error;
})();

poppy.Warning = (function () {
    // define function constructor Success
    var Warning;
    Warning = function (title, message, callback) {
        poppy.Popup.call(this, title, message);
        this._popupData.type = 'warning';
        this._popupData.position = 'bottomRight';
        this._popupData.callback = callback;
    };
    // extend base
    Warning.extends(poppy.Popup);
    return Warning;
})();