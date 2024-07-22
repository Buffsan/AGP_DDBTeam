using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBaseClass : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float DestroyIntarval = 10f;
    [SerializeField] private float BulletPower = 60;
    private float DestroyTime = 0;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField] private BulletData bulletData;
    [Header("�e���Փ˂��郌�C���["), SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        //rb = GetComponent<Rigidbody>();

        //Vector3 Forward = Player.transform.position - transform.position + Vector3.up * 0.5f;
        Vector3 Forward = transform.forward;
        Forward.Normalize();
        Quaternion look = Quaternion.LookRotation(Forward);
        transform.rotation = look * Quaternion.Euler(90, 0, 0);

        rb.AddForce(Forward * BulletPower, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        DestroyTime += Time.deltaTime;

        if (DestroyTime > DestroyIntarval)
        {
            DestroyTime = 0f;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    Debug.Log("Dameged!");
        //    Destroy(this.gameObject);
        //}

        if (((1 << other.gameObject.layer) & layerMask) != 0)// �Փ˂����Ƃ�
        {
            if (other.TryGetComponent<CharacterStatus>(out CharacterStatus character))// �L�����N�^�[�ɓ��������Ƃ�
            {
                if (gameObject.tag != other.tag)// �e��tag�ƏՓ˂��������tag���Ⴄ�Ƃ��i�v���C���[�̒e���G�ɁA�G�̒e���v���C���[�ɓ��������Ƃ��j
                {
                    character.TakeDamage(bulletData.AttackPower);
                    Debug.Log("Dagamed!");
                }
            }
            Destroy(this.gameObject);
        }
    }
}
