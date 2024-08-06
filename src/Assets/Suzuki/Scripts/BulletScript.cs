using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BulletBaseClass�Ɉڍs
/// </summary>
public class BulletScript : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    [Header("�e���Փ˂��郌�C���["), SerializeField] LayerMask layerMask;
    void Start()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerMask)
        {
            if (other.TryGetComponent<CharacterStatus>(out CharacterStatus character))// �L�����N�^�[�ɓ��������Ƃ�
            {
                character.TakeDamage(bulletData.AttackPower);
                Destroy(this.gameObject);
            }
        }
    }
}
