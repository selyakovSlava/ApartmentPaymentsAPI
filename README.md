# Проект REST API

* Проект для регистрации ежемесячных платежей
* Разработка API для работы с MS SQL
* Консольное приложение для работы с API
* APModelsLibrary - библиотека моделей

## Сведения о проекте

* .NET 8.0 
* REST API
* MS SQL
* Entity Framework

## Пакеты для установки

* `Install-Package Microsoft.EntityFrameworkCore`
* `Install-Package Microsoft.EntityFrameworkCore.SqlServer`
* `Install-Package Microsoft.EntityFrameworkCore.Tools`
* `Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design`

## Создание бд перед запуском

* `Add-Migration CreateDB`
* `Update-Database`

## Реализованные API
* GET: api/payments
* GET: api/payments/5
* POST: api/payments
* PUT: api/payments
* DELETE: api/payments/5