using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpin : MonoBehaviour
{   
    [SerializeField] private float speed = 5f;

    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * (-speed), 0));
    }
}
