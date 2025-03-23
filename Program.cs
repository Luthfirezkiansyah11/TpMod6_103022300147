using System;

namespace TpMod6_103022300147
{
    class SayTubeVideo
    {
        private string title;
        private int viewCount;

        public SayTubeVideo(string t)
        {
            title = t;
            viewCount = 0;
        }

        public void IncreasePlayCount(int n, Action printVideoDetails)
        {
            viewCount += n;
            printVideoDetails();
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Play Count: {viewCount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SayTubeVideo video = new SayTubeVideo("Belajar C# Dasar");
            video.PrintVideoDetails();
            video.IncreasePlayCount(100, video.PrintVideoDetails);
        }
    }
}