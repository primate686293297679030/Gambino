using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Button PlayButton;
    GameObject Player;
    [SerializeField]
    GameObject SpeechBubbleMenu;
    RectTransform rect;
    public bool _shrinkAnimation;

    // Start is called before the first frame update
    void Start()
    {
        rect = SpeechBubbleMenu.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    IEnumerator ShrinkMenu()
    {
        while(_shrinkAnimation==true)
        {
            rect.localScale = new Vector3(rect.localScale.x - 0.01f, rect.localScale.y - 0.01f);
            if (rect.localScale.x <= 0.0001 || rect.localScale.y <= 0.0001)
            {
                rect.localScale = new Vector3(0, 0);
                _shrinkAnimation = false;
            }
            yield return new WaitForSeconds(0.005f);
        }
      
    }

  public void toggleShrinkAnimation()
    {
        _shrinkAnimation = true;
        StartCoroutine(ShrinkMenu());
    }


}
