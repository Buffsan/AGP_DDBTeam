using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    /// <summary>
    /// �e���甭�˕������������e�e�𐶐�����
    /// </summary>
    /// <param name="bullet">�L�����N�^�[�̎�ނ��Ƃɐݒ肳�ꂽBullet�v���n�u��n��</param>
    /// <param name="position">���ˌ��̈ʒu</param>
    /// <param name="direction">���ː�̕���</param>
    /// <param name="remainBullets">�c�e��</param>
    /// <returns></returns>
    public bool Shoot(GameObject bulletPrefab, Vector3 position, Vector3 direction, int remainBullets)
    {
        if(remainBullets <= 0) return false;
        remainBullets--;
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.transform.LookAt(direction);
        return true;
    }
}
