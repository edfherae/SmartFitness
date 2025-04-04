USE DB_Smart_Fitness;


INSERT Memberships --Членство 
		( membership_type, duration, price)
VALUES  ( N'Базовый', 30, 15000),
		( N'Премиум', 365, 100000);

INSERT Trainers--Тренеры 
		( last_name,		first_name,		specialization,								email,				phone)
VALUES  ( N'Васин',			N'Никита',		N'Детский тренер',							N'dfgx@gmail.com',	'+7-678-999-77-11'),
		( N'Жукова',		N'Мария',		N'Детский тренер, тренер взрослых групп',	N'gggg@gmail.com',	'+7-999-555-66-22'),
		( N'Бессмертный',	N'Артем',		N'Тренер взрослых групп',					N'fgnnnn@gmail.com','+7-555-999-77-88');


INSERT Clients --Клиенты 
		( last_name,	first_name,		email,					phone,				birth_date,		registration_date,	membership_type)
VALUES  ( N'Иванов',	N'Павел',		N'hhgj@gmail.com',		'+7-999-999-77-55', '2001-04-15',	'2022-09-15',		1),
		( N'Петрова',	N'Наталья',		N'djhj@gmail.com',		'+7-999-999-77-11',	'1998-11-15',	'2012-09-15',		2),
		( N'Сидоров',	N'Сергей',		N'cygygb@gmail.com',	'+7-999-999-77-22',	'2015-04-16',	'2023-09-15',		1),
		( N'Соловьев',	N'Евгений',		N'cymllll@gmail.com',	'+7-999-999-77-33',	'2016-02-06',	'2023-09-15',		2);			   

INSERT Payments --Оплата
		( client,	amount,		payment_date,		payment_method)
VALUES  ( 1,		15000,		'2022-09-20',		'наличные'),
		( 2,		50000,		'2022-09-19',		'карта'),	
		( 3,		15000,		'2022-09-20',		'наличные');
		

