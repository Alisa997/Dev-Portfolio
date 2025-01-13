﻿/* 
 * Database "Wholesale Store. Sales Accounting" 
 */

-- Table for units of measurement of goods - Units
insert into Units
    (Short, Long)
values
    (N'pcs',   N'pieces'),          --  1
    (N'pkg',   N'package'),         --  2
    (N'pal',   N'palette'),         --  3
    (N'box',   N'box'),             --  4
    (N'can',   N'can'),             --  5
    (N'btl',   N'bottle'),          --  6
    (N'bags',  N'bags'),            --  7
    (N'blk',   N'block'),           --  8
    (N'ctn',   N'carton'),          --  9
    (N'cont',  N'container');       -- 10

-- Table for product catalog - Goods
insert into Goods
   (Item)
values
   (N'protective case'),          --  1
   (N'suede jacket'),             --  2
   (N'imported movie camera'),    --  3
   (N'gel pen'),                  --  4
   (N'alcohol marker'),           --  5
   (N'ceramic saucer'),           --  6
   (N'pot holder'),               --  7
   (N'protective boots'),         --  8
   (N'automatic umbrella'),       --  9
   (N'rubber boots'),             -- 10
   (N'aluminum mug'),             -- 11
   (N'backpack for laptop'),      -- 12
   (N'mountain bike'),            -- 13
   (N'tourist tent'),             -- 14
   (N'inflatable boat'),          -- 15
   (N'tea spoon'),                -- 16
   (N'corrugated hose'),          -- 17
   (N'reinforced hose'),          -- 18
   (N'black cable'),              -- 19
   (N'circuit breaker'),          -- 20
   (N'disconnection switch');     -- 21

-- Table for purchase facts - Purchases
insert into Purchases
    (IdItem, IdUnit, PurchaseDate, Price, Amount)
values
    ( 1,  1, '10-01-2021',    1700,   5),  --  1
    ( 1,  1, '10-02-2021',    1850,   2),  --  2
    ( 1,  1, '10-02-2021',    1600,  12),  --  3
    ( 3,  1, '10-03-2021',    8000,   6),  --  4
    ( 4,  9, '10-03-2021',    2000,   3),  --  5
    ( 5,  9, '10-04-2021',    2000,   3),  --  6
    ( 6,  1, '10-04-2021',     400,  10),  --  7
    ( 7,  1, '10-07-2021',    7900,  10),  --  8
    ( 4,  9, '10-07-2021',    3000,   3),  --  9
    ( 5,  1, '10-07-2021',     200,  30),  -- 10
    ( 3,  1, '10-07-2021',    8300,   5),  -- 11
    ( 7,  4, '10-17-2021',   36000,   3),  -- 12
    ( 6,  1, '10-17-2021',     380,  60),  -- 13
    ( 7,  4, '10-17-2021',   22000,   2),  -- 14
    ( 3,  9, '10-17-2021',   80000,   2),  -- 15
    ( 4,  1, '10-27-2021',      30, 200),  -- 16
    ( 7,  4, '10-27-2021',   12000,   3),  -- 17
    ( 1,  1, '10-27-2021',    1300, 300),  -- 18
    ( 2, 10, '10-27-2021', 1000000,   1),  -- 19
    (11,  1, '11-01-2021',     260,  20),  -- 20
    (12,  7, '11-01-2021',   60000,   3),  -- 21
    (11,  1, '11-07-2021',     250,  30),  -- 22
    (12,  1, '11-07-2021',    5200,  10);  -- 23

-- Table for seller's personal data - Persons
insert Persons
    (Surname, [Name], Patronymic, Passport)
values
    (N'Yurkovsky',   N'Mark',      N'Maksimilianovich', N'12 21 345671'),  --  1
	(N'Yakubovskaya',  N'Diana',     N'Pavlovna',        N'12 21 123452'),  --  2
    (N'Shapiro',      N'Fedor',     N'Fedorovich',       N'12 21 456123'),  --  3
	(N'Vozzhaev',     N'Sergey',    N'Denisovich',       N'12 21 123122'),  --  4
    (N'Khoromenko',    N'Igor',     N'Vladimirovich',    N'12 21 342121'),  --  5
	(N'Pelykh',       N'Marina',    N'Ulyanovna',       N'11 21 121212'),  --  6
	(N'Lapotnikova', N'Tamara',    N'Oscarovna',       N'11 21 098181'),  --  7
	(N'Ogorodnikov', N'Sergey',    N'Ivanovich',        N'12 21 091911'),  --  8
    (N'Yaylo',        N'Ekaterina', N'Nikolaevna',      N'12 21 345675'),  --  9
	(N'Loseva',      N'Inna',      N'Stepanovna',      N'12 21 187651'),  -- 10
    (N'Mikhaylovich',  N'Anna',      N'Valentinovna',    N'09 20 000122'),  -- 11
	(N'Tarapata',    N'Mikhail',    N'Isaakovich',       N'09 20 001981'),  -- 12
	(N'Trubikhin',    N'Edward',    N'Mikhaylovich',      N'09 21 121921'),  -- 13
	(N'Chmykhalo',     N'Oleg',      N'Tarasovich',       N'12 20 021121'),  -- 14
	(N'Knyazkov',    N'Stepan',    N'Sidorovich',       N'09 19 002165'),  -- 15
	(N'Potemkina',   N'Natalya',   N'Pavlovna',        N'09 19 002213'),  -- 16
    (N'Gritchenko',   N'Stepan',    N'Romanovich',       N'09 19 002129'),  -- 17
	(N'Selivanov',   N'Alexander', N'Mikhaylovich',      N'11 18 000503'),  -- 18
	(N'Tsarkova',    N'Larisa',    N'Ilinichna',       N'11 18 000523'),  -- 19
	(N'Yastrub',      N'Vladimir',  N'Danilovich',       N'14 21 091811');  -- 20
