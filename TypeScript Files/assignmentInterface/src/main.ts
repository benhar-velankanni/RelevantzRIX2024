import {ProductItem,BookItem,CarItem,EmployeeItem,CourseItem} from './Submain';
 
var p1=document.getElementById('pid') as HTMLInputElement;
var p2=document.getElementById('pname') as HTMLInputElement;
var p3=document.getElementById('pprice') as HTMLInputElement;
var p4=document.getElementById('pis') as HTMLInputElement;
var bu1=document.getElementById('b1') as HTMLInputElement;
 
bu1.addEventListener('click',function(e){
    e.preventDefault();
    var id=Number(p1.value);
    var name=p2.value;
    var price=Number(p3.value);
    var inStock=p4.checked;
    var p=new ProductItem(id,name,price,inStock);
    p.dis();
})
 
var b1=document.getElementById('bid') as HTMLInputElement;
var b2=document.getElementById('bname') as HTMLInputElement;
var b3=document.getElementById('bauthor') as HTMLInputElement;
var b4=document.getElementById('bpages') as HTMLInputElement;
var bu2=document.getElementById('b2') as HTMLInputElement;
 
bu2.addEventListener('click',function(e){
    e.preventDefault();
    var id=Number(b1.value);
    var name=b2.value;
    var author=b3.value;
    var pages=Number(b4.value);
    var b=new BookItem({id,name,author,pages});
    b.dis();
})
 
var c1=document.getElementById('cid') as HTMLInputElement;
var c2=document.getElementById('cname') as HTMLInputElement;
var c3=document.getElementById('cmake') as HTMLInputElement;
var c4=document.getElementById('cmodel') as HTMLInputElement;
var c5=document.getElementById('cyear') as HTMLInputElement;
var c6=document.getElementById('cis') as HTMLInputElement;
var bu3=document.getElementById('b3') as HTMLInputElement;
 
bu3.addEventListener('click',function(e){
    e.preventDefault();
    var id=Number(c1.value);
    var name=c2.value;
    var make=c3.value;
    var model=c4.value;
    var year=c5.value;
    var isRunning=c6.checked;
    var c=new CarItem(id,name,make,model,year,isRunning);
    c.dis();
})
 
var e1=document.getElementById('eid') as HTMLInputElement;
var e2=document.getElementById('ename') as HTMLInputElement;
var e3=document.getElementById('epos') as HTMLInputElement;
var e4=document.getElementById('esalary') as HTMLInputElement;
var e5=document.getElementById('eis') as HTMLInputElement;
var bu4=document.getElementById('b4') as HTMLInputElement;
 
bu4.addEventListener('click',function(e){
    e.preventDefault();
    var id=Number(e1.value);
    var name=e2.value;
    var position=e3.value;
    var salary=Number(e4.value);
    var isFullTime=e5.checked;
    var f=new EmployeeItem(id,name,position,salary,isFullTime);
    f.dis();
})
 
var co1=document.getElementById('coid') as HTMLInputElement;
var co2=document.getElementById('coname') as HTMLInputElement;
var co3=document.getElementById('coins') as HTMLInputElement;
var co4=document.getElementById('codur') as HTMLInputElement;
var co5=document.getElementById('cois') as HTMLInputElement;
var bu5=document.getElementById('b5') as HTMLInputElement;
 
bu5.addEventListener('click',function(e){
    e.preventDefault();
    var id=Number(co1.value);
    var name=co2.value;
    var instructor=co3.value;
    var duration=Number(co4.value);
    var isOnline=co5.checked;
    var c=new CourseItem(id,name,instructor,duration,isOnline);
    c.dis();
})
