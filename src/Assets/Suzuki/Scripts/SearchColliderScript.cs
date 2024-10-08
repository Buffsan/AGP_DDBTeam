using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchColliderScript : MonoBehaviour
{
    ConeCollider coneCollider;
    Transform player;
    bool inSearchArea = false;
    bool findPlayer = false;
    [SerializeField] LayerMask layerMask;

    public Transform FoundPlayer
    {
        get { return player != null ? player : null; }
    }
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
        if (inSearchArea && player != null)
        {
            Vector3 targetDirection = player.position - transform.position;
            Ray ray = new Ray(transform.position, targetDirection);
            bool raycast = Physics.Raycast(ray, out RaycastHit hit, coneCollider.Distance, layerMask);
            if (raycast)// �v���C���[���B��Ă��Ȃ��Ƃ��i���݂͏Ǝ˂�����_���ʂ邩�ǂ����Ŕ��肵�Ă���j
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    findPlayer = true;
                    Debug.Log("FindPlayer : true");
                }
                else
                {
                    findPlayer = false;
                    Debug.Log("FindPlayer : false");
                }
            }
        }
        else
        {
            findPlayer = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //if(other.TryGetComponent<PlayerMove>(out PlayerMove playerMove) && playerMove.enabled)// �v���C���[�������Ƃ�
        if (other.gameObject.tag == "Player")
        {
            inSearchArea = true;
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.TryGetComponent<PlayerMove>(out PlayerMove playerMove) && playerMove.enabled)// �v���C���[�������Ƃ�
        if (other.gameObject.tag == "Player")
        {
            inSearchArea = false;
        }
    }

    public void OnPlayerChange()
    {
        inSearchArea = false;
        player = null;
    }
}
