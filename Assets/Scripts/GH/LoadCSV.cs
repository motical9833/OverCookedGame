using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class LoadCSV<T>
{
    private string csvFilePath;
    T loadData;

    LoadCSV(T data)
    {
        loadData = data;
    }

    public string FilePath
    {
        get { return csvFilePath; }
        set { csvFilePath = FilePath; }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
