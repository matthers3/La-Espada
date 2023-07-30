using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysShowDialog : MonoBehaviour
{
    void LateUpdate()
    {
        GetComponent<CanvasGroup>().alpha = 1f;
    }
}
