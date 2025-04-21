
import {manager,developer,checkrole} from './employee';
 
var name=document.getElementById("name") as HTMLInputElement;
var pass=document.getElementById("pass") as HTMLInputElement;
var but=document.getElementById("two4") as HTMLButtonElement;
var op1=document.getElementById("hea1") as HTMLInputElement;
var op2 =document.getElementById("hea2") as HTMLInputElement;

but.addEventListener("click",(e)=>{
    e.preventDefault();
    var user=name.value;
    var password=pass.value;
    if(user==="manager" && password==="manager@1234")
    op1.innerHTML=checkrole(new manager());
    else if(user==="developer" && password==="developer@1234")
    op2.innerHTML=checkrole(new developer());
});