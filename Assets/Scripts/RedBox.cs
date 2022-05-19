using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : BOX
{
    Collider2D[] redBox;
    Collider2D[] redbox2;
    private int numRed,numRed2;
    void Start()
    {
        boxTag=GameObject.Find("TagBox");
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
    
    }
    public void OnMouseEnter() {
        if(Time.timeScale==1&&gameObject.transform.parent==GameObject.Find("BigBox").transform){
            firstColor=new Color(0.85f,0,0);
            secondColor=new Color(1,0,0);
            boxTag.tag="Red";
            isBoxNear();  
        }  
    }
    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)){
            boxDestroy();
        }
    }
    private void OnMouseExit(){
        boxExit();
    }
}