using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace FrenchBookApp
{
    internal class SpeechTranslator
    {
        static SpeechSynthesizer synth = new SpeechSynthesizer();
        public static void Speak(string text)
        {
            synth.SelectVoice("Microsoft Hortense Desktop");
            synth.SetOutputToDefaultAudioDevice();
            synth.Rate = 0;
            synth.Speak(text);
            //foreach (var voice in synth.GetInstalledVoices())
            //{
            //    Console.WriteLine(voice.VoiceInfo.Name);
            //}
        }
    }
}
