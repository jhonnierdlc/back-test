# Script para aplicar migraciones a la base de datos
Write-Host "Aplicando migraciones a la base de datos..."

# Navegar al directorio del proyecto
Set-Location EmployeeApi

# Aplicar migraciones
dotnet ef database update

# Volver al directorio raíz
Set-Location ..

Write-Host "Base de datos actualizada exitosamente"