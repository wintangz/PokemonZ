using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string nextScene;
    public BoxCollider2D gate;
    private PlayerController player;

    [SerializeField] Transform spawnPoint;
    [SerializeField] DestinationIdentifier destinationPortal;
    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null && playerObject.TryGetComponent(out PlayerController controller))
        {
            this.player = controller;
        }
        else
        {
            Debug.LogError("Player or PlayerController not found.");
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            player = other.gameObject.GetComponent<PlayerController>(); 
            if (player != null)
            {

                StartCoroutine(SwitchScenes());
            }
        }
    }

    IEnumerator SwitchScenes()
    {
        Transform parentTransform = transform.root;
        DontDestroyOnLoad(parentTransform.gameObject);
        yield return SceneManager.LoadSceneAsync(nextScene);
        var destPortal = FindObjectsOfType<SwitchScene>().FirstOrDefault(x => x != this && x.destinationPortal == destinationPortal);
        if (destPortal != null)
        {
            player.transform.position = destPortal.spawnPoint.position;
        }
        else
        {
            Debug.LogError("Destination portal not found.");
        }
        Destroy(parentTransform.gameObject);
    }
   


    public Transform SpawnPoint => spawnPoint;
}

public enum DestinationIdentifier { A, B, C, D, E, F }
