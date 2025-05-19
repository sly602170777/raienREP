select distinct DEPARTMENT_NAME from departments;  --DISTINCT 去重复值

select last_name , hire_date from employees 
where to_char(hire_date,'yyyy-mm-dd') ='1994-06-07' --日期的格式转换

--赋值使用的符号  :=

--第二位含有的字符用 _
select last_name , hire_date from employees 
where last_name like '_e%'

--含有转义字符的文字列 查询处理
select first_name, last_name , hire_date from employees 
where first_name like '%/_%' escape '/'


----对多个字段进行排序
select first_name, last_name , hire_date,salary from employees
order by salary desc , last_name asc


--in (A 或者是B)
select first_name, last_name , hire_date,salary from employees
where salary  in (9000.00,17000.00);

--between and (两个值之间)
select first_name, last_name , hire_date,salary from employees
where salary  between 9000.00 and 17000.00;


--选择在1994年的员工 to_char 函数日期格式转换
select first_name,last_name, hire_date from employees
where  to_char(hire_date,'YYYY')='1994'

DESCRIBE employees;

-- 查询表的列信息
SELECT 
  column_name, 
  data_type, 
  nullable, 
  data_default
FROM all_tab_columns
WHERE table_name = 'EMPLOYEES';  -- 表名需大写



--单行函数：在 SELECT 语句中使用字符，数字，日期和转换函数
--大小写控制函数：LOWER UPPER  INITCAP
--字符控制函数：CONCAT SUBSTR LENGTH INSTR LPAD | RPAD TRIM  REPLACE

--大小写控制函数　首字母大写的
SELECT employee_id, last_name, department_id
FROM   employees
WHERE  LOWER(last_name) = 'higgins';

select 
    CONCAT('Hello', 'World') as a,  --HelloWorld
    SUBSTR('HelloWorld',1,5) as b,  --Hello 截取一到五
    LENGTH('HelloWorld') as e,  --10 长度是10
    INSTR('HelloWorld', 'W') as f, --6 含有W是第六位 Contains 'W'?" 不存在返回0
    LPAD(salary,10,'*') as dd, --*****24000  LPAD(原字符串, 目标长度[, 填充字符])
    RPAD(salary, 10, '*') as h, --24000*****
    TRIM('H' FROM 'HelloWorld') as l, --elloWorld 截取掉'H'
    REPLACE('abcd','b','m') as m  --amcd 调换位置
from employees;

--返回系统时间
SELECT SYSDATE FROM dual;  --2025/05/10 17:12:30


--使用 TO_DATE  TO_DATE(char[, 'format_model']) 
select TO_DATE('2012年10月29日 08:10:21','yyyy"年"mm"月"dd"日"hh:mi:ss') a
From dual  -- 2012/10/29 8:10:21

--添加本地货币    ¥6,000.00
SELECT TO_CHAR(salary, 'L99,999.00') SALARY
FROM   employees
WHERE  last_name = 'Ernst';
--转为数字类型
SELECT  TO_NUMBER('$1,234,567,890.00','$999,999,999,999.99')  --1234567890
from dual



-- 这些函数适用于任何数据类型，同时也适用于空值：
-- NVL (expr1, expr2) 为空时 用后边值代题
-- NVL2 (expr1, expr2, expr3)
-- NULLIF (expr1, expr2)
-- COALESCE (expr1, expr2, ..., exprn)

--奖金当为空时设置为'0'
select first_name, last_name , hire_date,salary*12*(1+ nvl(COMMISSION_PCT,0))  as "年薪" from employees
where salary  in (9000.00,17000.00);

--使用数据转换后进行字符串进行输出
select first_name, last_name , hire_date,salary, nvl(to_char(COMMISSION_PCT，'0.99'),'没有奖金')  as "奖金" from employees
where salary  in (9000.00,17000.00);

--奖金是空时 进行奖励工资翻倍  NVL2 (expr1, expr2, expr3) 
select first_name, last_name , hire_date,salary, nvl2(COMMISSION_PCT,salary*(1+COMMISSION_PCT)，salary*(2))  as "奖金" from employees
where salary  in (9000.00,17000.00);


--查询id是10 20 30 的员工信息 并且给他们涨工资 
-- CASE expr WHEN comparison_expr1 THEN return_expr1
--          [WHEN comparison_expr2 THEN return_expr2
--           WHEN comparison_exprn THEN return_exprn
--           ELSE else_expr]
-- END

