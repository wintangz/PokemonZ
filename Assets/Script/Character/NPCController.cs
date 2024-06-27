using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    public void Interact()
    {
        Debug.Log(dialog.Lines[0]);
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
