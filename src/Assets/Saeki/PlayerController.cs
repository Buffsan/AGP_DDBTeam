using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private PlayerControls input;
    [SerializeField] PlayerInput Input;
    bool aButton, bButton;
    // Start is called before the first frame update
    void Start()
    {
        //Input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        if (Input == null) return;
        // �f���Q�[�g�o�^
        Input.onActionTriggered += OnAbutton;
        Input.onActionTriggered += OnBbutton;
    }

    private void OnDisable()
    {
        if (Input == null) return;
        // �f���Q�[�g�o�^����
        Input.onActionTriggered -= OnAbutton;
        Input.onActionTriggered -= OnBbutton;
    }


    private void OnAbutton(InputAction.CallbackContext context)
    {
        if (context.action.name != "Abutton") return;
        if (!context.performed)
        {
            aButton = false;
            return;  
        }
        Debug.Log("Press");
        var isButton = context.ReadValueAsButton();
        // ���͂�ێ�
        aButton = isButton;
    }
    private void OnBbutton(InputAction.CallbackContext context)
    {
        if (context.action.name != "Bbutton") return;
        // Action�̓��͒l���擾
        var isButton = context.ReadValueAsButton();
        // ���͂�ێ�
        bButton = isButton;
    }



    // Update is called once per frame
    void Update()
    {
        if(Input != null)
        {
            if (aButton)
            {
                Debug.Log(aButton);
            }
            if (bButton)
            {
                Debug.Log(bButton);
            }
        }
    }
}
