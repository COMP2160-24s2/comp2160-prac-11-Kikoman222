using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    private float defaultFov = 90;
    private float defalutOrtho = 10f;
    private Actions actions;
    private InputAction cameraMove;


    void Awake()
    {
        actions = new Actions();
        cameraMove = actions.camera.zoom;
    }
    void Start()
    {
        cam = Camera.main;
    }
    void OnEnable()
    {
        actions.camera.Enable();
        cameraMove.performed += CamMove;

    }
    void OnDisable()
    {
        actions.camera.Disable();
        cameraMove.canceled -= CamMove;
    }
    // Update is called once per frame
    void Update()
    {
        ZoomCamera(defaultFov,defalutOrtho);
    }
    void ZoomCamera(float target,float take)
    {
        cam.fieldOfView = target;
        cam.orthographicSize = take;
    }
    void CamMove(InputAction.CallbackContext context)
    {
        float val = context.ReadValue<float>();
        if(val>0){
            defaultFov -=2;
            defalutOrtho -= 0.2f;
        }else if(val<0){
            defaultFov +=2;
            defalutOrtho += 0.2f;
        }
        defalutOrtho = Mathf.Clamp(defalutOrtho,3,20);
        defaultFov = Mathf.Clamp(defaultFov, 20, 120);
    }

}
