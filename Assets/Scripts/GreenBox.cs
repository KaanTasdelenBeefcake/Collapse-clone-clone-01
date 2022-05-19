using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBox : BOX
{
    Collider2D[] greenBox;
    Collider2D[] greenbox2;
    private int numGreen,numGreen2;
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
            firstColor=new Color(0,0.75f,0);
            secondColor=new Color(0,1,0);
            boxTag.tag="Green";
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