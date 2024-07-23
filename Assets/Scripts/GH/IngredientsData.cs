using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientsData", menuName = "ScriptableObjects/IngredientsData", order = 1)]
public class IngredientsData : ScriptableObject
{
    private Vector2 burgerBun = Vector2.zero;
    private Vector2 onionOffset = new Vector2(0.25f, 0.5f);


    public Vector2 GetOnionOffset()
    {
        return onionOffset;
    }
}
