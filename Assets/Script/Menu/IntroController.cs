using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum IntroState { Intro, ProfOakDialog, ProfOakDialog2, RedDialog, LeafDialog, BlueDialog };

public class IntroController : MonoBehaviour
{
  [SerializeField] List<string> lines;
  [SerializeField] Dialog profOakDialog;
  [SerializeField] GameObject dialogBox;

  IntroState state;

  void Awake()
  {
    profOakDialog.AddLines(lines);
    dialogBox.SetActive(false);
    state = IntroState.Intro;
  }

  void Start()
  {
  }

  void Update()
  {
    if (state == IntroState.Intro)
    {
      if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
      {
        dialogBox.SetActive(true);
        StartCoroutine(DialogManager.Instance.ShowDialog(profOakDialog));
        state = IntroState.ProfOakDialog;
      }
    }
    else if (state == IntroState.ProfOakDialog)
    {
      DialogManager.Instance.HandleUpdate();
    }
  }

  private void LoadNextScene()
  {
    SceneManager.LoadSceneAsync(2);
  }
}
