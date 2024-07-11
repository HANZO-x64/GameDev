using TMPro;
using UnityEngine;

public class SaveRecord : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private TMP_Text AbsolutRecord;

    private void Update()
    {
        AbsolutRecord.text = PlayerPrefs.GetInt("HighestRecordInGame").ToString();
    }
}
