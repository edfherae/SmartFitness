USE DB_Smart_Fitness;


INSERT Memberships --�������� 
		( membership_type, duration, price)
VALUES  ( N'�������', 30, 15000),
		( N'�������', 365, 100000);

INSERT Trainers--������� 
		( last_name,		first_name,		specialization,								email,				phone)
VALUES  ( N'�����',			N'������',		N'������� ������',							N'dfgx@gmail.com',	'+7-678-999-77-11'),
		( N'������',		N'�����',		N'������� ������, ������ �������� �����',	N'gggg@gmail.com',	'+7-999-555-66-22'),
		( N'�����������',	N'�����',		N'������ �������� �����',					N'fgnnnn@gmail.com','+7-555-999-77-88');


INSERT Clients --������� 
		( last_name,	first_name,		email,					phone,				birth_date,		registration_date,	membership_type)
VALUES  ( N'������',	N'�����',		N'hhgj@gmail.com',		'+7-999-999-77-55', '2001-04-15',	'2022-09-15',		1),
		( N'�������',	N'�������',		N'djhj@gmail.com',		'+7-999-999-77-11',	'1998-11-15',	'2012-09-15',		2),
		( N'�������',	N'������',		N'cygygb@gmail.com',	'+7-999-999-77-22',	'2015-04-16',	'2023-09-15',		1),
		( N'��������',	N'�������',		N'cymllll@gmail.com',	'+7-999-999-77-33',	'2016-02-06',	'2023-09-15',		2);			   

INSERT Payments --������
		( client,	amount,		payment_date,		payment_method)
VALUES  ( 1,		15000,		'2022-09-20',		'��������'),
		( 2,		50000,		'2022-09-19',		'�����'),	
		( 3,		15000,		'2022-09-20',		'��������');
		

