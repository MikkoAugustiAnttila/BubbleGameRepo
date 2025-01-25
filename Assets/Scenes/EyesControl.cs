using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesControl : MonoBehaviour
{
    public GameObject eyes;
    public Camera camera;
    public float speed = 10;
    public float intensity = 0.3f;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera != null)
        {
            EyesAim();
        }

    }
    void EyesAim()
    {
        /* Get the mouse position in world space rather than screen space. */
        var mouseWorldCoord = camera.ScreenPointToRay(Input.mousePosition).origin;

        /* Get a vector pointing from initialPosition to the target. Vector shouldn't be longer than maxDistance. */
        var originToMouse = mouseWorldCoord - this.transform.position;
        originToMouse = Vector3.ClampMagnitude(originToMouse, intensity);

        /* Linearly interpolate from current position to mouse's position. */
        eyes.transform.position = Vector3.Lerp(eyes.transform.position, this.transform.position + originToMouse, speed * Time.deltaTime);
    }


}