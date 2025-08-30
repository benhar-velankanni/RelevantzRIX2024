import { employee, book, car, course, Product } from "./submain";

var name=document.getElementById("name") as HTMLInputElement;
var price=document.getElementById("price") as HTMLInputElement;
var stock=document.getElementById("stock") as HTMLInputElement;
var bt1=document.getElementById("bt1") as HTMLInputElement;

bt1.addEventListener("click",(e)=>{
    e.preventDefault();
    var p1=new Product();
    p1.prodis({name:name.value,price:parseInt(price.value),isStock:stock.checked});
})

var btitle=document.getElementById("btitle") as HTMLInputElement;
var author=document.getElementById("bauthor") as HTMLInputElement;
var pages=document.getElementById("bpage") as HTMLInputElement;
var bavailable=document.getElementById("bavailable") as HTMLInputElement;
var bt2=document.getElementById("bt2") as HTMLInputElement;

bt2.addEventListener("click",(e)=>{
    e.preventDefault();
    var b1=new book();
    b1.bookdis({title:btitle.value,author:author.value,pages:parseInt(pages.value),isAvailable:bavailable.checked});
})

var ename=document.getElementById("ename") as HTMLInputElement;
var eposition=document.getElementById("eposition") as HTMLInputElement;
var esalary=document.getElementById("esalary") as HTMLInputElement;
var efultime=document.getElementById("efultime") as HTMLInputElement;
var bt4=document.getElementById("bt4") as HTMLInputElement;

bt4.addEventListener("click",(e)=>{
    e.preventDefault();
    var e1=new employee();
    e1.empdis({name:ename.value,position:eposition.value,salary:parseInt(esalary.value),isFullTime:efultime.checked});
})

var make=document.getElementById("cmake") as HTMLInputElement;
var model=document.getElementById("cmodel") as HTMLInputElement;
var year=document.getElementById("cyear") as HTMLInputElement;
var running=document.getElementById("crunning") as HTMLInputElement;
var bt3=document.getElementById("bt3") as HTMLInputElement;

bt3.addEventListener("click",(e)=>{
    e.preventDefault();
    var c1=new car();
    c1.cardis({make:make.value,model:model.value,year:parseInt(year.value),isRunning:running.checked});
})

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
