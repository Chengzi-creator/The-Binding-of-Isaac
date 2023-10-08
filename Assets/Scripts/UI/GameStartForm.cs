using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameStartForm : MonoBehaviour
{
    [SerializeField] private GameObject startmasks;
    [SerializeField] private Button startButton;
    
    private void Awake()
    {
        GameStart();
        startButton.onClick.AddListener(OnstartButtonClick);//监听
        Debug.Log("okk");
    }
    
    private void OnstartButtonClick()
    {   
        Time.timeScale = 1f;
        startmasks.SetActive(false);//再隐藏
        SceneManager.LoadScene("FirstScene");
        // 禁用脚本
        enabled = false;
    }
    
    
    private void GameStart()
    {
        startmasks.SetActive(true);//先启用
        Time.timeScale = 0f;//暂停时间
    }
}
