using AngleSharp.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace Patterns_Part2.Final
{
    public class CommandVideoInfo : Command
    {
        Receiver receiver;
        YoutubeClient youtubeClient;
        
        public CommandVideoInfo(Receiver receiver, YoutubeClient youtubeClient) 
        { 
            this.receiver = receiver;
            this.youtubeClient = youtubeClient;
        }
        public override void Execute(string url)
        {
            ValueTask<Video> video = new ValueTask<Video>();
            Console.WriteLine("Команда на получении информации о видео");
            video = youtubeClient.Videos.GetAsync(url);
            Console.Write(
                video.Result.Author.Title + Environment.NewLine +   
                video.Result.Title + Environment.NewLine +
                video.Result.Description + Environment.NewLine +
                video.Result.Duration.ToString() + Environment.NewLine
                );
            receiver.Operation();
        }
    }
}
