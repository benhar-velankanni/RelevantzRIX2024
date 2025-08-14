var today = new Date();
var h = today.getHours();
var m = today.getMinutes();
var s = today.getSeconds();
if (h > 12) {
  console.log(h - 12 + ":" + m + ":" + s);
} else {
  console.log(h + ":" + m + ":" + s);
}
