function validation(){
    var name = document.getElementById("username").value;
    if(name == ""){
        document.querySelector(".name-alert").innerHTML = "Please enter your name";
        
    }
    var password= document.getElementById("password").value;
    if(password == ""){
        document.querySelector(".password-alert").innerHTML = "Please enter your password";
    }
    var email = document.getElementById("email").value;
    var em = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!em.test(email)) {
    alert("Invalid email address");
    }

    var phone=document.getElementById("phone").value;
    var ph=/^\d{10}$/;
    if(!(ph.test(phone))){
       alert("invalid mobile number");
    }
    var address=document.getElementById("address").value;
    if(address==""){
        document.querySelector(".address-alert").innerHTML="please enter your address";
    }

    window.location.href = "login.html";
    
    
}