create database TranslatorDB;

use TranslatorDB;

create table Translations(
TranslationId int primary key auto_increment,
TranslationString varchar(500),
FromLang varchar(100),
ToLang varchar(100)
);