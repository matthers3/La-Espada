using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEmission : MonoBehaviour
{
    public bool isSelectable = true;
    public bool isSelected = false;

    private Material emissiveMaterial;

    void Start() {
        emissiveMaterial = GetComponentInChildren<Renderer>().material;
    }

    IEnumerator stopSelection() {
        yield return new WaitForEndOfFrame();
        isSelected = false;
    }
    
    void LateUpdate() {
        if (isSelected && isSelectable) {
            emissiveMaterial.EnableKeyword("_EMISSION");
        } else {
            emissiveMaterial.DisableKeyword("_EMISSION");
        }
        StartCoroutine(stopSelection());
    }



}
