using System;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Button _firstButton;

    private void Start()
    {
        transform.position = _firstButton.transform.position;    
    }

    public void SetPointerPosition(Button target)
    {
        transform.position = target.transform.position;
    }
}

public static class Bezier
{
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float x = 1f - t;

        return (float)Math.Pow(x, 3) * p0 +
            3f * (float)Math.Pow(x, 2) * t * p1 +
            3f * x * (float)Math.Pow(t, 2) * p2 +
            (float)Math.Pow(t, 3) * p3;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float x = 1f - t;

        return 3f * (float)Math.Pow(x, 2) * (p1 - p0) +
            6f * x * t * (p2 - p1) +
            3f * (float)Math.Pow(t, 2) * (p3 - p2);
    }
}