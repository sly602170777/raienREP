--buffer cache的几个重要指标数
SELECT
    NAME
    , VALUE 
FROM
    v$sysstat 
WHERE
    NAME IN ( 
        'session logical reads'
        , 'physical reads'
        , 'physical reads direct'
        , 'physical reads direct (lob) '
        , 'consistent gets'
        , 'db block gets'
        , 'free buffer inspected'
        , 'free buffer requested'
        , 'dirty buffers inspected'
        , 'pinned buffers inspected'
    );


--Buffer Busy Waits:
SELECT
    event
    , total_waits 
FROM
    v$system_event 
WHERE
    event IN ('free buffer waits', 'buffer busy waits');


--   查询event事件名称
SELECT
    NAME
    , parameter1
    , parameter2
    , parameter3 
FROM
    v$event_name 
WHERE
    NAME = 'buffer busy waits';


--评估Cache的命中率计算命中率的思想
SELECT
    ROUND( 
        1 - ( 
            (physical.value - direct.value - lobs.value) / logical.value
        ) 
        , 3
    ) * 100 || '%' "Buffer Cache Hit Ratio" 
FROM
    v$sysstat physical
    , v$sysstat direct
    , v$sysstat lobs
    , v$sysstat logical 
WHERE
    physical.name = 'physical reads' 
    AND direct.name = 'physical reads direct' 
    AND lobs.name = 'physical reads direct (lob)' 
    AND logical.name = 'session logical reads';



select
    name 
from
    v$statname 
where
    statistic# in (54, 55, 56);


SELECT
    NAME
    , physical_reads
    , db_block_gets
    , consistent_gets
    , ROUND( 
        ( 
            1 - ( 
                physical_reads / (db_block_gets + consistent_gets)
            )
        ) * 100
    ) || '%' ratio 
FROM
    V$BUFFER_POOL_STATISTICS 
WHERE
    NAME = 'DEFAULT'
;


--查看当前buffer cache的大小
-- NAME    CURRENT_SIZE    BUFFERS
-- DEFAULT    1568    191884

SELECT
    NAME
    , current_size
    , buffers 
FROM
    v$buffer_pool
;

--使用 alter system set db_cache_size 来调整
--ALTER SYSTEM SET db_cache_size = 512M;


--*Captions 模拟的 buffer cache 大小 (MB),相对于当前设置的比例,估算的物理读次数（越少越好）
SELECT
  size_for_estimate AS "Cache Size (MB)",
  size_factor AS "Size Factor",
  estd_physical_reads AS "Estimated Physical Reads"
FROM
  v$db_cache_advice
WHERE
  name = 'DEFAULT'
  AND block_size = (SELECT value FROM v$parameter WHERE name = 'db_block_size')
  AND advice_status = 'ON'
ORDER BY
  size_for_estimate
;

--优化Buffer cache的常用参数及视图
--         db_cache_size
--         db_cache_advice
--         db_keep_cache_size
--         db_recycle_cache_size
--         db_file_multiblock_read_count
--         statspace report
--         v$db_cache_advice(view)


select * from v$version where rownum < 2;

select name,bytes/1024/1024 from v$sgainfo where name='Buffer Cache Size';


 select name,current_size,buffers,block_size  FROM v$buffer_pool;
 
 SELECT
    owner#
    , NAME
    , COUNT(*) blocks 
FROM
    v$cache 
GROUP BY
    owner#
    , NAME
order by blocks desc
;

 --跟踪recycle buffer pool的I/O情况
SELECT
    s.username
    , io.block_gets
    , io.consistent_gets
    , io.physical_reads 
FROM
    v$sess_io io
    , v$session s 
WHERE
    io.sid = s.sid;


--这个查询获得到经常访问的对象，可以将其放到keep pool中
SELECT
    o.owner
    , object_name
    , object_type
    , COUNT(1) buffers 
FROM
    SYS.x$bh
    , dba_objects o 
WHERE
    tch > 10 
    AND lru_flag = 8 
    AND obj = o.object_id 
    AND o.owner NOT IN ('SYSTEM', 'SYS') 
GROUP BY
    o.owner
    , object_name
    , object_type 
ORDER BY
    buffers;



