using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int NumberScene;
    public void LoadScene(int NumberScene)
    {
        Debug.Log("Transition to stage -> " + NumberScene);
        SceneManager.LoadScene(NumberScene);
    }
}
