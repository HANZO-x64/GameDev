using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenResolution : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    private void Start() { dropdown.value = 5; }

    public void ChangeScreenResolution()
    {
        switch (dropdown.value)
        {
            case 0: Screen.SetResolution(1280, 720, true); break;
            case 1: Screen.SetResolution(1280, 1024, true); break;
            case 2: Screen.SetResolution(1440, 900, true); break;
            case 3: Screen.SetResolution(1600, 900, true); break;
            case 4: Screen.SetResolution(1680, 1050, true); break;
            case 5: Screen.SetResolution(1920, 1080, true); break;
            case 6: Screen.SetResolution(2560, 1080, true); break;
            case 7: Screen.SetResolution(2560, 1440, true); break;
        }
    }

}
