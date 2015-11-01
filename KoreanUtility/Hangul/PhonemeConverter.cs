using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.KoreanUtility.Hangul
{
    /// <summary>
    /// 자소를 분리하는 클래스입니다.
    /// </summary>
    public static partial class PhonemeConverter
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
            int fcount = 0;
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
            int finalConsonantNumber = (finalConsonant == '\0') ? 0 : (finalConsonant - 0x11a7);

            // 조합
            char tempSource = (char)(((initialConsonantNumber * 21) + medialVowelNumber) * 28 + finalConsonantNumber + 0xac00);

            // 반환
            return new Phoneme(tempSource, initialConsonant, medialVowel, finalConsonant, (byte)initialConsonantNumber, (byte)medialVowelNumber, (byte)finalConsonantNumber);
        }
        /// <summary>
        /// 자모만으로 이루어진 문자의 배열을 조합된 Phoneme의 배열로 변환합니다.
        /// </summary>
        /// <param name="jamoChars">자모 문자 배열</param>
        /// <returns>조합된 Phoneme 배열</returns>
        public static Phoneme[] JamosToPhonomes(char[] jamoChars)
        {
            List<Phoneme> phonemeList = new List<Phoneme>();
            char tempInitialConsonant = '\0';
            char tempMedialVowel = '\0';
            char tempFinalConsonant = '\0';
            // 자모 타입 분석
            for (int i = 0; i < jamoChars.Length; i++)
            {
                char currentChar = jamoChars[i];
                CHECK_START:
                // 현재 글자는 초성이고 임시 초성 변수가 비어있다.
                if (JamoIsInitialConsonant(currentChar) && tempInitialConsonant == '\0')
                    tempInitialConsonant = JamoToInitialConsonant(currentChar);
                // 현재 글자는 중성이고 임시 중성 변수가 비어있다.
                else if (JamoIsMedialVowel(currentChar) && tempMedialVowel == '\0')
                    tempMedialVowel = JamoToMedialVowel(currentChar);
                // 현재 글자는 종성이고 임시 종성 변수가 비어있다.
                else if (JamoIsFinalConsonant(currentChar) && tempFinalConsonant == '\0')
                {
                    // 다음글자가 중성이 아니다.
                    int nextIndex = i + 1;
                    if (nextIndex >= jamoChars.Length || !JamoIsMedialVowel(jamoChars[nextIndex]))
                        tempFinalConsonant = JamoToFinalConsonant(currentChar);
                    // 임시변수에 초성과 중성이 들어있다.
                    else if (tempInitialConsonant != '\0' && tempMedialVowel != '\0')
                    {
                        phonemeList.Add(PhonemeCollecting(tempInitialConsonant, tempMedialVowel, tempFinalConsonant));
                        tempInitialConsonant = '\0';
                        tempMedialVowel = '\0';
                        tempFinalConsonant = '\0';
                    }
                    // 임시변수에 초성만 들어있다.
                    else if (tempInitialConsonant != '\0')
                    {
                        phonemeList.Add(CharacterToPhoneme(tempInitialConsonant));
                        tempInitialConsonant = '\0';
                        tempMedialVowel = '\0';
                        tempFinalConsonant = '\0';
                    }
                    // 현재 글자는 초성이고 임시 초성 변수가 비어있다.
                    if (JamoIsInitialConsonant(currentChar) && tempInitialConsonant == '\0')
                        tempInitialConsonant = JamoToInitialConsonant(currentChar);

                }
                // 임시변수에 초성과 중성이 들어있다.
                else if (tempInitialConsonant != '\0' && tempMedialVowel != '\0')
                {
                    phonemeList.Add(PhonemeCollecting(tempInitialConsonant, tempMedialVowel, tempFinalConsonant));
                    tempInitialConsonant = '\0';
                    tempMedialVowel = '\0';
                    tempFinalConsonant = '\0';
                    // 다시 확인해본다.
                    goto CHECK_START;
                }
                // 임시변수에 초성만 들어있다.
                else if (tempInitialConsonant != '\0')
                {
                    phonemeList.Add(CharacterToPhoneme(tempInitialConsonant));
                    tempInitialConsonant = '\0';
                    tempMedialVowel = '\0';
                    tempFinalConsonant = '\0';
                    // 다시 확인해본다.
                    goto CHECK_START;
                }
                // 현재 글자는 한글이 아니거나 완성되지 못한 자모이다.
                else
                    phonemeList.Add(CharacterToPhoneme(currentChar));
            }
            // 임시변수에 초성과 중성이 들어있다.
            if (tempInitialConsonant != '\0' && tempMedialVowel != '\0')
            {
                phonemeList.Add(PhonemeCollecting(tempInitialConsonant, tempMedialVowel, tempFinalConsonant));
                tempInitialConsonant = '\0';
                tempMedialVowel = '\0';
                tempFinalConsonant = '\0';
                // 다시 확인해본다.
            }
            // 임시변수에 초성과 중성이 들어있다.
            if (tempInitialConsonant != '\0' && tempMedialVowel != '\0')
            {
                phonemeList.Add(PhonemeCollecting(tempInitialConsonant, tempMedialVowel, tempFinalConsonant));
                tempInitialConsonant = '\0';
                tempMedialVowel = '\0';
                tempFinalConsonant = '\0';
                // 다시 확인해본다.
            }
            // 임시변수에 초성만 들어있다.
            else if (tempInitialConsonant != '\0')
            {
                phonemeList.Add(CharacterToPhoneme(tempInitialConsonant));
                tempInitialConsonant = '\0';
                tempMedialVowel = '\0';
                tempFinalConsonant = '\0';
                // 다시 확인해본다.
            }
            return phonemeList.ToArray();
        }
        /// <summary>
        /// 자모만으로 이루어진 문자열을 조합된 Phoneme의 배열로 변환합니다.
        /// </summary>
        /// <param name="jamoText">자모 문자열</param>
        /// <returns>조합된 Phoneme 배열</returns>
        public static Phoneme[] JamosToPhonomes(string jamoText)
        {
            return JamosToPhonomes(jamoText.ToCharArray());
        }
    }
}
