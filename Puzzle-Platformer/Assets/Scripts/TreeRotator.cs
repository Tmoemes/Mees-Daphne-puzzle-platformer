using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRotator : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ChangeHeight = false;
    public float MaxHeightChange = 0.5f;
    public bool ChangeRotation = false;
    public float MaxRotationChange = 90f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RotateTrees()
    {
        // Get all child transforms of this game object
        Transform[] children = GetComponentsInChildren<Transform>();

        // Loop through each child and give it a random rotation
        foreach (Transform child in children)
        {
            if (child == transform) continue; // Skip the parent transform

            // Generate a random rotation for the child
            if (ChangeRotation)
            {
                child.rotation = Quaternion.Euler(0, Random.Range(-MaxRotationChange, MaxRotationChange), 0);
            }

            if (ChangeHeight)
            {
                child.position += new Vector3(0, Random.Range(-MaxHeightChange, MaxHeightChange), 0);
            }
        }
    }
}
