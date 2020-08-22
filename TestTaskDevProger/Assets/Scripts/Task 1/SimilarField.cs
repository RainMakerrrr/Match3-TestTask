using UnityEngine;
using UnityEngine.UI;

public class SimilarField : MonoBehaviour
{
    [SerializeField] private Image _sameField;
    [SerializeField] private Button _sameButton;
    private Image _selfImage;
    private Button _selfButton;

    private void Start()
    {
        _selfImage = GetComponent<Image>();
        _selfButton = GetComponent<Button>();

        _selfButton.onClick.AddListener(DetectSimilarFields);
    }

    private void DetectSimilarFields()
    { 
        _selfImage.color = Color.red;
        _sameField.color = Color.red;

        _selfButton.enabled = false;
        _sameButton.enabled = false;

        Counter.Instance.CurrentScore -= 500;
    }
}
