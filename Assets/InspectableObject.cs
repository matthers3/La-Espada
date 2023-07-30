using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Yarn.Unity;

[RequireComponent(typeof(TriggerEmission))]
public class InspectableObject : MonoBehaviour
{
    private TriggerEmission objectSelector;
    private Vector3 originalPosition;
    private Vector3 originalRotation;
    private RaySelector raySelector;
    private bool currentSelection = false;

    public string startNode = default;
    public bool interactionDone = false;
    public float mouseSensitivity = 2f;
    float objectVerticalRotation = 0f;

    void Start() {
        objectSelector = GetComponent<TriggerEmission>();
        originalPosition = transform.localPosition;
        originalRotation = transform.eulerAngles;
        raySelector = FindObjectOfType<RaySelector>();
    }

    void LateUpdate() {
        if (Input.GetMouseButtonDown(0) && objectSelector.isSelected) {
            objectSelector.isSelectable = false;
            var targetTransform = GameObject.Find("ObjectPositionPivot").transform;
            transform.parent = targetTransform;
            transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.OutQuart)
                .OnComplete(() => FindObjectOfType<DialogueRunner>().StartDialogue(startNode) );
            raySelector.inspecting = true;
            FindObjectOfType<FadingBackground>().toggleBackground(true);
        }
    }

    public void StartInteraction() {
        currentSelection = true;
    }

    public void EndInteraction() {
        var targetTransform = GameObject.Find("Objects").transform;
        transform.parent = targetTransform;
        transform.DOLocalMove(originalPosition, 0.5f).SetEase(Ease.OutQuart);
        transform.DORotate(originalRotation, 0.5f).SetEase(Ease.OutQuart);
        raySelector.inspecting = false;
        currentSelection = false;   
    }

    void Update()
    {
        // Collect Mouse Input
        if (currentSelection == false || interactionDone) {
            return;
        }

        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the Player Object and the Camera around its Y axis

        var parent = transform.parent;
        parent.localEulerAngles = new Vector3(0, 0, 0);

        parent.Rotate(Vector3.down * inputX + Vector3.right * inputY);
        var myRotation = gameObject.transform.rotation;

        parent.localEulerAngles = new Vector3(0, 0, 0);
        gameObject.transform.rotation = myRotation;       
    }


}
