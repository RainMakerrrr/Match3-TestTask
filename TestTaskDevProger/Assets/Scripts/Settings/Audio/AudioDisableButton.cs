using UnityEngine;
using UnityEngine.UI;

public class AudioDisableButton : MonoBehaviour
{
    private Button _enableMusicButton;

    private void Start()
    {
        _enableMusicButton = GetComponent<Button>();

        _enableMusicButton.onClick.AddListener(AudioManager.Instance.DisableMusic);
    }
}
