using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneButton : MonoBehaviour
{

    public void ChangeScene(string nombre)
    {
        SceneManager.LoadScene(nombre); // Carga la escena con el nombre especificado
    }
}
