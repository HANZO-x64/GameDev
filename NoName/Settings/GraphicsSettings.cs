using System;
using UnityEngine;
using UnityEngine.Events;

public class GraphicsSettings : MonoBehaviour
{
    public void SetQuyyyyality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
