using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberObject : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject placeHolder;


    [SerializeField] GameObject conditionPlaceHolderA;


    [SerializeField] GameObject conditionPlaceHolderB;

   public bool occupying;

    GameObject pointer;

    GameObject destination;
 


    void Start()
    {
    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConditionA" && Player.isThouching == false)
        {
            if (conditionPlaceHolderA.GetComponent<ConditionPlaceholder>().isOccupied == true)
            {
                Debug.Log("isoccupied");
                if (this.occupying == false)
                {
                    destination = placeHolder;
                }
            }
            else if (conditionPlaceHolderA.GetComponent<ConditionPlaceholder>().isOccupied == false)
            {
                if(this.tag=="Star")
                {
                    if (conditionPlaceHolderB.GetComponent<ConditionPlaceholder>().Star == false)
                    {
                        this.occupying = true;
                        Debug.Log("inside condition a");
                        destination = conditionPlaceHolderA;
                    }
                    else
                    {
                        destination = placeHolder;
                    }
                }
                else if(this.tag=="Square")
                {
                    if (conditionPlaceHolderB.GetComponent<ConditionPlaceholder>().Square == false)
                    {
                        this.occupying = true;
                        Debug.Log("inside condition a");
                        destination = conditionPlaceHolderA;
                    }
                    else
                    {
                        destination = placeHolder;
                    }
                }
            
            }
        }
        if (collision.gameObject.tag == "ConditionB" && Player.isThouching == false)
        {
            if (conditionPlaceHolderB.GetComponent<ConditionPlaceholder>().isOccupied == true)
            {
                Debug.Log("isoccupied");
                if (this.occupying == false)
                {
                    destination = placeHolder;
                }
            }
            else if (conditionPlaceHolderB.GetComponent<ConditionPlaceholder>().isOccupied == false)
            {
                if (this.tag == "Star")
                {
                    if (conditionPlaceHolderA.GetComponent<ConditionPlaceholder>().Star == false)
                    {
                        this.occupying = true;
                        Debug.Log("inside condition b");
                        destination = conditionPlaceHolderB;
                    }
                    else
                    {
                        destination = placeHolder;
                    }
                }
                else if (this.tag == "Square")
                {
                    if (conditionPlaceHolderA.GetComponent<ConditionPlaceholder>().Square == false )
                    {
                        this.occupying = true;
                        Debug.Log("inside condition b");
                        destination = conditionPlaceHolderB;
                    }
                    else
                    {
                        destination = placeHolder;
                    }
                }
              
            }
        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pointer"&&Player.isThouching==true)
        {
            if(Player.pointerOccupied==false)
            {
                Debug.Log("pointerEnter");
                Player.pointerOccupied = true;
                destination = collision.gameObject;
            }
        }
     
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        

    }

    void Update()
    {
        if(destination!=null)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 1f);
        }
    }
}
