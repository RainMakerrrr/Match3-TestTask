using UnityEngine;
using UnityEngine.UI;

public class AudioEnableButton : MonoBehaviour
{
    private Button _disableMusicButton;

    private void Start()
    {
        _disableMusicButton = GetComponent<Button>();

        _disableMusicButton.onClick.AddListener(AudioManager.Instance.EnableMusic);
    }
}
