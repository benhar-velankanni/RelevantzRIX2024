function trim(str) {
  return str.replace(/^\s+|\s+$/g, "");
}

function validateForm() {
  var name = trim(document.getElementById("employeeName").value);
  var email = trim(document.getElementById("employeeEmail").value);
  var phone = trim(document.getElementById("employeePhone").value);
  var position = trim(document.getElementById("employeePosition").value);

  if (name === "" || name === null || name === undefined) {
    alert("Enter a valid name.");
    return false;
  }

  var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (email === "" || !emailRegex.test(email)) {
    alert("Please enter a valid Email ID.");
    return false;
  }

  if (phone === "" || phone === null || phone === undefined) {
    alert("Enter a valid phone number.");
    return false;
  }

  if (position === "" || position === null || position === undefined) {
    alert("Enter a valid position.");
    return false;
  }

  var summary =
    "Name: " +
    name +
    "\nEmail: " +
    email +
    "\nPhone: " +
    phone +
    "\nPosition: " +
    position;
  alert(summary);
  return true;
}
