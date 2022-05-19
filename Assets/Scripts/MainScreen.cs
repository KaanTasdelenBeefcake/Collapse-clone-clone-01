using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().StopPlaying("death");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(){
        SceneManager.LoadScene(1);
    }
    public void RestartGame(){
        SceneManager.LoadScene(1);
    }
}
