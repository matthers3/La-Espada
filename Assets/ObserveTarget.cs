using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObserveTarget : MonoBehaviour
{

    [SerializeField] private UnityEvent onInteractionEnd;
    private InspectableObject inspectableObject;
    private RaySelector raySelector;

    void Start() {
        inspectableObject = GetComponentInParent<InspectableObject>();
        raySelector = FindObjectOfType<RaySelector>();
    }

    public void TrySelect() {
        if (!inspectableObject.interactionDone && raySelector.inspecting) {
            inspectableObject.interactionDone = true;
            onInteractionEnd.Invoke();
        }
    }
}
