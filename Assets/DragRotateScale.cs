using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 本脚本实现场景的平移，缩放，旋转功能
/// 初始状态，要求场景所有模型对象（不包括摄像机）有一个父对象，并且此父对象的坐标为世界坐标系原点
/// 初始状态，摄像机位置为（0，0，-10），并朝向世界坐标系原点。
/// 平移功能：场景对象在世界坐标系的XY平面移动。
/// 缩放功能：摄像机沿着世界坐标系的Z轴方向，前后移动。
/// 旋转功能：场景对象绕自身坐标系的X轴和Y轴旋转。
/// </summary>
public class DragRotateScale : MonoBehaviour
{
    //场景对象
    public Transform scene;
    //镜头与目标距离
    public float camTarDistance = 2.0f, camTarDistanceMin = 2.0f, camTarDistanceMax = 30.0f;
    //拖拽灵敏度
    public float dragSensitive = 1.0f;
    //旋转灵敏度
    public float rotateSensitive = 10.0f;
    //缩放灵敏度
    public float scaleSensitive = 5.0f;
    //双击选中间隔系数
    public float selectedSensitive = 4.0f;
    //阻尼参数及系数
    public bool needDamping = true;
    private float dampingScale = 5.0f;
    //鼠标移动分量
    private float camEulerX, camEulerY;
    private Quaternion camRotation;
    private Vector3 camPosition;
    //鼠标右键上一次点击时间
    private float firstClickTime = 0;
    /// <summary>
    /// 双击鼠标右键，选中场景中心
    /// 使摄像机回到初始位置
    /// </summary>
    void SlectedCenter()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (firstClickTime != 0f && Time.realtimeSinceStartup - firstClickTime < 0.1f *

selectedSensitive)
            {
                transform.position = new Vector3(0, 0, -10);
            }
            firstClickTime = Time.realtimeSinceStartup;
        }
    }
    /// <summary>
    /// 鼠标滚轮调整镜头与目标距离,实现缩放
    /// </summary>
    void ScrollWheelScale()
    {
        //调整镜头距离
        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0.02f)
        {
            camTarDistance = Input.GetAxis("Mouse ScrollWheel") * scaleSensitive;
            camPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z

+ camTarDistance);
            transform.position = Vector3.Lerp(transform.position, camPosition, Time.deltaTime *

dampingScale);
        }
    }
    /// <summary>
    /// 鼠标右键旋转场景
    /// </summary>
    void RightDownRotate()
    {
        if (Input.GetMouseButton(1))
        {
            camEulerX += Input.GetAxis("Mouse X") * rotateSensitive;
            camEulerY += Input.GetAxis("Mouse Y") * rotateSensitive;

            Quaternion targetRotation = scene.rotation;

            targetRotation = Quaternion.Euler(camEulerY, -camEulerX, 0.0f);
            scene.rotation = targetRotation;
        }

    }
    /// <summary>
    /// 鼠标左键拖拽场景，实现场景平移（摄像机反向移动）
    /// </summary>
    void LeftDownDrag()
    {
        if (Input.GetMouseButton(0))
        {
            float horizontal = -Input.GetAxis("Mouse X") * dragSensitive;
            float vertical = -Input.GetAxis("Mouse Y") * dragSensitive;

            transform.Translate(new Vector3(horizontal, vertical, 0.0f));
        }
    }

    void Start()
    {
        //初始化参数
        camRotation = transform.rotation;
        camPosition = transform.position;
        Vector3 angles = transform.eulerAngles;
        camEulerX = angles.y;
        camEulerY = angles.x;
    }

    void Update()
    {
        LeftDownDrag();
        RightDownRotate();
        ScrollWheelScale();
        SlectedCenter();
    }
}