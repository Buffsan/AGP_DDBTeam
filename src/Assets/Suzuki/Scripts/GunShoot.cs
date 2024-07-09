using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    /// <summary>
    /// �e���甭�˕������������e�e�𐶐�����
    /// </summary>
    /// <returns>���Ă����ǂ�����Ԃ�</returns>
    public bool Shoot(GameObject bulletPrefab, Vector3 position, Vector3 direction, int remainBullets)
    {
        if(remainBullets <= 0) return false;
        remainBullets--;
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.transform.LookAt(direction);
        return true;
    }
}
