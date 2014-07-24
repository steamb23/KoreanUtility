using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamB23.KoreanUtility;

namespace KoreanUtilityTest
{
    [TestClass]
    public class StringExtenderTest
    {
        [TestMethod]
        public void AppendPostposition()
        {
            Assert.AreEqual<string>("사과".AppendJosa(Josa.JosaType.EN) + " 맛있다.", "사과는 맛있다.");
            Assert.AreEqual<string>("단감".AppendJosa(Josa.JosaType.EN) + " 맛있다.", "단감은 맛있다.");

            Assert.AreEqual<string>("사과".AppendJosa(Josa.JosaType.IG) + " 좋다.", "사과가 좋다.");
            Assert.AreEqual<string>("단감".AppendJosa(Josa.JosaType.IG) + " 좋다.", "단감이 좋다.");

            Assert.AreEqual<string>("사과".AppendJosa(Josa.JosaType.ER) + " 먹는다.", "사과를 먹는다.");
            Assert.AreEqual<string>("단감".AppendJosa(Josa.JosaType.ER) + " 먹는다.", "단감을 먹는다.");

            Assert.AreEqual<string>("사과".AppendJosa(Josa.JosaType.GW) + " 귤.", "사과와 귤.");
            Assert.AreEqual<string>("단감".AppendJosa(Josa.JosaType.GW) + " 귤.", "단감과 귤.");

            Assert.AreEqual<string>("사과".AppendJosa(Josa.JosaType.AY) + ", 넌 어찌 이리도 맛있니.", "사과야, 넌 어찌 이리도 맛있니.");
            Assert.AreEqual<string>("단감".AppendJosa(Josa.JosaType.AY) + ", 넌 어찌 이리도 맛있니.", "단감아, 넌 어찌 이리도 맛있니.");

            Assert.AreEqual<string>("사과".AppendJosa(Josa.JosaType.IYY) + ", 그대는 먹히기 위한 존재.", "사과여, 그대는 먹히기 위한 존재.");
            Assert.AreEqual<string>("단감".AppendJosa(Josa.JosaType.IYY) + ", 그대는 먹히기 위한 존재.", "단감이여, 그대는 먹히기 위한 존재.");

            Assert.AreEqual<string>("사과".AppendJosa(Josa.JosaType.IDD) + "다.", "사과다.");
            Assert.AreEqual<string>("단감".AppendJosa(Josa.JosaType.IDD) + "다.", "단감이다.");

            Assert.AreEqual<string>("사과".AppendJosa(Josa.JosaType.IDD) + " 장난치지마.", "사과로 장난치지마.");
            Assert.AreEqual<string>("단감".AppendJosa(Josa.JosaType.IDD) + " 장난치지마.", "단감으로 장난치지마.");

            Assert.AreEqual<string>("ABC".AppendJosa(Josa.JosaType.EN) + " 글자다.", "ABC은 글자다.");
            Assert.AreEqual<string>(Josa.AppendJosa("나", Josa.JosaType.EN) + " 테스트 중이다.", "나는 테스트 중이다.");
        }
    }
}
