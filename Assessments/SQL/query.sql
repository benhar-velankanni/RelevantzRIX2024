 create database smartinfra;
 use smartinfra;
 create table admin1(aid int primary key,aname varchar(20),age int);
 insert into admin1 values(101,'nithis',20);
 insert into admin1 values(102,'bangaru',20);
 insert into admin1 values(103,'mukesh',20);
 insert into admin1 values(104,'vicky',20);
 insert into admin1 values(105,'viswa',20);
 insert into admin1 values(106,'jes',20);
 insert into admin1 values(107,'arul',20);

select*from admin1;

create table citizen(cid int primary key,cname varchar(20) not null,age int check(age>18),address varchar(20));
insert into citizen values(1,'bnb',19,'abcdstreet');
insert into citizen values(2,'nmn',19,'bacdstreet');
insert into citizen values(3,'abc',19,'abcdstreet');
insert into citizen values(4,'def',19,'abcdstreet');
insert into citizen values(5,'ghi',19,'abcdstreet');
insert into citizen values(6,'jak',19,'abcdstreet');

create table employee(eid int primary key,ename varchar(20),department varchar(20));
insert into employee values(201,'charan','electric');
insert into employee values(202,'varun','drainage');
insert into employee values(203,'nalan','construction');
insert into employee values(204,'inia','transport');
insert into employee values(205,'karan','water supply');
insert into employee values(206,'raj','construction');
insert into employee values(207,'sangan','demolition');

create table service_request(rid int primary key,foreign key(cid) references citizen(cid),foreign key(eid) references employee(eid),request varchar(20));

insert into service_request values(1,1,201,'water supply problem');
insert into service_request values(2,4,206,'road damage');
insert into service_request values(3,6,204,'electricity problem');

alter table service_request add location varchar(20);
update service_request set location='abcd street' where rid=1;
update service_request set location='def street' where rid=2;
update service_request set location='efg street' where rid=3;
select*from service_request;

insert into service_request values(4,6,205,'electricity problem','efg street');
insert into service_request values(5,3,206,'construction problem','ghi street');
insert into service_request values(6,3,207,'demolition problem','efg street');
insert into service_request values(7,2,205,'electricity problem','efg street');
select*from service_request;

delete from service_request where rid=7;


drop table admin1;
select* from employee;
