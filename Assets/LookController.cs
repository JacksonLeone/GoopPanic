using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookController : MonoBehaviour
{
    public float CameraYChange = 0f;
    private float OrigCameraY;
    private float OrigDeadZoneHeight;
    private CinemachineVirtualCamera cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CinemachineVirtualCamera>();
        OrigCameraY = cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY;
        OrigDeadZoneHeight = cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight;
    }

    // Update is called once per frame
    void Update()
    {
        // print(Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical") != 0f)
        {
            cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = 0;
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetKeyDown(KeyCode.Space))
        {
            cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = OrigDeadZoneHeight;
        }

        if (Input.GetAxis("Vertical") > 0.5)
        {
            cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = OrigCameraY + CameraYChange;
        }
        else if (Input.GetAxis("Vertical") < -0.5)
        {
            cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = OrigCameraY - CameraYChange;
        }
        else
        {
            cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = OrigCameraY;
        }
    }
}
