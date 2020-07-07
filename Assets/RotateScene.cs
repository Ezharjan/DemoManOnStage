using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //transform.Rotate(0,30*Time.deltaTime,0);
        if (Input.GetMouseButton(0))
        {
            //将屏幕坐标转化为世界坐标
            var pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, Camera.main.farClipPlane));
            //求弧度
            var radian = Mathf.Atan2(-pos.y, pos.x);
            //将弧度转化为角度
            var angle = Mathf.Rad2Deg * radian;
            //改变当前对象在世界空间中的旋转角度
            transform.localEulerAngles = new Vector3(0, angle, 0);

        }
    }
}
