using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStatus : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    int remainBullets;

    void Start()
    {
        remainBullets = weaponData.MaxBullet;
    }
    /// <summary>
    /// �e���甭�˕������������e�e�𐶐�����
    /// </summary>
    /// <param name="infiniteBullet">�e��������邩�ǂ���</param>
    /// <returns>���Ă����ǂ�����Ԃ�</returns>
    public bool Shoot(Vector3 position, Vector3 forward, string tag, bool infiniteBullet)
    {
        if(remainBullets <= 0 && !infiniteBullet) return false;
        if(!infiniteBullet) remainBullets--;
        
        GameObject bullet = Instantiate(weaponData.BulletPrefab, position, Quaternion.identity);
        bullet.tag = tag;
        bullet.transform.forward = forward;
        return true;
    }
}
