using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArithmeticManager : MonoBehaviour
{
    int[] numA = new int[6] { 1, 3, 5, 10, 20, 30};
    int[] numB = new int[6] { 2, 4, 5, 6, 15, 25};
    int result;
    [SerializeField]GameObject numberA;
    [SerializeField]GameObject numberB;
    [SerializeField]Text resultText;
    int[] possibleA;
    int[] possibleB;
   
    void InitializeAdditionNumber()
    {
        result = Random.Range(3, 12);
        for(int i=0;i<6;i++)
        {
            for(int j=0;j<6;j++)
            {
                if(numA[i]+numB[j]==result)
                {
                    
                   
                }

            }
        }

    }
   

}
