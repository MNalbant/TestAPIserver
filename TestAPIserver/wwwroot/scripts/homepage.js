var placeholdertext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Morbi tristique senectus et netus et malesuada fames ac. Fermentum posuere urna nec tincidunt praesent.";

var element = document.getElementsByClassName("panel");

Array.prototype.forEach.call(element, function(e) {
  	e.getElementsByClassName("d-flex")[0].innerHTML = placeholdertext;
});



