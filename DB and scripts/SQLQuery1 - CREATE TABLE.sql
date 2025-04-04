USE DB_Smart_Fitness;
GO


CREATE TABLE Memberships --Членство 
(
    membership_id          INT            PRIMARY KEY IDENTITY(1,1),
	membership_type        NVARCHAR(150)   NOT NULL,
    duration           DATE            NOT NULL, -- срок действия членства (до даты)
	price  DECIMAL NOT NULL,--цена
	
);

CREATE TABLE Clients --Клиенты 
(
    client_id			INT             PRIMARY KEY IDENTITY(1,1),
	first_name			NVARCHAR(150)   NOT NULL,
	last_name			NVARCHAR(150)   NOT NULL,
	email				NVARCHAR(150)   NOT NULL,
	phone				NVARCHAR(150)   NOT NULL,
	birth_date			DATE			NOT NULL,
	registration_date	DATE			NOT NULL,
	-- ссылка на таблицу типов членства
	membership_type         INT        NOT NULL CONSTRAINT FK_ClientsMemberships   FOREIGN KEY  REFERENCES Memberships(membership_id)
);

CREATE TABLE Trainers --Тренеры  
(
    trainer_id 			INT             PRIMARY KEY IDENTITY(1,1),
	first_name			NVARCHAR(150)   NOT NULL,
	last_name			NVARCHAR(150)   NOT NULL,
	specialization		NVARCHAR(150)   NOT NULL,
	email				NVARCHAR(150)   NOT NULL,
	phone				NVARCHAR(150)   NOT NULL	
);

CREATE TABLE Payments --Оплата 
(
    payment_id			INT            PRIMARY KEY IDENTITY(1,1),
	client				INT        NOT NULL CONSTRAINT FK_PaymentsClients   FOREIGN KEY  REFERENCES Clients(client_id),
	amount				INT   NOT NULL,
	payment_date		DATE			NOT NULL,
	payment_method 		NVARCHAR(150)   NOT NULL,
);

CREATE TABLE Classes --Расписание занятий 
(
    class_id			INT            PRIMARY KEY IDENTITY(1,1),
	class_name			NVARCHAR(150)   NOT NULL, --Название занятия
	[description]		NVARCHAR(150)   NOT NULL, --Описание занятия
	schedule_time		TIME			NOT NULL,
	trainer				INT				NOT NULL CONSTRAINT FK_ClassesTrainers   FOREIGN KEY  REFERENCES Trainers(trainer_id)

);
CREATE TABLE Enrollments --Записи на занятия 
(
    enrollment_id          INT            PRIMARY KEY IDENTITY(1,1),
	client				INT        NOT NULL CONSTRAINT FK_EnrollmentsClients   FOREIGN KEY  REFERENCES Clients(client_id),
	class 				INT        NOT NULL CONSTRAINT FK_EnrollmentsClasses   FOREIGN KEY  REFERENCES Classes(class_id),
	enrollment_date 		DATE			NOT NULL, --Дата записи
	
);
