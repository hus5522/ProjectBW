﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 고유한 character code 설정하는 class */
public class NpcParser
{
    /// <summary>
    /// 총 11개
    /// 주민1 = 1100 / 주민2 = 1101 / 아이1 = 1102 / 아이2 = 1103
    /// 왼쪽벤치 = 1104 / 오른쪽벤치 = 1105 / 이사 가고싶은 주민 = 1106
    /// 폴(커플1) = 1107 / 마리(커플2) = 1108
    /// 주민3 = 1109 / 주민4 = 1110
    /// 
    /// 총 12개
    /// 메르테 = 1000 / 안드렌 = 1001 / 체스미터 = 1002 / 멜리사 = 1003
    /// 프란체티 = 1004 / 레이나 = 1005 / 더글라스 = 1006 / 에고이스모 륑 = 1007
    /// 메그 륑 = 1008 / 아놀드 = 1009 / 발루아 = 1010 / 도모니아 여왕 = 1011
    /// </summary>
    /// <param name="characterCode"></param>
    /// <returns></returns>

    public string GetNpcName(string characterCode)
    {
        switch (characterCode)
        {
            case "1000":
                return "메르테";

            case "1001":
                return "안드렌";

            case "1002":
                return "체스미터";

            case "1003":
                return "멜리사";

            case "1004":
                return "프란체티";

            case "1005":
                return "레이나";

            case "1006":
                return "더글라스";

            case "1007":
                return "에고이스모 륑";

            case "1008":
                return "메그 륑";

            case "1009":
                return "아놀드";

            case "1010":
                return "발루아";

            case "1011":
                return "도모니아 여왕";

            case "1100":
                return "주민1";

            case "1101":
                return "주민2";

            case "1102":
                return "아이1";

            case "1103":
                return "아이2";

            case "1104":
                return "왼쪽벤치";

            case "1105":
                return "오른쪽벤치";

            case "1106":
                return "이사 가고싶은 주민";

            case "1107":
                return "폴(커플1)";

            case "1108":
                return "마리(커플2)";

            case "1109":
                return "주민3";

            case "1110":
                return "주민4";

            default:
                return null;
        }//switch()
    }
}
