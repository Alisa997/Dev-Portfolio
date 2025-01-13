-- Test File - Procedure Calls
-- for queries 1 - 12 

-- Execute Query 1	
--    Stored Procedure. Selection Query
--    Selects information about patients with a specified last name 
exec Query01 N'Trubikhin';
go

exec Query01 N'Melashenko';
go

exec Query01 N'Demidova';
go

-- Execute Query 2
--    Stored Procedure. Selection Query	
--    Selects information about doctors for whom the percentage 
--    of salary allocation is greater than a specified value (e.g., > 30%)
exec Query02 4;
go

exec Query02 5;
go

exec Query02 6;
go

-- Execute Query 3	
--    Stored Procedure. Selection Query	
--    Selects information about patient appointments within a specified period
exec Query03 '10-21-21';
go

exec Query03 '10-24-21';
go

exec Query03 '11-02-21';
go

-- Execute Query 4	
--    Stored Procedure. Selection Query	
--    Selects information about doctors with a specified specialty
exec Query04 N'therapist';
go

exec Query04 N'dentist';
go

exec Query04 N'surgeon';
go

-- Execute Query 5	
--    Stored Procedure. Selection Query	
--    Selects information about all appointments (patient's full name, doctor's full name and specialty, appointment date)
--    in a specified time range. The lower and upper bounds of the interval are provided when the query is executed
exec Query05 '10-21-21', '10-23-21';
go

exec Query05 '10-24-21', '11-02-21';
go

exec Query05 '11-02-21', '11-30-21';
go

-- Execute Query 6	
--    Stored Procedure. Selection Query	
--    Calculates the doctor's salary for each appointment. 
--    Includes doctor's last name, first name, patronymic, specialty, appointment cost, salary. 
--    Sorted by doctor's specialty	 
exec Query06;
go

-- Execute Query 7	
--    Stored Procedure. Summary Query. 	
--    Groups by appointment date. 
--    For each date, calculates the maximum appointment cost
exec Query07;
go

-- Execute Query 8	
--    Stored Procedure. Summary Query	
--    Groups by specialty. 
--    For each specialty, calculates the average percentage of salary allocation from the appointment cost
exec Query09 '11-02-21';
go

-- Execute Query 9	
--    Stored Procedure. Create Base Table Query	
--    Creates the DOCTORS_DATE table containing information about doctors
--    who conducted patient appointments on a specified date
exec Query09 '11-02-21';
go

-- Execute Query 10
--    Stored Procedure. Create Base Table Query	
--    Creates a copy of the PATIENTS table named COPY_PATIENTS
exec Query10;
go

-- Execute Query 11
--    Stored Procedure. Delete Query	
--    Deletes records of patients born after a specified date from the COPY_PATIENTS table
exec Query11 '01-12-2001';
go

exec Query11 '12-20-1998';
go

exec Query11 '02-26-1997';
go

-- Execute Query 12	
--    Stored Procedure. Update Query
--    Increases the percentage of salary allocation in the COPY_DOCTORS table 
--    by a specified percentage for doctors with a given specialty
exec Query12 N'therapist', 10;
go

exec Query12 N'dentist', 15;
go

exec Query12 N'surgeon', 7;
go
