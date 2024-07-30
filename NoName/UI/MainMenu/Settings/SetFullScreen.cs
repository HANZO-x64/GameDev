using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SetFullScreen : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown.value = 0;
    }

    public void EnableFullScreen(bool isFullScreen)
    {
        switch (dropdown.value)
        {
            case 0: isFullScreen = false; Debug.Log("isFullScreen = false");  break;
            case 1: isFullScreen = true; Debug.Log("isFullScreen = true"); break;
        }
        Screen.fullScreen = isFullScreen; 
    }
}
