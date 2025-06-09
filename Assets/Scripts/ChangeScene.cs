using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Llama a esta función desde un botón u otro evento
    public void LoadScene(string nameScene)
    {
       SceneManager.LoadScene(nameScene);
    }
}