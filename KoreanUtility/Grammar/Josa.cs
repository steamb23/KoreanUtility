using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SteamB23.KoreanUtility.Hangul;

/// <summary>
/// 한국어 문법과 관련된 기능들을 다루는 네임스페이스입니다.
/// </summary>
namespace SteamB23.KoreanUtility.Grammar
{
    /// <summary>
    /// 한국어의 조사 처리와 관련된 기능을 제공하는 클래스입니다.
    /// </summary>
    public static class 조사
    {
        /// <summary>
        /// 한국어에서의 받침 유무에 따라 바뀌는 조사를 자동으로 추가합니다.
        /// </summary>
        /// <param name="text">대상 문자열입니다.</param>
        /// <param name="type">추가될 조사의 타입입니다.</param>
        /// <returns>조사가 추가된 문자열입니다.</returns>
        public static string 조사추가(this string text, 조사종류 type)
        {
            char lastChar = char.Parse(text.Substring(text.Length - 1, 1));
            return text + 조사결정(lastChar, type);
        }
        /// <summary>
        /// 한국어에서의 받침 유무에 따라 바뀌는 조사를 자동으로 추가합니다.
        /// </summary>
        /// <param name="textBuilder">대상 <c>StringBuilder</c>입니다.</param>
        /// <param name="type">추가될 조사의 타입입니다.</param>
        public static void 조사추가(this StringBuilder textBuilder, 조사종류 type)
        {
            string text = textBuilder.ToString();

            char lastChar = char.Parse(text.Substring(text.Length - 1, 1));
            textBuilder.Append(조사결정(lastChar, type));
        }
        static Regex josaSignRegex;
        /// <summary>
        /// 조사 기호를 사용하여 한국어에서의 받침 유무에 따라 바뀌는 조사를 자동으로 추가합니다.
        /// </summary>
        /// <param name="text">대상 문자열입니다.</param>
        /// <returns>조사가 추가된 문자열입니다.</returns>
        /// <remarks>
        /// <para>조사 기호에는 다음과 같이 중괄호로 묶여진 단어를 사용합니다.</para>
        /// <para>
        /// [은는]
        /// [는은]
        /// [이가]
        /// [가이]
        /// [을를]
        /// [를을]
        /// [과와]
        /// [와과]
        /// [아야]
        /// [야아]
        /// [이]
        /// [으로]
        /// [로]
        /// </para>
        /// </remarks>
        /// <example>
        /// 해당 기능은 다음과 같이 사용할 수 있습니다.
        /// <code>
        /// 조사.문자처리("마이크로소프트[은는] 새로운 증강현실 장치인 홀로렌즈[을를] 출시했다. 이는 컴퓨터[와과] 인간의 거리를 더욱 가깝게 해줄것이다.") == "마이크로소프트는 새로운 증강현실 장치인 홀로렌즈를 출시했다. 이는 컴퓨터와 인간의 거리를 더욱 가깝게 해줄것이다."
        /// 조사.문자처리("{0}[은는] 새로운 증강현실 장치인 {1}[을를] 출시했다. 이는 {2}[와과] 인간의 거리를 더욱 가깝게 해줄것이다.", "마이크로소프트", "홀로렌즈", 컴퓨터") == "마이크로소프트는 새로운 증강현실 장치인 홀로렌즈를 출시했다. 이는 컴퓨터와 인간의 거리를 더욱 가깝게 해줄것이다."
        /// </code>
        /// </example>
        public static string 문자처리(string text)
        {
            정규식컴파일();
            string[] spritedText = josaSignRegex.Split(text);
            MatchCollection matchedText = josaSignRegex.Matches(text);
            StringBuilder resultText = new StringBuilder(spritedText.Length);
            for (int i = 0; i < matchedText.Count; i++)
            {
                switch (matchedText[i].Value)
                {
                    case "[은는]":
                    case "[는은]":
                        resultText.Append(spritedText[i]);
                        resultText.조사추가(조사종류.은는);
                        break;
                    case "[이가]":
                    case "[가이]":
                        resultText.Append(spritedText[i]);
                        resultText.조사추가(조사종류.이가);
                        break;
                    case "[을를]":
                    case "[를을]":
                        resultText.Append(spritedText[i]);
                        resultText.조사추가(조사종류.을를);
                        break;
                    case "[과와]":
                    case "[와과]":
                        resultText.Append(spritedText[i]);
                        resultText.조사추가(조사종류.과와);
                        break;
                    case "[아야]":
                    case "[야아]":
                        resultText.Append(spritedText[i]);
                        resultText.조사추가(조사종류.아야);
                        break;
                    case "[이]":
                        resultText.Append(spritedText[i]);
                        resultText.조사추가(조사종류.이);
                        break;
                    case "[으로]":
                    case "[로]":
                        resultText.Append(spritedText[i]);
                        resultText.조사추가(조사종류.으로);
                        break;
                }
            }
            resultText.Append(spritedText.Last());
            return resultText.ToString();
        }
        /// <summary>
        /// 서식과 조사 기호를 사용하여 한국어에서의 받침 유무에 따라 바뀌는 조사를 자동으로 추가합니다.
        /// </summary>
        /// <param name="text">대상 문자열입니다.</param>
        /// <param name="args">서식을 지정할 개체를 0개 이상 포함하는 배열입니다.</param>
        /// <returns>조사가 추가된 문자열입니다.</returns>
        /// <example>
        /// 해당 기능은 다음과 같이 사용할 수 있습니다.
        /// <code>
        /// 조사.문자처리("마이크로소프트[은는] 새로운 증강현실 장치인 홀로렌즈[을를] 출시했다. 이는 컴퓨터[와과] 인간의 거리를 더욱 가깝게 해줄것이다.") == "마이크로소프트는 새로운 증강현실 장치인 홀로렌즈를 출시했다. 이는 컴퓨터와 인간의 거리를 더욱 가깝게 해줄것이다."
        /// 조사.문자처리("{0}[은는] 새로운 증강현실 장치인 {1}[을를] 출시했다. 이는 {2}[와과] 인간의 거리를 더욱 가깝게 해줄것이다.", "마이크로소프트", "홀로렌즈", 컴퓨터") == "마이크로소프트는 새로운 증강현실 장치인 홀로렌즈를 출시했다. 이는 컴퓨터와 인간의 거리를 더욱 가깝게 해줄것이다."
        /// </code>
        /// </example>
        public static string 문자처리(string text, params object[] args)
        {
            return 문자처리(string.Format(text, args));
        }
        /// <summary>
        /// 문자처리 메서드에서 사용되는 정규식을 미리 컴파일 시켜 성능을 향상시킵니다.
        /// </summary>
        public static void 정규식컴파일()
        {
            if (josaSignRegex == null)
            {
                josaSignRegex = new Regex(@"\[은는\]|\[이가\]|\[을를\]|\[과와\]|\[아야\]|\[이\]|\[으로\]|\[는은\]|\[가이\]|\[를을\]|\[와과\]|\[야아\]|\[로\]", RegexOptions.Compiled);
            }
        }
        /// <summary>
        /// 마지막 글자의 받침 유무에 따라 바뀌는 조사를 결정합니다. 
        /// </summary>
        /// <param name="lastChar">확인할 글자입니다.</param>
        /// <param name="type">결정될 조사의 타입입니다.</param>
        /// <returns>결정된 조사입니다.</returns>
        public static string 조사결정(char lastChar, 조사종류 type)
        {
            // 완성형 한글이 아니면 일단 '각'으로 특정해놓는다.
            if (!(lastChar >= '가' && lastChar <= '힣'))
            {
                lastChar = '각';
            }
            Phoneme phoneme = PhonemeConverter.CharacterToPhoneme(lastChar);
            switch (type)
            {
                case 조사종류.은_는:
                    return GenericJosaRule(phoneme, "은", "는");
                case 조사종류.이_가:
                    return GenericJosaRule(phoneme, "이", "가");
                case 조사종류.을_를:
                    return GenericJosaRule(phoneme, "을", "를");
                case 조사종류.과_와:
                    return GenericJosaRule(phoneme, "과", "와");
                case 조사종류.아_야:
                    return GenericJosaRule(phoneme, "아", "야");
                case 조사종류.이다_다:
                    return GenericJosaRule(phoneme, "이", "");
                case 조사종류.으로_로:
                    if (phoneme.finalConsonantNumber == 0 || phoneme.finalConsonantNumber == 8)
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
        /// <param name="phoneme">문자열 마지막에 발견되는 글자입니다.</param>
        /// <param name="lastCharHaveJongseong">받침이 있을때 반환할 문자열입니다.</param>
        /// <param name="lastCharNotHaveJongseong">받침이 없을때 반환할 문자열입니다.</param>
        /// <returns>받침이 있으면 <c>lastCharHaveJongseong</c>를 반환하고, 없으면 <c>lastCharNotHaveJongseong</c>을 반환합니다.</returns>
        internal static string GenericJosaRule(Phoneme phoneme, string lastCharHaveJongseong, string lastCharNotHaveJongseong)
        {
            if (phoneme.finalConsonantNumber == 0)
                return lastCharNotHaveJongseong;
            else
                return lastCharHaveJongseong;
        }
    }
    /// <summary>
    /// 조사와 관련된 메서드에 대한 조사의 종류를 정의합니다.
    /// </summary>
    public enum 조사종류
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
