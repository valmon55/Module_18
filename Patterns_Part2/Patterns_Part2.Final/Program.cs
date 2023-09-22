using System.Text.RegularExpressions;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace Patterns_Part2.Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите ссылку на Youtube-видео:");
            string? url = "https://www.youtube.com/watch?v=pF48yXghmkk";
                          //"https://www.youtube.com/shorts/uGwkUA56qa4"; 
                //"uGwkUA56qa4";
                //"https://www.youtube.com/shorts/v5ynfbAYW3w";// Console.ReadLine();

            YoutubeClient youtubeClient = new YoutubeClient();
            VideoId? videoId= new VideoId();

            videoId = VideoId.TryParse(url);

            if (videoId == null) 
            {
                ///Проверяем
                ///может это YouTube Shorts 
                ///т.к. TryParse не находит его

                videoId = Regex.Match(url, "youtube\\..+?\\/shorts\\/(.*?)(?:\\?|&|\\/|$)").Groups[1].Value;
                //if (url.StartsWith(@"https://www.youtube.com/shorts/"))
                //    videoId = url.Substring(@"https://www.youtube.com/shorts/".Length);
                if (!string.IsNullOrWhiteSpace(videoId))
                    goto VideoExists;

                Console.WriteLine("Видео не найдено.");
                return;
            }
VideoExists:

            var sender = new Sender();
            
            var receiver = new Receiver();
            
            //var videoInfo = new CommandVideoInfo(receiver, youtubeClient);
            //sender.SetCommand(videoInfo);
            //sender.Execute(videoId);

            var downloadVideo = new CommandDownloadVideo(receiver, youtubeClient);
            sender.SetCommand(downloadVideo);
            sender.Execute(videoId);  

            //Console.WriteLine("Название видео и описание:");
            //Console.WriteLine("Скачиваем видео.");
            Console.ReadKey();
        }
    }
}