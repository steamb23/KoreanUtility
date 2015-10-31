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
        public static Phoneme CharacterToPhoneme(char character)
        {
            if (character >= 0xac00 && character <= 0xd7a3)
            {
                int tempCharacter = character - 0xac00;
                int tempInitialConsonant = tempCharacter / (21 * 28);
                int tempVowel = (tempCharacter % (21 * 28)) / 28;
                int tempFinalConsonant = (tempCharacter % (21 * 28)) % 28;

                char initialConsonant = (char)(tempInitialConsonant + 0x1100);
                char vowel = (char)(tempVowel + 0x1161);
                char finalConsonant = (tempFinalConsonant != 0) ? (char)(tempFinalConsonant + 0x11a7) : '\0';

                return new Phoneme(character, initialConsonant, vowel, finalConsonant, (byte)tempInitialConsonant, (byte)tempFinalConsonant, (byte)tempFinalConsonant);
            }
            else
            {
                return new Phoneme(character, '\0', '\0', '\0', 0, 0, 0);
            }
        }
        /// <summary>
        /// 문자의 배열에서 자소의 배열을 가져옵니다.
        /// </summary>
        /// <param name="characters">자소 분리할 문자의 배열</param>
        /// <returns>분리된 자소의 배열</returns>
        public static Phoneme[] CharactersToPhonemes(char[] characters)
        {
            Phoneme[] phonemes = new Phoneme[characters.Length];
            int fcount=0;
            foreach (var ftemp in characters)
            {
                phonemes[fcount] = CharacterToPhoneme(ftemp);
                fcount++;
            }
            return phonemes;
        }
        /// <summary>
        /// 문자열에서 자소의 배열을 가져옵니다.
        /// </summary>
        /// <param name="text">자소 분리할 문자열</param>
        /// <returns>분리된 자소의 배열</returns>
        public static Phoneme[] StringToPhonemes(string text)
        {
            return CharactersToPhonemes(text.ToCharArray());
        }
        /// <summary>
        /// 첫가끝 문자를 모아서 Phoneme를 구성합니다.
        /// </summary>
        /// <param name="initialConsonant">초성입니다.</param>
        /// <param name="medialVowel">중성입니다.</param>
        /// <param name="finalConsonant">종성입니다. 없을 경우에는 '\0'가 대입되어야합니다.</param>
        /// <returns></returns>
        public static Phoneme PhonemeCollecting(char initialConsonant, char medialVowel, char finalConsonant)
        {
            // 첫가끝 번호 계산
            int initialConsonantNumber = initialConsonant - 0x1100;
            int medialVowelNumber = medialVowel - 0x1161;
            int finalConsonantNumber = (medialVowel == '\0') ? 0 : medialVowel - 0x11a7;

            // 조합
            char tempSource = (char)(((initialConsonantNumber * 21) + medialVowelNumber) * 28 + finalConsonantNumber + 0xac00);

            // 반환
            return new Phoneme(tempSource, initialConsonant, medialVowel, finalConsonant, (byte)initialConsonantNumber, (byte)medialVowelNumber, (byte)finalConsonantNumber);

        }
    }
}
