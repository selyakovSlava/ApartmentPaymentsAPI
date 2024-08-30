# Проект REST API

* Проект для регистрации ежемесячных платежей
* **ApartmentPaymentsAPI** - API для работы с MS SQL
* **APModelsLibrary** - библиотека моделей, реализация CRUD операций с API
* **ConsoleTestAPI** - консольное приложение для работы с API (CRUD операции)
* **PaymentsWeb** - приложение ASP.NET Core MVC для работы с REST API
* **ConsoleRabbitMQ** - консольное приложение для чтения сообщений из RabbitMQ и отправки сообщений в Telegram

## Сведения о проекте

* .NET 8.0 
* REST API
* MS SQL
* Entity Framework
* RabbitMQ
* Telegram.Bot

### Порядок сборки
1. APModelsLibrary
2. ApartmentPaymentsAPI
3. ConsoleRabbitMQ
4. Далее без разницы: ConsoleTestAPI или PaymentsWeb

### Порядок запуска
1. ApartmentPaymentsAPI
2. ConsoleRabbitMQ
4. Далее можно запустить один из клиентов: PaymentsWeb или ConsoleTestAPI

## Пакеты для установки
* `Install-Package Microsoft.EntityFrameworkCore`
* `Install-Package Microsoft.EntityFrameworkCore.SqlServer`
* `Install-Package Microsoft.EntityFrameworkCore.Tools`
* `Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design`

## Создание бд перед запуском
* `Add-Migration CreateDB`
* `Update-Database`

## Реализованные API
* **GET**: api/payments
* **GET**: api/payments/5
* **POST**: api/payments
* **PUT**: api/payments/5
* **DELETE**: api/payments/5

## Полезные ссылки для работы с API
* `https://jasonwatmore.com/c-restsharp-http-put-request-examples-in-net`
* `https://devhops.ru/code/dotnet/rest/`
* `https://code-maze.com/httpclient-example-aspnet-core-post-put-delete/`

## Полезные ссылки для работы с графиками
* `https://www.c-sharpcorner.com/article/creating-charts-with-asp-net-core-mvc-using-google-chart-api-part-two/`

## Полезные ссылки для работы с RabbitMQ
* `https://www.c-sharpcorner.com/article/rabbitmq-message-queue-using-net-core-6-web-api/`

## Установка и запуск RabbitMQ
* `docker pull rabbitmq:3-management`
* `docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management`
* RabbitMQ будет доступен по адресу http://localhost:15672/

## Установка Telegram.Bot
* `Install-Package Telegram.Bot`

