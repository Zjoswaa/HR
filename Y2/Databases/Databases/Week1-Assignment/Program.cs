using Microsoft.EntityFrameworkCore;
using Model;

using (var context = new TrialContext()) {
    string CreateDB = @"
        DROP TABLE IF EXISTS EMPLOYEE CASCADE;
        DROP TABLE IF EXISTS DEPARTMENT CASCADE;
        DROP TABLE IF EXISTS DEPT_LOCATIONS CASCADE;
        DROP TABLE IF EXISTS PROJECT CASCADE;
        DROP TABLE IF EXISTS WORKS_ON CASCADE;
        DROP TABLE IF EXISTS DEPENDENT CASCADE;

        CREATE TABLE IF NOT EXISTS EMPLOYEE (
            Fname VARCHAR(15),
            Minit CHAR,
            Lname VARCHAR(15),
            Ssn CHAR(9) NOT NULL,
            Bdate DATE,
            Address VARCHAR(50),
            Sex CHAR,
            Salary DECIMAL(10,2),
            Super_ssn CHAR(9),
            Dno INT,
            PRIMARY KEY (Ssn)
        );

        CREATE TABLE IF NOT EXISTS DEPARTMENT (
            Dname VARCHAR(15),
            Dnumber INT NOT NULL,
            Mgr_ssn CHAR(9),
            Mgr_start_date DATE,
            PRIMARY KEY (Dnumber)
        );

        CREATE TABLE IF NOT EXISTS DEPT_LOCATIONS (
            Dno INT NOT NULL,
            Dlocation VARCHAR(15) NOT NULL,
            PRIMARY KEY(Dno, Dlocation)
        );

        CREATE TABLE IF NOT EXISTS PROJECT (
            Pname VARCHAR(15),
            Pnumber INT NOT NULL,
            Plocation VARCHAR(15),
            Dno INT NOT NULL,
            PRIMARY KEY(Pnumber)
        );

        CREATE TABLE IF NOT EXISTS WORKS_ON (
            Essn CHAR(9) NOT NULL,
            Pno INT NOT NULL,
            Hours INT,
            PRIMARY KEY(Essn, Pno)
        );

        CREATE TABLE IF NOT EXISTS DEPENDENT (
            Essn CHAR(9) NOT NULL,
            Dependent_name VARCHAR(15) NOT NULL,
            Sex CHAR,
            Bdate DATE,
            Relationship VARCHAR(15),
            PRIMARY KEY (Essn, Dependent_name)
        );

        ALTER TABLE EMPLOYEE
        ADD FOREIGN KEY (Dno) REFERENCES DEPARTMENT (Dnumber)
            ON DELETE SET NULL ON UPDATE CASCADE,
        ADD FOREIGN KEY (Super_ssn) REFERENCES EMPLOYEE (Ssn)
            ON DELETE SET NULL ON UPDATE CASCADE;
        ALTER TABLE DEPARTMENT
        ADD FOREIGN KEY (Mgr_ssn) REFERENCES EMPLOYEE (Ssn)
            ON DELETE SET NULL ON UPDATE CASCADE;
        ALTER TABLE DEPT_LOCATIONS
        ADD FOREIGN KEY (Dno) REFERENCES DEPARTMENT (Dnumber)
            ON DELETE SET NULL ON UPDATE CASCADE;
        ALTER TABLE PROJECT
        ADD FOREIGN KEY (Dno) REFERENCES DEPARTMENT (Dnumber)
            ON DELETE SET NULL ON UPDATE CASCADE;
        ALTER TABLE WORKS_ON
        ADD FOREIGN KEY (Essn) REFERENCES EMPLOYEE (Ssn)
            ON DELETE SET NULL ON UPDATE CASCADE,
        ADD FOREIGN KEY (Pno) REFERENCES PROJECT (Pnumber)
            ON DELETE SET NULL ON UPDATE CASCADE;
        ALTER TABLE DEPENDENT
        ADD FOREIGN KEY (Essn) REFERENCES EMPLOYEE (Ssn)
            ON DELETE SET NULL ON UPDATE CASCADE;
    ";

    string SeedDB = @"
        --DEPARTMENT -Insert (with null values for Manager)
        INSERT into DEPARTMENT(Dname, Dnumber, Mgr_ssn, Mgr_start_date)
        VALUES('Headquarter', 1 , NULL, NULL),
            ('Human Resource', 2, NULL, NULL),
            ('Finance', 3, NULL, NULL),
            ('Administration', 4, NULL,NULL),
            ('Research', 5, NULL,NULL);

        --EMPLOYEE
        INSERT into EMPLOYEE (Fname, Minit, Lname, Ssn, Bdate, Address, Sex, Salary, Super_ssn, Dno)
        VALUES('James', 'E', 'Borg', 888, '1995-6-6', 'The Hague','F', 4500, NULL,4),
        ('Franklin', 'T', 'Wong', 222, '1955-2-2', '103 wijnhaven Rotterdam','M', 3000, 888,5),
        ('Jennifer', 'S', 'Wallace', 444, '1941-4-4', '50 St. Willibrordusstraat, Amsterdam','F', 4000, 888,4),
        ('John', 'B', 'Smith', 111, '1965-1-1', '1 Boompjes Rotterdam','M', 6000, 222,5),
        ('Ramesh', 'K', 'Narayan', 555, '1962-5-5', '2 Kroninburg, Delft','F', 4500, 222,4),
        ('Joyce', 'A', 'English', 666, '1972-6-6', 'Olof Palmestraat 1, Delft','F', 4500, 222,4),
        ('Alicia', 'J', 'Zelaya', 333, '1968-3-3', '52 Laan van Kroninburg, Amstelveen','F', 4500, 444,4),
        ('Ahmad', NULL, 'Jabbar', 777, '2000-7-8', 'Laan van Wateringse Veld 484, Den Haag','F', 4500, 444,4)
        ;

        --DEPARTMENT -Update
            UPDATE DEPARTMENT
            SET Mgr_ssn = 222,
            Mgr_start_date = '1988-05-22'
            WHERE Dnumber = 5;
            
            UPDATE DEPARTMENT
            SET Mgr_ssn = 777,
            Mgr_start_date = '1995-01-01'
            WHERE Dnumber = 4;
            
            UPDATE DEPARTMENT
            SET Mgr_ssn = 888,
            Mgr_start_date = '1981-06-19'
            WHERE Dnumber = 1;

        
        --DEPT_LOCATIONS
        INSERT into DEPT_LOCATIONS(Dno, Dlocation)
        VALUES(1, 'Houston'), (4, 'Stafford'), (5, 'Bellaire'), (5, 'Sugarland'), (5, 'Huston');

        --PROJECT
        INSERT INTO PROJECT(Pname, Pnumber, Plocation, Dno)
        VALUES('ProductX',1,'Bellaire',5),('ProductY',2,'Sugarland',5),('ProductZ',3,'Huston',5),('Computerization',10,'Stafford',4),('Reorganization',20,'Huston',1),('Newbenefits',30,'Stafford',4);

        --WORKS_ON
        INSERT INTO WORKS_ON(Essn, Pno, Hours)
        VALUES(111,1, 32),
        (111,2,8),
        (555,3,40),
        (666,1,20),
        (666,2,20),
        (222,2,10),
        (222,3,10),
        (222,10,10),
        (222,20,10),
        (333,30,30),
        (333,10,10),
        (777,10,35),
        (777,30,5),
        (444,30,20),
        (444,20,15),
        (888,20,NULL);

        --DEPENDENT
        INSERT INTO  DEPENDENT(Essn, Dependent_name, Sex, Bdate, Relationship)
        VALUES(222,'Alice','F','1986-04-05','Daughter'),
        (222,'Theo','M','1983-10-25','Son'),
        (222,'Joy','F','1958-05-03','Spouse'),
        (444,'Abner','M','1942-02-28','Spouse'),
        (111,'Michael','M','1988-01-04','Son'),
        (111,'Alice','F','1988-12-30','Daughter'),
        (111,'Elizabeth','F','1967-05-05','Spouse');
    ";

    string truncateTables = @"
        TRUNCATE EMPLOYEE CASCADE ;
        TRUNCATE DEPARTMENT CASCADE ;
        TRUNCATE DEPT_LOCATIONS CASCADE ;
        TRUNCATE PROJECT CASCADE ;
        TRUNCATE WORKS_ON CASCADE;
        TRUNCATE DEPENDENT CASCADE;
    ";

    context.Database.ExecuteSqlRaw(CreateDB);

    //Comment after completion of the given assignment:
    context.Database.ExecuteSqlRaw(truncateTables);
    context.Database.ExecuteSqlRaw(SeedDB);
}