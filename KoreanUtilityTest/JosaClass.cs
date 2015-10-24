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
            Assert.AreEqual<string>("사과".조사추가(조사.은는) + " 맛있다.", "사과는 맛있다.");
            Assert.AreEqual<string>("단감".조사추가(조사.은는) + " 맛있다.", "단감은 맛있다.");
        }
        [TestMethod]
        public void 이_가()
        {
            Assert.AreEqual<string>("사과".조사추가(조사.이가) + " 좋다.", "사과가 좋다.");
            Assert.AreEqual<string>("단감".조사추가(조사.이가) + " 좋다.", "단감이 좋다.");
        }
        [TestMethod]
        public void 을_를()
        {
            Assert.AreEqual<string>("사과".조사추가(조사.을를) + " 먹는다.", "사과를 먹는다.");
            Assert.AreEqual<string>("단감".조사추가(조사.을를) + " 먹는다.", "단감을 먹는다.");
        }
        [TestMethod]
        public void 와_과()
        {
            Assert.AreEqual<string>("사과".조사추가(조사.과와) + " 귤.", "사과와 귤.");
            Assert.AreEqual<string>("단감".조사추가(조사.과와) + " 귤.", "단감과 귤.");
        }
        [TestMethod]
        public void 아_야()
        {
            Assert.AreEqual<string>("사과".조사추가(조사.아야) + ", 넌 어찌 이리도 맛있니.", "사과야, 넌 어찌 이리도 맛있니.");
            Assert.AreEqual<string>("단감".조사추가(조사.아야) + ", 넌 어찌 이리도 맛있니.", "단감아, 넌 어찌 이리도 맛있니.");
        }
        [TestMethod]
        public void 이여_여()
        {
            Assert.AreEqual<string>("사과".조사추가(조사.이) + "여, 그대는 먹히기 위한 존재.", "사과여, 그대는 먹히기 위한 존재.");
            Assert.AreEqual<string>("단감".조사추가(조사.이) + "여, 그대는 먹히기 위한 존재.", "단감이여, 그대는 먹히기 위한 존재.");
        }
        [TestMethod]
        public void 이다_다()
        {
            Assert.AreEqual<string>("사과".조사추가(조사.이) + "다.", "사과다.");
            Assert.AreEqual<string>("단감".조사추가(조사.이) + "다.", "단감이다.");
        }
        [TestMethod]
        public void 으로_로()
        {
            Assert.AreEqual<string>("사과".조사추가(조사.으로) + " 장난치지마.", "사과로 장난치지마.");
            Assert.AreEqual<string>("물".조사추가(조사.으로) + " 장난치지마.", "물로 장난치지마.");
            Assert.AreEqual<string>("연근".조사추가(조사.으로) + " 장난치지마.", "연근으로 장난치지마.");
            Assert.AreEqual<string>("단감".조사추가(조사.으로) + " 장난치지마.", "단감으로 장난치지마.");
        }
        [TestMethod]
        public void 한글외_언어_인식()
        {
            Assert.AreEqual<string>("ABC".조사추가(조사.은는) + " 알파벳이다.", "ABC은 알파벳이다.");
        }
    }
}
