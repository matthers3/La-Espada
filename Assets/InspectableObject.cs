using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(TriggerEmission))]
public class InspectableObject : MonoBehaviour
{
    private TriggerEmission objectSelector;
    private Vector3 originalPosition;
    private Vector3 originalRotation;

    void Start() {
        objectSelector = GetComponent<TriggerEmission>();
        originalPosition = transform.localPosition;
        originalRotation = transform.eulerAngles;
    }

    void LateUpdate() {
        if (Input.GetMouseButtonDown(0) && objectSelector.isSelected) {
            objectSelector.isSelectable = false;
            GetComponent<Collider>().enabled = false;
            var targetTransform = GameObject.Find("ObjectPositionPivot").transform;
            transform.parent = targetTransform;
            transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.OutQuart);

        } else if (Input.GetMouseButtonDown(0) && !objectSelector.isSelectable) {
            var targetTransform = GameObject.Find("Objects").transform;
            transform.parent = targetTransform;
            transform.DOLocalMove(originalPosition, 0.5f).SetEase(Ease.OutQuart);
            transform.DORotate(originalRotation, 0.5f).SetEase(Ease.OutQuart);
        }
    }


}
