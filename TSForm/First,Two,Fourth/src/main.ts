import {course} from './submain'
var ctitle=document.getElementById("ctitle") as HTMLInputElement;
var cinstructor=document.getElementById("cinstructor") as HTMLInputElement;
var cduration=document.getElementById("cduration") as HTMLInputElement;
var cmode=document.getElementById("cmode") as HTMLInputElement;
var bt5=document.getElementById("bt5") as HTMLInputElement;
 
bt5.addEventListener("click",(e)=>{
    e.preventDefault();
    var c1=new course();
    c1.courdis({title:ctitle.value,instructor:cinstructor.value,duration:parseInt(cduration.value),isOnline:cmode.checked});
})