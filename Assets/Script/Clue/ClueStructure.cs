﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueStructure
{
    private string[] specialNum; //S.no
    private string eventNum;  //E.no
    private int id;
    private string clueName;    //단서 이름(rewards)
    private string numOfAct;    //사건
    private string timeSlot;    //시간대   -> 단서에서 시간대가 여러개일 경우가 필요하다고 생각될 때 수정하기(1223)
    private string obtainPos1;  //획득 위치 1
    private string obtainPos2;  //획득 위치 2
    private string firstInfoOfClue;  //단서창 1번 내용
    private string description; //desc2
    private string obtainPos2_Code; // 획득 위치 2 코드

    private ObtainPosParser obtainPosParser;

    public ClueStructure()
    {
        obtainPosParser = new ObtainPosParser();
    }

    /*
    public ClueStructure(string specialNum, string eventNum, int id, string clueName, string timeSlot, 
        string obtainPos1, string obtainPos2, string desctiption)
    {
        SetSpecialNum(specialNum);
        SetEventNum(eventNum);
        SetId(id);
        SetClueName(clueName);
        SetTimeSlot(timeSlot);
        SetObtainPos1(obtainPos1);
        SetObtainPos2(obtainPos2);
        SetFirstInfoOfClue("");
        SetDesc(desctiption);
    }

    public ClueStructure(string specialNum, string eventNum, int id, string clueName, string timeSlot,
        string obtainPos1, string obtainPos2, string firstInfoOfClue, string desctiption)
    {
        SetSpecialNum(specialNum);
        SetEventNum(eventNum);
        SetId(id);
        SetClueName(clueName);
        SetTimeSlot(timeSlot);
        SetObtainPos1(obtainPos1);
        SetObtainPos2(obtainPos2);
        SetFirstInfoOfClue(firstInfoOfClue);
        SetDesc(desctiption);
    }
    */
    public int GetNumSpecialNum()
    {
        if (specialNum == null)
            return 0;
        else
            return specialNum.Length;
    }

    public string[] GetSpecialNum()
    {
        return specialNum;
    }

    public void SetSpecialNum(string[] specialNum)
    {
        this.specialNum = specialNum;
    }

    public string GetEventNum()
    {
        return eventNum;
    }

    public void SetEventNum(string eventNum)
    {
        this.eventNum = eventNum;
    }

    public int GetId()
    {
        return id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public string GetClueName()
    {
        return clueName;
    }

    public void SetClueName(string clueName)
    {
        this.clueName = clueName;
    }

    public string GetNumOfAct()
    {
        return numOfAct;
    }

    public void SetNumOfAct(string numOfAct)
    {
        this.numOfAct = numOfAct;
    }

    public string GetTimeSlot()
    {
        return timeSlot;
    }

    public void SetTimeSlot(string timeSlot)
    {
        this.timeSlot = timeSlot;
    }

    public string GetObtainPos1()
    {
        return obtainPos1.ToString();
    }

    public void SetObtainPos1(string[] obtainPos1)
    {
        /* parsing 해서 넣어야함*/
        this.obtainPos1 = obtainPosParser.ParsingObtainPos1(obtainPos1);
    }

    public string GetObtainPos2()
    {
        return this.obtainPos2.ToString();
    }

    public string GetObtainPos2Code()
    {
        return this.obtainPos2_Code;
    }

    public void SetObtainPos2(string obtainPos2)
    {
        /* parsing 해서 넣어야함*/
        this.obtainPos2_Code = obtainPos2;
        this.obtainPos2 = obtainPosParser.ParsingObtainPos2(obtainPos2);
    }

    public string GetFirstInfoOfClue()
    {
        if (firstInfoOfClue == null)
            return "";
        else
            return this.firstInfoOfClue;
    }

    public void SetFirstInfoOfClue(string firstInfoOfClue)
    {
        this.firstInfoOfClue = firstInfoOfClue;
    }

    public string GetDesc()
    {
        return this.description;
    }

    public void SetDesc(string desc)
    {
        this.description = desc;
    }

}
