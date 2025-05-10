using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCoroutines : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    [SerializeField] PlayerData playerData;

    void Start()
    {
        if( VirtualCamera == null)
        {
            VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }
        if( playerData == null)
        {
            Debug.Log("oups");
        }
        
    }
    public IEnumerator LerpXYDamping()
    {
        float XstartValue = VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping;
        float YstartValue = VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping;
        float elapsed = 0f;
        

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 1f;
            VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = Mathf.Lerp(XstartValue, 0, t);
            VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = Mathf.Lerp(YstartValue, 0, t);
            yield return null;
        }

        // S'assure que la valeur finale est bien atteinte
        VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 0;
        VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = 0;
    }

    public IEnumerator LerpCameraNoise()
    {
        float AmplitudeStartValue = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain;
        float FrequencyStartValue = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain;
        float elapsed = 0f;


        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 0.5f;
            VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(AmplitudeStartValue, 0, t);
            VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Mathf.Lerp(FrequencyStartValue, 0, t);
            yield return null;
        }

        // S'assure que la valeur finale est bien atteinte
        VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 0;
        VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = 0;
    }
}