--SELECT * FROM investment_data WHERE ROWNUM <= 1000;

SELECT sql_text
FROM v$sql
WHERE sql_text LIKE '%INDEX(%'
   OR sql_text LIKE '%USE_CONCAT%'
   OR sql_text LIKE '%LEADING%'
;



SELECT index_name, index_type, table_name, uniqueness, status
FROM all_indexes
WHERE table_name = 'investment_data'
;

--表中的索引查询
SELECT index_name, table_name, tablespace_name, status FROM dba_indexes WHERE table_name = 'investment_data'
;


--创建索引
CREATE INDEX idx_fiscal_year ON investment_data (fiscal_year);
--删除索引
DROP INDEX idx_fiscal_year;

--- 可判断某个索引是否在查询中被实际使用
ALTER INDEX idx_fiscal_year MONITORING USAGE;

-- 等待一段时间后执行
SELECT index_name, table_name, used FROM v$object_usage WHERE table_name = 'investment_data'
;



--查看索引列类型
SELECT index_name, column_name, column_position FROM all_ind_columns WHERE table_name = 'INVESTMENT_DATA' ORDER BY index_name, column_position
;

--查询表中查看字段类型
SELECT column_name, data_type, data_length, nullable FROM all_tab_columns WHERE table_name = 'INVESTMENT_DATA'
;


--CREATE INDEX idx_fiscal_year_code ON investment_data(fiscal_year, code);


--方案一 SQL 进行全表查询
/* 
-  fiscal_year 是 Number 类型 → ❌ 会触发隐式转换 会全表查询
- SELECT *  全表扫描  --》最低效
- 索引失效（无法使用基于 fiscal_year 的索引）
- 查询性能下降
- 某些情况下，查询结果为空（如果转换失败）

*/  
EXPLAIN PLAN FOR SELECT * FROM investment_data WHERE fiscal_year = '202403';
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);

--方案二 SQL 进行全表查询
/* 
-  fiscal_year 是 Number 类型 → ❌ 会触发隐式转换 会全表查询
-  Fast Full Scan 扫描  --》中等效率，避免回表但仍扫描整个索引
- 索引失效（无法使用基于 fiscal_year 的索引）
- 查询性能下降
- 某些情况下，查询结果为空（如果转换失败）
*/  

EXPLAIN PLAN FOR SELECT code FROM investment_data WHERE fiscal_year = '202403';
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);




SELECT /*+ gather_plan_statistics */ code FROM investment_data WHERE fiscal_year = 202403;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY_CURSOR(NULL, NULL, 'ALLSTATS LAST'));


SELECT /*+ gather_plan_statistics */ code FROM investment_data WHERE fiscal_year = '202403';
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY_CURSOR(NULL, NULL, 'ALLSTATS LAST'));

/*
--方案三 SQL 进行Range Scan  使用新建索引
--优化后的SQL 不进行全表查询--》最优路径，按条件精准定位数据块
- 如果 fiscal_year 是 NUMBER 类型 → ✅ 完全匹配，索引可用 
- 如果 fiscal_year 是 VARCHAR2 类型 → ❌ 会触发隐式转换 会全表查询


方案一二三 性能提升总结
- ✅ 成本从 25 → 13 → 8，性能明显提升
- ✅ 查询路径从全表扫描 → 索引全扫描 → 索引范围扫描，越来越精准
- ✅ 优化器成功识别并使用你设计的索引结构

*/  
EXPLAIN PLAN FOR SELECT code FROM investment_data WHERE fiscal_year = 202403;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);


-- 查看表中所有的字段类型 
SELECT column_name, data_type FROM all_tab_columns WHERE table_name = 'INVESTMENT_DATA';


EXPLAIN PLAN FOR SELECT * FROM investment_data WHERE fiscal_year = '202403';


SELECT * FROM TABLE (DBMS_XPLAN.DISPLAY);


--系统级别的等待事件统计
SELECT event, total_waits, time_waited
FROM V$SYSTEM_EVENT
WHERE event NOT LIKE 'SQL*Net%';


