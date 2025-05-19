// See https://aka.ms/new-console-template for more information
using HWYDotNetTrainingBatch1.ConsoleApp2;

Console.WriteLine("Hello, World!");

//HomeworkService service = new HomeworkService();
//service.Read();
//service.Detail(1);
//service.Create();
//service.Read();
//service.Delete();
//service.Read();



//LoginDapperService serviceD = new LoginDapperService();
//serviceD.Read();

HomeworkService _dataUpload = new HomeworkService();
//_dataUpload.UploadBlogHeaderFromJson();
_dataUpload.UploadBlogDetailFromJson();

Console.ReadLine();