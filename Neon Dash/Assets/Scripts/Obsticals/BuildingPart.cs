using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPart : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] renderParts = null;

    public void SetColorOfPart(int partNum, Color newColor)
    {
        renderParts[partNum].color = newColor;
    }
}
