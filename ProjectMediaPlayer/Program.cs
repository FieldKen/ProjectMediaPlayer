using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace ProjectMediaPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {


            WindowsMediaPlayer player = new WindowsMediaPlayer();
            string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            bool looping = true;
            while (looping)
            {
                Console.Clear();
                Console.WriteLine("===========");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("MEDIAPLAYER");
                Console.ResetColor();
                Console.WriteLine("===========");
                Console.Write("Now playing: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(player.URL);
                Console.ResetColor();
                Console.Write("Volume: ");
                ShowVolume(player.settings.volume);

                Console.WriteLine("1: Pauze / Play");
                Console.WriteLine("2: Change volume");
                Console.WriteLine("3: Mute / Unmute");
                Console.WriteLine("4: Change song");
                Console.WriteLine("5: Stop");
                Console.WriteLine("6: Exit");


                Console.Write("Input: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        player.controls.pause();
                        //play
                        break;

                    case "2":
                        Console.Write("Volume: ");
                        int volume = Convert.ToInt32(Console.ReadLine());
                        player.settings.volume = volume;
                        break;
                    case "3":
                        //player.settings.mute ^= true;

                        if (player.settings.mute)
                            player.settings.mute = false;
                        else
                            player.settings.mute = true;
                        break;
                    case "4":
                        player.URL = Path.Combine(musicFolder, GetSongMp3());
                        break;

                    case "5":
                        player.controls.stop();
                        break;

                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ongeldige input");
                        break;
                }
            }
            Console.WriteLine("Program finished");

            Console.ReadLine();
        }

        static string GetSongMp3()
        {
            Console.Write("Song: ");
            return Console.ReadLine() + ".mp3";
        }

        static void ShowVolume(int volume)
        {
            int aantalBalkjes = volume / 5;

            Console.Write("[");
            for (int i = 0; i < 20; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (i < aantalBalkjes)
                    Console.Write("|");
                else
                    Console.Write(" ");
            }
            Console.ResetColor();
            Console.WriteLine("]");
        }
    }
}
