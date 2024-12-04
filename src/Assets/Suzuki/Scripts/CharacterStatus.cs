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
    bool possessed;
    public bool CanPossess// ���ڂ�邩�ǂ���
    {
        get { return IsDead || possessed; }
    }
    public string ObjectTag
    {
        get { return gameObject.tag; }
    }
    float damageTimer;
    UnityEngine.Animator animator;
    void Start()
    {
        possessed = false;
        StartSetUp();
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
        animator = GetComponent<UnityEngine.Animator>();
        remainPossessTime = characterData.MaxPossessTime;
        damageTimer = 0f;
        if(tag == "Player")
        {
            possessed = true;
        }
    }

    /// <summary>
    /// �_���[�W��^����
    /// </summary>
    public void TakeDamage(float damage, bool launch = false)
    {
        if (damageTimer > 0f) return;// ���G���Ԓ��̓_���[�W�������Ȃ�
        hp -= damage;
        if(hp <= 0f)
        {
            hp = 0f;
            if(launch && TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            }
        }

        if(gameObject.tag == "Player")
        {
            damageTimer = characterData.ImmunityTime;
        }

        animator.SetBool("Dead", IsDead);
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
        if(!possessed)// ������߂��̂Ƃ�
        {
            SetHpMax();
            possessed = true;
        }

        animator.SetBool("Dead", IsDead);
    }

    void SetHpMax()
    {
        hp = characterData.MaxHp;// HP���ő�ɐݒ�
    }
}
