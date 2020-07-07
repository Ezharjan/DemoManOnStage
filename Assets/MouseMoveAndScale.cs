using UnityEngine;
using System.Collections;

public class MouseMoveAndScale : MonoBehaviour
{
    Vector2 p1, p2;//用来记录鼠标的位置，以便计算移动距离
    void Start()
    {

    }
    void Update()
    {
        ///<说明>
        /// 通过鼠标X坐标拖动场景
        /// 
        if (Input.GetMouseButtonDown(0))
        {
            //鼠标左键按下时记录鼠标位置p1 
            p1 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            //鼠标左键拖动时记录鼠标位置p2   
            p2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (transform.position.x >= 10 && transform.position.x <= 300)  //控制在20-130之内  
            {
                float dx = (float)0.6 * (p2.x - p1.x);

                float dy = p2.y - p1.y;
                //鼠标左右移动  
                transform.Translate(-dx * Vector3.right * Time.deltaTime);
            }
            else if (transform.position.x < 10 && p2.x < p1.x)
            {
                float dx = (float)0.6 * (p2.x - p1.x);

                float dy = p2.y - p1.y;
                //鼠标左右移动  
                transform.Translate(-dx * Vector3.right * Time.deltaTime);
            }
            else if (transform.position.x > 300 && p2.x > p1.x)
            {
                float dx = (float)0.6 * (p2.x - p1.x);

                float dy = p2.y - p1.y;
                //鼠标左右移动  
                transform.Translate(-dx * Vector3.right * Time.deltaTime);
            }
        }
        //通过鼠标滚轮实现场景缩放
        //鼠标滚轮的效果
        //Camera.main.fieldOfView 摄像机的视野
        //Camera.main.orthographicSize 摄像机的正交投影
        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 20)
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }
    }
}