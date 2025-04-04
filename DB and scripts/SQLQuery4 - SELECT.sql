USE DB_Smart_Fitness_1;

--UPDATE Clients
--SET email = N'h1112@gmail.com'
--WHERE client_id = 1;

--SELECT	last_name +' '+ first_name AS FullName, 
--		email, 
--		phone, 
--		birth_date,
--		group_name
--FROM Clients, Groups,Schedule_weekdays
--WHERE YEAR(birth_date) < 2010 AND group_id = [group]
--ORDER BY birth_date DESC;--ASC;


--расписание зан€тий дл€ человека по фамилии
SELECT	last_name +' '+ first_name AS FullName, 		
		group_name,
		[date],
		[time],
		trainer
FROM Clients, Groups,Schedule
WHERE Clients.[group] = Schedule.[group] AND group_id=Schedule.[group]AND last_name =N'ѕетрова';

--люди которые могут быть на зан€тий дл€ группы на дату
SELECT	last_name +' '+ first_name AS FullName, 		
		group_name,
		[date],
		[time],
		trainer
FROM Clients, Groups,Schedule
WHERE Clients.[group] = Schedule.[group] AND group_id=Schedule.[group] AND trainer =2 AND [date] ='2025-04-01'

