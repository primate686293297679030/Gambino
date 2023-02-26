using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberObject : MonoBehaviour
{
    // Start is called before the first frame update
    bool follow;
    Collider2D ColliderToFollow;
    [SerializeField] GameObject PlaceHolder;
 
    UnityAction FollowPlaceHolder;
    Transform objectToFollow;
    bool conditionPlaceholder;
    bool occupied;
    bool onConditionCollider;
    Transform latestCollision;
    
    
    void Start()
    {
        FollowPlaceHolder += FollowConditionPlaceholder;
        objectToFollow = GetComponentInParent<Transform>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.tag=="Pointer"&&Player.pointerOccupied==false)
        {
            Debug.Log("Placeholder");
            objectToFollow = collision.gameObject.transform;
            follow = true;
            Player.pointerOccupied = true;
            
        }
        if(collision.gameObject.tag=="ConditionPlaceholder" && collision.gameObject.GetComponent<ConditionPlaceholder>().isOccupied ==false)
        {
            occupied = true;
            collision.gameObject.GetComponent<ConditionPlaceholder>().isOccupied=true;
            onConditionCollider = true;
            latestCollision = collision.gameObject.transform;
            Debug.Log("Condition");
        }
    }
    void FollowConditionPlaceholder()
    {
        conditionPlaceholder = !conditionPlaceholder;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exiting collider");
        Debug.Log("onConditionCollider " + onConditionCollider);
        if(collision.gameObject.tag=="ConditionPlaceholder"&&occupied==true)
        {
            onConditionCollider = false;
            latestCollision = null;
            collision.gameObject.GetComponent<ConditionPlaceholder>().isOccupied = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.isThouching == false && onConditionCollider == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, latestCollision.position, 1f);

        }      
        else if(Player.isThouching&&objectToFollow!=null)
        {
             transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, 1f);
        }
        else if (Player.isThouching==false)
        {
            Player.pointerOccupied = false;
             transform.position = Vector3.MoveTowards(transform.position, PlaceHolder.transform.position, 1f);
        }
    }
}
