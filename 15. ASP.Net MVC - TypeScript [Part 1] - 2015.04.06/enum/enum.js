var WidgetType;
(function (WidgetType) {
    WidgetType[WidgetType["TextBox"] = 0] = "TextBox";
    WidgetType[WidgetType["PasswordBox"] = 1] = "PasswordBox";
    WidgetType[WidgetType["FileUploader"] = 2] = "FileUploader";
})(WidgetType || (WidgetType = {}));
;
var Widget = (function () {
    function Widget() {
    }
    Widget.prototype.get_widget_type = function () {
        return this.widget_type;
    };
    Widget.prototype.set_widget_type = function (widget_type) {
        this.widget_type = widget_type;
    };
    return Widget;
})();
var myWidget = new Widget();
myWidget.set_widget_type(WidgetType.TextBox);
console.log(myWidget.get_widget_type());
myWidget.width = 100;
