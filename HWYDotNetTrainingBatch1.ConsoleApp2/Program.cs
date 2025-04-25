// See https://aka.ms/new-console-template for more information
using HWYDotNetTrainingBatch1.ConsoleApp2;

Console.WriteLine("Hello, World!");

HomeworkService service = new HomeworkService();
service.Read();
service.Detail(1);