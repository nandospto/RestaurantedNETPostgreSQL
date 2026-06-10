$baseUrl = "http://localhost:5105"

function Invoke-Api {
    param(
        [string]$Method,
        [string]$Path,
        [string]$Body = $null,
        [string]$ContentType = "application/json"
    )

    $headers = @{ }
    if ($Body) {
        $headers["Content-Type"] = $ContentType
    }

    try {
        if ($Body) {
            return Invoke-RestMethod -Method $Method -Uri "$baseUrl$Path" -Headers $headers -Body $Body
        }

        return Invoke-RestMethod -Method $Method -Uri "$baseUrl$Path" -Headers $headers
    }
    catch {
        Write-Host "Erro em $Method $Path"
        Write-Host $_.Exception.Message
    }
}

Write-Host "== GET /clientes =="
Invoke-Api -Method Get -Path "/clientes"

Write-Host ""
Write-Host "== POST /clientes =="
Invoke-Api -Method Post -Path "/clientes" -Body '{"nome":"Cliente teste automation","telefone":"123456","email":"automation@email.com"}'

Write-Host ""
Write-Host "== GET /itensmenu =="
Invoke-Api -Method Get -Path "/itensmenu"

Write-Host ""
Write-Host "== GET /pedidos =="
Invoke-Api -Method Get -Path "/pedidos"
