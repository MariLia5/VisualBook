using System;
using System.IO;
using System.Windows.Forms;
using WMPLib;

namespace VisualBook
{
    public class MusicPlayer : IDisposable
    {
        private WindowsMediaPlayer wmp;
        private string currentMusicPath;
        private bool isPlaying;

        public MusicPlayer()
        {
            wmp = new WindowsMediaPlayer();
            wmp.settings.volume = 50;
            wmp.settings.setMode("loop", true); // Зацикливание
            isPlaying = false;

            wmp.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
        }

        private void Player_PlayStateChange(int NewState)
        {
            if (NewState == (int)WMPPlayState.wmppsMediaEnded && isPlaying)
            {
                wmp.controls.play();
            }
        }

        public void PlayMusic(string musicPath)
        {
            try
            {
                if (!File.Exists(musicPath))
                {
                    MessageBox.Show($"Музыкальный файл не найден: {musicPath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isPlaying && currentMusicPath == musicPath)
                    return;

                currentMusicPath = musicPath;
                wmp.URL = musicPath;
                wmp.controls.play();
                isPlaying = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка воспроизведения музыки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void StopMusic()
        {
            if (isPlaying)
            {
                wmp.controls.stop();
                isPlaying = false;
            }
        }

        public void PauseMusic()
        {
            if (isPlaying)
            {
                wmp.controls.pause();
                isPlaying = false;
            }
        }

        public void ResumeMusic()
        {
            if (!isPlaying && !string.IsNullOrEmpty(currentMusicPath))
            {
                wmp.controls.play();
                isPlaying = true;
            }
        }

        public void SetVolume(int volume)
        {
            wmp.settings.volume = Math.Max(0, Math.Min(100, volume));
        }

        public bool IsPlaying
        {
            get { return isPlaying; }
        }

        public void Dispose()
        {
            StopMusic();
            wmp?.close();
        }
    }
}