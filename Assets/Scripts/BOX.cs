using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    protected GameManager gameManager;
    protected GameObject bigObject;
    private int numover,numover2;
    private GameObject tag1,tag2;
    Collider2D[] overBox,overBox2;
    public GameObject boxTag;
    protected Color firstColor,secondColor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void isBoxNear(){
        gameObject.tag=boxTag.tag+"2";
        overBox=Physics2D.OverlapBoxAll(transform.position,new Vector2(1f,1f),45);
        numover=0;
        numover2=0;
        if(GameObject.Find("BigC")==null){
            bigObject=new GameObject();
            bigObject.name="BigC";
            bigObject.transform.SetParent(GameObject.Find("BigBox").transform,true);
        }
        for (int i = 0; i < overBox.Length; i++)
        {
            if(overBox[i].gameObject.tag==boxTag.tag){
               Debug.Log("over2");
               overBox2=new Collider2D[numover+1];
               numover++;
            }
        }
        for (int i = 0; i < overBox.Length; i++)
        {
            if(overBox[i].gameObject.tag==boxTag.tag){
               overBox2[numover2]=overBox[i];
               overBox2[numover2].transform.SetParent(GameObject.Find("BigC").transform,true);
               overBox2[numover2].gameObject.GetComponent<BOX>().isBoxNearSeq();
               numover2++;
            }
        }
        Debug.Log(GameObject.Find("BigC").transform.childCount);
        gameObject.tag=boxTag.tag;
        if(GameObject.Find("BigC").transform.childCount>1){
            gameObject.transform.SetParent(GameObject.Find("BigC").transform,true);
            for (int i = 0; i < numover2; i++)
            {
                overBox2[i].tag=boxTag.tag;
            }
            for (int i = 0; i <GameObject.Find("BigC").transform.childCount; i++)
            {
                GameObject.Find("BigC").transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color=secondColor;
            }
            gameObject.GetComponent<SpriteRenderer>().color=secondColor;
            gameObject.tag=boxTag.tag;
        }
        
    }
    protected void isBoxNearSeq(){
        Debug.Log("over");
        gameObject.tag=boxTag.tag+"2";        
        overBox=Physics2D.OverlapBoxAll(transform.position,new Vector2(1f,1f),45);
        numover=0;
        numover2=0;
        for (int i = 0; i < overBox.Length; i++)
        {
            if(overBox[i].gameObject.tag==boxTag.tag){
               Debug.Log("over 2");
               overBox2=new Collider2D[numover+1];
               numover++;
            }
        }
        for (int i = 0; i < overBox.Length; i++)
        {
            if(overBox[i].gameObject.tag==boxTag.tag){
               if(overBox[i].transform.parent=GameObject.Find("BigBox").transform){
                    overBox2[numover2]=overBox[i];
                    overBox2[numover2].transform.SetParent(GameObject.Find("BigC").transform,true);
                    overBox2[numover2].gameObject.GetComponent<BOX>().isBoxNearSeq();
                    numover2++;
               }
            }
        }
        if(numover2>0){
            for (int i = 0; i < numover2; i++)
            {
                overBox2[i].tag=boxTag.tag;
            }
            gameObject.tag=boxTag.tag;
        }
    }
    protected void boxExit(){
        if(GameObject.Find("BigC").transform.childCount>0){
        GameObject[] oversBox = new GameObject[GameObject.Find("BigC").transform.childCount];
            for (int i = 0; i < GameObject.Find("BigC").transform.childCount; i++)
            {
               GameObject.Find("BigC").transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color=firstColor;
               GameObject.Find("BigC").transform.GetChild(i).gameObject.tag=boxTag.tag;
               oversBox[i]=GameObject.Find("BigC").transform.GetChild(i).gameObject;
            }
            gameObject.GetComponent<SpriteRenderer>().color=firstColor;
            GameObject.Find("BigC").transform.DetachChildren();
            for (int i = 0; i < oversBox.Length; i++)
            {
               oversBox[i].transform.SetParent(GameObject.Find("BigBox").transform,true);
            }
        }
    }
    public void boxDestroy(){
        gameManager.BoxScore+=GameObject.Find("BigC").transform.childCount;
        if(GameObject.Find("BigC").transform.childCount>1){
              gameManager.boxPoint.position=transform.position;
              gameManager.boxSum=0;
              gameManager.boxColumnEmptyCaller();
              Destroy(GameObject.Find("BigC"));
              FindObjectOfType<AudioManager>().Play("boxDestroy");
        }
    }
}
