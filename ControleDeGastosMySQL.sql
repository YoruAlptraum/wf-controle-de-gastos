/*
create user 'admcontroledegastos'@'localhost' identified by 'adm123';
grant all on controledegastos.* to 'admcontroledegastos'@'localhost';
*/

CREATE DATABASE controledegastos;
use controledegastos;

create table controle2021 (
id bigint primary key auto_increment,
descriçao varchar(255),
previsao bit(1),
valor double,
dataRegistro date
);

/* 
select id,descriçao,valor,previsao,dataRegistro 
from controle2021
where month(dataRegistro) = '12';

--insert example--
insert into controle2021 (descriçao,previsao,valor,dataRegistro)
values 
('descriçao de teste', 1, -123.11,'2021-07-31'),
('descriçao de teste 2', 0, -123.11,'2021-07-10');


show tables;

select id,descriçao,valor,previsao,dataRegistro
from controle2021
where month(dataRegistro) = '4' and previsao = 0 and valor < 0;

delete from controle2021
	where id = 3;
*/
