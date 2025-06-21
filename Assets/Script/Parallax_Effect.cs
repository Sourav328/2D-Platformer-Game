using UnityEngine;

public class Parallax_Effect : MonoBehaviour
{
    private Transform cam;
    private Vector3 lastCamPosition;
    [SerializeField] private float parallaxFactor = 0.5f;

    private void Start()
    {
        cam = Camera.main.transform;
        lastCamPosition = cam.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCamPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, 0);
        lastCamPosition = cam.position;
    }
}
