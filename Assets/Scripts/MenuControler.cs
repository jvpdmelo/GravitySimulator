using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void CarregarFase(string nomeFase)
    {
        switch (nomeFase)
        {
            case "Menu":
                SceneManager.LoadScene(0);
                break;

            case "Terra":
                SceneManager.LoadScene(1);
                break;

            case "Lua":
                SceneManager.LoadScene(2);
                break;

            case "Marte":
                SceneManager.LoadScene(3);
                break;

            default:
                Debug.LogWarning("Fase não encontrada");
                break;
        }
    }
}
