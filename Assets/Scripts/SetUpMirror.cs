using System.Collections;
using UnityEngine;

public class SetUpMirror : MonoBehaviour
{
    [SerializeField] private Shader materialShader;
    private float biasAngle = 90;
    private GameObject target;
    private GameObject mirrorCamera;
    private Material material;
    private RenderTexture texture;
    private bool isVisible;
    private Renderer mirrorRenderer;
    public Renderer MirrorRenderer 
    {
        get { return mirrorRenderer; }
    }
    public Transform[] raycastPoints;

    void Start()
    {
        target = GameObject.Find("MainCamera");
        mirrorRenderer = GetComponent<Renderer>();
        // isVisible = mirrorRenderer.isVisible;
        material = new Material(materialShader);
        texture = new RenderTexture(1024, 1024, 16, RenderTextureFormat.ARGB32);
        texture.Create();
        mirrorCamera = GameObject.Find("vision").gameObject;
        mirrorCamera.GetComponent<Camera>().targetTexture = texture;
        StartCoroutine(SetMirror());
        SetUpRaycastPoints();
    }

    void Update()
    {
        rotateCamera();
        mirrorCamera.GetComponent<Camera>().enabled = true;
    }

    private IEnumerator SetMirror()
    {
        mirrorRenderer.material = material;
        yield return new WaitForEndOfFrame();
        material.mainTexture = texture;
    }

    private void rotateCamera()
    {
        Vector3 targetAngle = target.transform.position - transform.position;
        targetAngle.y = 0;
        Vector3 right = transform.right;
        right.y = 0;
        float angle = Vector3.SignedAngle(targetAngle, right, Vector3.up);
        float newCameraAngle = (angle + 180) % 180 + biasAngle;
        mirrorCamera.transform.rotation = Quaternion.Euler(0, newCameraAngle, 0)
            * transform.rotation;

    }

    public void SetVisibility(bool active)
    {
        isVisible = active;
    }

    private void SetUpRaycastPoints()
    {
        Transform pivotParent = transform.Find("Pivots");
        raycastPoints = pivotParent.GetComponentsInChildren<Transform>();
    }

}
