using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunStatus : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    int remainBullets;
    [SerializeField] float firstShotIntarval = 2f, defaultShotIntarval = 0.5f;

    public float FirstIntarval => firstShotIntarval;
    public float DefaultIntarval => defaultShotIntarval;

    public int RemainBullets
    {
        get { return remainBullets; }
    }

    void Start()
    {
        FillBullet();
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

        if(remainBullets == 0 && weaponData.Role == WeaponData.WeaponRole.main)
        {
            ChangeWeapon();
        }
        return true;
    }

    void FillBullet()// �e�ۂ̕�[
    {
        remainBullets = weaponData.MaxBullet;
    }

    void ChangeWeapon()// ����̐؂�ւ�
    {
        if (weaponData.SubWeapon != null)
        {
            Debug.Log("�T�u������g���I");
            Transform parent = this.transform.parent;
            Instantiate(weaponData.SubWeapon, parent);// ����̐���
            PlayerMove playerMove = parent.GetComponentInChildren<PlayerMove>();

            this.transform.SetParent(null);// �e�q�t�����O��
            playerMove.SetGunObject();// �����Ă���e�̐ݒ�
            Destroy(this.gameObject);
        }
    }
}
