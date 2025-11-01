# Employee API

Una API REST desarrollada en .NET 9 para la gestión de empleados, utilizando Entity Framework Core con SQLite como base de datos.

## 📋 Descripción

Esta API proporciona operaciones CRUD (Create, Read, Update, Delete) para gestionar información de empleados. Incluye documentación automática con Swagger UI y está containerizada con Docker para facilitar el despliegue.

## 🚀 Características

- **API REST completa** con operaciones CRUD
- **Entity Framework Core** con SQLite
- **Documentación automática** con Swagger/OpenAPI
- **Containerización** con Docker
- **.NET 9** con las últimas características
- **Arquitectura limpia** y escalable

## 📊 Modelo de Datos

### Employee
```csharp
public class Employee
{
    public int Id { get; set; }           // ID único del empleado
    public string Name { get; set; }      // Nombre del empleado (requerido)
    public string? Position { get; set; } // Posición/Cargo (opcional)
    public double? Salary { get; set; }   // Salario (opcional)
}
```

## 🛠️ Endpoints de la API

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/Employees/{id}` | Obtener empleado por ID |
| `POST` | `/Employees` | Crear nuevo empleado |
| `PUT` | `/Employees/{id}` | Actualizar empleado existente |
| `DELETE` | `/Employees/{id}` | Eliminar empleado |

### Ejemplos de uso

#### Crear empleado
```bash
POST /Employees
Content-Type: application/json

{
  "name": "Juan Pérez",
  "position": "Desarrollador Senior",
  "salary": 75000
}
```

#### Obtener empleado
```bash
GET /Employees/1
```

#### Actualizar empleado
```bash
PUT /Employees/1
Content-Type: application/json

{
  "id": 1,
  "name": "Juan Pérez",
  "position": "Tech Lead",
  "salary": 85000
}
```

#### Eliminar empleado
```bash
DELETE /Employees/1
```

## 📋 Prerrequisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://www.docker.com/get-started) (opcional, para containerización)

## 🔧 Instalación

### 1. Clonar el repositorio
```bash
git clone <url-del-repositorio>
cd EmployeeApi
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Crear la base de datos
```bash
dotnet ef database update
```

## 🏗️ Compilación

### Compilación en modo Debug
```bash
dotnet build
```

### Compilación en modo Release
```bash
dotnet build --configuration Release
```

### Verificar compilación
```bash
dotnet build --verbosity normal
```

## ▶️ Ejecución

### Ejecución en desarrollo
```bash
dotnet run
```

### Ejecución con configuración específica
```bash
dotnet run --environment Development
```

### Ejecución en modo Release
```bash
dotnet run --configuration Release
```

La aplicación estará disponible en:
- **HTTP**: http://localhost:5000
- **HTTPS**: https://localhost:5001
- **Swagger UI**: http://localhost:5000/swagger

## 🐳 Ejecución con Docker

### Opción 1: Docker Build y Run

#### Construir la imagen
```bash
docker build -t employeeapi .
```

#### Ejecutar el contenedor
```bash
docker run -d \
  --name employeeapi-container \
  -p 5000:8080 \
  -p 5001:8081 \
  -v $(pwd)/data:/app/data \
  employeeapi
```

### Opción 2: Docker Compose (Recomendado)

#### Ejecutar con docker-compose
```bash
# Construir y ejecutar
docker-compose up --build

# Ejecutar en segundo plano
docker-compose up -d --build

# Ver logs
docker-compose logs -f

# Detener servicios
docker-compose down
```

### Acceso a la aplicación containerizada
- **HTTP**: http://localhost:5000
- **HTTPS**: https://localhost:5001
- **Swagger UI**: http://localhost:5000/swagger

### Comandos útiles de Docker

```bash
# Ver contenedores en ejecución
docker ps

# Ver logs del contenedor
docker logs employeeapi-container

# Acceder al contenedor
docker exec -it employeeapi-container /bin/bash

# Detener el contenedor
docker stop employeeapi-container

# Eliminar el contenedor
docker rm employeeapi-container

# Eliminar la imagen
docker rmi employeeapi
```

## 🗂️ Estructura del Proyecto

```
EmployeeApi/
├── Employee.cs              # Modelo de datos
├── EmployeesController.cs   # Controlador de la API
├── AppDbContext.cs          # Contexto de Entity Framework
├── Program.cs               # Punto de entrada de la aplicación
├── EmployeeApi.csproj       # Archivo de proyecto
├── appsettings.json         # Configuración de la aplicación
├── Dockerfile               # Configuración de Docker
├── docker-compose.yml       # Orquestación con Docker Compose
├── .dockerignore           # Archivos ignorados por Docker
├── .gitignore              # Archivos ignorados por Git
└── README.md               # Documentación del proyecto
```

## 🔧 Configuración

### Base de datos
La aplicación utiliza SQLite por defecto. La cadena de conexión se encuentra en `AppDbContext.cs`:

```csharp
optionsBuilder.UseSqlite("Data Source=employees.db");
```

### Variables de entorno
Puedes configurar las siguientes variables de entorno:

- `ASPNETCORE_ENVIRONMENT`: Entorno de ejecución (Development, Production)
- `ASPNETCORE_URLS`: URLs de escucha de la aplicación

## 🧪 Pruebas

### Ejecutar pruebas unitarias
```bash
dotnet test
```

### Ejecutar con cobertura
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## 📝 Desarrollo

### Agregar migración
```bash
dotnet ef migrations add NombreDeLaMigracion
```

### Actualizar base de datos
```bash
dotnet ef database update
```

### Generar script SQL
```bash
dotnet ef migrations script
```

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 👥 Autores

- **Tu Nombre** - *Desarrollo inicial* - [TuGitHub](https://github.com/tuusuario)

## 🙏 Agradecimientos

- Equipo de .NET por las excelentes herramientas
- Comunidad de desarrolladores por las mejores prácticas
- Contribuidores del proyecto

---

## 📞 Soporte

Si tienes alguna pregunta o problema, por favor:

1. Revisa la documentación
2. Busca en los issues existentes
3. Crea un nuevo issue si es necesario

**¡Gracias por usar Employee API!** 🚀