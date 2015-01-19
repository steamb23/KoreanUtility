using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.KoreanUtility.Hangul
{
    /// <summary>
    /// 자소를 분리하는 클래스입니다.
    /// </summary>
    public static class PhonemeConverter
    {
        /// <summary>
        /// 문자에서 자소를 가져옵니다.
        /// </summary>
        /// <param name="character">자소 분리할 글자</param>
        /// <returns>분리된 자소</returns>
        public static Phoneme ToPhoneme(char character)
        {
            if (character >= 0xac00 && character <= 0xd7a3)
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
            else
            {
                return new Phoneme(character, '\0', '\0', '\0', 0xff, 0xff, 0xff);
            }
        }
        /// <summary>
        /// 문자의 배열에서 자소의 배열을 가져옵니다.
        /// </summary>
        /// <param name="characters">자소 분리할 문자의 배열</param>
        /// <returns>분리된 자소의 배열</returns>
        public static Phoneme[] ToPhonemes(char[] characters)
        {
            Phoneme[] phonemes = new Phoneme[characters.Length];
            int fcount=0;
            foreach (var ftemp in characters)
            {
                phonemes[fcount] = ToPhoneme(ftemp);
                fcount++;
            }
            return phonemes;
        }
        /// <summary>
        /// 문자열에서 자소의 배열을 가져옵니다.
        /// </summary>
        /// <param name="text">자소 분리할 문자열</param>
        /// <returns>분리된 자소의 배열</returns>
        public static Phoneme[] ToPhonemes(string text)
        {
            return ToPhonemes(text.ToCharArray());
        }
    }
}
