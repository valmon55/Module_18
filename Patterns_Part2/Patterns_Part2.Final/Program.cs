using YoutubeExplode;

namespace Patterns_Part2.Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите ссылку на Youtube-видео:");
            string? url = "https://www.youtube.com/watch?v=pF48yXghmkk";
                //"https://www.youtube.com/shorts/uGwkUA56qa4"; 
                //"https://www.youtube.com/shorts/v5ynfbAYW3w";// Console.ReadLine();

            YoutubeClient youtubeClient = new YoutubeClient();
            
            var sender = new Sender();
            
            var receiver = new Receiver();
            
            var videoInfo = new CommandVideoInfo(receiver, youtubeClient);
            sender.SetCommand(videoInfo);
            sender.Execute(url);

            var downloadVideo = new CommandDownloadVideo(receiver, youtubeClient);
            sender.SetCommand(downloadVideo);
            sender.Execute(url);  

            //Console.WriteLine("Название видео и описание:");
            //Console.WriteLine("Скачиваем видео.");
            Console.ReadKey();
        }
    }
}