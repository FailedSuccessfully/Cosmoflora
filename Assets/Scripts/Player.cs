using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    float smoothTime = 0.3f;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraTrack();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = new Vector2(transform.position.x + deltaX, transform.position.y + deltaY);

        transform.position = newXPos;
    }

    private void CameraTrack()
    {
        Vector3 targetPos = transform.TransformPoint(new Vector3(0, 0, -10));
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, targetPos, ref velocity, smoothTime);
    }
}
