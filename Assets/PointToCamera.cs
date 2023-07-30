using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointToCamera : MonoBehaviour
{
    [SerializeField] private bool fixSides = false;

    public GameObject Camera = default;
    protected Quaternion initialRotation;

    [Header("RotationSPeeds")]
    public Transform child;
    public float rotationTime = 0.5f;
    private bool lastWasLeft = false;
    private bool lastWasRight = false;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    protected void Update()
    {   

        Quaternion toRotate = Quaternion.RotateTowards(transform.rotation, Camera.transform.rotation, 1000 * Time.deltaTime);

        if (fixSides)
        {
            toRotate.z = 0;
            toRotate.y = 0;
        }
        transform.rotation = toRotate;
    }

    public void rotateLeft() {
        if (lastWasLeft) {
            return;
        }

        lastWasLeft = true;
        lastWasRight = false;
        DOTween.Kill("Player");
        child.DOLocalRotate(new Vector3(0f, 1f, 0f), rotationTime).SetId("Player");
    }

    public void rotateRight() {
        if (lastWasRight) {
            return;
        }

        lastWasLeft = false;
        lastWasRight = true;
        DOTween.Kill("Player");
        child.DOLocalRotate(new Vector3(0f, 179f, 0f), rotationTime).SetId("Player");
    }
}
