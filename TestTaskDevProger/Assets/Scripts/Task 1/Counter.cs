using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Counter : MonoBehaviour
{
    public List<DetectionField> Differences = new List<DetectionField>();

    [SerializeField] private Text _count;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;


    private int _currentScore;
    private int _maxScore = 9999;
    
    public int CurrentScore
    {
        get { return _currentScore; }
        set { if(_currentScore < _maxScore && value < _maxScore) _currentScore = value; }
    }


    public static Counter Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Differences.AddRange(FindObjectsOfType<DetectionField>());
    }

    private void Update()
    {
        _count.text = CurrentScore.ToString();

        if (CurrentScore >= 5000)
        {
            _winPanel.SetActive(true);
            LevelManager.Instance.PassLevel();
            StartCoroutine(LoadMiniMapScene());
        }
        if(Differences.Count == 0 && CurrentScore != 5000)
        {
            _losePanel.SetActive(true);
            StartCoroutine(LoadMiniMapScene());
        }

    }

    private IEnumerator LoadMiniMapScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(4);
    }

    public void RemoveFromList(DetectionField firstDifferences, DetectionField secondDifferences)
    {
        Differences.Remove(firstDifferences);
        Differences.Remove(secondDifferences);
    }

}