--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    
--COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
select first_name, last_name , hire_date,salary, DEPARTMENT_ID ,
case DEPARTMENT_ID 
    when 10 then salary *1.1
    when 20 then salary *1.2
    else  salary *1.3
    end 
    as "新工资"                                 
from employees 
where  DEPARTMENT_ID in (10,20,30)
order by DEPARTMENT_ID desc
;
--使用decode代替 when then
select first_name, last_name , hire_date,salary, DEPARTMENT_ID ,
-- case DEPARTMENT_ID 
--     when 10 then salary *1.1
--     when 20 then salary *1.2
--     else  salary *1.3
--     end 
--     as "新工资"    
decode(DEPARTMENT_ID,10,salary *1.1,
20,salary *1.2,
30,salary *1.3
)                             
from employees 
where  DEPARTMENT_ID in (10,20,30)
order by DEPARTMENT_ID desc
 



--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--■■■■■■■■■■■■■■多表查询■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

--查看员工的工资等级
select employee_id,last_name,salary,grade_level
from employees e , job_grades j
where e.salary between j.lowest_sal and j.highest_sal
order by employee_id asc


select e.last_name, employee_id　--106件
from employees e 
select d.department_name  --27件
from departments d


--左外连接 右边缺少＋右边 107件
select e.last_name, employee_id,last_name,salary,d.department_name
from employees e , departments d
where e.department_id = d.department_id(+)


--左连接 以左边表为基准 未匹配的值显示Null  107件
--方法一
select e.last_name, employee_id,last_name,salary,d.department_name
from employees e left join departments d
on e.department_id = d.department_id
--方法二
select e.last_name, employee_id,last_name,salary,d.department_name
from employees e left outer join departments d
on e.department_id = d.department_id

select * from employees ;
select * from departments;

--1,自连接 查询公司员工chen 的manager信息
select emp.LAST_NAME, man.MANAGER_ID ,man.email from employees emp , employees man 
where 
emp.manager_id = man.employee_id 
and
LOWER(emp.last_name) ='chen';



--2.    查询90号部门,员工的job_id和90号部门的location_id 并且对jobID 去重
select distinct e.JOB_ID,d.department_id,d.location_id  
from employees e join departments d
on e.department_id = d.department_id
where d.department_id=90 


select * from employees ;
select * from departments;
select * from locations ;
--3.    选择所有有奖金的员工的信息
select emp.last_name, emp.salary,emp.COMMISSION_PCT 
from employees emp 
join departments dep
on emp.DEPARTMENT_ID = dep.DEPARTMENT_ID
join  locations loc
on loc.LOCATION_ID= dep.LOCATION_ID
where emp.COMMISSION_PCT is not null


--5.    选择指定员工的姓名，员工号，以及他的管理者的姓名和员工号，结果类似于下面的格式
select * from employees where LOWER(employees.last_name) ='kochhar';
select * from departments;
select * from locations ;
select emp.last_name as "employees", man.EMPLOYEE_ID as "Emp#",man.LAST_NAME as "manager",man.EMPLOYEE_ID as "Mgr#"
from employees emp , employees man 
where 
emp.manager_id = man.employee_id(+) 
--and LOWER(emp.last_name) ='kochhar';



--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--■■■■■■■■■■■■■■分 组 函 数■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
-- AVG 平均值 => SUM()/COUNT() 
-- COUNT 求个数
-- MAX  求最大值
-- MIN 求最小值
-- STDDEV 求标准偏差
-- SUM 求和
select * from employees ;
select * from departments;
select * from locations ;
select avg(SALARY),max(SALARY),sum(SALARY),min(SALARY)
from employees

--count 计算的是非空的值的总数
select count(1),count(2)
,count(*)
from employees

--求奖金的平均值 需要将所有人都要统计进去
select avg(COMMISSION_PCT) "有水分", SUM(COMMISSION_PCT)/count(COMMISSION_PCT) "有水分",SUM(COMMISSION_PCT)/count(*) "真实的"
from employees

--可以用nvl处理非空  
select avg(COMMISSION_PCT) "有水分", SUM(COMMISSION_PCT)/count(nvl(COMMISSION_PCT,1)) "nvl 处理",SUM(COMMISSION_PCT)/count(*) "真实的"
from employees

