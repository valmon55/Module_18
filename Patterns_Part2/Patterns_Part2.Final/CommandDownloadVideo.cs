using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;

namespace Patterns_Part2.Final
{
    public class CommandDownloadVideo : Command
    {
        Receiver receiver;
        YoutubeClient youtubeClient;
        public CommandDownloadVideo(Receiver receiver, YoutubeClient youtubeClient)
        {
            this.receiver = receiver;
            this.youtubeClient = youtubeClient;
        }
        public override async void Execute(string url)
        {
            Console.WriteLine("Команда на скачивание видео");
            await youtubeClient.Videos.DownloadAsync(url, "D:\\",builder => builder.SetPreset(ConversionPreset.UltraFast));
            receiver.Operation();
        }
    }
}
