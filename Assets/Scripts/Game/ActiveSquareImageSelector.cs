using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSquareImageSelector : MonoBehaviour
{
    public SquareTextureData squareTextureData;
    public bool updateImageOnReachedTreshold = false;

    private void OnEnable()
    {
        UpdateSquareColorBaseOnCurrentPoints();

        if (updateImageOnReachedTreshold)
            GameEvents.UpdateSquareColor += UpdateSquareColor;
    }

    private void OnDisable()
    {
        if (updateImageOnReachedTreshold)
            GameEvents.UpdateSquareColor -= UpdateSquareColor;
    }
    private void UpdateSquareColorBaseOnCurrentPoints()
    {
        foreach (var sqaureTexture in squareTextureData.activeSquareTextures)
        {
            if(squareTextureData.currentColor == sqaureTexture.squareColor)
            {
                GetComponent<Image>().sprite = sqaureTexture.texture;
            }
        }
    }
    private void UpdateSquareColor(Config.SquareColor color)
    {
        foreach (var squareTexture in squareTextureData.activeSquareTextures)
        {
            if(color == squareTexture.squareColor)
            {
                GetComponent<Image>().sprite = squareTexture.texture;
            }
        }
    }

}
