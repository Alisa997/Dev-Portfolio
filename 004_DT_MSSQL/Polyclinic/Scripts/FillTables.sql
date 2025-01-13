-- Populating the Database Tables for Polyclinic

-- Personal data table
insert Persons
    (Surname, [Name], Patronymic)
values
    (N'Yurkovsky',   N'Mark',      N'Maksimilianovich'), /*  1 */
	(N'Yakubovskaya', N'Diana',     N'Pavlovna'),		 /*  2 */
    (N'Shapiro',      N'Fedor',     N'Fedorovich'),      /*  3 */
	(N'Vozhzaev',     N'Sergey',    N'Denisovich'),      /*  4 */
    (N'Khromenko',    N'Igor',     N'Vladimirovich'),  	 /*  5 */
	(N'Pelykh',       N'Marina',    N'Ulyanovna'),     	 /*  6 */
	(N'Lapotnikova', N'Tamara',    N'Oscarovna'),     	 /*  7 */
	(N'Ogorodnikov', N'Sergey',    N'Ivanovich'),      	 /*  8 */
    (N'Yaylo',        N'Ekaterina', N'Nikolaevna'),    	 /*  9 */
	(N'Loseva',      N'Inna',      N'Stepanovna'),    	 /* 10 */
    (N'Mikhaylovich',  N'Anna',      N'Valentinovna'),   /* 11 */
	(N'Tarapata',    N'Mikhail',    N'Isaakovich'),      /* 12 */
	(N'Trubikhin',    N'Edward',    N'Mikhailovich'),    /* 13 */
	(N'Chmykhalo',     N'Oleg',      N'Tarasovich'),     /* 14 */
	(N'Knyazkov',    N'Stepan',    N'Sidorovich'),     	 /* 15 */
	(N'Potemkina',   N'Natalia',   N'Pavlovna'),      	 /* 16 */
    (N'Gritchenko',   N'Stepan',    N'Romanovich'),      /* 17 */
	(N'Selivanov',   N'Alexander', N'Mikhaylovich'),     /* 18 */
	(N'Tsarkhova',    N'Larisa',    N'Ilinichna'),     	 /* 19 */
	(N'Yastrub',      N'Vladimir',  N'Danilovich'),      /* 20 */
    (N'Melashenko',   N'Alexander', N'Alekseevich'),     /* 21 */
	(N'Ponomarenko', N'Vladislav', N'Dmitrievich'),    	 /* 22 */ 
	(N'Khavalzhi',    N'Lyubov',    N'Amirovna'),      	 /* 23 */
	(N'Parkhomenko',  N'Irina',     N'Vladimirovna'),  	 /* 24 */
    (N'Demidova',    N'Alina',     N'Aleksandrovna'), 	 /* 25 */
	(N'Lyshenko',     N'Elena',     N'Egorovna'),      	 /* 26 */
	(N'Fedoshenko',   N'Oksana',    N'Vladimirovna'),  	 /* 27 */
	(N'Bogatyryova',  N'Ekaterina', N'Alekseevna'),		 /* 28 */
	(N'Ivanova',     N'Valentina', N'Stepanovna'),		 /* 29 */
	(N'Ilyushin',     N'Sergey',    N'Yurievich');		 /* 30 */
go

-- Medical specialties reference table
insert Specialities
    (Speciality)
values
    (N'therapist'),                      /*  1 */    
	(N'dentist'),  	                     /*  2 */
	(N'optometrist'),     	             /*  3 */
	(N'cardiologist'),   	             /*  4 */
	(N'pulmonologist'), 	             /*  5 */
	(N'surgeon'),      	                 /*  6 */
	(N'obstetrician'),      	         /*  7 */
	(N'ENT Specialist'),                 /*  8 */     
	(N'infectious Disease Specialist'),  /*  9 */    
	(N'physical Therapist'),             /* 10 */    
	(N'oncologist'),      	             /* 11 */
	(N'venereologist'),                  /* 12 */ 
	(N'urologist');      	             /* 13 */
go

