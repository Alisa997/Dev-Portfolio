-- Creating Database Tables
begin transaction    -- Start of the transaction

-- Deleting existing tables, works in MS SQL Server 2016+
drop table if exists Appointments;
drop table if exists Doctors;
drop table if exists Patients;
drop table if exists Persons;
drop table if exists Specialities;

-- Table for personal data common for both doctors 
-- and patients - Persons
create table dbo.Persons (
	Id          int          not null primary key identity (1, 1),
	Surname     nvarchar(60) not null,    -- Person's last name
	[Name]      nvarchar(50) not null,    -- Person's first name
	Patronymic  nvarchar(60) not null     -- Person's patronymic
);

-- Table for the dictionary of medical specialties of doctors - Specialities
create table dbo.Specialities (
	Id          int          not null primary key identity (1, 1),
	Speciality  nvarchar(40) not null    -- Name of the medical specialty
);

-- Doctors' table - Doctors
create table dbo.Doctors (
	Id           int          not null primary key identity (1, 1),
	IdPerson     int          not null,    -- Foreign key, link to personal data
	IdSpeciality int          not null,    -- Foreign key, link to medical specialties
	Price        int          not null,    -- Cost of the appointment
	[Percent]    float        not null,    -- Percentage of the appointment cost for the doctor's salary
	
	-- Constraints for the fields in the table
	constraint CK_Doctors_Price   check (Price > 0),
	constraint CK_Doctors_Percent check ([Percent] > 0),

	-- Foreign key - 1:1 relation to the Persons table
	constraint FK_Doctors_Persons foreign key (IdPerson) references dbo.Persons(Id),

	-- Foreign key - M:1 relation to the Specialities table (e.g., many doctors of one specialty)
	constraint FK_Doctors_Specialities foreign key (IdSpeciality) references dbo.Specialities(Id)
);

-- Patients' table - Patients
create table dbo.Patients (
	Id          int          not null primary key identity (1, 1),
	IdPerson    int          not null,    -- Foreign key, link to personal data
	BornDate    date         not null,    -- Patient's birthdate
	[Address]   nvarchar(80) not null     -- Patient's home address
	
	-- Foreign key - 1:1 relation to the Persons table
	constraint  FK_Patients_Persons foreign key (IdPerson) references dbo.Persons(Id)
);

-- Appointments' table - Appointments
create table dbo.Appointments (
    Id              int  not null primary key identity (1, 1),
	AppointmentDate date not null,
	IdPatient       int  not null,
	IdDoctor        int  not null,

	-- Foreign key - M:1 relation to the Patients table
	constraint FK_Appointments_Patients foreign key (IdPatient) references dbo.Patients(Id),

	-- Foreign key - M:1 relation to the Doctors table
	constraint FK_Appointments_Doctors foreign key (IdDoctor) references dbo.Doctors(Id)
);

commit tran;