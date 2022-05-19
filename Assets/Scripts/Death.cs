using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Death : MonoBehaviour
{
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject){
            if(gameManager.BoxScore>gameManager.highScore){
            PlayerPrefs.SetInt("BoxHighScore",gameManager.BoxScore);
            gameManager.highScore=PlayerPrefs.GetInt("BoxHighScore");
            }
            gameManager.highScoreText.gameObject.SetActive(true);
            gameManager.highScoreText.text="HighScore:"+gameManager.highScore;
            gameManager.retryButton.SetActive(true);
            Time.timeScale=0;
                                   
        }
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
        FindObjectOfType<AudioManager>().Play("death");
    }
    
}
