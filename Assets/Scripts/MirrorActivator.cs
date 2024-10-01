using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorActivator : MonoBehaviour
{
    [SerializeField] private SetUpMirror[] mirrors;
    [SerializeField] private LayerMask ignoreLayer;
    [SerializeField] private bool skipDetection = false;
    [SerializeField] private bool checkByDistance = false;
    [SerializeField] private float maxDistance = 20.0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        mirrors = FindObjectsOfType<SetUpMirror>();
    }

    void Update()
    {
        DetectMirrors();
    }

    public void DetectMirrors()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        foreach (SetUpMirror mirror in mirrors)
        {
            if (skipDetection)
            {
                mirror.SetVisibility(true);
                continue;
            }
            
            bool inFrontOfCamera = GeometryUtility.TestPlanesAABB(planes, mirror.MirrorRenderer.bounds);

            if (inFrontOfCamera)
            {
                mirror.SetVisibility(true);
            }
            else
            {
                mirror.SetVisibility(true);
            }
        }
    }

    private bool RaycastCorners(SetUpMirror mirror)
    {

        if ((mirror.gameObject.transform.position - transform.position).magnitude > maxDistance)
        {
            return false;
        }

        foreach (Transform point in mirror.raycastPoints)
        {
            Transform targetTransform = mirror.gameObject.transform;
            Vector3 direction = point.position - transform.position;

            if (Physics.Raycast(transform.position, direction, out var raycastHit, ignoreLayer)) 
            {
                if (raycastHit.transform == targetTransform)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
