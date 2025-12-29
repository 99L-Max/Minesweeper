using NAudio.Wave;
using System.IO;

namespace Minesweeper
{
    class OneTimeSound
    {
        private readonly UnmanagedMemoryStream _stream;
        private readonly WaveFileReader _reader;
        private readonly WaveOut _waveOut;

        public OneTimeSound(UnmanagedMemoryStream stream)
        {
            _stream = stream;
            _reader = new WaveFileReader(stream);
            _waveOut = new WaveOut();
            _waveOut.PlaybackStopped += OnWaveOutPlaybackStopped;
            _waveOut.Init(_reader);
        }

        public void Play()
        {
            _waveOut?.Play();
        }

        private void OnWaveOutPlaybackStopped(object sender, StoppedEventArgs e)
        {
            _waveOut.PlaybackStopped -= OnWaveOutPlaybackStopped;
            _waveOut.Dispose();
            _reader.Dispose();
            _stream.Dispose();
        }
    }
}
