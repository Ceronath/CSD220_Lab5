-- create a database with full unicode character set
create schema if not exists 
	superheros
character set 
	utf8mb4
collate
	utf8mb4_unicode_ci
;

-- all subsequent lines will apply to this specific database
use
	superheros
;

-- drop tables so the entire script can be run multiple times without errors
drop table if exists
	power_of_hero
;

drop table if exists
	powers
;

drop table if exists
	superheros
;

-- create superhero table
create table if not exists
	superheros (
		id int unsigned not null auto_increment primary key, 
		name varchar(25) not null, 
		alias varchar(25) not null, 
		email varchar(50) not null
	)
engine = InnoDB
;

-- create power table
create table if not exists
	powers (
		id int unsigned not null auto_increment primary key, 
		name varchar(20) unique not null, 
		description varchar(150) not null
	)
engine = InnoDB 
;

-- create associative power_of_hero table
create table if not exists
	power_of_hero (
		id int unsigned not null auto_increment primary key, 
		hero_id int unsigned not null,
		power_id int unsigned not null,
		constraint fk_hero_id foreign key (hero_id)
			references superheros(id)
			on update cascade
			on delete cascade,
		constraint fk_power_id foreign key (power_id)
			references powers(id)
			on update cascade
			on delete no action
	)
engine = InnoDB
;		