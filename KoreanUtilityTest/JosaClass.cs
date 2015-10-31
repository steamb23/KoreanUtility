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
        public void 은_는()
        {
            Assert.AreEqual("사과".조사추가(조사종류.은는) + " 맛있다.", "사과는 맛있다.");
            Assert.AreEqual("단감".조사추가(조사종류.은는) + " 맛있다.", "단감은 맛있다.");
        }
        [TestMethod]
        public void 이_가()
        {
            Assert.AreEqual("사과".조사추가(조사종류.이가) + " 좋다.", "사과가 좋다.");
            Assert.AreEqual("단감".조사추가(조사종류.이가) + " 좋다.", "단감이 좋다.");
        }
        [TestMethod]
        public void 을_를()
        {
            Assert.AreEqual("사과".조사추가(조사종류.을를) + " 먹는다.", "사과를 먹는다.");
            Assert.AreEqual("단감".조사추가(조사종류.을를) + " 먹는다.", "단감을 먹는다.");
        }
        [TestMethod]
        public void 와_과()
        {
            Assert.AreEqual("사과".조사추가(조사종류.과와) + " 귤.", "사과와 귤.");
            Assert.AreEqual("단감".조사추가(조사종류.과와) + " 귤.", "단감과 귤.");
        }
        [TestMethod]
        public void 아_야()
        {
            Assert.AreEqual("사과".조사추가(조사종류.아야) + ", 넌 어찌 이리도 맛있니.", "사과야, 넌 어찌 이리도 맛있니.");
            Assert.AreEqual("단감".조사추가(조사종류.아야) + ", 넌 어찌 이리도 맛있니.", "단감아, 넌 어찌 이리도 맛있니.");
        }
        [TestMethod]
        public void 이여_여()
        {
            Assert.AreEqual("사과".조사추가(조사종류.이) + "여, 그대는 먹히기 위한 존재.", "사과여, 그대는 먹히기 위한 존재.");
            Assert.AreEqual("단감".조사추가(조사종류.이) + "여, 그대는 먹히기 위한 존재.", "단감이여, 그대는 먹히기 위한 존재.");
        }
        [TestMethod]
        public void 이다_다()
        {
            Assert.AreEqual("사과".조사추가(조사종류.이) + "다.", "사과다.");
            Assert.AreEqual("단감".조사추가(조사종류.이) + "다.", "단감이다.");
        }
        [TestMethod]
        public void 으로_로()
        {
            Assert.AreEqual("사과".조사추가(조사종류.으로) + " 장난치지마.", "사과로 장난치지마.");
            Assert.AreEqual("물".조사추가(조사종류.으로) + " 장난치지마.", "물로 장난치지마.");
            Assert.AreEqual("연근".조사추가(조사종류.으로) + " 장난치지마.", "연근으로 장난치지마.");
            Assert.AreEqual("단감".조사추가(조사종류.으로) + " 장난치지마.", "단감으로 장난치지마.");
        }
        [TestMethod]
        public void 한글외_언어_인식()
        {
            Assert.AreEqual("ABC".조사추가(조사종류.은는) + " 알파벳이다.", "ABC은 알파벳이다.");
        }
        [TestMethod]
        public void 문자처리()
        {
            Assert.AreEqual(조사.문자처리("영희{은는} 배{이가} 아파서 아버지{와과} 함께 병원{으로} 향했다."),"영희는 배가 아파서 아버지와 함께 병원으로 향했다.");
        }
    }
}
