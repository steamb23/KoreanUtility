using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.KoreanUtility.Hangul
{
    public struct Phoneme
    {
        internal Phoneme(char source, char initialConsonant, char vowel, char finalConsonant, byte initialConsonantNumber, byte vowelNumber, byte finalConsonantNumber)
        {
            this.source = source;
            this.initialConsonant = initialConsonant;
            this.vowel = vowel;
            this.finalConsonant = finalConsonant;
            this.initialConsonantNumber = initialConsonantNumber;
            this.vowelNumber = vowelNumber;
            this.finalConsonantNumber = finalConsonantNumber;
        }
        public char source;
        public char initialConsonant;
        public char vowel;
        public char finalConsonant;
        public byte initialConsonantNumber;
        public byte vowelNumber;
        public byte finalConsonantNumber;
    }
}
