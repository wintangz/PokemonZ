using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsstentialObjectsSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject essentialObjectsPrefab;

    private void Awake()
    {
        var existingObjects = FindObjectsOfType<EssentialObjects>();
        if(existingObjects.Length == 0 )
            Instantiate(essentialObjectsPrefab, new Vector3(0,0,0), Quaternion.identity);
    }
}
