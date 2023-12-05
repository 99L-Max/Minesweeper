using NAudio.Wave;
using System.IO;

namespace Minesweeper
{
    static class Sound
    {
        public static bool IsPlaySounds;

        public static void Play(UnmanagedMemoryStream sound)
        {
            if (IsPlaySounds)
            {
                WaveFileReader stream = new WaveFileReader(sound);
                WaveOut waveOut = new WaveOut();
                waveOut.PlaybackStopped += (s, e) => { waveOut.Dispose(); stream.Dispose(); };
                waveOut.Init(stream);
                waveOut.Play();
            }
        }
    }
}