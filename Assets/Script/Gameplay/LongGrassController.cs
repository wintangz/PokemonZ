using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongGrassController : MonoBehaviour
{
    public GameObject longGrass;
    public BoxCollider2D playerCollider;
    Collider2D[] longGrassColliders;

    // Start is called before the first frame update
    void Start()
    {
        longGrassColliders = longGrass.GetComponents<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerCollider)
        {
            // The player has collided with one of the longGrass trigger colliders
            Debug.Log("Player entered long grass!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerCollider)
        {
            // The player has exited one of the longGrass trigger colliders
            Debug.Log("Player exited long grass!");
        }
    }
}
