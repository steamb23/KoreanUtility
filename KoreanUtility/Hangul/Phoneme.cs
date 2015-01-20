using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.KoreanUtility.Hangul
{
    /// <summary>
    /// 자소에 대한 정보를 제공하는 구조체입니다.
    /// </summary>
    public struct Phoneme
    {
        internal Phoneme(char source, char initial, char peak, char final, byte initialNumber, byte peakNumber, byte finalNumber)
        {
            this.source = source;
            this.initial = initial;
            this.peak = peak;
            this.final = final;
            this.initialNumber = initialNumber;
            this.peakNumber = peakNumber;
            this.finalNumber = finalNumber;
        }
        /// <summary>
        /// 원본 글자입니다.
        /// </summary>
        public char source;
        /// <summary>
        /// 초성입니다.
        /// 한글 완성형 외의 글자의 기본값은 \0입니다.
        /// </summary>
        public char initial;
        /// <summary>
        /// 중성입니다.
        /// 한글 완성형 외의 글자의 기본값은 \0입니다.
        /// </summary>
        public char peak;
        /// <summary>
        /// 종성입니다.
        /// 한글 완성형 외의 글자의 기본값은 \0입니다.
        /// </summary>
        public char final;
        /// <summary>
        /// 초성 번호입니다.
        /// 한글 완성형 외의 글자의 기본값은 0xff입니다.
        /// </summary>
        public byte initialNumber;
        /// <summary>
        /// 중성 번호입니다.
        /// 한글 완성형 외의 글자의 기본값은 0xff입니다.
        /// </summary>
        public byte peakNumber;
        /// <summary>
        /// 종성 번호입니다.
        /// 한글 완성형 외의 글자의 기본값은 0xff입니다.
        /// </summary>
        public byte finalNumber;
    }
}
