# 🥐 Flancita – Sistema de Panadería (CRUD con API REST y MVC)

Proyecto desarrollado como **Evaluación Aplicativa**, implementando una arquitectura moderna basada en **API REST**, **Entity Framework Core** y **ASP.NET Core MVC**, aplicando buenas prácticas de desarrollo.

---

## 📌 Descripción del Proyecto

**Flancita** es un sistema de gestión para una panadería artesanal que permite administrar productos mediante un CRUD completo (Crear, Listar, Editar y Eliminar).

El sistema está dividido en dos aplicaciones:

- **API REST**: maneja la lógica de negocio y el acceso a datos.
- **Aplicación Web MVC**: consume la API y muestra la información al usuario.

---

## 🏗️ Arquitectura del Sistema

El proyecto está organizado en una arquitectura por capas:

- **API REST (ASP.NET Core)**
  - Controladores REST
  - Patrón Repositorio
  - DTOs
  - AutoMapper
  - Entity Framework Core
  - SQL Server

- **Aplicación Web MVC**
  - Controladores MVC
  - Vistas Razor
  - Consumo de la API mediante `HttpClient`

---

## 🛠️ Tecnologías Utilizadas

- C#
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- AutoMapper
- ASP.NET Core MVC
- HttpClient
- Git y GitHub
- Docker (básico)

---

## 🗂️ Estructura del Proyecto

Flancita/
│
├── Panaderia.Api
│ ├── Controllers
│ ├── Data
│ ├── DTOs
│ ├── Models
│ ├── Profiles
│ ├── Repositories
│ └── Program.cs
│
├── Panaderia.Mvc
│ ├── Controllers
│ ├── Models
│ ├── Views
│ ├── wwwroot
│ └── Program.cs
│
└── Dockerfile

---

## 🗄️ Base de Datos

- **Motor:** SQL Server
- **ORM:** Entity Framework Core
- **Migraciones:** habilitadas mediante `Add-Migration` y `Update-Database`

Ejemplo de entidad principal:
- Producto (Nombre, Precio, Stock)

---

## 🔄 Funcionalidades Implementadas

✔ Listar productos  
✔ Registrar productos  
✔ Editar productos  
✔ Eliminar productos  
✔ Consumo de API REST desde MVC  
✔ Separación de responsabilidades  

---

## ▶️ Ejecución del Proyecto

### 1️⃣ Ejecutar la API
- Iniciar el proyecto `Panaderia.Api`
- Acceder a Swagger:
https://localhost:7041/swagger

### 2️⃣ Ejecutar el MVC
- Iniciar el proyecto `Panaderia.Mvc`
- Acceder a:
https://localhost:7296/Productos

---

## 🐳 Docker

Se incluye un `Dockerfile` básico para la API REST, permitiendo su empaquetado y despliegue en contenedores.

---
