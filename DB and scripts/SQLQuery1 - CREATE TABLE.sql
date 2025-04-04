USE DB_Smart_Fitness;
GO


CREATE TABLE Memberships --�������� 
(
    membership_id          INT            PRIMARY KEY IDENTITY(1,1),
	membership_type        NVARCHAR(150)   NOT NULL,
    duration           DATE            NOT NULL, -- ���� �������� �������� (�� ����)
	price  DECIMAL NOT NULL,--����
	
);

CREATE TABLE Clients --������� 
(
    client_id			INT             PRIMARY KEY IDENTITY(1,1),
	first_name			NVARCHAR(150)   NOT NULL,
	last_name			NVARCHAR(150)   NOT NULL,
	email				NVARCHAR(150)   NOT NULL,
	phone				NVARCHAR(150)   NOT NULL,
	birth_date			DATE			NOT NULL,
	registration_date	DATE			NOT NULL,
	-- ������ �� ������� ����� ��������
	membership_type         INT        NOT NULL CONSTRAINT FK_ClientsMemberships   FOREIGN KEY  REFERENCES Memberships(membership_id)
);

CREATE TABLE Trainers --�������  
(
    trainer_id 			INT             PRIMARY KEY IDENTITY(1,1),
	first_name			NVARCHAR(150)   NOT NULL,
	last_name			NVARCHAR(150)   NOT NULL,
	specialization		NVARCHAR(150)   NOT NULL,
	email				NVARCHAR(150)   NOT NULL,
	phone				NVARCHAR(150)   NOT NULL	
);

CREATE TABLE Payments --������ 
(
    payment_id			INT            PRIMARY KEY IDENTITY(1,1),
	client				INT        NOT NULL CONSTRAINT FK_PaymentsClients   FOREIGN KEY  REFERENCES Clients(client_id),
	amount				INT   NOT NULL,
	payment_date		DATE			NOT NULL,
	payment_method 		NVARCHAR(150)   NOT NULL,
);

CREATE TABLE Classes --���������� ������� 
(
    class_id			INT            PRIMARY KEY IDENTITY(1,1),
	class_name			NVARCHAR(150)   NOT NULL, --�������� �������
	[description]		NVARCHAR(150)   NOT NULL, --�������� �������
	schedule_time		TIME			NOT NULL,
	trainer				INT				NOT NULL CONSTRAINT FK_ClassesTrainers   FOREIGN KEY  REFERENCES Trainers(trainer_id)

);
CREATE TABLE Enrollments --������ �� ������� 
(
    enrollment_id          INT            PRIMARY KEY IDENTITY(1,1),
	client				INT        NOT NULL CONSTRAINT FK_EnrollmentsClients   FOREIGN KEY  REFERENCES Clients(client_id),
	class 				INT        NOT NULL CONSTRAINT FK_EnrollmentsClasses   FOREIGN KEY  REFERENCES Classes(class_id),
	enrollment_date 		DATE			NOT NULL, --���� ������
	
);
