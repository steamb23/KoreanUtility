KoreanUtility
=============

**KoreanUtility**는 C#에서 사용할 수 있는 한국어 관련 유틸리티를 제공합니다.

## 특징

- '은/는', '이/가', '을/를', '과/와', '아/야', '이다/다', '으로/로' 등의 세세한 조사 처리 지원.
- String, StringBuilder 확장 메서드 지원.

## 사용 예제

### 조사 처리

``` C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KoreanUtility;

namespace KoreanUtilityExample
{
    public static class JosaExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("사과".AppendJosa(JosaType.EN)+" 빨간색.");
        }
    }
}
```
결과 : 사과는 빨간색.
