using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuFirst;
    [SerializeField] private GameObject menuSecond;
    [SerializeField] private bool transitionStatus;

    private void Awake()
    {
        menuFirst.SetActive(true);
        menuSecond.SetActive(false);
    }

    private void TransitionCheck(bool transitionStatus)
    {
        if (transitionStatus)
        {
            menuFirst.SetActive(false);
            menuSecond.SetActive(true);
        }
        else
        {
            menuFirst.SetActive(true);
            menuSecond.SetActive(false);
        }
    }

    public void NextMenu(bool transitionStatus)
    {
        TransitionCheck(transitionStatus);
    }
}
