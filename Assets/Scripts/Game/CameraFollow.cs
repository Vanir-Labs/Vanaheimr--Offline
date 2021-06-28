// CameraFollow
// By: Lex King
// Place on Main Camera
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float minXClamp = -41f;
    public float maxXClamp = 5f;
    public float minYClamp = 32f;
    public float maxYClamp = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            //create a variable to store the camera's x, y and z position
            Vector3 cameraTransform;

            //take my position values and put them in the variable
            cameraTransform = transform.position;

            cameraTransform.x = player.transform.position.x - 0.5f;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);
            cameraTransform.y = player.transform.position.x - 0.5f;
            cameraTransform.y = Mathf.Clamp(cameraTransform.x, minYClamp, maxYClamp);
            transform.position = cameraTransform;
        }
    }
}
