using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls
{
    public static bool GetComfirm() {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
