using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDataBase<T> : ScriptableObject where T : BaseData
{
    [SerializeField] List<T> itemList = new List<T>();

    // �v���p�e�B
    public List<T> ItemList
    {
        get { return itemList; }
    }
}
