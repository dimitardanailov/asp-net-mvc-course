
enum WidgetType {TextBox, PasswordBox, FileUploader};

class Widget {
  private widget_type: WidgetType;
  private static myStaticProperty: number;
  width: number;

  get_widget_type() {
      return this.widget_type;
  }
  set_widget_type(widget_type: WidgetType) {
    this.widget_type = widget_type;
  }
}

var myWidget = new Widget();
myWidget.set_widget_type(WidgetType.TextBox);
console.log(myWidget.get_widget_type());

// Width is public property
myWidget.width = 100;
