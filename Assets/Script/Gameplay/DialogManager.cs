using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;

    bool isTyping;
    int currentLine = 0;
    Dialog dialog;

    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDiaglog(dialog.Lines[0]));
    }

    public void HandleUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)) && !isTyping)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDiaglog(dialog.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogBox.SetActive(false);
                OnCloseDialog?.Invoke();
            }
        }
    }

    public IEnumerator TypeDiaglog(string dialog)
    {
        isTyping = true;
        dialogText.text = "";
        Debug.Log(dialog.ToCharArray().Length);

        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            if (!(letter.ToString() == " "))
            {
              yield return new WaitForSeconds(1f / lettersPerSecond);
            }
        }
        Debug.Log(dialogText.text);
        isTyping = false;
    }
}
