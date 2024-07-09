using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchColliderScript : MonoBehaviour
{
    ConeCollider coneCollider;
    Transform player;
    bool inSearchArea = false;
    bool findPlayer = false;

    public bool FindPlayer
    {
        get { return findPlayer; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent<ConeCollider>(out coneCollider))
        {
            Debug.LogWarning("���̃I�u�W�F�N�g��ConeCollider ���A�^�b�`����Ă��܂���B");
        }
        player = null;
        inSearchArea = false;
        findPlayer = false;
    }

    void FixedUpdate()
    {
        if(inSearchArea && player != null)
        {
            Vector3 targetDirection = player.position - transform.position;
            Ray ray = new Ray(transform.position, targetDirection);
            if(Physics.Raycast(ray, out RaycastHit hit, coneCollider.Distance))// �v���C���[���B��Ă��Ȃ��Ƃ��i���݂͏Ǝ˂�����_���ʂ邩�ǂ����Ŕ��肵�Ă���j
            {
                if (hit.transform == player)
                {
                    findPlayer = true;
                    Debug.Log("FindPlayer : true");
                }
            }
        }
        else
        {
            findPlayer = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerMove>(out PlayerMove playerMove) && playerMove.enabled)// �v���C���[�������Ƃ�
        {
            inSearchArea = true;
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMove>(out PlayerMove playerMove) && playerMove.enabled)// �v���C���[�������Ƃ�
        {
            inSearchArea = false;
        }
    }
}
