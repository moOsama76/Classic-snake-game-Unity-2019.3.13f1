using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BODY : MonoBehaviour
{
    public string direc;
    public float posX, posY;
    public float tim, timeToWait;
    public GameObject head;
    
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        tim = head.GetComponent<BODY>().tim;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
             
                timeToWait = head.GetComponent<BODY>().timeToWait;

                if(Time.timeSinceLevelLoad > tim){
                        if(direc == "up" ){
                            posY += 0.2f;
                         }   
                        else if(direc == "down"){
                            posY -= 0.2f;
                        }    
                        else if(direc == "right"){
                            posX += 0.2f;
                        }
                        else if(direc == "left"){
                            posX -= 0.2f;
                        }
                        gameObject.transform.position = new Vector2(posX, posY);
                        tim += timeToWait;
                }
    }
}
