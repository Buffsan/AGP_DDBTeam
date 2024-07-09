using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    float hp;
    float remainPossessTime;

    // �v���p�e�B
    public float Hp
    {
        get { return hp; }
    }
    public float RemainPossessTime
    {
        get { return remainPossessTime; }
    }
    public bool IsDead
    {
        get { return hp <= 0; }
    }
    public bool CanPossess
    {
        get { return IsDead && remainPossessTime > 0; }
    }
    // Start is called before the first frame update
    void Start()
    {
        hp = characterData.MaxHp;
        remainPossessTime = characterData.MaxPossessTime;
    }

    /// <summary>
    /// �_���[�W��^����
    /// </summary>
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0f)
        {
            hp = 0f;
        }
    }

    /// <summary>
    /// ���߂����Ԃ��o��
    /// </summary>
    public void ElapsePossessTime()
    {
        remainPossessTime -= Time.fixedDeltaTime;
        if(remainPossessTime <= 0f)
        {
            remainPossessTime = 0f;
        }
    }
}
