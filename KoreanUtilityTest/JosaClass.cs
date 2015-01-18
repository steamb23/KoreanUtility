using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamB23.KoreanUtility;
using SteamB23.KoreanUtility.Grammar;

namespace KoreanUtilityTest
{
    [TestClass]
    public class JosaClass
    {
        [TestMethod]
        public void 조사추가()
        {
            // 은/는
            Assert.AreEqual<string>("사과".조사추가(조사.은는) + " 맛있다.", "사과는 맛있다.");
            Assert.AreEqual<string>("단감".조사추가(조사.은는) + " 맛있다.", "단감은 맛있다.");
            // 이/가
            Assert.AreEqual<string>("사과".조사추가(조사.이가) + " 좋다.", "사과가 좋다.");
            Assert.AreEqual<string>("단감".조사추가(조사.이가) + " 좋다.", "단감이 좋다.");
            // 을/를
            Assert.AreEqual<string>("사과".조사추가(조사.을를) + " 먹는다.", "사과를 먹는다.");
            Assert.AreEqual<string>("단감".조사추가(조사.을를) + " 먹는다.", "단감을 먹는다.");
            // 와/과
            Assert.AreEqual<string>("사과".조사추가(조사.과와) + " 귤.", "사과와 귤.");
            Assert.AreEqual<string>("단감".조사추가(조사.과와) + " 귤.", "단감과 귤.");
            // 아/야
            Assert.AreEqual<string>("사과".조사추가(조사.아야) + ", 넌 어찌 이리도 맛있니.", "사과야, 넌 어찌 이리도 맛있니.");
            Assert.AreEqual<string>("단감".조사추가(조사.아야) + ", 넌 어찌 이리도 맛있니.", "단감아, 넌 어찌 이리도 맛있니.");
            // 이여/여
            Assert.AreEqual<string>("사과".조사추가(조사.이) + "여, 그대는 먹히기 위한 존재.", "사과여, 그대는 먹히기 위한 존재.");
            Assert.AreEqual<string>("단감".조사추가(조사.이) + "여, 그대는 먹히기 위한 존재.", "단감이여, 그대는 먹히기 위한 존재.");
            // 이다/다
            Assert.AreEqual<string>("사과".조사추가(조사.이) + "다.", "사과다.");
            Assert.AreEqual<string>("단감".조사추가(조사.이) + "다.", "단감이다.");
            // 으로/로
            Assert.AreEqual<string>("사과".조사추가(조사.으로) + " 장난치지마.", "사과로 장난치지마.");
            Assert.AreEqual<string>("단감".조사추가(조사.으로) + " 장난치지마.", "단감으로 장난치지마.");
            // 한글외 언어 인식 테스트
            Assert.AreEqual<string>("ABC".조사추가(조사.은는) + " 글자다.", "ABC은 글자다.");
            // Josa클래스 직접 사용
            Assert.AreEqual<string>(Josa.조사추가("나", 조사.은는) + " 테스트 중이다.", "나는 테스트 중이다.");
        }
    }
}
