using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIRECTIONS : MonoBehaviour
{
    public GameObject[] bodyParts;

    void Start()
    {
        growUpCheck();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         growUpCheck();
         for(int i = 1; i < bodyParts.Length; i++){
               if(transform.position == bodyParts[i].transform.position && tag == "right"){
                    bodyParts[i].GetComponent<BODY>().direc = "right";
                    if(i != bodyParts.Length-1)
                    Instantiate(transform, transform.position, Quaternion.identity);  
                    Destroy(gameObject);
               } else if(transform.position == bodyParts[i].transform.position && tag == "left"){
                     bodyParts[i].GetComponent<BODY>().direc = "left";
                     if(i != bodyParts.Length-1)
                     Instantiate(transform, transform.position, Quaternion.identity);  
                     Destroy(gameObject);
               }else if(transform.position == bodyParts[i].transform.position && tag == "up"){
                     bodyParts[i].GetComponent<BODY>().direc = "up";
                     if(i != bodyParts.Length-1)
                     Instantiate(transform, transform.position, Quaternion.identity);                       
                     Destroy(gameObject);
               }else if(transform.position == bodyParts[i].transform.position && tag == "down"){
                     bodyParts[i].GetComponent<BODY>().direc = "down";
                     if(i != bodyParts.Length-1)
                     Instantiate(transform, transform.position, Quaternion.identity);                       
                     Destroy(gameObject);
               }
         }
    }
    
    void growUpCheck(){
                
            bodyParts = GameObject.FindGameObjectsWithTag("BodyPart");
    }
}
