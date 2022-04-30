using UnityEngine;
using UnityEngine.UI;

public class FPSCountDisplay : MonoBehaviour
{
    [SerializeField] public Text FPSCount;

    private float _pollingTime = 1f;
    private float _time;
    private float _frameCount;
    
    void Update()
    {
        _time += Time.deltaTime;

        _frameCount++;

        if (_time >= _pollingTime)
        {
            int frameRate = Mathf.RoundToInt(_frameCount / _time);
            FPSCount.text = frameRate.ToString();

            _time -= _pollingTime;
            _frameCount = 0;
        }
    }
}