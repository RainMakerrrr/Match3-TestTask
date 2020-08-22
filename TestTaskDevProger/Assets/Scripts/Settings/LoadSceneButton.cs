using UnityEngine;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    private Button _returnButton;

    private void Start()
    {
        _returnButton = GetComponent<Button>();

        _returnButton.onClick.AddListener(() => 
        {
            SceneLoader.Instance.LoadScene(_sceneIndex);
        });
    }
}
