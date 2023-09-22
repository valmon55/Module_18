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

        public CommandDownloadVideo(Receiver receiver, YoutubeClient youtubeClient)
        {
            this.receiver = receiver;
            this.youtubeClient = youtubeClient;
        }
        public override async void Execute(string VideoId)
        {
            Console.WriteLine("Cкачивание видео...");
            try
            {
                var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(VideoId);
                var streamVideo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();
                if( streamVideo == null) 
                {
                    Console.WriteLine("The video has no steams!");
                }
                var file = $"{VideoId}.{streamVideo.Container.Name}";

                await youtubeClient.Videos.Streams.DownloadAsync(streamVideo, file);

                receiver.Operation($"Видео {file} скачано.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());    
            }
        }
    }
}
