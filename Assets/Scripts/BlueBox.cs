using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBox : BOX
{
    Collider2D[] blueBox;
    Collider2D[] bluebox2;
    private int numBlue,numBlue2;
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
            firstColor=new Color(0,0.03529412f,1);
            secondColor=new Color(0,0.454902f,1);
            boxTag.tag="Blue";
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