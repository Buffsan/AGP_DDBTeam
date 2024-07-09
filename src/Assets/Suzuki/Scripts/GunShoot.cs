using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    /// <summary>
    /// 銃から発射方向を向いた銃弾を生成する
    /// </summary>
    /// <returns>撃てたかどうかを返す</returns>
    public bool Shoot(GameObject bulletPrefab, Vector3 position, Vector3 direction, int remainBullets)
    {
        if(remainBullets <= 0) return false;
        remainBullets--;
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.transform.LookAt(direction);
        return true;
    }
}
