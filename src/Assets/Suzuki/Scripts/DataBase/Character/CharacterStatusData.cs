using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(menuName = "OriginalScriptableObjects/Data/CharacterStatus")]
public class CharacterStatusData : BaseData
{
    [SerializeField] float maxHp;
    [SerializeField] float maxPossesTime;

    // �v���p�e�B
    public float MaxHp
    {
        get { return maxHp; }
    }
    public float MaxPossesTime
    {
        get { return maxPossesTime;}
    }
}
