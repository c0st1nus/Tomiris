using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using XNode;
using Button = UnityEngine.UI.Button;

public class Say : MonoBehaviour
{
    [SerializeField] private Dialogs dialogs;
    [SerializeField] private new GameObject name;
    [SerializeField] private GameObject text;
    public float delay = 0.1f;
    private bool _isTyping;
    [SerializeField] private Button[] buttons;
    private Player _player = new Player();
    [SerializeField] private Image playerImage;
    public Image background;
    [SerializeField] private TextMeshProUGUI EndText;

    private Node _dialog;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextDialog();
        }
    }

    public void NextDialog()
    {
        if (dialogs == null) return;
        DisActiveButtons();
        name.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        _dialog ??= dialogs.nodes.Find(node => node is StoryStartNode);
        if (!_isTyping)
        {
            switch (_dialog)
            {
                case StoryStartNode storyStartNode:
                    if(storyStartNode.background != null)
                    {
                        ChangeBackground(storyStartNode.background);
                    }
                    _dialog = storyStartNode.GetOutputPort("exit").Connection.node;
                    NextDialog();
                    break;
                case Dialog dialog:
                    ShowText(dialog.Text);
                    name.GetComponentInChildren<TextMeshProUGUI>().text = dialog.personage.name;
                    playerImage.sprite = dialog.personage.image;
                    playerImage.rectTransform.position = dialog.personagePosition.normalized;
                    break;
                case DialogStart dialogStart:
                    ShowText(dialogStart.Text);
                    name.GetComponentInChildren<TextMeshProUGUI>().text = dialogStart.personage.name;
                    playerImage.sprite = dialogStart.personage.image;
                    playerImage.rectTransform.position = dialogStart.personagePosition;
                    break;
                case Choise choise:
                    Choise(choise.choise);
                    break;
                case StatChange change:
                    ChangeStat(change._stats);
                    break;
                case StatCheck check:
                    StatCheck(check.conditions);
                    break;
                case BackGroundChange backGroundChange:
                    ChangeBackground(backGroundChange.background);
                    break;
                case StoryEndNode storyEndNode:
                    foreach (var v in buttons) { v.gameObject.SetActive(false); }
                    name.gameObject.SetActive(false);
                    text.gameObject.SetActive(false);
                    playerImage.gameObject.SetActive(false);
                    EndText.gameObject.SetActive(true);
                    print("End");
                    break;
            }
            
        }
        else
        {
            _isTyping = false;
            StopAllCoroutines();
            switch (_dialog)
            {
                case Dialog dialog:
                    text.GetComponentInChildren<TextMeshProUGUI>().text = dialog.Text;
                    name.GetComponentInChildren<TextMeshProUGUI>().text = dialog.personage.name;
                    break;
                case DialogStart dialogStart:
                    text.GetComponentInChildren<TextMeshProUGUI>().text = dialogStart.Text;
                    name.GetComponentInChildren<TextMeshProUGUI>().text = dialogStart.personage.name;
                    break;
            }
            if (_dialog.GetOutputPort("output").Connection != null)
            {
                _dialog = _dialog.GetOutputPort("output").Connection.node;
            }
        }
    }
    private void ShowText(string message)
    {
        StartCoroutine(TypeText(message));
    }
    IEnumerator TypeText(string message)
    {
        _isTyping = true;
        text.GetComponentInChildren<TextMeshProUGUI>().text = "";
        foreach (char c in message)
        {
            text.GetComponentInChildren<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(delay);
        }
        _isTyping = false;
        if (_dialog.GetOutputPort("output").Connection != null)
        {
            _dialog = _dialog.GetOutputPort("output").Connection.node;
        }
    }
    private void DisActiveButtons()
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false);
        }
        name.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
    }
    private void Choise(string[] choise)
    {
        name.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        if (choise.Length == 0) return;
        for (int i = 0; i < choise.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = choise[i];
        }
    }
    public void OnButtonClick(int index)
    {
        _dialog = _dialog.GetOutputPort($"choise {index}").Connection.node;
    }
    private void ChangeStat(Dict stats)
    {
        print("ChangeStat");
        if (stats?._dictElements != null)
        {
            foreach (var v in stats._dictElements)
            {
                switch (v.Key)
                {
                    case playerStats.Agility:
                        _player.Agility += v.Value;
                        break;
                    case playerStats.Charisma:
                        _player.Charisma += v.Value;
                        break;
                    case playerStats.Health:
                        _player.Health += v.Value;
                        break;
                    case playerStats.Intellect:
                        _player.Intellect += v.Value;
                        break;
                    case playerStats.Reputation:
                        _player.Reputation += v.Value;
                        break;
                    case playerStats.Luck:
                        _player.Luck += v.Value;
                        break;
                    case playerStats.Strength:
                        _player.Strength += v.Value;
                        break;
                }
            }
        }

        // ReSharper disable once Unity.NoNullPropagation
        if (_dialog?.GetOutputPort("output")?.Connection != null)
        {
            _dialog = _dialog.GetOutputPort("output").Connection.node;
        }
        NextDialog();
    }
    private void StatCheck(condition[] stats)
    {
        print("statCheck");
        bool result = false;
        foreach (var v in stats)
        {
            switch (v.conditionType)
            {
                case equality.equal:
                    result = _player[v.stat] == v.value;
                    break;
                case equality.notEqual:
                    result = _player[v.stat] != v.value;
                    break;
                case equality.less:
                    result = _player[v.stat] < v.value;
                    break;
                case equality.greater:
                    result = _player[v.stat] > v.value;
                    break;
                case equality.lessOrEqual:
                    result = _player[v.stat] <= v.value;
                    break;
                case equality.greaterOrEqual:
                    result = _player[v.stat] >= v.value;
                    break;
            }
        }
        _dialog = result ? _dialog.GetOutputPort("trueOutput").Connection.node : _dialog.GetOutputPort("falseOutput").Connection.node;
        NextDialog();
    }
    private void ChangeBackground(Sprite sprite)
    {
        background.sprite = sprite;
        _dialog = _dialog.GetOutputPort("output").Connection.node;
        NextDialog();
    }
}
