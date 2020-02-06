using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace JavaCompilingToolMurtada.Speechability
{
    class Speechability 
    {
        private SpeechSynthesizer synthesizer;

        public Speechability()
        {
            synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = 0;     // -10...10
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult); 

        }
        

        public void ConvertTxtToSpeech(string txt) 
        {
            synthesizer.Speak(txt);              
        }
        public void setGender(int gender) //0 for male else for female
        {
            synthesizer.SelectVoiceByHints((gender == 0) ? VoiceGender.Male : VoiceGender.Female, VoiceAge.Adult);
        }

        public void SetVolume(int value)
        {
            if(value>100||value<0)
                synthesizer.Volume = 100;  // 0...100
            else
                synthesizer.Volume = value;  // 0...100
           
        }
    }
}
