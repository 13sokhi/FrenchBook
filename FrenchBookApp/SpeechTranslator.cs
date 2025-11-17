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
        public static void Speak(string text, int rate)
        {
            synth.SelectVoice("Microsoft Hortense Desktop");
            synth.SetOutputToDefaultAudioDevice();
            synth.Rate = rate;
            synth.Speak(text);
        }
    }
}
