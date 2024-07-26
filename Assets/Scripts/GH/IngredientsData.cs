using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IngredientsData : MonoBehaviour
{
    public string csvFilePath = "Assets/Resources/IngredientData/IngredientData.csv";
    private Dictionary<string, Vector2> ingredientOffsets;

    private void Awake()
    {
        LoadCSVData();
        Vector2 onionOffset = GetIngredientOffset("Onion");
        Debug.Log($"Onion Offset: {onionOffset}");
    }

    private void LoadCSVData()
    {
        ingredientOffsets = new Dictionary<string, Vector2>();


        try
        {
            string[] lines = File.ReadAllLines(csvFilePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                if (values.Length == 3)
                {
                    string ingredient = values[0];
                    float offsetX = float.Parse(values[1]);
                    float offsetY = float.Parse(values[2]);
                    ingredientOffsets.Add(ingredient, new Vector2(offsetX, offsetY));
                }
                else
                {
                    Debug.LogWarning("��ȿ���� ���� ������ ����");
                }

            }
        }
        catch (IOException e)
        {

            Debug.LogError("csv������ ���� �� ����");
        }
    }

    public Vector2 GetIngredientOffset(string ingredient)
    {
        if(ingredientOffsets.TryGetValue(ingredient,out Vector2 offset))
        {
            return offset;
        }
        else
        {
            Debug.LogWarning("�����͸� ã�� �� ����");
            return Vector2.zero;
        }
    }
}