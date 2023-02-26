using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEdgeCollision : MonoBehaviour
{
    Camera _mainCamera;
    float _animDuration=3f; float _currentAnimDuration = 0f; float startTime;
    [SerializeField] AnimationCurve animationCurve;
    float distance;
    float fadeDistance;
    Vector3 pointA, pointB;
    bool cameraLevelTransition;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            setVariables();
            cameraLevelTransition = true;

           // Player.PlayerInstance._playerAnimator.SetBool("IsMoving", false);
        }
    }
 
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraLevelTransition==true)
        {
            float easing = animationCurve.Evaluate(((Time.time - startTime) * _animDuration) / distance);
            _mainCamera.transform.position = Vector3.Lerp(pointA, pointB, easing);
            if (easing >= 1)
            {
                cameraLevelTransition = false;
               
            }
        }
     
    }


  
    void setVariables()
    {
        startTime= Time.time;
        pointA = _mainCamera.transform.position;
        pointB = pointA + new Vector3(17.77778f, 0, 0);
        distance = Vector3.Distance(pointA, pointB);
    }
}
