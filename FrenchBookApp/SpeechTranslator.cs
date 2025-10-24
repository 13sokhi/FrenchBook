using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace FrenchBookApp
{
    public class SpeechTranslator
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
            //    Console.WriteLine("description - " + voice.VoiceInfo.Description);
            //    Console.WriteLine("name - " + voice.VoiceInfo.Name);
            //    Console.WriteLine("additionalinfo - " + voice.VoiceInfo.AdditionalInfo);
            //    Console.WriteLine("culture - " + voice.VoiceInfo.Culture);
            //    Console.WriteLine();
            //}
        }
    }
}
