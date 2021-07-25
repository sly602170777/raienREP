--查询比空老师年龄大的学员信息
--1.使用子查询实现
select * from Student where BornDate<(select BornDate from Student where StudentName='空空')
--使用变量的方式  declare @变量名称 变量类型=值
declare @age datetime=(select BornDate from Student where StudentName='空空')
select * from Student where BornDate<@age
--为变量赋值 set/select /=
--1.使用=号赋值
go
declare @age datetime=(select BornDate from Student where StudentName='空空')
go
--使用set和select赋值的共同点：当=号右边是完整的sql语句的时候,set/select一样
declare @stuNo int=100
--使用set赋值，=号后面只能写完整的sql语句--子查询
--set @stuNo=(select studentno from Student where StudentName='空空')
--select @stuNo=(select studentno from Student where StudentName='空空')
--select @stuNo=(select studentno from Student)
--set @stuNo=(select studentno from Student)
--select @stuNo=(select studentno from Student where StudentName='空fs空')
set @stuNo=(select studentno from Student where StudentName='空fs空')
print @stuNo
--使用set/select赋值的区别：如果=后面的sql语句不是完整的Sql语句才有区别:set不能接不完整的sql语句
go
declare @stuNo int=100
select @stuNo=studentno from Student where StudentName='空空'
print @stuno
go
--区别1：set不能同时为多个变量赋值(一次只能为单个变量赋值),但是select可以同时为多个变量赋值
declare @stuNo int=100,@age int=18
--set @stuNo=20,@age=20
select  @stuNo=20,@age=20
print @stuno
print @age
go
--区别2：当后面是不完整的sql语句时，如果语句返回多个值(多行一列)，那么就返回最后一个值
declare @stuNo int=100,@age int=18
--set @stuNo=(select Studentno from Student)
select @stuNo= Studentno from Student
print @stuno
go
--区别3：当后面的sql语句不完整时，如果sql语句返回值为null,那么select会保留原始值(如果有)
declare @stuNo int=100,@age int=18
--set @stuNo=(select Studentno from Student where StudentName='sdafdsfsadfa') --null值将原始值覆盖了
select @stuNo=Studentno from Student where StudentName='sdafdsfsadfa'
print @stuno
select 'aaaa',1
--select和print都可以输出，默认情况下select输出在虚拟表，print输出为文本形式
--1.select可以同时输出多个值，但是print只能输出单个值，除非你将多个值连接在一起
print 'a','b'



---全局变量的使用
select @@SERVERNAME --服务器名称  。 localhost..计算机名称
select @@SERVICENAME  --服务名称--mssqlerver  \sqlexpress
select @@VERSION

select * from Student
select @@ROWCOUNT  --可以得到当前任何操作的受影响行数

select COUNT(*) from Student

select COUNT(*) from Studen
select @@ERROR --查询语句的错误号得不到

declare @error int =0
update Student set LoginPwd='aaa' where StudentNo=6
set @error+=@@ERROR  --得到增加删除和修改的错误号，这个错误号就是以后事务提交或者回滚的判断标志
if(@error<>0)
 print '有错误，回滚'
else
 print '没有错误，提交' 
go
declare @@age int 
set @@age=100
print @@age
go
----查询六期班的学员信息，使用变量实现 --不要使用子查询，也不要使用表连接
--1.通过班级名称查询出班级ID，将ID存储到变量中
--2.在查询学员信息的时候使用变量做为条件
declare @classId int --在子查询做为条件或者赋值的时候，不能添加多列，否则会当成数据查询，但是可以返回一列多行的数据，在使用select进行赋值，sql语句不是完整的sql语句的时候
select @classId= ClassId from Grade where ClassName='六期班'
select * from Student where ClassId=@classId