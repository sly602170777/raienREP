-- 连接到数据库
CONNECT sys/123456@testdb

-- 执行 SQL 操作
SET PAGESIZE 100
SELECT * FROM Player;

-- 退出 SQL*Plus
EXIT;