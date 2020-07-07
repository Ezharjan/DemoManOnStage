using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float _rotationX;
    float rotationY;
    public float sensitivityHor = 5.0f;
    public float sensitivityVert = 5.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    // Update is called once per frame
    void Update()
    {
        //摄像头移动
        //float x = Input.GetAxis("Horizontal") * Time.deltaTime * 5;
        //float y = Input.GetAxis("Vertical") * Time.deltaTime * 5;
        //transform.Translate(x, 0, y);
        //限制摄像头移动的范围
        //float move_x = Mathf.Clamp(transform.position.x, -20f, 20f);
        //float move_y = Mathf.Clamp(transform.position.y, -20f, 20f);
        //float move_z = Mathf.Clamp(transform.position.z, -20f, 20f);
        //transform.position = new Vector3(move_x, move_y, move_z);
        //点击鼠标右键旋转摄像头
        if (Input.GetMouseButton(1))
        {
            rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }

    }
}