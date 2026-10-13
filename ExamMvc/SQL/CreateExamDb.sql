-- ============================================================
-- Вариант 3: Автомобили — база данни ExamDb, таблица dbo.Cars
-- Изпълнете в SQL Server Management Studio или във Visual Studio
-- (View → SQL Server Object Explorer → десен клик върху сървъра → New Query).
-- Скриптът може да се пуска многократно — връща началните данни.
-- ============================================================

IF DB_ID(N'ExamDb') IS NULL
    CREATE DATABASE ExamDb;
GO

USE ExamDb;
GO

IF OBJECT_ID(N'dbo.Cars', N'U') IS NOT NULL
    DROP TABLE dbo.Cars;
GO

CREATE TABLE dbo.Cars
(
    Id    INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Model NVARCHAR(200)  NOT NULL,
    Brand NVARCHAR(100)  NOT NULL,
    FuelType NVARCHAR(50)   NOT NULL,
    Year INT            NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);
GO

-- N пред текста е задължително за кирилица (NVARCHAR)
INSERT INTO dbo.Cars (Model, Brand, FuelType, Year, Price) VALUES
    (N'Corolla', N'Toyota', N'Бензин', 2019, 28500),
    (N'Yaris', N'Toyota', N'Хибрид', 2020, 26900),
    (N'Land Cruiser', N'Toyota', N'Дизел', 2018, 89000),
    (N'Golf', N'Volkswagen', N'Дизел', 2017, 21500),
    (N'Octavia', N'Škoda', N'Дизел', 2019, 27900),
    (N'X5', N'BMW', N'Дизел', 2016, 54000),
    (N'Model 3', N'Tesla', N'Електрически', 2022, 72000),
    (N'Clio', N'Renault', N'Бензин', 2018, 16800);
GO

SELECT * FROM dbo.Cars;
