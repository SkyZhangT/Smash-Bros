using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sounds
{
    static class SoundManager
    {
        private static Dictionary<String, SoundEffect> SoundSet;
        public static SoundEffectInstance backGroundMusic;
        public static bool MusicPlaying = false;
        private static List<SoundEffectInstance> Sounds= new List<SoundEffectInstance>();
        public static bool PlayedOnce = false;

        public static void Load(Dictionary<String, SoundEffect> loadedSounds)
        {
            SoundSet = loadedSounds;
        }

        public static void PlaySound(String soundName)
        {
            if (SoundSet.ContainsKey(soundName))
            {
                SoundEffectInstance soundInstance = SoundSet[soundName].CreateInstance();
                Sounds.Add(soundInstance);
                soundInstance.Play();
            }
        }
        public static void EndAllSound()
        {

            foreach (SoundEffectInstance s in Sounds)
            {
                s.Stop();
            }
            backGroundMusic.Stop();
        }

        public static void PauseAllSound()
        {
            foreach (SoundEffectInstance s in Sounds){
                if (s.State == SoundState.Playing)
                {
                    s.Pause();
                }
            }
            List<SoundEffectInstance> finishedSounds = new List<SoundEffectInstance>();
            foreach (SoundEffectInstance s in Sounds)
            {
                if (s.State == SoundState.Stopped)
                {
                    finishedSounds.Add(s);
                }
            }
            Sounds = Sounds.Except(finishedSounds).ToList();
            backGroundMusic.Pause();


        }

        public static void ResumeAllSound()
        {

            foreach (SoundEffectInstance s in Sounds)
            {
                if (s.State == SoundState.Paused)
                {
                    s.Resume();
                }
            }
            backGroundMusic.Resume();
        }



        public static void PlaySoundContinuous(String soundName)
        {
            if (SoundSet != null)
            {
                if (SoundSet.ContainsKey(soundName))
                {
                    SoundManager.backGroundMusic = SoundSet[soundName].CreateInstance();
                    SoundManager.backGroundMusic.IsLooped = true;
                    SoundManager.backGroundMusic.Play();
                }
                SoundManager.MusicPlaying = true;
            }

        }

        public static void EndBackground()
        {
            SoundManager.backGroundMusic.Stop();
            SoundManager.MusicPlaying = false;
        }

       
        public static void Mute()
        {
            if (SoundEffect.MasterVolume == 0)
            {
                SoundEffect.MasterVolume = 1f;
            }
            else
            {
                SoundEffect.MasterVolume = 0;
            }
        }
    }
}
