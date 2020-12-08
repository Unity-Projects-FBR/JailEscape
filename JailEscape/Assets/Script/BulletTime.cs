using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BulletTime : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public PostProcessLayer postProcessEffectLayer;

    public void SlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        postProcessEffectLayer.enabled = true;
    }
    public void NormalMotion()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        postProcessEffectLayer.enabled = false;
    }
}
