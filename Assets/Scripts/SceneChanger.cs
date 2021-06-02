using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneTo(int SceneNeeded)
    {
        SceneManager.LoadScene(SceneNeeded);
    }
}
