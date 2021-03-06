﻿using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamB23.KoreanUtility;
using SteamB23.KoreanUtility.Grammar;
using SteamB23.KoreanUtility.Hangul;

namespace KoreanUtilityTest
{
    [TestClass]
    public class JosaClass
    {
        [TestInitialize]
        public void Initalize()
        {
            조사.정규식컴파일();
        }
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
        public void 으로_로()
        {
            Assert.AreEqual("사과".조사추가(조사종류.으로) + " 장난치지마.", "사과로 장난치지마.");
            Assert.AreEqual("물".조사추가(조사종류.으로) + " 장난치지마.", "물로 장난치지마.");
            Assert.AreEqual("연근".조사추가(조사종류.으로) + " 장난치지마.", "연근으로 장난치지마.");
            Assert.AreEqual("단감".조사추가(조사종류.으로) + " 장난치지마.", "단감으로 장난치지마.");
        }
        [TestMethod]
        public void 이_()
        {
            Assert.AreEqual("사과".조사추가(조사종류.이) + "다.", "사과다.");
            Assert.AreEqual("단감".조사추가(조사종류.이) + "다.", "단감이다.");
        }
        [TestMethod]
        public void 이에_예()
        {
            Assert.AreEqual("사과".조사추가(조사종류.이에) + "요.", "사과예요.");
            Assert.AreEqual("단감".조사추가(조사종류.이에) + "요.", "단감이에요.");
        }
        [TestMethod]
        public void 이어_여()
        {
            Assert.AreEqual("사과".조사추가(조사종류.이어) + "서 다행이다.", "사과여서 다행이다.");
            Assert.AreEqual("단감".조사추가(조사종류.이어) + "서 다행이다.", "단감이어서 다행이다.");
        }
        [TestMethod]
        public void 이었_였()
        {
            Assert.AreEqual("사과".조사추가(조사종류.이었) + "다.", "사과였다.");
            Assert.AreEqual("단감".조사추가(조사종류.이었) + "다.", "단감이었다.");
        }
        [TestMethod]
        public void 한글외_언어_인식()
        {
            Assert.AreEqual("ABC".조사추가(조사종류.은는) + " 알파벳이다.", "ABC은 알파벳이다.");
        }
        [TestMethod]
        public void 문자처리_단문()
        {
            Assert.AreEqual(조사.문자처리("영희[은는] 배고프다."), "영희는 배고프다.");
        }
        [TestMethod]
        public void 문자처리_중문()
        {
            Assert.AreEqual(조사.문자처리("영희[은는] 배[이가] 아파서 아버지[와과] 함께 병원[으로] 향했다."),"영희는 배가 아파서 아버지와 함께 병원으로 향했다.");
        }
        [TestMethod]
        public void 문자처리_장문()
        {
            Assert.AreEqual(조사.문자처리(@"킹 조지 섬[은는] 남극의 사우스 셰틀랜드 제도에 속하는 섬이다. 크기[은는] 제주도의 반 정도[이]고, 실제로 녹은 지역[은는] 8.4㎢정도. 500여 명의 사람들이 거주(?)하고 있다. 세종과학기지[이가] 이 섬에 위치하고 있다. 구글 어스

1819년 영국인들[이가] 이 섬[을를] 발견하고 영유권[을를] 주장했고 1940년 칠레[이가], 1943년엔 아르헨티나도 이 섬의 영유권[을를] 주장했으나 모두 인정받지 못하고 있다.[1] 대한민국, 아르헨티나, 브라질, 칠레, 중화인민공화국, 에콰도르, 페루, 폴란드, 러시아, 우루과이의 기지[이가] 있고 인구 밀도도 1km²당 0.5명 정도로 남극에선 가장 번화한(?) 곳 중 하나라 할 수 있다.또한 교회도 있고 온실도 있다.

기후도 남극에서 가장 따뜻해 8월 평균기온 - 6.8℃, 2월 평균기온 1.1℃로(남반구라서 계절이 반대) 겨울에도 대관령 정도까지만 내려가는 따뜻한 날씨를 보인다.남위 60도 정도의 사실상 아남극권에 가까운 지역[이]라 본격적인 빙하 및 남극연구에는 제약이 따른다. 1988년 당시 쇄빙선[이가] 없는 한국[이가] 세울 수 있던 유일한 남극기지.아무래도 접근성[이가] 있다보니 여러나라 기지[이가] 옹기종기 모여있다.

여기서 킹 조지 섬의 오늘 날씨[을를] 확인해 보자.

1박 2일 시즌1 에서 남극특집으로 이곳을 방문하려 하였으나, 중간에 반드시 들러야 하는 칠레에서 지진이 나는 바람에 무기한 연기되었다.방송사고, 참사 나느니 연기된게 다행이다 현재 시즌1의 멤버들 및 주요 스태프들이 하차하고 난 이후에는 유야무야 무산된 모양."), @"킹 조지 섬은 남극의 사우스 셰틀랜드 제도에 속하는 섬이다. 크기는 제주도의 반 정도고, 실제로 녹은 지역은 8.4㎢정도. 500여 명의 사람들이 거주(?)하고 있다. 세종과학기지가 이 섬에 위치하고 있다. 구글 어스

1819년 영국인들이 이 섬을 발견하고 영유권을 주장했고 1940년 칠레가, 1943년엔 아르헨티나도 이 섬의 영유권을 주장했으나 모두 인정받지 못하고 있다.[1] 대한민국, 아르헨티나, 브라질, 칠레, 중화인민공화국, 에콰도르, 페루, 폴란드, 러시아, 우루과이의 기지가 있고 인구 밀도도 1km²당 0.5명 정도로 남극에선 가장 번화한(?) 곳 중 하나라 할 수 있다.또한 교회도 있고 온실도 있다.

기후도 남극에서 가장 따뜻해 8월 평균기온 - 6.8℃, 2월 평균기온 1.1℃로(남반구라서 계절이 반대) 겨울에도 대관령 정도까지만 내려가는 따뜻한 날씨를 보인다.남위 60도 정도의 사실상 아남극권에 가까운 지역이라 본격적인 빙하 및 남극연구에는 제약이 따른다. 1988년 당시 쇄빙선이 없는 한국이 세울 수 있던 유일한 남극기지.아무래도 접근성이 있다보니 여러나라 기지가 옹기종기 모여있다.

여기서 킹 조지 섬의 오늘 날씨를 확인해 보자.

1박 2일 시즌1 에서 남극특집으로 이곳을 방문하려 하였으나, 중간에 반드시 들러야 하는 칠레에서 지진이 나는 바람에 무기한 연기되었다.방송사고, 참사 나느니 연기된게 다행이다 현재 시즌1의 멤버들 및 주요 스태프들이 하차하고 난 이후에는 유야무야 무산된 모양.");
        }
        [TestMethod]
        public void 문자처리_Format()
        {
            Assert.AreEqual(조사.문자처리("{0}[은는] {1}[이가] 아파서 {2}[와과] 함께 {3}[으로] 향했다.","영희","배","아버지","병원"), "영희는 배가 아파서 아버지와 함께 병원으로 향했다.");
        }
        [TestMethod]
        public void 문자조합()
        {
            Phoneme[] phonemes= PhonemeConverter.JamosToPhonomes("ㅇㅕㅇㅎㅢㅇㅑ ㅇㅏㄴㄴㅕㅇ? 넌 ㅈㅓㅇㅁㅏㄹ Sexy하구나.");
            StringBuilder resultStringBuilder = new StringBuilder();
            foreach (var phoneme in phonemes)
            {
                resultStringBuilder.Append(phoneme.source);
            }
            Assert.AreEqual(resultStringBuilder.ToString(), "영희야 안녕? 넌 정말 Sexy하구나.");
        }
    }
}
