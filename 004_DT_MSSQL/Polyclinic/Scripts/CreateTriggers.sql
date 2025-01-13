-- • Create and test triggers for insert, update, and delete operations on the Appointments table
-- o Prevent deletion of appointments from the last 3 years
-- o Prevent modification of records for dates other than the current date (prohibit backdating)
-- o Prevent re-registration of a patient with the same doctor on the same day

-- Delete Trigger
drop trigger if exists onDeleteAppointments;
go

create trigger onDeleteAppointments on Appointments 
    after delete
	as
	begin
	    declare @hasEe int, @count int;

        -- Get the count of records to delete
		select
		   @count = count(id)
		from
		    deleted;

		-- Check if there are appointments in the last 3 years among the deleted records
		select
		   @hasEe = count(id)
		from
		    deleted
		where 
		    Year(AppointmentDate) > YEAR(GETDATE()) - 3;
			
		-- If there are, rollback the transaction, cancel the deletion
		if @hasEe > 0 begin
			print(N'Record cannot be deleted!');
			rollback tran;
		end else begin
		    raiserror(N'Records deleted from Appointments table: %d', 0, 1, @count);
		end;
	end;
go

-- Update Trigger
drop trigger if exists onUpdateAppointments;
go

create trigger onUpdateAppointments on Appointments 
    after update 
	as
	begin
	    declare @hasEe int, @count int;

        -- Get the count of records to update
		select
		   @count = count(id)
		from
		    deleted;

		-- Check if there are records with a date other than the current one
		select
		   @hasEe = count(id)
		from
		    deleted
		where 
		    AppointmentDate <> GETDATE();
			
		-- If there are, rollback the transaction, cancel the update
		if @hasEe > 0 begin
			print(N'Record cannot be updated!');
			rollback tran;
		end else begin
		    raiserror(N'Records updated in the Appointments table: %d', 0, 1, @count);
		end;
	end;
go

-- Insert Trigger
drop trigger if exists onInsertAppointments;
go

create trigger onInsertAppointments on Appointments 
instead of insert
	as
	begin
	    declare @hasEe int, @count int, @date date;

        -- Get the count of records to insert
		select
		   @count = count(id)
		from
		    inserted;

		-- Check if there are duplicate records among the inserted records
		select
		   @hasEe = count(id)
		from
		    inserted
		where 
		    inserted.AppointmentDate in (select 
											AppointmentDate 
										 from
											Appointments 
										 where 
											Appointments.IdDoctor = inserted.IdDoctor and Appointments.IdPatient = inserted.IdPatient);
			
		-- If there are, rollback the transaction, cancel the insertion
		if @hasEe > 0 begin
			print(N'Duplicate insertion is not allowed!');
			rollback tran;
		end else begin
		    raiserror(N'Records added to the Appointments table: %d', 0, 1, @count);
		end;
	end;
go