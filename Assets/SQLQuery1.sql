use CitiHoloDB;

--Table - 1
CREATE TABLE [dbo].[FL_insurance_sample_2] (
[policyID] varchar(50) NOT NULL PRIMARY KEY,
[statecode] varchar(50),
[county] varchar(50),
[eq_site_limit] varchar(50),
[hu_site_limit] varchar(50),
[fl_site_limit] varchar(50),
[fr_site_limit] varchar(50),
[tiv_2011] varchar(50),
[tiv_2012] varchar(50),
[eq_site_deductible] varchar(50),
[hu_site_deductible] varchar(50),
[fl_site_deductible] varchar(50),
[fr_site_deductible] varchar(50),
[point_latitude] varchar(50),
[point_longitude] varchar(50),
[line] varchar(50),
[construction] varchar(50),
[point_granularity] int
)


--Table 2
CREATE TABLE [dbo].[FL_insurance_sample_1] (
[policyID] varchar(50) NOT NULL FOREIGN KEY REFERENCES [dbo].[FL_insurance_sample_2]([policyID] ),
[statecode] varchar(50),
[county] varchar(50),
[tiv_2011] float,
[tiv_2012] float,
[fl_site_deductible] float,
[fr_site_deductible] float,
[point_latitude] decimal(38,0),
[point_longitude] decimal(38,0),
[construction] varchar(50),
[point_granularity] int
)



--Datetime columns added to both tthe tables

ALTER TABLE dbo.FL_insurance_sample_1 
ADD  Created_At DATETIME NOT NULL DEFAULT '2011-01-26 14:30:00'  ;

ALTER TABLE dbo.FL_insurance_sample_1 
ADD  Valid_Until DATETIME NOT NULL DEFAULT '2017-01-26 14:30:00'  ;


ALTER TABLE dbo.FL_insurance_sample_2
ADD  Created_At DATETIME NOT NULL DEFAULT '2011-01-26 14:30:00'  ;

ALTER TABLE dbo.FL_insurance_sample_2
ADD  Valid_Until DATETIME NOT NULL DEFAULT '2017-01-26 14:30:00'  ;



--Procedures
GO

CREATE PROCEDURE dbo.uspGetsampledata1
AS
SELECT * FROM dbo.FL_insurance_sample_1
GO


--second procedure to inner join the two tables based on the primary key
go
create PROCEDURE dbo.uspJoinsampledata
AS
BEGIN
SELECT dbo.FL_insurance_sample_1.* FROM dbo.FL_insurance_sample_1
INNER JOIN dbo.FL_insurance_sample_2 ON (dbo.FL_insurance_sample_1.policyID=dbo.FL_insurance_sample_1.policyID)
END
go

---Third procedure to check if the two tables are identical or not

GO

CREATE PROCEDURE dbo.uspCheckIdenticalsampledata
AS
SELECT table1.policyID
FROM dbo.FL_insurance_sample_1 table1
WHERE EXISTS(SELECT table2.policyID 
FROM dbo.FL_insurance_sample_2 table2
WHERE table2.policyID = table1.policyID);
GO

--Records present in Table1 but not in Table 2


GO

CREATE PROCEDURE dbo.uspGetTable1sampledata
AS
SELECT dbo.FL_insurance_sample_1.*
FROM dbo.FL_insurance_sample_1
    LEFT JOIN dbo.FL_insurance_sample_2 ON (dbo.FL_insurance_sample_1.policyID = dbo.FL_insurance_sample_2.policyID)
WHERE dbo.FL_insurance_sample_2.policyID IS NULL
GO



--Records present in table 2 but not in table 1
CREATE PROCEDURE dbo.uspGetTable2sampledata
AS
SELECT dbo.FL_insurance_sample_2.*
FROM dbo.FL_insurance_sample_2
    LEFT JOIN dbo.FL_insurance_sample_1 ON (dbo.FL_insurance_sample_2.policyID = dbo.FL_insurance_sample_1.policyID)
WHERE dbo.FL_insurance_sample_1.policyID IS NULL
GO



--Records which are not common to both the tables


CREATE PROCEDURE dbo.uspGetDifferentDatasampledata
AS
SELECT dbo.FL_insurance_sample_1.*, dbo.FL_insurance_sample_2.*
FROM dbo.FL_insurance_sample_1
    FULL JOIN dbo.FL_insurance_sample_2 ON (dbo.FL_insurance_sample_1.policyID = dbo.FL_insurance_sample_2.policyID)
WHERE  dbo.FL_insurance_sample_1.policyID IS NULL OR  dbo.FL_insurance_sample_2.policyID IS NULL
GO



--procedure to see the number/percentage by which the two records/tables are different
CREATE PROCEDURE dbo.uspCalculateDifferentDatasampledata
AS
SELECT a.policyID,
       a.total1,
       b.total2,
       (b.total2 / a.total1 * 100) AS percentage
FROM
    (SELECT policyID, Count(*) AS total1
     FROM dbo.FL_insurance_sample_1
     GROUP BY policyID) a,
    (SELECT policyID, Count(*) AS total2
     FROM dbo.FL_insurance_sample_2
     GROUP BY policyID) b
WHERE a.policyID = b.policyID


GO








