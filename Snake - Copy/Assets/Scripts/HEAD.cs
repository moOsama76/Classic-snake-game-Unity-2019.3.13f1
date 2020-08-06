using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HEAD : MonoBehaviour
{

    public GameObject egg;
    public Transform[] directions;
    public Transform body;
    int randomIntX, randomFractionX, randomIntY, randomFractionY;
    public float posToCopyX, posToCopyY;
    public GameObject[] bodyParts;
    int points = 1;
    public Text pointLable;
    public GameObject loseLable;
    
    
    void Start()
    {
        reLocate(); 
        bodyParts = GameObject.FindGameObjectsWithTag("BodyPart");
    }
    
    void Update()
    {
        if(Input.GetKeyDown("w")){
            if(bodyParts.Length == 1){
                bodyParts[0].GetComponent<BODY>().direc = "up";

            } else if (checkWS()){
                bodyParts[0].GetComponent<BODY>().direc = "up";
                Instantiate(directions[2], transform.position, Quaternion.identity);

            }
         

        } else if(Input.GetKeyDown("s")){
            if(bodyParts.Length == 1){ 
                bodyParts[0].GetComponent<BODY>().direc = "down";

            } else if (checkWS()){
                bodyParts[0].GetComponent<BODY>().direc = "down";
                Instantiate(directions[3], transform.position, Quaternion.identity); 

            }
        } else if(Input.GetKeyDown("d")){
            if(bodyParts.Length == 1){
                bodyParts[0].GetComponent<BODY>().direc = "right";

            } else if (checkAD()){
                bodyParts[0].GetComponent<BODY>().direc = "right";
                Instantiate(directions[0], transform.position, Quaternion.identity); 

            }                  
                                           
        } else if(Input.GetKeyDown("a")){
            if(bodyParts.Length == 1){
                bodyParts[0].GetComponent<BODY>().direc = "left";

            } else if(checkAD()){
                bodyParts[0].GetComponent<BODY>().direc = "left";
                Instantiate(directions[1], transform.position, Quaternion.identity);  

            }

        } 
        
              

        for(int i = 0; i < bodyParts.Length; i++){                                                                                                                                                    /////////
            if( bodyParts[i].transform.position == egg.transform.position){
                reLocate(); 
                growUp();
                points++;
                pointLable.GetComponent<Text>().text = points.ToString();
                break;
            }
        }   

        if(transform.position.x > 4.6 || transform.position.x < -4.6 || transform.position.y > 4.6 || transform.position.y < -4.6 ){
                    loseLable.SetActive(true);
                    Time.timeScale = 0;
        }

        for(int i = 1; i < bodyParts.Length; i++){
            if(bodyParts[0].transform.position == bodyParts[i].transform.position ){
                    loseLable.SetActive(true);
                    Time.timeScale = 0;  
            }
        }  

        if(Input.GetKey("space")){
            Application.LoadLevel(0);
            Time.timeScale = 1;        
        }

    }
    
    
    void reLocate(){
            randomIntX = Random.Range(-4, 4);
            randomFractionX = Random.Range(-6, 6);
            
            randomIntY = Random.Range(-4, 4);
            randomFractionY = Random.Range(-6, 6);
                            
                if(randomFractionX % 2 == 1 ){
                    randomFractionX++;
                } else if(randomFractionX % 2 == -1){
                    randomFractionX--;
                }
                
                if(randomFractionY % 2 == 1 ){
                    randomFractionY++;
                } else if(randomFractionY % 2 == -1){
                    randomFractionY--;
                }
                
             egg.transform.position = new Vector2(randomIntX + randomFractionX/10.0f, randomIntY + randomFractionY/10.0f ); 
    }
    
       void growUp(){
            Transform clone;
            if(bodyParts[bodyParts.Length-1].GetComponent<BODY>().direc == "up"){
                posToCopyY = bodyParts[bodyParts.Length-1].transform.position.y - 0.2f;
                clone = Instantiate(body, new Vector2(bodyParts[bodyParts.Length-1].transform.position.x, posToCopyY), Quaternion.identity);  
                clone.tag = "BodyPart";

                }   
            else if(bodyParts[bodyParts.Length-1].GetComponent<BODY>().direc == "down"){
                posToCopyY = bodyParts[bodyParts.Length-1].transform.position.y + 0.2f;
                clone = Instantiate(body, new Vector2(bodyParts[bodyParts.Length-1].transform.position.x, posToCopyY), Quaternion.identity);  
                    clone.tag = "BodyPart";

            }    
            else if(bodyParts[bodyParts.Length-1].GetComponent<BODY>().direc == "right"){
                posToCopyX = bodyParts[bodyParts.Length-1].transform.position.x - 0.2f;
                clone = Instantiate(body, new Vector2(posToCopyX, bodyParts[bodyParts.Length-1].transform.position.y), Quaternion.identity);  
                clone.tag = "BodyPart";

            }
            else if(bodyParts[bodyParts.Length-1].GetComponent<BODY>().direc == "left"){
                posToCopyX = bodyParts[bodyParts.Length-1].transform.position.x + 0.2f;
                clone = Instantiate(body, new Vector2(posToCopyX, bodyParts[bodyParts.Length-1].transform.position.y), Quaternion.identity); 
                    clone.tag = "BodyPart";
            
            }
        
        
            bodyParts = GameObject.FindGameObjectsWithTag("BodyPart");
            bodyParts[bodyParts.Length-1].GetComponent<BODY>().direc = bodyParts[bodyParts.Length-2].GetComponent<BODY>().direc;
            for(int i = 0; i < bodyParts.Length; i++){
                bodyParts[i].GetComponent<BODY>().timeToWait -= 0.005f;
            } 

        }
    
    
        bool checkWS(){
            if(bodyParts[1].GetComponent<BODY>().transform.position.y != bodyParts[0].GetComponent<BODY>().transform.position.y && 
               bodyParts[1].GetComponent<BODY>().transform.position.x == bodyParts[0].GetComponent<BODY>().transform.position.x ){
                return false;
            } else {
                return true; 
            }
        }

        bool checkAD(){
            if(bodyParts[1].GetComponent<BODY>().transform.position.y == bodyParts[0].GetComponent<BODY>().transform.position.y && 
               bodyParts[1].GetComponent<BODY>().transform.position.x != bodyParts[0].GetComponent<BODY>().transform.position.x ){
                return false;
            } else {
                return true; 
            }
        }

    
    
}
