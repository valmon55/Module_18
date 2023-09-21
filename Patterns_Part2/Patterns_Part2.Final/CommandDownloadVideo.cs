using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

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
            Console.WriteLine("Команда на скачивание видео");
            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync("https://www.youtube.com/watch?v=pF48yXghmkk");
            //var streamVideo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            //await youtubeClient.Videos.Streams.DownloadAsync(streamVideo, "video.mp4");
                

            //await youtubeClient.Videos.DownloadAsync(url, Path.Combine(path, file), builder => builder.SetPreset(ConversionPreset.UltraFast));

            receiver.Operation($"Видео {file} скачано в каталог {path}.");
        }
    }
}
