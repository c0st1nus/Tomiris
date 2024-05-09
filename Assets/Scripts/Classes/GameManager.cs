using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityFigmaBridge.Runtime.UI;

public class GameManager : MonoBehaviour
{
    public static Dialogs currentStory;
    public TMP_Text balance;
    public TMP_Text lives;
    public TMP_Text uid;
    public TMP_Text usernameText;
    public Dialogs testStory;
    public InputField username;
    public InputField password;
    private static User _user = new User();
    public void Start()
    {
        DataBaseHandler db = gameObject.GetComponent<DataBaseHandler>() == null
            ? gameObject.AddComponent<DataBaseHandler>()
            : gameObject.GetComponent<DataBaseHandler>();
        
        // var prototypeFlowController =
        //     GetComponentInParent<Canvas>().rootCanvas?.GetComponent<PrototypeFlowController>();
        // if (prototypeFlowController != null &&
        //     prototypeFlowController.CurrentScreenInstance.name != "iPhone 13 & 14 - 13" &&
        //     prototypeFlowController.CurrentScreenInstance.name != "iPhone 13 & 14 - 14")
        // {
        //     try
        //     {
        //         String message = PlayerPrefs.GetString("username");
        //         var db = gameObject.GetComponent<DataBaseHandler>() == null
        //             ? gameObject.AddComponent<DataBaseHandler>()
        //             : gameObject.GetComponent<DataBaseHandler>();
        //         print("playerprefs: " + message);
        //         Data[] res = db.Select($"SELECT * FROM users WHERE username = '{message}'");
        //         print(res[0]);
        //         _user = new User(res[0].Username, res[0].Balance, res[0].Lives, res[0].UID);
        //         balance.text = _user.Balance.ToString();
        //         lives.text = _user.Lives.ToString();
        //         if (uid != null) uid.text = _user.ID.ToUpper();
        //         if (usernameText != null) usernameText.text = _user.Username;
        //     }
        //     catch (Exception)
        //     {
        //         if (prototypeFlowController != null) prototypeFlowController.TransitionToScreenById("13");
        //     }
        // }
    }

    public void HandleDropdownChangeRu(int value)
    {
        var prototypeFlowController =
            GetComponentInParent<Canvas>().rootCanvas?.GetComponent<PrototypeFlowController>();
        switch (value)
        {
            case 0:
                if (prototypeFlowController != null) prototypeFlowController.TransitionToScreenById("4");
                break;
            case 1:
                if (prototypeFlowController != null) prototypeFlowController.TransitionToScreenById("8");
                break;
        }
    }
    public void HandleDropdownChangeKz(int value)
    {
        var prototypeFlowController =
            GetComponentInParent<Canvas>().rootCanvas?.GetComponent<PrototypeFlowController>();
        switch (value)
        {
            case 0:
                if (prototypeFlowController != null) prototypeFlowController.TransitionToScreenById("8");
                break;
            case 1:
                if (prototypeFlowController != null) prototypeFlowController.TransitionToScreenById("4");
                break;
        }
    }
    public void StartStory()
    {   
        currentStory = testStory;
        SceneManager.LoadScene("Story");
    }
    
    public void ExitApp()
    {
        PlayerPrefs.DeleteKey("username");
        Application.Quit();
    }

    public void Link(string url)
    {
        Application.OpenURL(url);
    }

    public void CheckUser()
    {
        // var prototypeFlowController =
        //     GetComponentInParent<Canvas>().rootCanvas?.GetComponent<PrototypeFlowController>();
        // var db = gameObject.GetComponent<DataBaseHandler>() == null
        //     ? gameObject.AddComponent<DataBaseHandler>()
        //     : gameObject.GetComponent<DataBaseHandler>();
        // Data[] data = db.Select($"SELECT * FROM users WHERE username = '{username.text}'");
        // try
        // {
        //     if (data[0].Password == password.text)
        //     {
        //         PlayerPrefs.SetString("username", username.text);
        //         if (prototypeFlowController != null) prototypeFlowController.TransitionToScreenById("1");
        //     }
        //     else
        //     {
        //         Debug.LogWarning("Wrong password");
        //     }
        // }
        // catch
        // {
        //     Debug.LogWarning("Invalid username");
        // }
    }
}

public class User
{
    public readonly string Username;
    public readonly int Balance;
    public readonly int Lives;
    public readonly string ID;
    public User(string username, int balance, int lives, string id)
    {
        this.Username = username;
        this.Balance = balance;
        this.Lives = lives;
        this.ID = id;
    }

    public User()
    {
        this.Username = null;
        this.Balance = 0;
        this.Lives = 0;
    }
}