using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.KoreanUtility.Hangul
{
    /// <summary>
    /// 자소를 분리하는 클래스입니다.
    /// </summary>
    public static class PhonemeSeparation
    {
        public static Phoneme GetPhoneme(char character)
        {
            int tempCharacter = character - 0xac00;
            int tempInitialConsonant = tempCharacter / (21 * 28);
            int tempVowel = (tempCharacter % (21 * 28)) / 28;
            int tempFinalConsonant = (tempCharacter % (21 * 28)) % 28;

            char initialConsonant = (char)(tempInitialConsonant + 0x1100);
            char vowel = (char)(tempVowel + 0x1161);
            char finalConsonant = (char)(tempFinalConsonant + 0x11a7);

            return new Phoneme(character, initialConsonant, vowel, finalConsonant, (byte)tempInitialConsonant, (byte)tempFinalConsonant, (byte)tempFinalConsonant);
        }
        public static Phoneme[] GetPhonemes(char[] characters)
        {
            Phoneme[] phonemes = new Phoneme[characters.Length];
            int fcount=0;
            foreach (var ftemp in characters)
            {
                phonemes[fcount] = GetPhoneme(ftemp);
                fcount++;
            }
            return phonemes;
        }
        public static Phoneme[] GetPhonemes(string text)
        {
            return GetPhonemes(text.ToCharArray());
        }
    }
}
