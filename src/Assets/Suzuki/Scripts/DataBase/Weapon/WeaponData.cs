using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OriginalScriptableObjects/Data/WeaponData")]
public class WeaponData : BaseData
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float attackPower;// �����炭�e�ۂ̃f�[�^�x�[�X����肻����Ɉڍs����
    [SerializeField] int maxBullet;

    // �v���p�e�B
    public GameObject BulletPrefab
    {
        get { return bulletPrefab; }
    }
    public float AttackPower
    {
        get { return attackPower; }
    }
    public int MaxBullet
    {
        get { return maxBullet; }
    }
}