/**
CPU 优化：避免复杂计算、函数嵌套、无谓排序
🎯 原因
- 函数调用会导致无法使用索引，增加 CPU 计算负担。
- 多层嵌套函数或表达式会增加解析与执行成本。
- 无谓排序（如未分页的 ORDER BY）会消耗排序区内存与 CPU。


*/

-- 不推荐 原因：使用函数嵌套
-- UPPER(name) 会导致索引失效，执行计划为 TABLE ACCESS FULL。
SELECT * FROM employees WHERE UPPER(name) = 'JOHN';
-- 推荐
-- 假设 name 字段已全部小写
SELECT * FROM employees WHERE name = 'john';
-- 使用函数索引
CREATE INDEX emp_name_upper_idx ON employees(UPPER(name));
SELECT * FROM employees WHERE UPPER(name) = 'JOHN';


--不推荐 
-- ❌ 不限量排序
SELECT * FROM orders ORDER BY order_date;

--推荐 
-- ✅ 限量分页
SELECT * FROM (
  SELECT * FROM orders ORDER BY order_date
) WHERE ROWNUM <= 100
;


/**
I/O 优化：减少全表扫描，优先使用索引访问
🎯 原因
- 全表扫描会读取整个表的数据块，增加磁盘 I/O。
- 索引访问可直接定位目标 ROWID，减少物理读。
✅ 优化示例
❌ 不推荐
SELECT * FROM orders WHERE customer_id = 100;
-- 若无索引，执行计划为 TABLE ACCESS FULL
**/
-- ✅ 推荐使用
-- 创建索引
CREATE INDEX orders_cust_idx ON orders(customer_id);
-- 查询自动使用 INDEX RANGE SCAN
SELECT * FROM orders WHERE customer_id = 100;


-- 查询条件包含多个列
SELECT * FROM orders WHERE customer_id = 100 AND order_status = 'SHIPPED';
-- 创建复合索引
CREATE INDEX orders_cust_status_idx ON orders(customer_id, order_status);



/***
内存优化：控制排序区、哈希区使用，避免溢出到磁盘
🎯 原因
- 排序或哈希操作超出内存限制会写入临时表空间，导致性能下降。
- 大量 GROUP BY、ORDER BY、JOIN 操作需谨慎控制数据量。
✅ 优化示例
❌ 不推荐
SELECT customer_id, COUNT(*) FROM orders GROUP BY customer_id;
-- 若 orders 表数据量巨大，GROUP BY 会消耗大量内存


**/
--✅ 推荐
-- 限制时间范围
SELECT customer_id, COUNT(*) 
FROM orders 
WHERE order_date >= SYSDATE - 30 
GROUP BY customer_id;


-- 创建索引以支持 ORDER BY
CREATE INDEX orders_date_idx ON orders(order_date);
-- 查询自动使用 INDEX FULL SCAN
SELECT * FROM orders ORDER BY order_date;




SELECT sql_id, sql_text FROM v$sql WHERE buffer_gets > 100000;
SELECT sql_id, sql_text FROM v$sql WHERE buffer_gets > 100000 AND ROWNUM <= 10;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY_CURSOR('sql_id', child_number));

--性能基准记录器 | 记录执行时间、逻辑读、物理读等指标
--*Captions 累计执行耗时（微秒）,逻辑读次数（访问内存中的数据块，值越大内存资源的消耗越大）,SQLID
SELECT SQL_TEXT,elapsed_time, buffer_gets ,sql_id FROM v$sql WHERE buffer_gets > 100000 AND ROWNUM <= 10 order by buffer_gets desc;


/***

| 问题类型 | 检测规则 | 改写建议 |
|----------|----------|----------|
| 函数导致索引失效 | WHERE 子句中包含函数 | 使用函数索引或改写为原始值 |
| IN vs EXISTS | IN 子句用于子查询 | 改为 EXISTS 提升可读性与性能 |
| UNION vs UNION ALL | 使用 UNION 且无重复数据需求 | 改为 UNION ALL 减少排序开销 |
| 隐式转换 | WHERE 中字段与常量类型不一致 | 显式转换或调整字段类型 |
| 全表扫描 | 无 WHERE 或无索引字段 | 添加过滤条件或创建索引 |
| 排序未限量 | ORDER BY 无 LIMIT 或 ROWNUM | 添加分页限制，避免内存溢出 |

---
**/



  SELECT
    f.code,
    c.industry,
    c.company_name,
    f.revenue,
    RANK() OVER (PARTITION BY c.industry ORDER BY f.revenue DESC) AS industry_rank
  FROM financial_summary f
  JOIN company_info c ON f.code = c.code
  WHERE f.fiscal_year BETWEEN 202401 AND 202412
