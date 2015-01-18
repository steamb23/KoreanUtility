using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamB23.KoreanUtility
{
    /// <summary>
    /// 한국어의 조사 처리와 관련된 기능을 제공하는 클래스입니다.
    /// </summary>
    public static class Josa
    {
        /// <summary>
        /// 한국어에서의 받침 유무에 따라 바뀌는 조사를 자동으로 추가합니다.
        /// </summary>
        /// <param name="text">대상 문자열입니다.</param>
        /// <param name="type">추가될 조사의 타입입니다.</param>
        /// <returns>조사가 추가된 문자열입니다.</returns>
        public static string 조사추가(this string text, 조사 type)
        {
            char lastChar = char.Parse(text.Substring(text.Length - 1, 1));
            return text + 조사결정(lastChar, type);
        }
        /// <summary>
        /// 한국어에서의 받침 유무에 따라 바뀌는 조사를 자동으로 추가합니다.
        /// </summary>
        /// <param name="textBuilder">대상 <c>StringBuilder</c>입니다.</param>
        /// <param name="type">추가될 조사의 타입입니다.</param>
        public static void 조사추가(this StringBuilder textBuilder, 조사 type)
        {
            string text = textBuilder.ToString();

            char lastChar = char.Parse(text.Substring(text.Length - 1, 1));
            textBuilder.Append(조사결정(lastChar, type));
        }
        /// <summary>
        /// 마지막 글자의 받침 유무에 따라 바뀌는 조사를 결정합니다. 
        /// </summary>
        /// <param name="lastChar">확인할 글자입니다.</param>
        /// <param name="type">결정될 조사의 타입입니다.</param>
        /// <returns>결정된 조사입니다.</returns>
        public static string 조사결정(char lastChar, 조사 type)
        {
            if ((lastChar <= '가' && lastChar >= '힣'))
            {
                lastChar = '아';
            }
            switch (type)
            {
                case 조사.은_는:
                    return GenericJosaRule(lastChar, "은", "는");
                case 조사.이_가:
                    return GenericJosaRule(lastChar, "이", "가");
                case 조사.을_를:
                    return GenericJosaRule(lastChar, "을", "를");
                case 조사.과_와:
                    return GenericJosaRule(lastChar, "과", "와");
                case 조사.아_야:
                    return GenericJosaRule(lastChar, "아", "야");
                case 조사.이다_다:
                    return GenericJosaRule(lastChar, "이", "");
                case 조사.으로_로:
                    if (((lastChar - 0xAC00) % (21 * 28)) % 28 == 0 || ((lastChar - 0xAC00) % (21 * 28)) % 28 == 5)
                        return "로";
                    else
                        return "으로";
                default:
                    return "";
            }
        }
        /// <summary>
        /// 일반적인 조사 선택 규칙입니다.
        /// </summary>
        /// <param name="lastChar">문자열 마지막에 발견되는 글자입니다.</param>
        /// <param name="lastCharHaveJongseong">받침이 있을때 반환할 문자열입니다.</param>
        /// <param name="lastCharNotHaveJongseong">받침이 없을때 반환할 문자열입니다.</param>
        /// <returns>받침이 있으면 <c>lastCharHaveJongseong</c>를 반환하고, 없으면 <c>lastCharNotHaveJongseong</c>을 반환합니다.</returns>
        internal static string GenericJosaRule(char lastChar, string lastCharHaveJongseong, string lastCharNotHaveJongseong)
        {
            if (((lastChar - 0xAC00) % (21 * 28)) % 28 == 0)
                return lastCharNotHaveJongseong;
            else
                return lastCharHaveJongseong;
        }
    }
    /// <summary>
    /// 조사와 관련된 메서드에 대한 조사의 종류를 정의합니다.
    /// </summary>
    public enum 조사
    {
        // 빠른 자동 완성 사용을 위한 값
        /// <summary>
        /// 보조사 : 은/는
        /// </summary>
        _은는 = 0,
        /// <summary>
        /// 주격조사 : 이/가
        /// </summary>
        _이가 = 1,
        /// <summary>
        /// 목적격 조사 : 을/를
        /// </summary>
        _을를 = 2,
        /// <summary>
        /// 접속조사 : 과/와
        /// </summary>
        _과와 = 3,
        /// <summary>
        /// 호격 조사 : 아/야
        /// </summary>
        _아야 = 4,
        /// <summary>
        /// 서술격 조사 : 이다/다
        /// (경고 : 이다/다, 이고/고, 이니/고, 이면/면, 이지/지, 이여/여 등으로 변형 사례가 많기 때문에 '이'와 ''를 리턴합니다.)
        /// </summary>
        _이다 = 5,
        /// <summary>
        /// 부사격 조사 : 으로/로,
        /// (경고 : ㄹ받침은 받침이 없는 경우와 같습니다.)
        /// </summary>
        _으로 = 6,

        // 빠른 작성을 위한 값
        /// <summary>
        /// 보조사 : 은/는
        /// </summary>
        은는 = 0,
        /// <summary>
        /// 주격조사 : 이/가
        /// </summary>
        이가 = 1,
        /// <summary>
        /// 목적격 조사 : 을/를
        /// </summary>
        을를 = 2,
        /// <summary>
        /// 접속조사 : 과/와
        /// </summary>
        과와 = 3,
        /// <summary>
        /// 호격 조사 : 아/야
        /// </summary>
        아야 = 4,
        /// <summary>
        /// 서술격 조사 : 이다/다
        /// (경고 : 이다/다, 이고/고, 이니/고, 이면/면, 이지/지, 이여/여 등으로 변형 사례가 많기 때문에 '이'와 ''를 리턴합니다.)
        /// </summary>
        이 = 5,
        /// <summary>
        /// 부사격 조사 : 으로/로,
        /// (경고 : ㄹ받침은 받침이 없는 경우와 같습니다.)
        /// </summary>
        으로 = 6,

        // 가독성을 위한 값
        /// <summary>
        /// 보조사 : 은/는
        /// </summary>
        은_는 = 0,
        /// <summary>
        /// 주격조사 : 이/가
        /// </summary>
        이_가 = 1,
        /// <summary>
        /// 목적격 조사 : 을/를
        /// </summary>
        을_를 = 2,
        /// <summary>
        /// 접속조사 : 과/와
        /// </summary>
        과_와 = 3,
        /// <summary>
        /// 호격 조사 : 아/야
        /// </summary>
        아_야 = 4,
        /// <summary>
        /// 서술격 조사 : 이다/다
        /// (경고 : 이다/다, 이고/고, 이니/고, 이면/고, 이지/지 등으로 변형 사례가 많기 때문에 '이'와 ''를 리턴합니다.)
        /// </summary>
        이다_다 = 5,
        /// <summary>
        /// 부사격 조사 : 으로/로,
        /// ㄹ받침은 받침이 없는 경우와 같다.
        /// </summary>
        으로_로 = 6,

        // 영어 대문자 값
        /// <summary>
        /// 보조사 : 은/는
        /// </summary>
        EN = 0,
        /// <summary>
        /// 주격조사 : 이/가
        /// </summary>
        IG = 1,
        /// <summary>
        /// 목적격 조사 : 을/를
        /// </summary>
        ER = 2,
        /// <summary>
        /// 접속조사 : 과/와
        /// </summary>
        GW = 3,
        /// <summary>
        /// 호격 조사 : 아/야
        /// </summary>
        AY = 4,
        /// <summary>
        /// 서술격 조사 : 이다/다
        /// (경고 : 이다/다, 이고/고, 이니/고, 이면/고, 이지/지 등으로 변형 사례가 많기 때문에 '이'와 ''를 리턴합니다.)
        /// </summary>
        IDD = 5,
        /// <summary>
        /// 부사격 조사 : 으로/로,
        /// ㄹ받침은 받침이 없는 경우와 같다.
        /// </summary>
        ERR = 6
    }
}
