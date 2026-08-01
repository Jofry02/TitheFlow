# TitheFlow - Gestor de Diezmos y Mayordomía

Plataforma sencilla e intuitiva para registrar ingresos (fijos, variables, extraordinarios) y calcular
automáticamente el diezmo (10%) y otros aportes opcionales, manteniendo un historial claro de cálculos.

## Stack

- **Framework:** ASP.NET Core MVC (.NET 8)
- **Persistencia:** Datos en memoria (servicios con `List<T>`)
- **Interfaz:** Razor Views + Bootstrap 5

## Funcionalidades (CRUD)

- **Create:** Registrar un nuevo ingreso (monto, fecha, fuente/categoría, descripción) y calcular la
  asignación del diezmo sugerida.
- **Read:** Visualizar la lista de ingresos con su diezmo calculado, y resumen mensual/acumulado
  (Total Ingresos vs. Total Diezmo calculado/entregado).
- **Update:** Editar un ingreso y recalcular automáticamente el diezmo.
- **Delete:** Eliminar un registro de ingreso/diezmo.

## Estructura del proyecto

```
Controllers/    Controladores MVC (Incomes, Tithes, Dashboard, Reports)
Domain/         Entidades (Income, TitheRecord) y configuración (TitheSettings)
Services/       Lógica de negocio (servicios con datos en memoria)
Views/          Vistas Razor
Models/         ViewModels
```

## Ejecución

```bash
dotnet restore
dotnet run
```

La aplicación estará disponible en `http://localhost:5xxx` (ver `Properties/launchSettings.json`).

## Flujo Git Flow

El repositorio sigue la metodología **Git Flow**:

| Rama | Propósito |
|------|-----------|
| `main` | Producción (integración final de todos los cambios) |
| `qa` | Aseguramiento de calidad / pruebas |
| `dev` | Integración de desarrollo |
| `feature/*` | Funcionalidades nuevas |
| `hotfix/*` | Correcciones urgentes |

### Ramas del proyecto

- `feature/income-management` -> CRUD base para registrar y listar ingresos.
- `feature/tithe-calculator` -> Lógica matemática para calcular el diezmo (10%), con soporte para
  configurar si el diezmo es sobre el monto bruto o neto.
- `feature/summary-dashboard` -> Vista de resúmenes mensuales e indicadores clave.
- `feature/export-reports` -> Exportación de reportes y consulta del historial por rango de fechas.
- `hotfix/fix-decimal-precision` -> Corrección del redondeo de centavos en el cálculo del diezmo.

Cada rama se integra mediante **Pull Requests** hacia `dev`, `qa` y `main`, de modo que al final del
flujo todos los cambios quedan integrados en `main`.
