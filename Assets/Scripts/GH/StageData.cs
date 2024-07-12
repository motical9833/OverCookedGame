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

    public StageInfo(string stageName, int score, bool isCleared, bool isAble)
    {
        this.stageName = stageName;
        this.score = score;
        this.isCleared = isCleared;
        this.isAble = isAble;
    }
}