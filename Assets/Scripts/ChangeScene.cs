using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Llama a esta funci�n desde un bot�n u otro evento
    public void LoadScene(string nameScene)
    {
       SceneManager.LoadScene(nameScene);
    }
}