using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OnMouseUp,OnMouseDown 触发条件：
// 游戏物体有碰撞盒
// 或者 该物体为UI元素
public class RotateBySelfPivot : MonoBehaviour
{
    public MeshRenderer liverMesh;
    // public GameObject liverMesh;

    private bool isClick = false;
    private float speed = 2;



    private void Start()
    {
        print("center of liver gameobject!");
        //print(gameObject.GetComponent<MeshRenderer>().bounds.center);
        print(liverMesh.bounds.center);
    }


    void OnMouseUp()
    {
        isClick = false;
    }


    void OnMouseDown()
    {
        isClick = true;
    }

    void Update()
    {
        // ?? 为什么Space.Local，结果变成了绕着z轴转?
        // 0:Space.World  1:Space.Local
        //transform.Rotate(0, 20 * Time.deltaTime, 1);


        if (isClick)
        {
            float fMouseX = Input.GetAxis("Mouse X");// 获取鼠标drag时，x轴移动的距离
            float fMouseY = Input.GetAxis("Mouse Y");

            //print(fMouseX + "," + fMouseY);

            //  之所以这么奇怪，是因为整个器官是横着的
            transform.RotateAround(liverMesh.bounds.center, new Vector3(0, 1, 0), -fMouseX * speed);
            transform.RotateAround(liverMesh.bounds.center, new Vector3(1, 0, 0), fMouseY * speed);

            // 该方法不行
            //transform.Rotate(Vector3.up, fMouseX * speed, Space.Self);
            //transform.Rotate(Vector3.right, fMouseY * speed, Space.Self);

        }
    }
}

