using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ParalaxItem : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    [SerializeField]
    Vector2 backgroundSpeed;

    Vector3 lastCameraPosition;
    float length;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<CinemachineVirtualCamera>();
        lastCameraPosition = cam.transform.position;
        length = GetComponent<SpriteRenderer>().size.x;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cam.transform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * backgroundSpeed.x, deltaMovement.y * backgroundSpeed.y);
        lastCameraPosition = cam.transform.position;

        // Spostamento paralax sull'asse X
        if (cam.transform.position.x - transform.position.x > length)
        {
            transform.position = new Vector3(transform.position.x + length, transform.position.y);
        }
        else if (cam.transform.position.x - transform.position.x < -length)
        {
            transform.position = new Vector3(transform.position.x - length, transform.position.y);
        }

        // Spostamento paralax sull'asse Y
        if (cam.transform.position.y - transform.position.y > length)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + length);
        }
        else if (cam.transform.position.y - transform.position.y < -length)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - length);
        }
    }
}