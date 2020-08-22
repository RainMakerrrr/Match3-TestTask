using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    
    private int _unlockedLevels;

    public static LevelManager Instance;

    private void Awake()
    {
        if (!Instance) Instance = this;

        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _unlockedLevels = PlayerPrefs.GetInt("Level", 1);
        DontDestroyOnLoad(this);

        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
            var parentButton = _buttons[i].transform.parent.GetComponent<Button>();
            parentButton.interactable = false;
        }

        for (int i = 0; i < _unlockedLevels; i++)
        {
            _buttons[i].interactable = true;
            var parentButton = _buttons[i].transform.parent.GetComponent<Button>();
            parentButton.interactable = true;
        }
    }

    public void PassLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("Level"))
        {
            PlayerPrefs.SetInt("Level", currentLevel + 1);
        }
    }

    public void ResetSaves()
    {
        PlayerPrefs.SetInt("Level", 1);

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }

        for (int i = 0; i < _unlockedLevels; i++)
        {
            _buttons[i].interactable = true;
        }

        SceneManager.LoadScene(4);
    }
}
