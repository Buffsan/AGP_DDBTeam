using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadManager : MonoBehaviour
{
    [SerializeField] GameObject head;
    
    public void OnHeadThrow()// animator����Ăяo�����
    {
        head.SetActive(false);
        TargetManeger.StartHeadChange();
    }

    public void OnHeadLand()
    {
        head.SetActive(true);
    }
}
