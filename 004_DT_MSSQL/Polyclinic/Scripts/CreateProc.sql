/*
 * Creating Stored Procedures
 * Queries 1 - 12
 *
 */

drop procedure if exists Query01;
drop procedure if exists Query02;
drop procedure if exists Query03;
drop procedure if exists Query04;
drop procedure if exists Query05;
drop procedure if exists Query06;
drop procedure if exists Query07;
drop procedure if exists Query08;
drop procedure if exists Query09;
drop procedure if exists Query10;
drop procedure if exists Query11;
drop procedure if exists Query12;
go


-- 1. Stored Procedure. Selection Query
--    Selects information about patients with a specified last name 
create proc Query01
	@surname nvarchar(60)
as
begin
    select
        Patients.Id
        , Persons.Surname      as PatientSurname
        , Persons.[Name]       as PatientName
        , Persons.Patronymic   as PatientPatronymic
        , Patients.BornDate
        , Patients.[Address]
    from
        Patients join Persons on Patients.IdPerson = Persons.Id
    where
        Persons.Surname = @surname;
end
go


-- 2. Stored Procedure. Selection Query	
--    Selects information about doctors for whom the percentage 
--    of salary allocation is greater than a specified value (e.g., > 30%)
create proc Query02
	@percent float
as
begin
    select
        Doctors.Id
        , Persons.Surname
        , Persons.[Name]
        , Persons.Patronymic
        , Specialities.Speciality
        , Doctors.Price
        , Doctors.[Percent]
    from
        Doctors join Persons on Doctors.IdPerson = Persons.Id
                join Specialities on Doctors.IdSpeciality = Specialities.Id
    where
        Doctors.[Percent] > @percent;
end
go


-- 3. Stored Procedure. Selection Query	
--    Selects information about patient appointments in a specified period
create proc Query03
	@date date
as
begin
    select
        ViewAppointments.Id
        -- Patient's full name
        , ViewAppointments.PatientSurname + N' ' 
        + SUBSTRING(ViewAppointments.[PatientName], 1, 1) 
        + N'.' + SUBSTRING(ViewAppointments.PatientPatronymic, 1, 1) + N'.' as Patient
        -- Doctor's full name
        , ViewAppointments.DoctorSurname + N' ' 
        + SUBSTRING(ViewAppointments.DoctorName, 1, 1) 
        + N'.' + SUBSTRING(ViewAppointments.DoctorPatronymic, 1, 1) + N'.' as Doctor
        , ViewAppointments.AppointmentDate
    from
        ViewAppointments
    where
        ViewAppointments.AppointmentDate = @date;
end
go


-- 4. Stored Procedure. Selection Query	
--    Selects information about doctors with a specified specialty
create proc Query04
	@speciality nvarchar(40)
as
begin
    select
        Doctors.Id
        , Persons.Surname
        , Persons.[Name]
        , Persons.Patronymic
        , Specialities.Speciality
        , Doctors.Price
        , Doctors.[Percent]
    from
        Doctors join Persons on Doctors.IdPerson = Persons.Id
                join Specialities on Doctors.IdSpeciality = Specialities.Id
    where
        Specialities.Speciality = @speciality;
end
go


-- 5. Stored Procedure. Selection Query	
--    Selects information about all appointments (patient's full name, doctor's full name and specialty, appointment date)
--    in a specified time range. The lower and upper boundaries of the interval are provided when the query is executed
create proc Query05
	@from date,
	@to date
as
begin
    select
        ViewAppointments.Id
        -- Patient's full name
        , ViewAppointments.PatientSurname 
        , ViewAppointments.PatientName
        , ViewAppointments.PatientPatronymic
        -- Doctor's full name
        , ViewAppointments.DoctorSurname
        , ViewAppointments.DoctorName
        , ViewAppointments.DoctorPatronymic
        -- Appointment date
        , ViewAppointments.AppointmentDate
    from
        ViewAppointments
    where
        ViewAppointments.AppointmentDate between @from and @to;
end
go

-- 6. Stored Procedure. Selection Query	
--    Calculates the doctor's salary for each appointment. 
--    Includes doctor's last name, first name, patronymic, specialty, appointment cost, salary. 
--    Sorted by doctor's specialty	 
create proc Query06
as
begin
    select 
        ViewDoctors.Id
        , ViewDoctors.Surname
        , ViewDoctors.[Name]
        , ViewDoctors.Patronymic
        , ViewDoctors.Speciality
        , ViewDoctors.Price
        , ViewDoctors.[Percent]
    
        -- Calculated field: salary per appointment - 87% of the calculated amount, 13% income tax
        , 0.87 * (ViewDoctors.Price * ViewDoctors.[Percent] / 100) as Salary
    from
        ViewDoctors
    order by
        ViewDoctors.Speciality;
end
go


-- 7. Stored Procedure. Summary Query. 	
--    Groups by appointment date. 
--    For each date, calculates the maximum appointment cost
create proc Query07
as
begin
    select
        Appointments.AppointmentDate
        , COUNT(Doctors.Price) as Amount
        , MIN(Doctors.Price) as MinPrice
        , AVG(Doctors.Price) as AvgPrice
        , MAX(Doctors.Price) as MaxPrice
    from
        Appointments join Doctors on Appointments.IdDoctor = Doctors.Id
    group by
        Appointments.AppointmentDate;
end
go


-- 8. Stored Procedure. Summary Query.	
--    Groups by specialty. 
--    For each specialty, calculates the average percentage of salary allocation from appointment cost
create proc Query08
as
begin
    select
        Specialities.Speciality
        , COUNT(*)                as Amount
        , AVG(Doctors.[Percent])  as AvgPercent
    from
        Doctors join Specialities on Doctors.IdSpeciality = Specialities.Id
    group by
        Specialities.Speciality;
end
go


-- 9. Stored Procedure. Create Base Table Query	
--    Creates the DOCTORS_DATE table, containing information about doctors
--    who conducted patient appointments on a specified date
drop table if exists Doctors_Date;
go

create proc Query09
    @date date 
as
begin
    select distinct
	    Doctors.Id
        , Doctors.[Percent]
        , Doctors.IdSpeciality
        , Doctors.IdPerson
        , Doctors.Price
		into Doctors_Date
	from
        Appointments join (Doctors join Specialities on Doctors.IdSpeciality = Specialities.Id
                          join Persons P on Doctors.IdPerson = P.Id)
                      on Appointments.IdDoctor = Doctors.Id
    where
        Appointments.AppointmentDate = @date;
end;
go

-- 10. Stored Procedure. Create Base Table Query	
--     Creates a copy of the PATIENTS table named COPY_PATIENTS
drop table if exists Copy_Patients;
go

create proc Query10
as
begin
    select
	    *
		into Copy_Patients
	from
	    Patients;
end;
go

-- 11. Stored Procedure. Delete Query	
--     Deletes records from the COPY_PATIENTS table for patients born after a specified date
create proc Query11
    @date date
as
begin
    delete from 
        Copy_Patients
    where
        Copy_Patients.BornDate > @date;
end;
go


-- 12. Stored Procedure. Update Query
--     Increases the percentage of salary allocation in the COPY_DOCTORS table 
--     by a specified percentage for doctors with a given specialty
create proc Query12
	@speciality nvarchar(40),
    @percent float
as
begin
    update 
	    Doctors_Date
    set
	    Doctors_Date.[Percent] += @percent
    where
	    Doctors_Date.IdSpeciality in (select Id from Specialities where Speciality = @speciality)
end;
go