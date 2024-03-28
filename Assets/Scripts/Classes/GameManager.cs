using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _storyPanel;
    public static Dialogs currentstory;
    public Dialogs testStory;
    [SerializeField] private GameObject blur;
    public void OnHistoryClick()
    {
        _storyPanel.SetActive(true);        
        blur.SetActive(true);
    }
    public void OutHistoryClick()
    {
        _storyPanel.SetActive(false);
        blur.SetActive(false);
    }
    public void OnPlayClick()
    {
        currentstory = testStory;
        SceneManager.LoadScene(1);
    }
    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
