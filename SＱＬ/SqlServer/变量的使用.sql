--��ѯ�ȿ���ʦ������ѧԱ��Ϣ
--1.ʹ���Ӳ�ѯʵ��
select * from Student where BornDate<(select BornDate from Student where StudentName='�տ�')
--ʹ�ñ����ķ�ʽ  declare @�������� ��������=ֵ
declare @age datetime=(select BornDate from Student where StudentName='�տ�')
select * from Student where BornDate<@age
--Ϊ������ֵ set/select /=
--1.ʹ��=�Ÿ�ֵ
go
declare @age datetime=(select BornDate from Student where StudentName='�տ�')
go
--ʹ��set��select��ֵ�Ĺ�ͬ�㣺��=���ұ���������sql����ʱ��,set/selectһ��
declare @stuNo int=100
--ʹ��set��ֵ��=�ź���ֻ��д������sql���--�Ӳ�ѯ
--set @stuNo=(select studentno from Student where StudentName='�տ�')
--select @stuNo=(select studentno from Student where StudentName='�տ�')
--select @stuNo=(select studentno from Student)
--set @stuNo=(select studentno from Student)
--select @stuNo=(select studentno from Student where StudentName='��fs��')
set @stuNo=(select studentno from Student where StudentName='��fs��')
print @stuNo
--ʹ��set/select��ֵ���������=�����sql��䲻��������Sql����������:set���ܽӲ�������sql���
go
declare @stuNo int=100
select @stuNo=studentno from Student where StudentName='�տ�'
print @stuno
go
--����1��set����ͬʱΪ���������ֵ(һ��ֻ��Ϊ����������ֵ),����select����ͬʱΪ���������ֵ
declare @stuNo int=100,@age int=18
--set @stuNo=20,@age=20
select  @stuNo=20,@age=20
print @stuno
print @age
go
--����2���������ǲ�������sql���ʱ�������䷵�ض��ֵ(����һ��)����ô�ͷ������һ��ֵ
declare @stuNo int=100,@age int=18
--set @stuNo=(select Studentno from Student)
select @stuNo= Studentno from Student
print @stuno
go
--����3���������sql��䲻����ʱ�����sql��䷵��ֵΪnull,��ôselect�ᱣ��ԭʼֵ(�����)
declare @stuNo int=100,@age int=18
--set @stuNo=(select Studentno from Student where StudentName='sdafdsfsadfa') --nullֵ��ԭʼֵ������
select @stuNo=Studentno from Student where StudentName='sdafdsfsadfa'
print @stuno
select 'aaaa',1
--select��print�����������Ĭ�������select����������print���Ϊ�ı���ʽ
--1.select����ͬʱ������ֵ������printֻ���������ֵ�������㽫���ֵ������һ��
print 'a','b'



---ȫ�ֱ�����ʹ��
select @@SERVERNAME --����������  �� localhost..���������
select @@SERVICENAME  --��������--mssqlerver  \sqlexpress
select @@VERSION

select * from Student
select @@ROWCOUNT  --���Եõ���ǰ�κβ�������Ӱ������

select COUNT(*) from Student

select COUNT(*) from Studen
select @@ERROR --��ѯ���Ĵ���ŵò���

declare @error int =0
update Student set LoginPwd='aaa' where StudentNo=6
set @error+=@@ERROR  --�õ�����ɾ�����޸ĵĴ���ţ��������ž����Ժ������ύ���߻ع����жϱ�־
if(@error<>0)
 print '�д��󣬻ع�'
else
 print 'û�д����ύ' 
go
declare @@age int 
set @@age=100
print @@age
go
----��ѯ���ڰ��ѧԱ��Ϣ��ʹ�ñ���ʵ�� --��Ҫʹ���Ӳ�ѯ��Ҳ��Ҫʹ�ñ�����
--1.ͨ���༶���Ʋ�ѯ���༶ID����ID�洢��������
--2.�ڲ�ѯѧԱ��Ϣ��ʱ��ʹ�ñ�����Ϊ����
declare @classId int --���Ӳ�ѯ��Ϊ�������߸�ֵ��ʱ�򣬲�����Ӷ��У�����ᵱ�����ݲ�ѯ�����ǿ��Է���һ�ж��е����ݣ���ʹ��select���и�ֵ��sql��䲻��������sql����ʱ��
select @classId= ClassId from Grade where ClassName='���ڰ�'
select * from Student where ClassId=@classId