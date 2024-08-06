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

    public StageInfo()
    {
        this.stageName = null;
        this.score = 0;
        this.isCleared = false;
        this.isAble = false;
        this.goals = new int[] { 20, 40, 60 };
    }

    public StageInfo(string stageName, int score, bool isCleared, bool isAble = false, int[] goals = null)
    {
        this.stageName = stageName;
        this.score = score;
        this.isCleared = isCleared;
        this.isAble = isAble;

        this.goals = goals ?? new int[] { 20, 40, 60 };
    }
}