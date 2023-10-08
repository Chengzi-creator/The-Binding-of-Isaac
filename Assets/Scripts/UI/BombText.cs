using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombText : MonoBehaviour
{
    //public TextMesh uiText; // 引用UI文本框
    public TMP_Text uiText;
    public PlayerController player;

    private void Start()
    {
        //uiText = GetComponent<TextMesh>();
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        // 检查确保uiText和player不为空
        if (uiText != null && player != null)
        {
            // 初始时设置文本内容
            UpdateText();
        }
    }

    // 更新UI文本框的内容
    private void UpdateText()
    {
        if (uiText != null && player != null)
        {
            uiText.text = ":" + player.bombCount;
        }
    }
}
