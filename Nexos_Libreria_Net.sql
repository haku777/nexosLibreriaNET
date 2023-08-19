CREATE DATABASE Nexos_Libreria_Net
GO

USE Nexos_Libreria_Net


CREATE TABLE AUTORES(
		Id int primary key identity not null,
		Nombre_completo varchar not null,
		Fecha_nacimiento date not null,
		Ciudad_de_procedencia varchar,
		Correo_electronico varchar
	)

CREATE TABLE LIBROS(
		Id int primary key identity not null,
		Titulo varchar not null,
		Fecha varchar,
		Genero varchar,
		Numero_de_paginas int,
		Autor int,
		FOREIGN KEY (Autor) REFERENCES AUTORES(id)
	)
