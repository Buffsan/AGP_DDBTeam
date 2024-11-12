using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField] CharacterData characterData;

    float hp;
    public float Hp
    {
        get { return hp; }
    }

    float remainPossessTime;
    public float RemainPossessTime
    {
        get { return remainPossessTime; }
    }

    public bool IsDead
    {
        get { return hp <= 0; }
    }
    public bool CanPossess// ���ڂ�邩�ǂ���
    {
        get { return IsDead && remainPossessTime > 0; }
    }
    public string ObjectTag
    {
        get { return gameObject.tag; }
    }
    float damageTimer;

    void Start()
    {
        //damageTimer = 0f;
    }

    void FixedUpdate()
    {
        if(damageTimer > 0f)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    public void StartSetUp()
    {
        SetHpMax();
        remainPossessTime = characterData.MaxPossessTime;
        damageTimer = 0f;
    }

    /// <summary>
    /// �_���[�W��^����
    /// </summary>
    public void TakeDamage(float damage)
    {
        if (damageTimer >= 0f) return;// ���G���Ԓ��̓_���[�W�������Ȃ�
        hp -= damage;
        if(hp <= 0f)
        {
            hp = 0f;
        }

        if(gameObject.tag == "Player")
        {
            damageTimer = characterData.ImmunityTime;
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

    public void OnPossess()// ���߂����̏���
    {
        SetHpMax();
    }

    void SetHpMax()
    {
        hp = characterData.MaxHp;// HP���ő�ɐݒ�
    }
}
