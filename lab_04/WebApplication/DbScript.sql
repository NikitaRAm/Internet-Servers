drop database nikram_asp4;
create database nikram_asp4;
use nikram_asp4;

create table users
(
	id  int identity(1,1),
	name nvarchar(255),
	phoneNumber nvarchar(50),
	primary key(id)
);

insert into users	values	('Nikira Roman', '+375298207908'),
							('Yan Pershay',  '+375293442128'),
							('Nikita Slavin',  '+375292071881'),
							('Vodem Dokurno', '+375293343392');