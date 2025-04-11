using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogPanel;

    [SerializeField]
    private List<KeyCode> closeKeys = new List<KeyCode> { KeyCode.Escape };

    [SerializeField]
    private List<KeyCode> openKeys = new List<KeyCode> { KeyCode.Escape };

    [SerializeField]
    private string buttonPressSound;

    public UnityEvent onDialogOpened;
    public UnityEvent onDialogClosed;

    private bool isDialogOpen = false;

    void Update()
    {
        if (!isDialogOpen)
        {
            foreach (KeyCode key in openKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    ShowDialog();
                    PlayButtonPressSound();
                    break;
                }
            }
        }
        else
        {
            foreach (KeyCode key in closeKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    PlayButtonPressSound();
                    HideDialog();
                    break;
                }
            }
        }
    }

    public void PlayButtonPressSound()
    {
        if (!string.IsNullOrEmpty(buttonPressSound))
        {
            AudioManager.Instance.PlaySFX(buttonPressSound);
        }
    }

    public void ChangeScene(string sceneName){
        SimpleSceneManager.Instance.LoadScene(sceneName);
    }

    public void ShowDialog()
    {
        dialogPanel.SetActive(true);
        isDialogOpen = true;
        onDialogOpened?.Invoke();
    }

    public void HideDialog()
    {
        dialogPanel.SetActive(false);
        isDialogOpen = false;
        onDialogClosed?.Invoke();
    }
}
