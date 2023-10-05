using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SecretDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //把当前活动场景的属性拿出，+1即到下一个场景
        }
    }
}