--处理重复值的求总数 count(distinct
select count(distinct department_id),count(department_id),count(*)
from employees



--求出EMPLOYEES表中各部门的平均工资
--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
select ROUND(avg(SALARY),2),DEPARTMENT_ID
from employees
group by DEPARTMENT_ID

--表中(40,60,80)部门的平均工资
select ROUND(avg(SALARY),2),NVL(TO_CHAR(DEPARTMENT_ID), '无部门')
from employees
where DEPARTMENT_ID in(40,60,80)
group by DEPARTMENT_ID

--表中不同部门 不同工种类的平均工资 group by + where
select ROUND(avg(SALARY),2),NVL(TO_CHAR(DEPARTMENT_ID), '无部门'),JOB_ID
from employees
where DEPARTMENT_ID in(40,60,80)
group by DEPARTMENT_ID,JOB_ID


--求出各部门中平均工资大于6000的部门  以及平均工资 对分组函数进行过滤需要用Having
select NVL(TO_CHAR(DEPARTMENT_ID), '无部门'),JOB_ID,ROUND(avg(SALARY),2)
from employees
having ROUND(avg(SALARY),2) >6000
group by DEPARTMENT_ID,JOB_ID
order by ROUND(AVG(SALARY),2) asc



--7.    查询员工最高工资和最低工资的差距（DIFFERENCE）
select MAX( SALARY),MIN( SALARY) ,MAX( SALARY)- MIN( SALARY) as  "DIFFERENCE" --,JOB_ID,ROUND(avg(SALARY),2)
from employees

--8.    查询各个管理者手下员工的最低工资，其中最低工资不能低于6000，没有管理者的员工不计算在内
--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID

select MANAGER_ID, MIN( SALARY)  --,JOB_ID,ROUND(avg(SALARY),2)
from employees
where MANAGER_ID is not null
group by MANAGER_ID
having MIN( SALARY) >= 6000
order by MIN( SALARY)


--10.    查询公司在1995-1998年之间，每年雇用的人数，结果类似下面的格式

--select count(*) as "total", avg(count(*))  --,JOB_ID,ROUND(avg(SALARY),2)
--select to_char(HIRE_DATE,'yyyy') ,count(*) 
select count(*) as "total", 
    count(decode(to_char(HIRE_DATE,'yyyy'),'1995',1,null)) as "1995", 
    count(decode(to_char(HIRE_DATE,'yyyy'),'1996',1,null)) as "1996",
    count(decode(to_char(HIRE_DATE,'yyyy'),'1997',1,null)) as "1997",
    count(decode(to_char(HIRE_DATE,'yyyy'),'1998',1,null)) as "1998"
from employees
where to_char(HIRE_DATE,'yyyy') in ('1995' ,'1996' ,'1997','1998')
--group by "1995","1996","1997","1998"
-- order by to_char(HIRE_DATE,'yyyy')




--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--■■■■■■■■■■■■■■子  查   询■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

--返回job_id与141号员工相同，salary比143号员工多的员工姓名，job_id 和工资
--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID

select LAST_NAME,JOB_ID,SALARY
from employees
where job_id =(
    select job_id from employees where  EMPLOYEE_ID =141
) and salary>(
    select salary from employees where  EMPLOYEE_ID =143
)


--返回公司工资最少的员工的last_name,job_id和salary

select LAST_NAME,JOB_ID,SALARY
from employees
where SALARY =(
    select min(salary) from employees 
)

--1.    查询和Zlotkey相同部门的员工姓名和雇用日期
select LAST_NAME,JOB_ID,HIRE_DATE
from employees
where DEPARTMENT_ID =(
        select DEPARTMENT_ID
        from employees
        where LAST_NAME='Zlotkey'
)

--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
--2.    查询工资比公司平均工资高的员工的员工号，姓名和工资。
select LAST_NAME,EMPLOYEE_ID,SALARY
from employees
where SALARY >(
    select avg(SALARY)
    from employees
)
--2.    查询奖金比公司平均工资高的员工的员工号，姓名和工资。
select LAST_NAME,EMPLOYEE_ID,SALARY,COMMISSION_PCT
from employees
where COMMISSION_PCT >(
    select 
        avg(COMMISSION_PCT) --0.22 不真实
    from employees
)

select LAST_NAME,EMPLOYEE_ID,SALARY,COMMISSION_PCT
from employees
where COMMISSION_PCT >(
    select 
        --avg(COMMISSION_PCT)
        sum(nvl(COMMISSION_PCT,0))/count(nvl(COMMISSION_PCT,1)) --0.07 真实的值
    from employees
)

--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
--3.    查询各部门中工资比本部门平均工资高的员工的员工号, 姓名和工资
--两个主要步骤：计算每个部门的平均工资，然后将每个员工与其所在部门的平均工资进行比较。
select DEPARTMENT_ID,LAST_NAME,EMPLOYEE_ID,SALARY
from employees e1
where
SALARY >(
    --使用一个子查询来计算所有部门的平均工资
    select avg(SALARY)
        from employees e2
        --所有员工所在部门
        where  (e2.DEPARTMENT_ID is not null) and (e1.department_id=e2.department_id)
        group by 
        e2.DEPARTMENT_ID
)


--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
--4.    查询和姓名中包含字母u的员工在相同部门的员工的员工号和姓名
select e1.FIRST_NAME,e1.LAST_NAME,e1.EMPLOYEE_ID,e1.DEPARTMENT_ID
from employees e1
WHERE UPPER(first_name) LIKE '%U%' OR UPPER(last_name) LIKE '%U%'
and e1.DEPARTMENT_ID in (
        select 
            distinct DEPARTMENT_ID
        from 
            employees e2
        where 
            DEPARTMENT_ID is not null
        and  UPPER(e2.first_name) LIKE '%U%' OR UPPER(e2.last_name) LIKE '%U%'
)

    select employee_id,last_name
    from employees
    where department_id in (
                          select department_id
                          from employees
                          where last_name like '%u%'
                           )
   and last_name not like '%u%'



--5. 查询在部门的location_id为1700的部门工作的员工的员工号
    select employee_id,last_name
    from employees
    where department_id in (
                          select distinct department_id
                          from departments
                          where departments.location_id = 1700
                       )
--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
--6.查询管理者是King的员工姓名和工资

    select * --employee_id,last_name,salary,MANAGER_ID
    from employees e1
    where MANAGER_ID in (
            select employee_id
            from employees e2
            where e2.last_name ='King' --and e2.MANAGER_ID is not null 
    )  


--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
-- 查询平均工资最低的部门信息
--1 查询公司中各部门的最低工资
--2 查询公司中各部门的平均工资中最少
--3. 哪个部门的平均工资 —— 2的结果
--4，查询此部门的部门信息

select
    * 
from
    departments 
where
    department_id = ( 
        SELECT
            DEPARTMENT_ID 
        FROM
            employees 
        GROUP BY
            DEPARTMENT_ID 
        HAVING
            AVG(SALARY) = ( 
                -- 子查询：计算所有部门平均工资的最小值（单行结果）
                SELECT
                    MIN(avg_salary) 
                FROM
                    ( 
                        SELECT
                            DEPARTMENT_ID
                            , AVG(SALARY) AS avg_salary 
                        FROM
                            employees 
                        GROUP BY
                            DEPARTMENT_ID
                    )
            )
    );




-- 查询平均工资最低的部门信息和该部门的平均工资
select
    d.* ,(select avg(salary) from employees where DEPARTMENT_ID = d.department_id) as "平均工资"
from
    departments d
where
    department_id = ( 
        SELECT
            DEPARTMENT_ID 
        FROM
            employees 
        GROUP BY
            DEPARTMENT_ID 
        HAVING
            AVG(SALARY) = ( 
                -- 子查询：计算所有部门平均工资的最小值（单行结果）
                SELECT
                    MIN(avg_salary) 
                FROM
                    ( 
                        SELECT
                            DEPARTMENT_ID
                            , AVG(SALARY) AS avg_salary 
                        FROM
                            employees 
                        GROUP BY
                            DEPARTMENT_ID
                    )
            )
    );




--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
-- 查询平均工资最高的job信息
--方法一
select
    * 
from
    jobs ,( 
        SELECT
            JOB_ID
            , avg_salary 
        FROM
            ( 
                SELECT
                    JOB_ID
                    , AVG(SALARY) AS avg_salary 
                FROM
                    employees 
                GROUP BY
                    JOB_ID
            ) 
        WHERE
            avg_salary = ( 
                SELECT
                    MAX(AVG(SALARY)) 
                FROM
                    employees 
                GROUP BY
                    JOB_ID
            )
    ) a
where
    jobs.JOB_ID = a.JOB_ID;


--方法二
select
    * 
from
    jobs 
where
    job_id in ( 
        select
            job_id 
        from
            employees 
        having
            avg(salary) = ( 
                SELECT
                    MAX(AVG(SALARY)) 
                FROM
                    employees 
                GROUP BY
                    JOB_ID
            ) 
        group by
            JOB_ID
    )

--查询平均工资高于公司平均工资的部门有哪些
select DEPARTMENT_ID,avg(SALARY) from employees 
group by DEPARTMENT_ID
having avg(salary) >(select avg(SALARY) from employees)



--查询出公司中所有manager的详细信息

select
    * 
from
    employees em1 
where
    em1.EMPLOYEE_ID in ( 
        select distinct
            MANAGER_ID 
        from
            employees em2 
        where
    )



--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
--各个部门中最高工资中最低的那个部门的最低工资是多少
--方法一
select DEPARTMENT_ID,min(SALARY)
from employees 
having DEPARTMENT_ID =(
    select DEPARTMENT_ID
    from employees 
    where SALARY =(
        select min("mi") from (
            select
                DEPARTMENT_ID,max(SALARY) as "mi"
            from
                employees group by DEPARTMENT_ID
                order by max(SALARY)
        )
    )
)
group by DEPARTMENT_ID

--方法二
select DEPARTMENT_ID,min(SALARY)
from employees 
having DEPARTMENT_ID =(
        select DEPARTMENT_ID
        from employees 
        group by DEPARTMENT_ID
        having max(salary) =(
            select
                min(max(SALARY)) as "mi"
            from
                employees 
            group by DEPARTMENT_ID
        )
)
group by DEPARTMENT_ID



--查询平均工资最高的部门的manager详细信息
--方法一
select
    * 
from
    employees 
where
    EMPLOYEE_ID in ( 
        select distinct
            MANAGER_ID 
        from
            employees em1
            , ( 
                select
                    DEPARTMENT_ID
                    , max("avg") as "groupMax" 
                from
                    ( 
                        select
                            DEPARTMENT_ID
                            , avg(SALARY) as "avg" 
                        from
                            employees 
                        group by
                            DEPARTMENT_ID
                    ) 
                group by
                    DEPARTMENT_ID 
                having
                    max("avg") = ( 
                        select
                            max("groupMax") 
                        from
                            ( 
                                select
                                    DEPARTMENT_ID
                                    , max("avg") as "groupMax" 
                                from
                                    ( 
                                        select
                                            DEPARTMENT_ID
                                            , avg(SALARY) as "avg" 
                                        from
                                            employees 
                                        group by
                                            DEPARTMENT_ID
                                    ) 
                                group by
                                    DEPARTMENT_ID
                            )
                    )
            ) KK 
        where
            em1.DEPARTMENT_ID = KK.DEPARTMENT_ID 
            and MANAGER_ID is not null
    )

        

--方法二
select
    * 
from
    employees 
where
    EMPLOYEE_ID in ( 
        select distinct
            MANAGER_ID 
        from
            employees 
        where
            DEPARTMENT_ID = ( 
                select
                    DEPARTMENT_ID 
                from
                    employees 
                group by
                    DEPARTMENT_ID 
                having
                    avg(SALARY) = ( 
                        select
                            max(avg(SALARY)) 
                        from
                            employees 
                        group by
                            DEPARTMENT_ID
                    )
            )
    )




--ROWID    EMPLOYEE_ID    FIRST_NAME    LAST_NAME    EMAIL    
--PHONE_NUMBER    HIRE_DATE    JOB_ID    SALARY    COMMISSION_PCT    MANAGER_ID    DEPARTMENT_ID
--查询1999年来公司的员工中的最高工资的那个员工的信息
--1999年来公司的员工的信息
--1. 筛选1999年入职的员工。
--2. 在这些员工中找到最高工资。
--3. 根据最高工资找到对应的员工记录。
select * from employees a
 where a.SALARY =( 
    --1999年来公司的员工最高工资
    select 
    max(SALARY)
    from employees
    where to_char(HIRE_DATE,'yyyy') = '1999'
)
 and to_char(a.HIRE_DATE,'yyyy') = '1999'


--方法二
SELECT *
FROM (
    SELECT *
    FROM employees
    WHERE hire_date BETWEEN TO_DATE('1999-01-01', 'YYYY-MM-DD') 
                        AND TO_DATE('1999-12-31', 'YYYY-MM-DD')
    ORDER BY salary DESC, employee_id
)
WHERE ROWNUM = 1;

























































































































































































































