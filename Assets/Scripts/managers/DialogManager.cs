using UnityEngine;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogPanel;
    [SerializeField]
    private List<KeyCode> closeKeys = new List<KeyCode> { KeyCode.Escape };

    private bool isDialogOpen = false;

    void Update()
    {
        if (isDialogOpen)
        {
            foreach (KeyCode key in closeKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    AudioManager.Instance.PlaySFX("thud");
                    HideDialog();
                    break;
                }
            }
        }
    }

    public void ShowDialog()
    {
        dialogPanel.SetActive(true);
        isDialogOpen = true;
    }

    public void HideDialog()
    {
        dialogPanel.SetActive(false);
        isDialogOpen = false;
    }
}
