using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEmission : MonoBehaviour
{
    public bool isSelected = false;

    private Material emissiveMaterial;

    void Start() {
        emissiveMaterial = GetComponentInChildren<Renderer>().material;
    }
    
    void LateUpdate() {
        if (isSelected) {
            emissiveMaterial.EnableKeyword("_EMISSION");
        } else {
            emissiveMaterial.DisableKeyword("_EMISSION");
        }
        isSelected = false;
    }

}
