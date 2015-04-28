(function() {
  var myThirdFunction;

  if (typeof elvis !== "undefined" && elvis !== null) {
    alert("I knew it!");
  }

  myThirdFunction = function() {
    return 'third';
  };

}).call(this);
