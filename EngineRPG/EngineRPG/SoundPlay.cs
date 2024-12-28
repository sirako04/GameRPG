using System;
using NAudio.Wave;
using System.Threading.Tasks;

namespace EngineRPG
{
    public static class SoundPlay
    {
        private static bool isPlaying = false;

        public static async Task PlayingMusic(string filePath)
        {
            try
            {
               
                // Sound asynchron abspielen
                await PlaySoundAsync(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static async Task PlaySoundAsync(string filePath)
        {
           

            if (isPlaying)
            {
                Console.WriteLine("Sound is already playing. Please wait.");
                return; // Abbrechen, wenn Sound schon läuft
            }

            isPlaying = true; // Wiedergabe starten

            try
            {
                while (isPlaying)
                {
                    using (var audioFile = new AudioFileReader(filePath))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);

                        Console.WriteLine("Playing sound...");
                        outputDevice.Play();
                        // Überwache die Wiedergabe
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            await Task.Delay(100);
                        }

                        Console.WriteLine("Sound finished.");

                        
                    }
                    if (!isPlaying)
                    {
                        break;
                    }
                }
                Console.WriteLine("Sound loop stopped.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        } 
            private static void StopSound()
            {
                
                isPlaying = false;
            }
    }
}
    

