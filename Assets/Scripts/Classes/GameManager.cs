using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityFigmaBridge.Runtime.UI;

public class GameManager : MonoBehaviour
{
    public static Dialogs currentstory;
    public Dialogs testStory;
    public void HandleDropdownChangeRu(int value)
    {
        var prototypeFlowController =
            GetComponentInParent<Canvas>().rootCanvas?.GetComponent<PrototypeFlowController>();
        switch (value)
        {
            case 0:
                prototypeFlowController.TransitionToScreenById("4");
                break;
            case 1:
                prototypeFlowController.TransitionToScreenById("8");
                break;
        }
    }
    public void HandleDropdownChangeKZ(int value)
    {
        var prototypeFlowController =
            GetComponentInParent<Canvas>().rootCanvas?.GetComponent<PrototypeFlowController>();
        switch (value)
        {
            case 0:
                prototypeFlowController.TransitionToScreenById("8");
                break;
            case 1:
                prototypeFlowController.TransitionToScreenById("4");
                break;
        }
    }
    public void StartStory()
    {   
        currentstory = testStory;
        SceneManager.LoadScene("Story");
    }
    
    public void exitApp()
    {
        Application.Quit();
    }
}
