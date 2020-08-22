using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    [SerializeField] private GameObject _pointerPrefab;
    [SerializeField] private Button _helpButton;

    private void Update()
    {
        if (_pointerPrefab.transform.position.x == transform.position.x)
        {
            _helpButton.enabled = false;

        }
        else if(_pointerPrefab.transform.position.x != transform.position.x)
        {
            _helpButton.enabled= true;
        }
    }
}
