function login(event) {
  event.preventDefault();
  let name = document.getElementById("username").value;
  let passwd = document.getElementById("password").value;
  if (name === "user" && passwd === "user") {
    alert("Login successful");
    alert("Welcome " + name);
    window.location.href = "home.html";
  } else {
    alert("Invalid username or password");
    return;
  }
}

function register(event) {
  event.preventDefault();
  let name = document.getElementById("username").value;
  let passwd = document.getElementById("password").value;
  let confirmpassword = document.getElementById("confirmpassword").value;
  let age = document.getElementById("age").value;
  let mail = document.getElementById("mail").value;
  let phone = document.getElementById("phone").value;
  let address = document.getElementById("address").value;
  let income = document.getElementById("income").value;
  let occupation = document.getElementById("occupation").value;
  // validate whether there is file uploaded or not
  let fileInput = document.getElementById("file");

  let emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (
    name === "" ||
    passwd === "" ||
    confirmpassword === "" ||
    age === "" ||
    mail === "" ||
    phone === "" ||
    address === "" ||
    income === "" ||
    occupation === ""
  ) {
    alert("All fields are mandatory");
    return;
  } else if (passwd !== confirmpassword) {
    alert("Passwords do not match");
    return;
  } else if (age < 18) {
    alert("You must be 18 years or older to register");
    return;
  } else if (!fileInput) {
    alert("Please upload an ID");
    return;
  } else if (!emailRegex.test(mail)) {
    alert("Invalid email address");
    return;
  } else if (phone.length !== 10) {
    alert("Phone number must be 10 digits");
    return;
  } else if (income < 0) {
    alert("Income cannot be negative");
    return;
  } else if (occupation === "") {
    alert("Please select an occupation");
    return;
  } else {
    savecookies();
  }
}

function savecookies() {
  let name = document.getElementById("username").value;
  let passwd = document.getElementById("password").value;

  let date = new Date();
  date.setTime(date.getTime() + 1 * 24 * 60 * 60 * 1000);
  let expires = "expires=" + date.toUTCString();
  document.cookie = "username=" + name + ";" + expires + ";path=/";
  document.cookie = "password=" + passwd + ";" + expires + ";path=/";

  let cookies = document.cookie.split(";");
  for (let i = 0; i < cookies.length; i++) {
    let cookie = cookies[i].trim();
    if (cookie.startsWith("username=")) {
      let username = cookie.substring("username=".length);
      alert("Welcome: " + username);
      window.location.href = "home.html";
    }
  }
}
