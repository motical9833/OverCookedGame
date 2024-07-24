using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTextureSetting : MonoBehaviour
{

    private Vector2 offset = Vector2.zero;
    private Renderer skinnedMeshRenderer;
    private IngredientsData ingredientsData;
    private MaterialPropertyBlock propertyBlock;

    void Start()
    {
        ingredientsData = GameObject.FindWithTag("StageManager").GetComponent<IngredientsData>();
        offset = ingredientsData.GetIngredientOffset(this.name);
        skinnedMeshRenderer = gameObject.GetComponent<Transform>().GetChild(2).GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();


        skinnedMeshRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetVector("_MainTex_ST", new Vector4(0.5f, 0.5f, offset.x, offset.y));
        skinnedMeshRenderer.SetPropertyBlock(propertyBlock);
    }
}
