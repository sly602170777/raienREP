--复制一个新表 还有数据
create table emp2 as select * from employees



--复制一个空表  没有数据
create table emp3 as select * from employees where 1 = 2


-- INSERT INTO departments 
--             (department_id, department_name, location_id)
-- VALUES      (&department_id, '&department_name',&location);

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--■■■■■■■■■■■■■■相关子  查   询■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

--查询员工中工资大于本部门平均工资的员工的last_name,salary和其department_id
SELECT last_name, salary, department_id
FROM   employees outer1
WHERE  salary >(
            SELECT AVG(salary)
             FROM   employees
             WHERE  department_id =  outer1.department_id
        )


--若employees表中employee_id与job_history表中employee_id相同的数目不小于2，
--输出这些相同id的员工的employee_id,last_name和其job_id
--ROWID    EMPLOYEE_ID    START_DATE    END_DATE    JOB_ID    DEPARTMENT_ID
--方法一
select * from employees e1 where 2 <=  
            (
                select count(*) 
                from job_history job 
                where job.employee_id = e1.employee_id  
            );

--方法二
select * from employees e1 where e1.employee_id in(
    SELECT 
        jh.employee_id 
    FROM 
        job_history jh 
    GROUP BY 
        jh.employee_id 
    HAVING 
        COUNT(*) >= 2
)


--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    PHONE_NUMBER    HIRE_DATE    
--JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
--查询公司管理者的employee_id,last_name,job_id,department_id信息

--方法一
select * from employees em1 where em1.employee_id in (
    select em2.MANAGER_ID  
    from employees em2 
    where em1.employee_id = em2.MANAGER_ID
) 


--方法二
select * from employees em1 where  EXISTS (
    select em2.MANAGER_ID  
    from employees em2 
    where em1.employee_id = em2.MANAGER_ID
) 

