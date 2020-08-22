using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private void Awake()
    {
        if (!Instance) Instance = this;

        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }


    public void LoadScene(int index) => SceneManager.LoadScene(index);
}
