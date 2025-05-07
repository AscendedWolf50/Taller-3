using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    public void LoadFactoryScene()
    {
        SceneManager.LoadScene("FactoryScene");
    }
}
