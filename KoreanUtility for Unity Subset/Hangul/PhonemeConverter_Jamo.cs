using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.KoreanUtility.Hangul
{
    public static partial class PhonemeConverter
    {
        /// <summary>
        /// 자모를 초성으로 변환합니다.
        /// </summary>
        /// <param name="jamo">변환할 자모</param>
        /// <returns>자모에서 변환된 초성</returns>
        public static char JamoToInitialConsonant(char jamo)
        {
            switch (jamo)
            {
                case 'ㄱ':
                    return '\u1100';
                case 'ㄲ':
                    return '\u1101';
                case 'ㄴ':
                    return '\u1102';
                case 'ㄷ':
                    return '\u1103';
                case 'ㄸ':
                    return '\u1104';
                case 'ㄹ':
                    return '\u1105';
                case 'ㅁ':
                    return '\u1106';
                case 'ㅂ':
                    return '\u1107';
                case 'ㅃ':
                    return '\u1108';
                case 'ㅅ':
                    return '\u1109';
                case 'ㅆ':
                    return '\u110a';
                case 'ㅇ':
                    return '\u110b';
                case 'ㅈ':
                    return '\u110c';
                case 'ㅉ':
                    return '\u110d';
                case 'ㅊ':
                    return '\u110e';
                case 'ㅋ':
                    return '\u110f';
                case 'ㅌ':
                    return '\u1110';
                case 'ㅍ':
                    return '\u1111';
                case 'ㅎ':
                    return '\u1112';
                case '\u1100':
                case '\u1101':
                case '\u1102':
                case '\u1103':
                case '\u1104':
                case '\u1105':
                case '\u1106':
                case '\u1107':
                case '\u1108':
                case '\u1109':
                case '\u110a':
                case '\u110b':
                case '\u110c':
                case '\u110d':
                case '\u110e':
                case '\u110f':
                case '\u1110':
                case '\u1111':
                case '\u1112':
                    return jamo;
                default:
                    throw new ArgumentException("해당 문자에 해당되는 초성을 찾을 수 없습니다.");
            }
        }
        /// <summary>
        /// 자모를 중성으로 변환합니다.
        /// </summary>
        /// <param name="jamo">변환할 자모</param>
        /// <returns>변환된 중성</returns>
        public static char JamoToMedialVowel(char jamo)
        {
            switch (jamo)
            {
                case 'ㅏ':
                    return '\u1161';
                case 'ㅐ':
                    return '\u1162';
                case 'ㅑ':
                    return '\u1163';
                case 'ㅒ':
                    return '\u1164';
                case 'ㅓ':
                    return '\u1165';
                case 'ㅔ':
                    return '\u1166';
                case 'ㅕ':
                    return '\u1167';
                case 'ㅖ':
                    return '\u1168';
                case 'ㅗ':
                    return '\u1169';
                case 'ㅘ':
                    return '\u116a';
                case 'ㅙ':
                    return '\u116b';
                case 'ㅚ':
                    return '\u116c';
                case 'ㅛ':
                    return '\u116d';
                case 'ㅜ':
                    return '\u116e';
                case 'ㅝ':
                    return '\u116f';
                case 'ㅞ':
                    return '\u1170';
                case 'ㅟ':
                    return '\u1171';
                case 'ㅠ':
                    return '\u1172';
                case 'ㅡ':
                    return '\u1173';
                case 'ㅢ':
                    return '\u1174';
                case 'ㅣ':
                    return '\u1175';
                case '\u1161':
                case '\u1162':
                case '\u1163':
                case '\u1164':
                case '\u1165':
                case '\u1166':
                case '\u1167':
                case '\u1168':
                case '\u1169':
                case '\u116a':
                case '\u116b':
                case '\u116c':
                case '\u116d':
                case '\u116f':
                case '\u1170':
                case '\u1171':
                case '\u1172':
                case '\u1173':
                case '\u1174':
                case '\u1175':
                    return jamo;
                default:
                    throw new ArgumentException("해당 문자에 해당되는 초성을 찾을 수 없습니다.");
            }
        }
        /// <summary>
        /// 자모를 종성으로 변환합니다.
        /// </summary>
        /// <param name="jamo">변환할 자모</param>
        /// <returns>변환된 종성</returns>
        public static char JamoToFinalConsonant(char jamo)
        {
            switch (jamo)
            {
                case 'ㄱ':
                    return '\u11a8';
                case 'ㄲ':
                    return '\u11a9';
                case 'ㄳ':
                    return '\u11aa';
                case 'ㄴ':
                    return '\u11ab';
                case 'ㄵ':
                    return '\u11ac';
                case 'ㄶ':
                    return '\u11ad';
                case 'ㄷ':
                    return '\u11ae';
                case 'ㄹ':
                    return '\u11af';
                case 'ㄺ':
                    return '\u11b0';
                case 'ㄻ':
                    return '\u11b1';
                case 'ㄼ':
                    return '\u11b2';
                case 'ㄽ':
                    return '\u11b3';
                case 'ㄾ':
                    return '\u11b4';
                case 'ㄿ':
                    return '\u11b5';
                case 'ㅀ':
                    return '\u11b6';
                case 'ㅁ':
                    return '\u11b7';
                case 'ㅂ':
                    return '\u11b8';
                case 'ㅄ':
                    return '\u11b9';
                case 'ㅅ':
                    return '\u11ba';
                case 'ㅆ':
                    return '\u11bb';
                case 'ㅇ':
                    return '\u11bc';
                case 'ㅈ':
                    return '\u11bd';
                case 'ㅊ':
                    return '\u11be';
                case 'ㅋ':
                    return '\u11bf';
                case 'ㅌ':
                    return '\u11c0';
                case 'ㅍ':
                    return '\u11c1';
                case 'ㅎ':
                    return '\u11c2';
                case '\u11a8':
                case '\u11a9':
                case '\u11aa':
                case '\u11ab':
                case '\u11ac':
                case '\u11ad':
                case '\u11ae':
                case '\u11af':
                case '\u11b0':
                case '\u11b1':
                case '\u11b2':
                case '\u11b3':
                case '\u11b4':
                case '\u11b5':
                case '\u11b6':
                case '\u11b7':
                case '\u11b8':
                case '\u11b9':
                case '\u11ba':
                case '\u11bb':
                case '\u11bc':
                case '\u11bd':
                case '\u11be':
                case '\u11bf':
                case '\u11c0':
                case '\u11c1':
                case '\u11c2':
                    return jamo;
                default:
                    throw new ArgumentException("해당 문자에 해당되는 초성을 찾을 수 없습니다.");
            }
        }
        /// <summary>
        /// 자모가 초성인지 아닌지 확인합니다.
        /// </summary>
        /// <param name="jamo">확인할 자모</param>
        /// <returns>초성이 맞다면 true이고 아니라면 false입니다.</returns>
        public static bool JamoIsInitialConsonant(char jamo)
        {
            switch (jamo)
            {
                case 'ㄱ':
                    return true;
                case 'ㄲ':
                    return true;
                case 'ㄴ':
                    return true;
                case 'ㄷ':
                    return true;
                case 'ㄸ':
                    return true;
                case 'ㄹ':
                    return true;
                case 'ㅁ':
                    return true;
                case 'ㅂ':
                    return true;
                case 'ㅃ':
                    return true;
                case 'ㅅ':
                    return true;
                case 'ㅆ':
                    return true;
                case 'ㅇ':
                    return true;
                case 'ㅈ':
                    return true;
                case 'ㅉ':
                    return true;
                case 'ㅊ':
                    return true;
                case 'ㅋ':
                    return true;
                case 'ㅌ':
                    return true;
                case 'ㅍ':
                    return true;
                case 'ㅎ':
                    return true;
                case '\u1100':
                case '\u1101':
                case '\u1102':
                case '\u1103':
                case '\u1104':
                case '\u1105':
                case '\u1106':
                case '\u1107':
                case '\u1108':
                case '\u1109':
                case '\u110a':
                case '\u110b':
                case '\u110c':
                case '\u110d':
                case '\u110e':
                case '\u110f':
                case '\u1110':
                case '\u1111':
                case '\u1112':
                    return true;
                default:
                    return false;
            }
        }
        /// <summary>
        /// 자모가 중성인지 아닌지 확인합니다.
        /// </summary>
        /// <param name="jamo">확인할 자모</param>
        /// <returns>중성이 맞다면 true이고 아니라면 false입니다.</returns>
        public static bool JamoIsMedialVowel(char jamo)
        {
            switch (jamo)
            {
                case 'ㅏ':
                    return true;
                case 'ㅐ':
                    return true;
                case 'ㅑ':
                    return true;
                case 'ㅒ':
                    return true;
                case 'ㅓ':
                    return true;
                case 'ㅔ':
                    return true;
                case 'ㅕ':
                    return true;
                case 'ㅖ':
                    return true;
                case 'ㅗ':
                    return true;
                case 'ㅘ':
                    return true;
                case 'ㅙ':
                    return true;
                case 'ㅚ':
                    return true;
                case 'ㅛ':
                    return true;
                case 'ㅜ':
                    return true;
                case 'ㅝ':
                    return true;
                case 'ㅞ':
                    return true;
                case 'ㅟ':
                    return true;
                case 'ㅠ':
                    return true;
                case 'ㅡ':
                    return true;
                case 'ㅢ':
                    return true;
                case 'ㅣ':
                    return true;
                case '\u1161':
                case '\u1162':
                case '\u1163':
                case '\u1164':
                case '\u1165':
                case '\u1166':
                case '\u1167':
                case '\u1168':
                case '\u1169':
                case '\u116a':
                case '\u116b':
                case '\u116c':
                case '\u116d':
                case '\u116f':
                case '\u1170':
                case '\u1171':
                case '\u1172':
                case '\u1173':
                case '\u1174':
                case '\u1175':
                    return true;
                default:
                    return false;
            }
        }
        /// <summary>
        /// 자모가 종성인지 아닌지 확인합니다.
        /// </summary>
        /// <param name="jamo">확인할 자모</param>
        /// <returns>종성이 맞다면 true이고 아니라면 false입니다.</returns>
        public static bool JamoIsFinalConsonant(char jamo)
        {
            switch (jamo)
            {
                case 'ㄱ':
                    return true;
                case 'ㄲ':
                    return true;
                case 'ㄳ':
                    return true;
                case 'ㄴ':
                    return true;
                case 'ㄵ':
                    return true;
                case 'ㄶ':
                    return true;
                case 'ㄷ':
                    return true;
                case 'ㄹ':
                    return true;
                case 'ㄺ':
                    return true;
                case 'ㄻ':
                    return true;
                case 'ㄼ':
                    return true;
                case 'ㄽ':
                    return true;
                case 'ㄾ':
                    return true;
                case 'ㄿ':
                    return true;
                case 'ㅀ':
                    return true;
                case 'ㅁ':
                    return true;
                case 'ㅂ':
                    return true;
                case 'ㅄ':
                    return true;
                case 'ㅅ':
                    return true;
                case 'ㅆ':
                    return true;
                case 'ㅇ':
                    return true;
                case 'ㅈ':
                    return true;
                case 'ㅊ':
                    return true;
                case 'ㅋ':
                    return true;
                case 'ㅌ':
                    return true;
                case 'ㅍ':
                    return true;
                case 'ㅎ':
                    return true;
                case '\u11a8':
                case '\u11a9':
                case '\u11aa':
                case '\u11ab':
                case '\u11ac':
                case '\u11ad':
                case '\u11ae':
                case '\u11af':
                case '\u11b0':
                case '\u11b1':
                case '\u11b2':
                case '\u11b3':
                case '\u11b4':
                case '\u11b5':
                case '\u11b6':
                case '\u11b7':
                case '\u11b8':
                case '\u11b9':
                case '\u11ba':
                case '\u11bb':
                case '\u11bc':
                case '\u11bd':
                case '\u11be':
                case '\u11bf':
                case '\u11c0':
                case '\u11c1':
                case '\u11c2':
                    return true;
                default:
                    return false;
            }
        }
    }
}
