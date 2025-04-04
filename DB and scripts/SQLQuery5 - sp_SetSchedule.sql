USE DB_Smart_Fitness_1;
GO



ALTER PROCEDURE sp_SetSchedule
--CREATE PROCEDURE sp_SetSchedule
	--@group_name			AS	NVARCHAR(50),  -- Название группы
	@start_date			AS	DATE,          -- Дата начала занятий
	@end_date			AS	DATE          -- Дата окончания занятий
AS
BEGIN
	PRINT('======================');
	SET DATEFIRST 1; -- Устанавливаем первый день недели на понедельник
	-- Получаем время тренировки для указанной группы
	DECLARE @time1		AS	TIME	 = (SELECT schedule_time FROM Groups WHERE group_id =1);
	DECLARE @time2		AS	TIME	 = (SELECT schedule_time FROM Groups WHERE group_id=2);
	DECLARE @time3		AS	TIME	 = (SELECT schedule_time FROM Groups WHERE group_id=3);
	PRINT(@time1)
	PRINT(@time2)
	PRINT(@time3)
	-- Получаем идентификатор группы
	--DECLARE @group		AS	INT		 = (SELECT group_id FROM Groups WHERE group_name=@group_name);							
	---- Печатаем идентификаторы для отладки
	--PRINT(@group)
	--PRINT(@group)
	
	-- Устанавливаем начальную дату
	DECLARE @date		AS	DATE	 = @start_date
	DECLARE @dw		AS	INT	 = DATEPART(DW,@date)
	PRINT(@date)
	PRINT(@dw)
	PRINT('======================');
	 --Цикл для добавления уроков в расписание
	WHILE (@date < @end_date)
		BEGIN	
			IF (DATEPART(DW,@date)=6 OR DATEPART(DW,@date)=7 ) --перебираем дни до вт, чт или сб
			--IF (@dw=6 OR @dw=7 ) --перебираем дни до вт, чт или сб
						BEGIN
							
							-- Проверяем, есть ли данная дата в таблице расписания на указанное время
							--IF NOT EXISTS (SELECT Schedule.training_session_id FROM Schedule 
							--			WHERE [date]=@date AND [time]=@time3)
							--	BEGIN
									-- Если время свободно, добавляем урок в расписание
									INSERT	Schedule
											([date], [time], [group], spent)
									VALUES	(@date,  @time3,	3,  0)--IIF(@date < GETDATE(), 1, 0)
									PRINT ('установить 3 группу')
									PRINT(@date);
									PRINT(DATENAME(WEEKDAY, @date)); -- Печатаем название дня недели
									PRINT(DATEPART(DW, @date)); -- Печатаем номер дня недели
								--END								
						END
						else PRINT ('не установить 3 группу')

				PRINT('----------------------');
					IF (DATEPART(DW,@date)=1 OR DATEPART(DW,@date)=3 OR DATEPART(DW,@date)=5) --перебираем дни  пн, ср или пт
						BEGIN
							
							--IF NOT EXISTS (SELECT Schedule.training_session_id FROM Schedule 
							--	WHERE [date]=@date AND [time]=@time1)
							--	BEGIN
									-- Проверяем, есть ли данная дата в таблице расписания на указанное время
									-- Если время свободно, добавляем урок в расписание
									INSERT	Schedule
											([date], [time], [group], spent)
									VALUES	(@date,  @time1,	 1, 0)--IIF(@date < GETDATE(), 1, 0)
									PRINT ('установить 1 группу')
									PRINT(@date);
									PRINT(DATENAME(WEEKDAY, @date)); -- Печатаем название дня недели
									PRINT(DATEPART(DW, @date)); -- Печатаем номер дня недели
								--END		
						END

																									
					PRINT('----------------------');
					
					IF (DATEPART(DW,@date)=2 OR DATEPART(DW,@date)=4 OR DATEPART(DW,@date)=6) --перебираем дни до вт, чт или сб
						BEGIN
							-- Проверяем, есть ли данная дата в таблице расписания на указанное время									
							--IF NOT EXISTS (SELECT Schedule.training_session_id FROM Schedule 
							--		WHERE [date]=@date AND [time]=@time2 )
								--BEGIN
									-- Если время свободно, добавляем урок в расписание
									INSERT	Schedule
											([date], [time], [group], spent)
									VALUES	(@date,  @time2,	 2, 0)--IIF(@date < GETDATE(), 1, 0)
									PRINT ('установить 2 группу')
									PRINT(@date);
									PRINT(DATENAME(WEEKDAY, @date)); -- Печатаем название дня недели
									PRINT(DATEPART(DW, @date)); -- Печатаем номер дня недели

								--END					
						END								

																			
					PRINT('----------------------');
					PRINT('----------------------');
					PRINT(@date);
					SET @date = DATEADD(DAY, 1, @date);
					PRINT(@date);
					PRINT(DATENAME(WEEKDAY, @date)); -- Печатаем название дня недели
					PRINT(DATEPART(DW, @date)); -- Печатаем номер дня недели
					PRINT('----------------------');
					PRINT('----------------------');
		END
END
