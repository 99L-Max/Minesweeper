using NAudio.Wave;
using System;
using System.IO;

namespace Minesweeper
{
    static class Sound
    {
        public static bool IsPlaySounds;

        public static void Play(UnmanagedMemoryStream stream)
        {
            if (IsPlaySounds)
            {
                var reader = new WaveFileReader(stream);
                var waveOut = new WaveOut();
        
                waveOut.PlaybackStopped += Dispose;
                waveOut.Init(reader);
                waveOut.Play();
        
                void Dispose(object sender, EventArgs e)
                {
                    waveOut.Dispose();
                    reader.Dispose();
                    stream.Dispose();
        
                    waveOut.PlaybackStopped -= Dispose;
                }
            }
        }
    }
}