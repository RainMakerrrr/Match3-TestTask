using UnityEngine;
using UnityEngine.UI;

public class DetectionField : MonoBehaviour
{
    [SerializeField] private Image _correspondingImage;
    [SerializeField] private Button _correspongdingButton;

    private Button _detectionButton;
    private Image _detectionImage;

    private void Start()
    {
        _detectionButton = GetComponent<Button>();
        _detectionImage = GetComponent<Image>();

        _detectionButton.onClick.AddListener(DetectCoincidence);   
    }

    private void DetectCoincidence()
    {
        _detectionImage.color = Color.green;
        _correspondingImage.color = Color.green;

        _detectionButton.enabled = false;
        _correspongdingButton.enabled = false;

        Counter.Instance.CurrentScore += 1000;
        Counter.Instance.RemoveFromList(this, _correspondingImage.gameObject.GetComponent<DetectionField>());
        
    }
}

