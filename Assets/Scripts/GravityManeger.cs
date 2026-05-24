using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityManager : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            default:
                Physics.gravity = Vector3.zero;
                break;
            case "FaseLua":
                Physics.gravity = new Vector3(0f, -1.62f, 0f);
                break;
            case "FaseTerra":
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
                break;
            case "FaseMarte":
                Physics.gravity = new Vector3(0f, -3.72f, 0f);
                break;
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}