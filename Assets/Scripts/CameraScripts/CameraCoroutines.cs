using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCoroutines : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    void Start()
    {
        if( VirtualCamera == null)
        {
            VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }
        
    }
    public IEnumerator LerpXDamping()
    {
        float startValue = VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping;
        float elapsed = 0f;
        

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 1f;
            VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = Mathf.Lerp(startValue, 0, t);
            yield return null;
        }

        // S'assure que la valeur finale est bien atteinte
        VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 0;
    }
}