go

-- Table for sellers - Sellers
insert into Sellers
    (IdPerson, Interest)
values
    ( 1,  3.5),  --  1
    ( 2,  5.5),  --  2
    ( 3,  5.5),  --  3
    ( 4,  6.5),  --  4
    ( 5,  8.5),  --  5
    ( 6, 10.5),  --  6
    ( 7,  8.0),  --  7
    ( 8,  5.0),  --  8
    ( 9,  8.0),  --  9
    (10,  8.0),  -- 10
    (11,  3.5),  -- 11
    (12,  3.0),  -- 12
    (13,  4.0),  -- 13
    (14, 10.0),  -- 14
    (15,  5.5),  -- 15
    (16, 10.0),  -- 16
    (17,  8.0),  -- 17
    (18,  5.0),  -- 18
    (19,  4.5),  -- 19
    (20, 11.0);  -- 20
go

-- Table for sales facts - Sales
insert into Sales
    (IdPurchase, IdUnit, IdSeller, SaleDate, Price, Amount)
values
    ( 1,  1, 1, '10-02-2021',    1900,   2),  --  1
    ( 1,  1, 2, '10-02-2021',    1950,   3),  --  2
    ( 2,  1, 5, '10-02-2021',    1960,   2),  --  3
    ( 3,  1, 3, '10-03-2021',    1900,   6),  --  4
    ( 3,  1, 2, '10-03-2021',    1950,   5),  --  5
    ( 4,  1, 3, '10-04-2021',    9000,   3),  --  6
    ( 4,  1, 1, '10-04-2021',    9300,   2),  --  7
    ( 4,  1, 2, '10-04-2021',    9200,   1),  --  8
    ( 5,  9, 3, '10-05-2021',    2500,   2),  --  9
    ( 5,  9, 5, '10-05-2021',    2600,   1),  -- 10
    ( 6,  9, 4, '10-05-2021',    2300,   1),  -- 11
    ( 7,  1, 5, '10-05-2021',     500,   1),  -- 12
    ( 8,  1, 4, '10-07-2021',    8300,   6),  -- 13
    ( 6,  9, 3, '10-07-2021',    2500,   2),  -- 14
    ( 7,  1, 6, '10-07-2021',     500,   8),  -- 15
    ( 9,  9, 5, '10-09-2021',    4300,   2),  -- 16
    ( 8,  1, 1, '10-09-2021',    8300,   4),  -- 17
    (11,  1, 2, '10-09-2021',    9000,   3),  -- 18
    (10,  1, 3, '10-10-2021',     500,  20),  -- 19
    (11,  1, 4, '10-10-2021',    9000,   1),  -- 20
    (10,  1, 3, '10-11-2021',     450,   8),  -- 21
    (11,  1, 2, '10-12-2021',    9000,   1),  -- 22
    (10,  1, 1, '10-13-2021',     510,   3),  -- 23
    (10,  1, 4, '10-15-2021',     560,   1),  -- 24
    (10,  1, 6, '10-16-2021',     480,   6),  -- 25
    (15,  9, 5, '10-17-2021',  100000,   1),  -- 26
    (12,  4, 3, '10-17-2021',   40000,   1),  -- 27
    (13,  1, 6, '10-17-2021',     600,  20),  -- 28
    (12,  4, 5, '10-18-2021',   43000,   1),  -- 29
    (15,  9, 1, '10-18-2021',  110000,   1),  -- 30
    (13,  1, 2, '10-20-2021',     580,  30),  -- 41
    (14,  4, 3, '10-20-2021',   25500,   1),  -- 42
    (14,  4, 1, '10-21-2021',   27000,   1),  -- 43
    (12,  4, 3, '10-23-2021',   45000,   1),  -- 44
    (13,  1, 2, '10-25-2021',     650,  10),  -- 45
    (18,  1, 2, '10-27-2021',     500, 200),  -- 46
    (19, 10, 5, '10-27-2021', 1600000,   1),  -- 47
    (16,  1, 4, '10-27-2021',      60, 100),  -- 48
    (17,  4, 2, '10-28-2021',   16000,   1),  -- 49
    (18,  1, 5, '10-29-2021',     660, 100),  -- 40
    (16,  1, 4, '10-30-2021',      60, 100),  -- 51
    (17,  4, 3, '10-30-2021',   16000,   1),  -- 52
    (17,  4, 2, '10-30-2021',   16800,   1),  -- 53
    (18,  1, 6, '10-31-2021',     580, 200),  -- 54
    (18,  1, 1, '10-31-2021',     680, 100),  -- 55
    (21,  7, 6, '11-02-2021',   80000,   1),  -- 56
    (20,  1, 5, '11-03-2021',     380,   2),  -- 57
    (21,  7, 4, '11-04-2021',   82000,   1),  -- 58
    (20,  1, 3, '11-05-2021',     360,   12), -- 59
    (21,  7, 4, '11-06-2021',   80000,    1), -- 60
    (20,  1, 3, '11-07-2021',     380,    6), -- 61
    (23,  1, 3, '11-07-2021',    6600,    3), -- 62
    (22,  1, 4, '11-08-2021',     650,   10), -- 63
    (23,  1, 5, '11-08-2021',    6800,    4), -- 64
    (22,  1, 5, '11-08-2021',     600,   15), -- 65
    (22,  1, 4, '11-09-2021',     650,    5), -- 66
    (23,  1, 3, '11-09-2021',    6600,    3); -- 67
go