-- Doctors' data table
insert Doctors
    (IdPerson, IdSpeciality, Price, [Percent])
values
    ( 1, 1,  110, 5.0),  /*  1 */
	( 2, 2,  600, 3.0),	 /*  2 */
    ( 3, 1,  160, 3.5),	 /*  3 */
	( 4, 1,  250, 3.2),	 /*  4 */
    ( 5, 3,  300, 4.5),	 /*  5 */
	( 6, 2,  600, 4.5),	 /*  6 */
	( 7, 4,  300, 4.0),	 /*  7 */
	( 8, 5,  250, 3.5),	 /*  8 */
    ( 9, 6,  800, 5.1),	 /*  9 */
	(10, 6, 1300, 4.5),	 /* 10 */
    (11, 2,  350, 3.1),	 /* 11 */
	(12, 1,  120, 6.2);	 /* 12 */
go

-- Patients' data table
insert Patients  
    (IdPerson, BornDate, [Address])
values                                                    	
    (13, '02-12-2001', N'Sadovaya St., 123, apt. 12'),         /*  1 */
	(14, '07-09-1991', N'Zaitseva St., 2'),				       /*  2 */
	(15, '03-18-1963', N'Titov Ave., 11, apt. 91'),		       /*  3 */
	(16, '04-21-1957', N'Sodovaya St., 9'),				       /*  4 */
    (17, '02-12-2001', N'Chelyuskintsev St., 112, apt. 211'),  /*  5 */
	(18, '06-01-1935', N'Titov Ave., 9, apt. 21'),		       /*  6 */
	(19, '07-06-1992', N'Constitution Square, 3, apt. 75'),	   /*  7 */
	(20, '07-09-1991', N'Mira Ave., 3, apt. 64'),			   /*  8 */
    (21, '12-23-1947', N'Sodovaya St., 9, apt. 6'),		       /*  9 */
	(22, '07-09-1991', N'Sadovaya St., 10'),				   /* 10 */
	(23, '09-29-1956', N'Sudovaya St., 1, apt. 91'),		   /* 11 */
	(24, '04-13-1963', N'Titov Ave., 31, apt. 42'),		       /* 12 */
    (25, '04-21-1957', N'Chelyuskintsev St., 3'),			   /* 13 */
	(26, '02-12-2001', N'Sodovaya Ave., 13'),				   /* 14 */
	(27, '11-04-2001', N'Constitution Square, 1, apt. 50'),	   /* 15 */
	(28, '10-09-2001', N'Shors St., 23, apt. 17'),		       /* 16 */
	(29, '12-21-1998', N'Ovnatanyan St., 4, apt. 98'),         /* 17 */
	(30, '02-27-1997', N'Chkalov St., 11');		               /* 18 */
go

-- Doctors' Appointments data table
insert Appointments
    (AppointmentDate, IdPatient, IdDoctor)
values
    ('10-21-21',  1,  1),   /*  1 */
    ('10-21-21',  2,  1),	/*  2 */
    ('10-21-21',  3,  2),	/*  3 */
    ('10-22-21',  4,  3),	/*  4 */
    ('10-22-21',  4,  5),	/*  5 */
    ('10-22-21',  3,  5),	/*  6 */
    ('10-22-21',  2,  6),	/*  7 */
    ('10-23-21',  5,  2),	/*  8 */
    ('10-23-21',  6,  5),	/*  9 */
    ('10-24-21',  9,  6),	/* 10 */
    ('10-24-21',  7,  6),	/* 11 */
    ('10-28-21',  3,  7),	/* 12 */
    ('10-28-21',  2,  8),	/* 13 */
    ('10-28-21',  4,  9),	/* 14 */
    ('11-02-21',  6,  9),	/* 15 */
    ('11-02-21',  7,  1),	/* 16 */
    ('11-02-21',  8,  2),	/* 17 */
    ('11-02-21', 10,  4),	/* 18 */
    ('11-03-21',  5,  5),	/* 19 */
    ('11-03-21',  9,  7),	/* 20 */
    ('11-03-21',  6,  7);	/* 21 */
go
