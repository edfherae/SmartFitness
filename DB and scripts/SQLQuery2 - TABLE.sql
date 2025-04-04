USE DB_Smart_Fitness_1;
GO

CREATE TABLE Memberships --�������� 
(
    membership_id          INT            PRIMARY KEY IDENTITY(1,1),
	membership_type        NVARCHAR(150)   NOT NULL,
    --duration           DATE            NOT NULL, -- ���� �������� �������� (�� ����)
    duration           INT            NOT NULL, -- ���� �������� �������� (���������� �������)
	price  DECIMAL NOT NULL,--����	
);
INSERT INTO Memberships --�������� 
		( membership_type, duration, price)
VALUES  ( N'�������', 12, 12000),
		( N'�������', 140, 70000);


CREATE TABLE Trainers --�������  
(
    trainer_id 			INT             PRIMARY KEY IDENTITY(1,1),
	first_name			NVARCHAR(150)   NOT NULL,
	last_name			NVARCHAR(150)   NOT NULL,
	specialization		NVARCHAR(150)   NOT NULL,
	email				NVARCHAR(150)   NOT NULL,
	phone				NVARCHAR(16)	NOT NULL
);
INSERT INTO Trainers--������� 
		( last_name,		first_name,		specialization,								email,				phone)
VALUES  ( N'�����',			N'������',		N'������� ������',							N'dfgx@gmail.com',	'+7-678-999-77-11'),
		( N'������',		N'�����',		N'������� ������, ������ �������� �����',	N'gggg@gmail.com',	'+7-999-555-66-22'),
		( N'�����������',	N'�����',		N'������ �������� �����',					N'fgnnnn@gmail.com','+7-555-999-77-88');




CREATE TABLE Schedule_weekdays --��� ������� 
(
    schedule_weekday_id          INT            PRIMARY KEY IDENTITY(1,1),
	schedule_weekday_type        NVARCHAR(50)   NOT NULL,
);
INSERT INTO Schedule_weekdays --��� ������� 
		(schedule_weekday_type)
VALUES  ( N'��, ��, ��'),( N'��, ��, ��'),( N'��, ��');



CREATE TABLE Groups --������ 
(
group_id		INT				PRIMARY KEY IDENTITY(1,1),
group_name	NVARCHAR(50)	NOT NULL,--�������� 
[description]		NVARCHAR(150),   --�������� �������
schedule_weekday	INT				NOT NULL 
			CONSTRAINT FK_GroupsSchedule_weekdays   FOREIGN KEY  REFERENCES Schedule_weekdays(schedule_weekday_id),
schedule_time		TIME			NOT NULL,
trainer				INT				NOT NULL 
			CONSTRAINT FK_GroupsTrainers   FOREIGN KEY  REFERENCES Trainers(trainer_id),
free_seats			INT				DEFAULT 15  
			CONSTRAINT CK_free_seats	CHECK (free_seats >= 0 AND free_seats <= 15),	
);
INSERT INTO Groups --������ 
		( group_name,	[description],	schedule_weekday,	schedule_time, trainer )
VALUES  ( N'������',	N'��������� ������',	1,			'18:00',		1),
		( N'������',	N'��������� ������',	2,			'18:00',		2),
		( N'��������',	N'��������� ������',	3,			'12:00',		3);



CREATE TABLE Clients --������� 
(
    client_id			INT             PRIMARY KEY IDENTITY(1,1),
	first_name			NVARCHAR(150)   NOT NULL,
	last_name			NVARCHAR(150)   NOT NULL,
	email				NVARCHAR(150)   NULL,
	phone				NVARCHAR(16)	NOT NULL,
	birth_date			DATE			NOT NULL,
	[start_date]		DATE			NOT NULL,
	[group]				INT				NOT NULL
							CONSTRAINT FK_ClientsGroups FOREIGN KEY  REFERENCES Groups(group_id),	
	--membership		INT        NOT NULL -- ������ �� ������� ����� ��������
	--						CONSTRAINT FK_ClientsMemberships   FOREIGN KEY  REFERENCES Memberships(membership_id),
	--debt				INT, --  ����������� �� ������
	unassigned			INT           DEFAULT 0  --(������) ���������� ������������� ������� � ���������� 
);
INSERT INTO Clients --������� 
		( last_name,	first_name,		email,					phone,				birth_date,		[start_date],		[group])
VALUES  ( N'������',	N'�����',		N'hhgj@gmail.com',		'+7-999-999-77-55', '2001-04-15',	'2025-04-01',		1),
		( N'�������',	N'�������',		N'djhj@gmail.com',		'+7-999-999-77-11',	'1998-11-15',	'2025-04-15',		2),
		( N'�������',	N'������',		N'cygygb@gmail.com',	'+7-999-999-77-22',	'2015-04-16',	'2025-04-05',		1),
		( N'��������',	N'�������',		N'cymllll@gmail.com',	'+7-999-999-77-33',	'2016-02-06',	'2025-04-01',		2),			   
		( N'��������',	N'�������',		N'fjfdd@gmail.com',		'+7-000-999-77-55', '1978-12-30',	'2025-04-01',		1),
		( N'��������',	N'�������',		N'dhjghj@gmail.com',	'+7-888-999-77-11',	'1985-10-10',	'2025-04-15',		2),
		( N'�������',	N'���',			N'fghhhjj@gmail.com',	'+7-444-999-77-22',	'2000-04-16',	'2025-04-05',		3),
		( N'������',	N'�����',		N'yyjty@gmail.com',		'+7-333-999-77-33',	'2015-02-06',	'2025-04-01',		3);
CREATE TABLE Schedule
(
	training_session_id		BIGINT				PRIMARY KEY		IDENTITY(1,1),
	[group]			INT				NOT NULL 
		CONSTRAINT FK_Schedule_Groups		FOREIGN KEY	REFERENCES Groups(group_id),
	[date]			DATE			NOT NULL,
	[time]			TIME			NOT NULL,
	--trainer				INT				NOT NULL 
	--		CONSTRAINT FK_ScheduleTrainers   FOREIGN KEY  REFERENCES Trainers(trainer_id),
	spent			BIT				NOT NULL
);