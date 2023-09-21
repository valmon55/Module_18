using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        static string path = "D:\\Temp\\Module_18";
        static string file = "TestDownlaod.mpeg";
        //string s = Path.Combine(path, file);
        public CommandDownloadVideo(Receiver receiver, YoutubeClient youtubeClient)
        {
            this.receiver = receiver;
            this.youtubeClient = youtubeClient;
        }
        public override async void Execute(string url)
        {
            ValueTask video = new ValueTask();

            Console.WriteLine("Команда на скачивание видео");
            await (video = youtubeClient.Videos.DownloadAsync(url, Path.Combine(path, file), builder => builder.SetPreset(ConversionPreset.UltraFast)) );
            receiver.Operation($"Видео {file} скачано в каталог {path}.");
        }
    }
}
