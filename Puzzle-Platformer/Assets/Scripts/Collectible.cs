using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float MoveAmplitute = 0.15f;
    public float MoveSpeed = 0.5f;
    public float RotationSpeed = 45;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * MoveSpeed) * MoveAmplitute * Time.deltaTime, transform.position.z);
    }
}
