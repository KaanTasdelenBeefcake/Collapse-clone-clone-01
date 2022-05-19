using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int BoxScore=0,highScore,factorBox=0,boxSum=0;
    [SerializeField]GameObject[] RGBboxes;
    public GameObject retryButton;
    GameObject BigBox,BlockBox;
    [SerializeReference]GameObject[] Boxes=new GameObject[5];
    [SerializeReference]TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    [SerializeReference]GameObject isColumnBox;
    public Transform boxPoint;
    void Start()
    {
        boxPoint=new GameObject().transform;
        Time.timeScale=1;
        highScore=PlayerPrefs.GetInt("BoxHighScore");  
        BigBox=GameObject.Find("BigBox");
        BlockBox=GameObject.Find("Block");
        for (int i = 0; i < 30; i++)
        {
            startBox();
        }
        InvokeRepeating("spawnBox",5,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Time.timeScale==1){
                Time.timeScale=0;
            }
            else{
                Time.timeScale=1;
            }
        }
        scoreText.text="Score:"+BoxScore;
    }
    void spawnBox(){
        float newPoint=1.1f*factorBox;
        Vector2 RGBspawnPoint=new Vector2(-2.2f+newPoint,-4.45f);
        int RandomBox=Random.Range(0,3);
        Boxes[factorBox]=Instantiate(RGBboxes[RandomBox],RGBspawnPoint,RGBboxes[RandomBox].transform.rotation,BlockBox.transform);
        factorBox++;
        if(factorBox==5){
            StartCoroutine("goBrr");
            factorBox=0;
        }
    }
    public void startBox(){
        float newPoint=1.1f*factorBox;
        Vector2 RGBspawnPoint=new Vector2(-2.2f+newPoint,-4.45f);
        int RandomBox=Random.Range(0,3);
        Instantiate(RGBboxes[RandomBox],RGBspawnPoint,RGBboxes[RandomBox].transform.rotation,BigBox.transform);
        factorBox++;
        if(factorBox==5){
            BigBox.transform.position+=new Vector3(0,1.1f,0);
            factorBox=0;
        }
    }
    public void boxColumnEmptyCaller(){
        Invoke("boxColumnEmpty",0.2f);
    }
    void boxColumnEmpty(){
        RaycastHit2D isColumnEmpty = Physics2D.Raycast(new Vector2(boxPoint.position.x,-3.68f),Vector2.up,2);
        if(isColumnEmpty.collider==null){
            float xAxisPoint=0+boxSum;
            float columnPoint=1.1f;
            if(boxPoint.position.x>xAxisPoint){
                RaycastHit2D[] columnRight=Physics2D.RaycastAll(new Vector2(boxPoint.position.x+columnPoint,-3.68f),Vector2.up,7.4f);
                for (int i = 0; i < columnRight.Length; i++)
                {
                    columnRight[i].collider.gameObject.transform.position-=new Vector3(columnPoint,0,0);
                }
                columnRight=null;
                RaycastHit2D isColumnEmpty2 = Physics2D.Raycast(new Vector2(boxPoint.position.x+(columnPoint*2),-3.68f),Vector2.up,2);
                if(isColumnEmpty2.collider!=null){
                    RaycastHit2D[] columnRight2=Physics2D.RaycastAll(new Vector2(boxPoint.position.x+(columnPoint*2),-3.68f),Vector2.up,7.4f);
                    for (int i = 0; i < columnRight2.Length; i++)
                    {
                        columnRight2[i].collider.gameObject.transform.position-=new Vector3(columnPoint,0,0);
                    }
                    columnRight2=null;
                }
            }
            else if(boxPoint.position.x<xAxisPoint){
                RaycastHit2D[] columnRight=Physics2D.RaycastAll(new Vector2(boxPoint.position.x-columnPoint,-3.68f),Vector2.up,7.4f);
                for (int i = 0; i < columnRight.Length; i++)
                {
                    columnRight[i].collider.gameObject.transform.position+=new Vector3(columnPoint,0,0);
                }
                columnRight=null;
                RaycastHit2D isColumnEmpty2 = Physics2D.Raycast(new Vector2(boxPoint.position.x-(columnPoint*2),-3.68f),Vector2.up,2);
                if(isColumnEmpty2.collider!=null){
                    RaycastHit2D[] columnRight2=Physics2D.RaycastAll(new Vector2(boxPoint.position.x-(columnPoint*2),-3.68f),Vector2.up,7.4f);
                    for (int i = 0; i < columnRight2.Length; i++)
                    {
                        columnRight2[i].collider.gameObject.transform.position+=new Vector3(columnPoint,0,0);
                    }
                    columnRight2=null;
                }
            }
            else{
                RaycastHit2D[] columnRight=Physics2D.RaycastAll(new Vector2(boxPoint.position.x+columnPoint,-3.68f),Vector2.up,7.4f);
                RaycastHit2D[] columnLeft=Physics2D.RaycastAll(new Vector2(boxPoint.position.x-columnPoint,-3.68f),Vector2.up,7.4f);
                if(columnLeft.Length>columnRight.Length){
                    boxSum+=1;
                    boxColumnEmpty();
                }
                else if(columnLeft.Length<columnRight.Length){
                    boxSum-=1; 
                    boxColumnEmpty();
                }
                else{
                    RaycastHit2D[] columnRight2=Physics2D.RaycastAll(new Vector2(boxPoint.position.x+(columnPoint*2),-3.68f),Vector2.up,7.4f);
                    RaycastHit2D[] columnLeft2=Physics2D.RaycastAll(new Vector2(boxPoint.position.x-(columnPoint*2),-3.68f),Vector2.up,7.4f);
                    if(columnLeft2.Length>columnRight2.Length){
                    boxSum+=2;
                    boxColumnEmpty();
                    }
                    else if(columnLeft2.Length<columnRight2.Length){
                    boxSum-=2; 
                    boxColumnEmpty();
                    }
                }
            }
        }
        else{
            isColumnBox=isColumnEmpty.collider.gameObject;
        }
    }
    IEnumerator goBrr(){
        yield return new WaitForSeconds(0.5f);
        BlockBox.transform.DetachChildren();
        for (int i = 0; i < 5; i++)
        {
            Boxes[i].transform.SetParent(BigBox.transform,true);
        }
        BigBox.transform.position+=new Vector3(0,1.1f,0);
    }
    
}
