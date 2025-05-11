-- Project Name : noname
-- Date/Time    : 2025/05/10 19:40:45
-- Author       : 81702
-- RDBMS Type   : Oracle Database
-- Application  : A5:SQL Mk-2

/*
  << 注意！！ >>
  BackupToTempTable, RestoreFromTempTable疑似命令が付加されています。
  これにより、drop table, create table 後もデータが残ります。
  この機能は一時的に $$TableName のような一時テーブルを作成します。
  この機能は A5:SQL Mk-2でのみ有効であることに注意してください。
*/

-- DEPARTMENTS
-- * RestoreFromTempTable
create table DEPARTMENTS (
  DEPARTMENT_ID NUMBER(4, 0) not null
  , DEPARTMENT_NAME VARCHAR2(30) not null
  , MANAGER_ID NUMBER(6, 0)
  , LOCATION_ID NUMBER(4, 0)
  , constraint DEPARTMENTS_PKC primary key (DEPARTMENT_ID)
) ;

-- EMPLOYEES
-- * RestoreFromTempTable
create table EMPLOYEES (
  EMPLOYEE_ID NUMBER(6, 0) not null
  , FIRST_NAME VARCHAR2(20)
  , LAST_NAME VARCHAR2(25) not null
  , EMAIL VARCHAR2(25) not null
  , PHONE_NUMBER VARCHAR2(20)
  , HIRE_DATE DATE not null
  , JOB_ID VARCHAR2(10) not null
  , SALARY NUMBER(8, 2)
  , COMMISSION_PCT NUMBER(2, 2)
  , MANAGER_ID NUMBER(6, 0)
  , DEPARTMENT_ID NUMBER(4, 0)
  , constraint EMPLOYEES_PKC primary key (EMPLOYEE_ID)
) ;

alter table EMPLOYEES add constraint EMP_EMAIL_UK
  unique (EMAIL) ;

-- JOB_GRADES
-- * RestoreFromTempTable
create table JOB_GRADES (
  GRADE_LEVEL VARCHAR2(3)
  , LOWEST_SAL NUMBER
  , HIGHEST_SAL NUMBER
) ;

-- JOBS
-- * RestoreFromTempTable
create table JOBS (
  JOB_ID VARCHAR2(10) not null
  , JOB_TITLE VARCHAR2(35) not null
  , MIN_SALARY NUMBER(6, 0)
  , MAX_SALARY NUMBER(6, 0)
  , constraint JOBS_PKC primary key (JOB_ID)
) ;

-- LOCATIONS
-- * RestoreFromTempTable
create table LOCATIONS (
  LOCATION_ID NUMBER(4, 0) not null
  , STREET_ADDRESS VARCHAR2(40)
  , POSTAL_CODE VARCHAR2(12)
  , CITY VARCHAR2(30) not null
  , STATE_PROVINCE VARCHAR2(25)
  , COUNTRY_ID CHAR(2)
  , constraint LOCATIONS_PKC primary key (LOCATION_ID)
) ;

comment on table DEPARTMENTS is 'DEPARTMENTS';
comment on column DEPARTMENTS.DEPARTMENT_ID is 'DEPARTMENT_ID';
comment on column DEPARTMENTS.DEPARTMENT_NAME is 'DEPARTMENT_NAME';
comment on column DEPARTMENTS.MANAGER_ID is 'MANAGER_ID';
comment on column DEPARTMENTS.LOCATION_ID is 'LOCATION_ID';

comment on table EMPLOYEES is 'EMPLOYEES';
comment on column EMPLOYEES.EMPLOYEE_ID is 'EMPLOYEE_ID';
comment on column EMPLOYEES.FIRST_NAME is 'FIRST_NAME';
comment on column EMPLOYEES.LAST_NAME is 'LAST_NAME';
comment on column EMPLOYEES.EMAIL is 'EMAIL';
comment on column EMPLOYEES.PHONE_NUMBER is 'PHONE_NUMBER';
comment on column EMPLOYEES.HIRE_DATE is 'HIRE_DATE';
comment on column EMPLOYEES.JOB_ID is 'JOB_ID';
comment on column EMPLOYEES.SALARY is 'SALARY';
comment on column EMPLOYEES.COMMISSION_PCT is 'COMMISSION_PCT';
comment on column EMPLOYEES.MANAGER_ID is 'MANAGER_ID';
comment on column EMPLOYEES.DEPARTMENT_ID is 'DEPARTMENT_ID';

comment on table JOB_GRADES is 'JOB_GRADES';
comment on column JOB_GRADES.GRADE_LEVEL is 'GRADE_LEVEL';
comment on column JOB_GRADES.LOWEST_SAL is 'LOWEST_SAL';
comment on column JOB_GRADES.HIGHEST_SAL is 'HIGHEST_SAL';

comment on table JOBS is 'JOBS';
comment on column JOBS.JOB_ID is 'JOB_ID';
comment on column JOBS.JOB_TITLE is 'JOB_TITLE';
comment on column JOBS.MIN_SALARY is 'MIN_SALARY';
comment on column JOBS.MAX_SALARY is 'MAX_SALARY';

comment on table LOCATIONS is 'LOCATIONS';
comment on column LOCATIONS.LOCATION_ID is 'LOCATION_ID';
comment on column LOCATIONS.STREET_ADDRESS is 'STREET_ADDRESS';
comment on column LOCATIONS.POSTAL_CODE is 'POSTAL_CODE';
comment on column LOCATIONS.CITY is 'CITY';
comment on column LOCATIONS.STATE_PROVINCE is 'STATE_PROVINCE';
comment on column LOCATIONS.COUNTRY_ID is 'COUNTRY_ID';

