# Oracle TNS 設定の診断
Write-Host "=== Oracle TNS 設定診断開始 ===`n"

# 1. TNS_ADMIN 環境変数を確認
$tnsAdmin = [System.Environment]::GetEnvironmentVariable("TNS_ADMIN","Machine")
if (-not $tnsAdmin) {
    Write-Host "[警告] TNS_ADMIN 環境変数が設定されていません。既定値として %ORACLE_HOME%\network\admin を使用します"
    $oracleHome = [System.Environment]::GetEnvironmentVariable("ORACLE_HOME","Machine")
    if ($oracleHome) {
        $tnsAdmin = Join-Path $oracleHome "network\admin"
    } else {
        Write-Host "[エラー] ORACLE_HOME が見つかりません。tnsnames.ora を特定できません"
        exit
    }
} else {
    Write-Host "[情報] TNS_ADMIN = $tnsAdmin"
}

# 2. tnsnames.ora ファイルの存在を確認
$tnsFile = Join-Path $tnsAdmin "tnsnames.ora"
if (Test-Path $tnsFile) {
    Write-Host "[情報] tnsnames.ora ファイルを発見: $tnsFile"
} else {
    Write-Host "[エラー] tnsnames.ora ファイルが見つかりません。パスが正しいか確認してください"
    exit
}

# 3. ORCL エイリアスの存在を確認
$tnsContent = Get-Content $tnsFile
if ($tnsContent -match "^\s*ORCL\s*=") {
    Write-Host "[情報] tnsnames.ora 内に ORCL エイリアスを確認しました"
} else {
    Write-Host "[エラー] tnsnames.ora 内に ORCL エイリアスが存在しません。設定を確認してください"
}

# 4. 次のステップを案内
Write-Host "`n=== 次の推奨ステップ ==="
Write-Host "1. tnsping ORCL を使用してエイリアス解決をテスト"
Write-Host "2. sqlplus scott/tiger@ORCL を使用して接続をテスト"
Write-Host "3. それでも失敗する場合、sqlnet.ora 内の NAMES.DIRECTORY_PATH に TNSNAMES が含まれているか確認"
Write-Host "=== 診断終了 ==="