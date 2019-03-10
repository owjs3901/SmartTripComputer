using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Speech;
using Microsoft.Speech.Synthesis;

namespace SpeechSystem
{
    class Speech
    {
		//bool a=false;

		public static SpeechSynthesizer ts = new SpeechSynthesizer();

		static Thread preth;
		//static Thread postth;
		
		public static void init(){
			ts.SelectVoice("Microsoft Server Speech Text to Speech Voice (ko-KR, Heami)");
			ts.SetOutputToDefaultAudioDevice();
		}

		public static void addSpeech(string str){
			preth = new Thread(new ParameterizedThreadStart(work));
			preth.Start(str);
		}
		static void work(object str){
			ts.Speak((string)str);
		}
    }
}
