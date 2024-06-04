using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { OpenWorld, Battle, Dialog }

public class GameController : MonoBehaviour
{
    GameState state;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.OpenWorld)
        {

        }
        else if (state == GameState.Battle)
        {

        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
    }
}
