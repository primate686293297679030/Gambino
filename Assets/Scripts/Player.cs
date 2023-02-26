using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Animator _playerAnimator;
    Vector3 _playerPos;
    [SerializeField] float movementSpeed=1f;
    public static Player PlayerInstance;
   [SerializeField] GameObject pointerPrefab;
    public static bool isThouching;
    public static bool pointerOccupied;
    GameObject pointer;
    private void Awake()
    {
        if(PlayerInstance==null)
        {
            PlayerInstance = this;

        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerAnimator.GetBool("IsMoving"))
        {
            transform.position += Vector3.right*movementSpeed*Time.deltaTime;
        }

        if(Input.GetMouseButtonDown(0))
        {
            isThouching = true;
            
            pointer=Instantiate(pointerPrefab,new Vector3
            (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0) , Quaternion.identity);
            pointer.tag = "Pointer";
            
        }
        if(Input.GetMouseButton(0))
        {
           pointer.transform.position = Vector3.MoveTowards
           (pointer.transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), 1f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isThouching = false;
            Destroy(pointer);
        }
    }
   public void MoveRight()
    {
        _playerAnimator.SetBool("IsMoving", true);
       
      
    }
    public void StopMoving()
    {
        _playerAnimator.SetBool("IsMoving", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="StopCollider")
        {
            StopMoving();
        }
    }
}
