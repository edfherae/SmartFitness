USE DB_Smart_Fitness_1;
GO



ALTER PROCEDURE sp_SetSchedule
--CREATE PROCEDURE sp_SetSchedule
	--@group_name			AS	NVARCHAR(50),  -- �������� ������
	@start_date			AS	DATE,          -- ���� ������ �������
	@end_date			AS	DATE          -- ���� ��������� �������
AS
BEGIN
	PRINT('======================');
	SET DATEFIRST 1; -- ������������� ������ ���� ������ �� �����������
	-- �������� ����� ���������� ��� ��������� ������
	DECLARE @time1		AS	TIME	 = (SELECT schedule_time FROM Groups WHERE group_id =1);
	DECLARE @time2		AS	TIME	 = (SELECT schedule_time FROM Groups WHERE group_id=2);
	DECLARE @time3		AS	TIME	 = (SELECT schedule_time FROM Groups WHERE group_id=3);
	PRINT(@time1)
	PRINT(@time2)
	PRINT(@time3)
	-- �������� ������������� ������
	--DECLARE @group		AS	INT		 = (SELECT group_id FROM Groups WHERE group_name=@group_name);							
	---- �������� �������������� ��� �������
	--PRINT(@group)
	--PRINT(@group)
	
	-- ������������� ��������� ����
	DECLARE @date		AS	DATE	 = @start_date
	DECLARE @dw		AS	INT	 = DATEPART(DW,@date)
	PRINT(@date)
	PRINT(@dw)
	PRINT('======================');
	 --���� ��� ���������� ������ � ����������
	WHILE (@date < @end_date)
		BEGIN	
			IF (DATEPART(DW,@date)=6 OR DATEPART(DW,@date)=7 ) --���������� ��� �� ��, �� ��� ��
			--IF (@dw=6 OR @dw=7 ) --���������� ��� �� ��, �� ��� ��
						BEGIN
							
							-- ���������, ���� �� ������ ���� � ������� ���������� �� ��������� �����
							--IF NOT EXISTS (SELECT Schedule.training_session_id FROM Schedule 
							--			WHERE [date]=@date AND [time]=@time3)
							--	BEGIN
									-- ���� ����� ��������, ��������� ���� � ����������
									INSERT	Schedule
											([date], [time], [group], spent)
									VALUES	(@date,  @time3,	3,  0)--IIF(@date < GETDATE(), 1, 0)
									PRINT ('���������� 3 ������')
									PRINT(@date);
									PRINT(DATENAME(WEEKDAY, @date)); -- �������� �������� ��� ������
									PRINT(DATEPART(DW, @date)); -- �������� ����� ��� ������
								--END								
						END
						else PRINT ('�� ���������� 3 ������')

				PRINT('----------------------');
					IF (DATEPART(DW,@date)=1 OR DATEPART(DW,@date)=3 OR DATEPART(DW,@date)=5) --���������� ���  ��, �� ��� ��
						BEGIN
							
							--IF NOT EXISTS (SELECT Schedule.training_session_id FROM Schedule 
							--	WHERE [date]=@date AND [time]=@time1)
							--	BEGIN
									-- ���������, ���� �� ������ ���� � ������� ���������� �� ��������� �����
									-- ���� ����� ��������, ��������� ���� � ����������
									INSERT	Schedule
											([date], [time], [group], spent)
									VALUES	(@date,  @time1,	 1, 0)--IIF(@date < GETDATE(), 1, 0)
									PRINT ('���������� 1 ������')
									PRINT(@date);
									PRINT(DATENAME(WEEKDAY, @date)); -- �������� �������� ��� ������
									PRINT(DATEPART(DW, @date)); -- �������� ����� ��� ������
								--END		
						END

																									
					PRINT('----------------------');
					
					IF (DATEPART(DW,@date)=2 OR DATEPART(DW,@date)=4 OR DATEPART(DW,@date)=6) --���������� ��� �� ��, �� ��� ��
						BEGIN
							-- ���������, ���� �� ������ ���� � ������� ���������� �� ��������� �����									
							--IF NOT EXISTS (SELECT Schedule.training_session_id FROM Schedule 
							--		WHERE [date]=@date AND [time]=@time2 )
								--BEGIN
									-- ���� ����� ��������, ��������� ���� � ����������
									INSERT	Schedule
											([date], [time], [group], spent)
									VALUES	(@date,  @time2,	 2, 0)--IIF(@date < GETDATE(), 1, 0)
									PRINT ('���������� 2 ������')
									PRINT(@date);
									PRINT(DATENAME(WEEKDAY, @date)); -- �������� �������� ��� ������
									PRINT(DATEPART(DW, @date)); -- �������� ����� ��� ������

								--END					
						END								

																			
					PRINT('----------------------');
					PRINT('----------------------');
					PRINT(@date);
					SET @date = DATEADD(DAY, 1, @date);
					PRINT(@date);
					PRINT(DATENAME(WEEKDAY, @date)); -- �������� �������� ��� ������
					PRINT(DATEPART(DW, @date)); -- �������� ����� ��� ������
					PRINT('----------------------');
					PRINT('----------------------');
		END
END
