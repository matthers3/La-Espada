using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SwapDialogueViews : MonoBehaviour
{
    public GameObject normalLineView = default;
    public GameObject friendLineView = default;

    public GameObject normalBackground = default;
    public GameObject friendBackground = default;

    [YarnCommand("set_friend_line_view")]
    public void SetFriendLineView(bool setFriend) {
        if (setFriend) {
            normalLineView.SetActive(false);
            normalBackground.SetActive(false);
            friendLineView.SetActive(true);
            friendBackground.SetActive(true);
            FindObjectOfType<DialogueRunner>().dialogueViews[0] = friendLineView.GetComponentInChildren<DialogueViewBase>();
        } else {
            normalLineView.SetActive(true);
            normalBackground.SetActive(true);
            friendLineView.SetActive(false);
            friendBackground.SetActive(false);
            FindObjectOfType<DialogueRunner>().dialogueViews[0] = normalLineView.GetComponentInChildren<DialogueViewBase>();
        }
    }
}
