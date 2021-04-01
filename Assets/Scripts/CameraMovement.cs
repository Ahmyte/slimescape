using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /*[HideInInspector] */
    public bool canAscend;
    [SerializeField] public float speedFactor;
    public float targetSpeedFactor;
    [Range(0, 1)] public float smoothness;

    private void FixedUpdate()
    {
        Ascend();
    }

    private void Ascend()
    {
        if (canAscend)
        {
            speedFactor = Mathf.Lerp(speedFactor, targetSpeedFactor, smoothness);
            transform.Translate(Vector3.up * speedFactor * Time.deltaTime);
        }  
    }

}
