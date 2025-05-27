using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CameraData : ScriptableObject
{
    [Header("Camera attributes")]
    public float DashXDamping;
    public float DashYDamping;
    public float HurtXDamping;
    public float HurtYDamping;
    public float AmplitudeGain;
    public float FrequencyGain;

    public float[] cameraOrthoSize = new float[6];

}
