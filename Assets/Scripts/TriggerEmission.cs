using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEmission : MonoBehaviour
{
    public bool isSelectable = true;
    public bool isSelected = false;

    private Material emissiveMaterial;
    private InspectableObject inspectableObject;
    private RaySelector raySelector;

    void Start() {
        emissiveMaterial = GetComponentInChildren<Renderer>().material;
        inspectableObject = GetComponent<InspectableObject>();
        raySelector = FindObjectOfType<RaySelector>();
    }

    IEnumerator stopSelection() {
        yield return new WaitForEndOfFrame();
        isSelected = false;
    }
    
    void LateUpdate() {
        if (isSelected && isSelectable && !inspectableObject.isLocked && !raySelector.inspecting
            && !inspectableObject.alreadySelected) {
            emissiveMaterial.EnableKeyword("_EMISSION");
        } else {
            emissiveMaterial.DisableKeyword("_EMISSION");
        }
        StartCoroutine(stopSelection());
    }



}