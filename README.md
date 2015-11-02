KoreanUtility
=============

**KoreanUtility**는 C#에서 사용할 수 있는 한국어 관련 유틸리티를 제공합니다.

## 특징
- '은/는', '이/가', '을/를', '과/와', '아/야', '이다/다', '으로/로' 등의 세세한 조사 처리를 지원합니다.
- 한글과 함께 자주 쓰이는 클래스와 메서드는 한글로 표기하여 한영키 전환을 최소화 하였습니다.
- String, StringBuilder에 대한 확장 메서드를 지원합니다..
- 자소 분리 기능을 지원합니다.
- 호환 및 유니코드 자모 조합 기능을 지원합니다.
- 유니티용 라이브러리를 지원합니다.

## 사용 예제
사용 예제에 없는 KoreanUtility의 다른 기능들은 [단위테스트 코드](KoreaUtility/KoreanUtilityTest.JosaClass.cs)를 참고하세요.

### 조사 처리 (메서드 사용)

``` C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KoreanUtility.Grammar;

namespace KoreanUtilityExample
{
    public static class JosaExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("사과".조사추가(조사종류.은는)+" 빨간색.");
        }
    }
}
```
결과 : 사과는 빨간색.

### 조사 처리 (조사 기호 사용)

``` C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KoreanUtility.Grammar;

namespace KoreanUtilityExample
{
    public static class JosaExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(조사.문자처리("철수[은는] 영희[와과] 함께 영화[을를] 보고 싶어한다."));
            Console.WriteLine(조사.문자처리("영희[는은] 배[이가]아파서 화장실[으로] 들어갔다."));
        }
    }
}
```
결과 :
철수는 영희와 함께 영화를 보고 싶어한다.
영희는 배가 아파서 화장실로 들어갔다.
