using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionPlaceholder : MonoBehaviour
{
    public bool isOccupied;
    public bool Star;
    public bool Square;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star"&&Player.isThouching==false)
        {
            Debug.Log("star is staying");
            isOccupied = true;
            Star = true;
        }
        if (collision.gameObject.tag == "Square" && Player.isThouching == false&&collision.gameObject.GetComponent<NumberObject>().occupying==true)
        {
            Debug.Log("square is staying");
            isOccupied = true;
            Square = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

       
       
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
           if(collision.gameObject.GetComponent<NumberObject>().occupying==true)
            {
                isOccupied = false;
                Star = false;
                collision.gameObject.GetComponent<NumberObject>().occupying = false;
            }
           else
            {
               
               
            }
        
        }
        if (collision.gameObject.tag == "Square")
        {
            if (collision.gameObject.GetComponent<NumberObject>().occupying == true)
            {
                Debug.Log("squareleaving");
                isOccupied = false;
                Square = false;
                collision.gameObject.GetComponent<NumberObject>().occupying = false;
            }
            else
            {
               
            }
           
        }
      
    }
  
}
