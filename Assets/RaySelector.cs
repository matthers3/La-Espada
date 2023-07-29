using UnityEngine;
using System.Collections;

public class RaySelector : MonoBehaviour {

    [SerializeField] private float maxDistance = 5f;

    public Camera camera;

    void Update() {
        RaycastHit hit;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;

            if (hit.distance > maxDistance) {
                return;
            }

            if (objectHit.gameObject.GetComponentInChildren<TriggerEmission>()) {
                objectHit.gameObject.GetComponentInChildren<TriggerEmission>().isSelected = true;
            }
            print(objectHit);
            var direction = objectHit;
            // Do something with the object that was hit by the raycast.
        }
    }
}