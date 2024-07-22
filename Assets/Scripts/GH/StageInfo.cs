using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageInfo
{
    public string stageName;
    public int score;
    public bool isCleared;
    public bool isAble;
    public int[] goals = new int[3];

    public StageInfo(string stageName, int score, bool isCleared, bool isAble, int[] goals)
    {
        this.stageName = stageName;
        this.score = score;
        this.isCleared = isCleared;
        this.isAble = isAble;
        this.goals = goals;
    }
}