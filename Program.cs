using System;

namespace TpMod6_103022300147
{
    class SayTubeVideo
    {
        private string title;
        private int viewCount;

        public SayTubeVideo(string t)
        {
            if (string.IsNullOrEmpty(t))
            {
                throw new ArgumentException("Judul video tidak boleh kosong!");
            }
            if (t.Length > 100)
            {
                throw new ArgumentException("Judul video maksimal 100 karakter!");
            }
            title = t;
            viewCount = 0;
        }

        public void IncreasePlayCount(int n, Action printVideoDetails)
        {
            if (n > 10_000_000)
            {
                throw new OverflowException("Penambahan playCount maksimal 10.000.000!");
            }
            if (n < 0)
            {
                throw new ArgumentException("Penambahan playCount tidak boleh negatif!");
            }
            if (viewCount > int.MaxValue - n)
            {
                throw new OverflowException("PlayCount melebihi batas maksimal integer!");
            }

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
            try
            {
                SayTubeVideo video = new SayTubeVideo("Belajar C# Dasar");
                video.PrintVideoDetails();
                video.IncreasePlayCount(100, video.PrintVideoDetails);

                //SayTubeVideo video2 = new SayTubeVideo("");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Terjadi kesalahan tidak terduga! {ex.Message}");
            }
        }
    }
}