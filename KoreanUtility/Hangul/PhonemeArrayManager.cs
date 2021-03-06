﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.KoreanUtility.Hangul
{
    /// <summary>
    /// Phoneme[]에 대응하는 확장메서드를 정의합니다.
    /// </summary>
    public static class PhonemeArrayManager
    {
        /// <summary>
        /// Phoneme배열에서 source 문자들을 모아 문자열을 가져옵니다.
        /// </summary>
        /// <param name="phonemes">대상 Phoneme 배열입니다.</param>
        /// <returns>source 문자들을 조합한 문자열입니다.</returns>
        public static string GetSourceString(this Phoneme[] phonemes)
        {
            StringBuilder tempStringBuilder = new StringBuilder();
            foreach (var ftemp in phonemes)
            {
                tempStringBuilder.Append(ftemp.source);
            }
            return tempStringBuilder.ToString();
        }
        /// <summary>
        /// Phoneme배열에서 초,중,종성 문자를 모아 문자열을 가져옵니다.
        /// </summary>
        /// <param name="phonemes">대상 Phoneme 배열입니다.</param>
        /// <returns>initial, peak, final 문자들을 조합한 문자열입니다.</returns>
        public static string GetPhonemeString(this Phoneme[] phonemes)
        {
            StringBuilder tempStringBuilder = new StringBuilder();
            foreach (var ftemp in phonemes)
            {
                if (ftemp.initialConsonant != '\0' || ftemp.medialVowel != '\0')
                {
                    tempStringBuilder.Append(ftemp.ToString());
                }
                else
                    tempStringBuilder.Append(ftemp.source);
            }
            return tempStringBuilder.ToString();
        }
    }
}
