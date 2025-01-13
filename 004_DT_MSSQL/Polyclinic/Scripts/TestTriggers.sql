-- • Create and test triggers for insert, update, and delete operations on the Appointments table
-- o Prevent deletion of appointments from the last 3 years
-- o Prevent modification of records for dates other than the current one (prohibit backdating)
-- o Prevent re-registration of a patient with the same doctor on the same day


-- Test query for the insert trigger
insert Appointments
    (AppointmentDate, IdPatient, IdDoctor)
values
    ('10-21-21',  1,  1),   /*  1 */
    ('10-21-21',  2,  1),	/*  2 */
    ('10-21-21',  3,  2),	/*  3 */
    ('10-22-21',  4,  3)	/*  4 */
go

-- Test query for the delete trigger
delete from
    Appointments
where
    Year(AppointmentDate) > YEAR(GETDATE()) - 3;
go

-- Test query for the update trigger
update Appointments
	set
		IdDoctor = (select Id from Doctors where IdPerson = (select Id from Persons where Surname = N'Yurkovsky'))
	where					
		AppointmentDate = '10-28-21';