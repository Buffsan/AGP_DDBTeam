using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    /// <summary>
    /// �e���甭�˕������������e�e�𐶐�����
    /// </summary>
    /// <param name="infiniteBullet">�e��������邩�ǂ���</param>
    /// <returns>���Ă����ǂ�����Ԃ�</returns>
    public bool Shoot(GameObject bulletPrefab, Vector3 position, Vector3 direction, string tag, int remainBullets, bool infiniteBullet)
    {
        if(remainBullets <= 0 && !infiniteBullet) return false;
        if(!infiniteBullet) remainBullets--;
        
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.tag = tag;
        bullet.transform.LookAt(direction);
        return true;
    }
}
