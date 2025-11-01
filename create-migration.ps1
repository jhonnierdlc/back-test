# Script para crear migración inicial
Write-Host "Creando migración inicial..."

# Navegar al directorio del proyecto
Set-Location EmployeeApi

# Crear migración inicial
dotnet ef migrations add InitialCreate

# Volver al directorio raíz
Set-Location ..

Write-Host "Migración creada exitosamente"