;

--执行 SQL 并收集统计信息
EXPLAIN PLAN FOR SELECT 
f.code, f.revenue FROM financial_summary f WHERE EXISTS (SELECT 1 FROM company_info c WHERE f.code = c.code AND f.fiscal_year BETWEEN 202401 AND 202412);
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);


SELECT /*+ gather_plan_statistics */ f.code, f.revenue FROM financial_summary f WHERE EXISTS (SELECT 1 FROM company_info c WHERE f.code = c.code AND f.fiscal_year BETWEEN 202401 AND 202412);
--查询执行计划（需获取 SQL_ID）
SELECT * FROM TABLE (DBMS_XPLAN.DISPLAY_CURSOR(NULL, NULL, 'ALLSTATS LAST'));



--执行 SQL 并收集统计信息
EXPLAIN PLAN FOR SELECT /*+ gather_plan_statistics */ f.code, f.revenue FROM financial_summary f WHERE f.code IN (SELECT c.code FROM company_info c WHERE f.fiscal_year BETWEEN 202401 AND 202412);
--SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY);
--查询执行计划（需获取 SQL_ID）
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY_CURSOR(NULL, NULL, 'ALLSTATS LAST'));

--执行 SQL 并收集统计信息
SELECT /*+ gather_plan_statistics */
f.code, f.revenue FROM financial_summary f WHERE f.code IN (SELECT c.code FROM company_info c WHERE f.fiscal_year BETWEEN 202401 AND 202412);
--查询执行计划（需获取 SQL_ID）
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY_CURSOR(NULL, NULL, 'ALLSTATS LAST'));

SELECT /*+ gather_plan_statistics USE_NL(f c) INDEX(c IDX_COMPCODE) */ f.code, f.revenue FROM financial_summary f, company_info c WHERE f.code = c.code AND f.fiscal_year BETWEEN 202401 AND 202412;
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY_CURSOR(NULL, NULL, 'ALLSTATS LAST'));



--要查看真实执行计划（包括实际行数、I/O、CPU 等），请按以下步骤操作：
--🔁 步骤一：执行 SQL 并收集统计信息
SELECT /*+ gather_plan_statistics */ f.code, f.revenue FROM financial_summary f WHERE EXISTS (SELECT 1 FROM company_info c WHERE f.code = c.code AND f.fiscal_year BETWEEN 202401 AND 202412);
--🔁 步骤二：查询实际执行计划
SELECT * FROM TABLE(DBMS_XPLAN.DISPLAY_CURSOR(NULL, NULL, 'ALLSTATS LAST'));
-- 🧱 步骤三：索引管理（Index Management）
-- ### ✅ 目的  
-- 通过创建、删除、修改索引来影响优化器选择更优路径。
CREATE INDEX idx_financial_code_year ON financial_summary(code, fiscal_year);
CREATE INDEX idx_compcode ON company_info (code);
-- ####  步骤四. 查看索引是否被使用
-- 在执行计划中观察是否出现：
-- - `INDEX RANGE SCAN`  优化器成功利用索引进行范围过滤，效率最高。
-- - `INDEX SKIP SCAN`  - 查询条件中没有使用复合索引的第一列，但使用了后面的列时   --》- 如果你频繁查询非前导列，考虑重建复合索引，将常用列放在最前面
-- - `INDEX FAST FULL SCAN`  表示对整个表进行扫描
---- TABLE ACCESS FULL  无索引：使用 ，表示对整个表进行扫描，成本高。







--表中的索引查询 表名必须大写
SELECT index_name, table_name, tablespace_name, status FROM dba_indexes WHERE table_name = 'FINANCIAL_SUMMARY'
;
SELECT * FROM dba_indexes WHERE table_name = 'COMPANY_INFO'
;