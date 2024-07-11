using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Records")]
    public TMP_Text records;
    public static int GameRecord;
    private int hightRecord;

    private void Start()
    {
        GameRecord = 0;
    }
    private void Update()
    {
        RecordFunction();
    }

    private void RecordFunction()
    {
        hightRecord = GameRecord;
        records.text = GameRecord.ToString();

        if (PlayerPrefs.GetInt("HighestRecordInGame") <= hightRecord)
        {
            PlayerPrefs.SetInt("HighestRecordInGame", hightRecord);
        }
    }
}