using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRay : MonoBehaviour
{
    private CinemachineVirtualCamera _cam;
    [SerializeField] Camera fpsCam;
    [SerializeField] float distance = 50.0f;    //���o�\�ȋ���

    // Start is called before the first frame update
    void Start() 
    {
       _cam= GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            //�J�����̈ʒu����Ƃ΂�
            var rayStartPosition = fpsCam.transform.position;

            //�J�����������Ă�����ɂƂ΂�
            var rayDirection = fpsCam.transform.forward.normalized;

            //Hit�����I�u�W�F�N�g�i�[�p
            RaycastHit raycastHit;

            Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

            if (Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance)) 
            {
                // Log��Hit�����I�u�W�F�N�g�����o��
                //Debug.Log(context.phase);
                Debug.Log("HitObject : " + raycastHit.collider.gameObject.name);

                if (raycastHit.collider.tag == "Enemy")
                {
                    Debug.Log("Hit");
                    //�e��Enemy��
                    transform.parent.gameObject.tag = "Enemy";
                    //�e�̕t���ւ�
                    this.gameObject.transform.parent = raycastHit.transform;
                    //�e��Player��
                    transform.parent.gameObject.tag = "Player";

                    _cam.Follow = raycastHit.transform;
                    this.transform.position = raycastHit.transform.position;
                }
            }
        }
    }
}
