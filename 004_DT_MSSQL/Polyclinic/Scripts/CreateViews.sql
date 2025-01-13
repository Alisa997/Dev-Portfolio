-- Materialized View for Doctors
drop view if exists ViewDoctors;
go

create view ViewDoctors with schemabinding
as
select
    Doctors.Id
	, Doctors.Price
	, Doctors.[Percent]
	, Persons.[Name]
	, Persons.Patronymic
	, Persons.Surname
	, Specialities.Speciality
from
    dbo.Doctors join dbo.Persons on Doctors.IdPerson = Persons.Id
				join dbo.Specialities on Doctors.IdSpeciality = Specialities.Id;
go

-- Materialized View for Patients
drop view if exists ViewPatients;
go

create view ViewPatients with schemabinding
as
select
    Patients.Id
	, Patients.[Address]
	, Patients.BornDate
	, Persons.[Name]
	, Persons.Patronymic
	, Persons.Surname
from
    dbo.Patients join dbo.Persons on Patients.IdPerson = Persons.Id;
go

-- Materialized View for Appointments
drop view if exists ViewAppointments;
go

create view ViewAppointments --with schemabinding
as
select
    Appointments.Id
	, Appointments.AppointmentDate
	, ViewPatients.[Name]     as PatientName
	, ViewPatients.Patronymic as PatientPatronymic
	, ViewPatients.Surname    as PatientSurname
	, ViewPatients.[Address]  as PatientAddress
	, ViewPatients.BornDate   as PatientBornDate 
	, ViewDoctors.[Name]     as DoctorName
	, ViewDoctors.Patronymic as DoctorPatronymic
	, ViewDoctors.Surname    as DoctorSurname
	, ViewDoctors.Speciality as DoctorSpeciality
	, ViewDoctors.[Percent]  as DoctorPercent
	, ViewDoctors.Price      as DoctorPrice
from
    dbo.Appointments join ViewPatients on Appointments.IdPatient = ViewPatients.Id
					 join ViewDoctors on Appointments.IdDoctor = ViewDoctors.Id;
go