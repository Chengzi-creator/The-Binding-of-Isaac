using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverForm : MonoBehaviour
{   
    // 
    [SerializeField] private GameObject masks;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        masks.SetActive(false);//先隐藏
        exitButton.onClick.AddListener(OnexitButtonClick);//监听
        restartButton.onClick.AddListener(OnrestartButtonClick);
    }

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
    }

    private void OnexitButtonClick()
    {
        //当点击退出
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void OnrestartButtonClick()
    {
        SceneManager.LoadScene("FirstScene");
        ObjectPool.Instance.Initialize(); // 初始化对象池
    }

    private void GameOver()
    {
        masks.SetActive(true);//再启用
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
    }
}
