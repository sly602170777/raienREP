@echo off
REM 1. 设置工作目录为脚本所在路径
pushd %~dp0

REM 2. 设置字符集（修复乱码）
chcp 65001 > nul

REM 3. 调用 SQL*Plus 执行 SQL 脚本
sqlplus -L /nolog @"%~dp0your_sql_script.sql"

REM 4. 检查 SQL*Plus 执行结果
if %errorlevel% neq 0 (
    echo [ERROR] SQL 执行失败，错误码: %errorlevel%
) else (
    echo [SUCCESS] SQL 执行成功
)

REM 5. 恢复原始目录
popd
pause