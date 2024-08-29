# Проект REST API

* Проект для регистрации ежемесячных платежей
* Разработка API для работы с MS SQL
* ConsoleTestAPI - Консольное приложение для работы с API (CRUD операции)
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
* PUT: api/payments/5
* DELETE: api/payments/5

## Полезные ссылки для работы с API
* `https://jasonwatmore.com/c-restsharp-http-put-request-examples-in-net`
* `https://devhops.ru/code/dotnet/rest/`
* `https://code-maze.com/httpclient-example-aspnet-core-post-put-delete/`