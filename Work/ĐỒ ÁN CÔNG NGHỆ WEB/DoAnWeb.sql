CREATE DATABASE QuanLyTinTuc

use QuanLyTinTuc

drop database QuanLyTinTuc

create table users(
	id_user int primary key,
	username varchar(30),
	pass varchar(20),
	birthday date,
	gender char(5),
	phone varchar(15),
	email varchar(30),
	diachi varchar(30)
)

create table baiviet(
	id_post int identity(1,1) primary key,
	name_post varchar(30),
	admin_name varchar(30),
	date_create date
)

create table admins(
	id_admin int primary key,
	admin_name varchar(30), 
	pass varchar(20),
	birthday date,
	gender char(5),
	phone varchar(15),
	email varchar(30),
	diachi varchar(30),
	id_post int,
	Foreign Key (id_post) References baiviet(id_post)
)


create table danhmuc(
	id_danhmuc int identity(1,1) primary key,
	name_danhmuc nvarchar(30),
	id_post int,
	id_admin int,
	Foreign Key (id_post) References baiviet(id_post),
)

create table QuanLy(
	id_user int,
	id_admin int,
	Foreign Key (id_user) References users(id_user),
	Foreign Key (id_admin) References admins(id_admin)
)

create table ThaoTac(
	id_admin int,
	id_danhmuc int,
	Foreign Key (id_admin) References admins(id_admin),
	Foreign Key (id_danhmuc) References danhmuc(id_danhmuc)
)



	