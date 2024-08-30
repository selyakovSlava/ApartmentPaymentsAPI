
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

string _token = "YOUR_TELEGRAM_BOT_TOKEN_HERE";
TelegramBotClient _botClient = new TelegramBotClient(_token);
ChatId _chatId = new ChatId(0); // Установить id Вашего чата в Telegram.


Console.WriteLine("**********************************");
Console.WriteLine("*                                *");
Console.WriteLine("* Получение сообщений с RabbitMQ *");
Console.WriteLine("*                                *");
Console.WriteLine("**********************************");


var me = _botClient.GetMeAsync().Result;
Console.WriteLine($"Bot id: {me.Id}, Bot Name: {me.FirstName}");




var factory = new ConnectionFactory
{
    HostName = "localhost"
};

var connection = factory.CreateConnection();

using
var channel = connection.CreateModel();

channel.QueueDeclare("period", exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) => {
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Получено сообщение из очереди 'period': {message}");

    _botClient.SendTextMessageAsync(_chatId, message.ToString());
};

// Чтение сообщения.
channel.BasicConsume(queue: "period", autoAck: true, consumer: consumer);


Console.ReadLine();
