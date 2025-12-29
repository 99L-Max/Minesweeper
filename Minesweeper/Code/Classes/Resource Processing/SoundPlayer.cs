using System.IO;

namespace Minesweeper
{
    class SoundPlayer
    {
        public bool IsPlaySounds { get; set; }

        public void Play(UnmanagedMemoryStream stream)
        {
            if (IsPlaySounds)
                new OneTimeSound(stream).Play();
        }
    }
}