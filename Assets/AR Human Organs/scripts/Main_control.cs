using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using System;
using UnityEngine.SceneManagement;
using I2.Loc;

public class Main_control : MonoBehaviour
{
    public static Main_control instance;

    [Header("识别平面后放置的物体 Identify objects placed behind the plane")] //todo 改成数组
    public GameObject objectToPlace;

    [Header("识别平面的提示框 Recognition plane prompt box")]
    public GameObject placementIndicator;

    [Header("放置物体的按钮 Button to place the object")]
    public GameObject gameobject_place_btn;

    [Header("重置物体的按钮 Button to reset the object")]
    public GameObject gameobject_reset_btn;

    [Header("返回第一个场景的按钮 Button to reset the object")]
    public GameObject gameobject_back_btn;

    [Header("提示文本的物体 Prompt text object")]
    public GameObject gameobject_hint_scanning;

    //[Header("debug文本 显示平面到摄像机的距离 debug text display the distance from the plane to the camera")]
    //public Text Text_debug;

    [Header("Directional light's transform")]
    public Transform transform_directional_light;

    //现实世界中的平面的位置 The position of the plane in the real world
    private Pose placementPose;

    //是否识别到平面 Whether the plane is recognized
    private bool placementPoseIsValid = false;

    //AR 数据源 AR data source
    private ARSessionOrigin arOrigin;

    //AR foundation 释放射线的对象 AR foundation releases the ray object
    private ARRaycastManager raycastManager;

    void Awake()
    {
        Main_control.instance = this;
    }

    void Start()
    {
        //找到ar数据源
        this.arOrigin = FindObjectOfType<ARSessionOrigin>();

        //找到AR射线对象
        this.raycastManager = FindObjectOfType<ARRaycastManager>();

        //初始化切换到识别状态
        this.change_to_recognizing();
    }

    void Update()
    {
        if (Config.instance.ar_statu == AR_statu.recognizing)
        {
            this.UpdatePlacementPose();

            this.UpdatePlacementIndicator();
        }
    }

    //切换到识别平面状态 Switch to the recognition plane state
    public void change_to_recognizing()
    {
        Config.instance.ar_statu = AR_statu.recognizing;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("ar_object");
        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i].gameObject);
        }

        this.gameobject_place_btn.SetActive(false);

        this.gameobject_reset_btn.SetActive(false);

        this.gameobject_back_btn.SetActive(false);
    }

    //切换到已经放置物体状态 Switch to the placed object state
    public void change_to_object_is_placed()
    {
        Config.instance.ar_statu = AR_statu.object_is_placed;

        this.PlaceObject();

        this.gameobject_reset_btn.SetActive(true);

        this.gameobject_back_btn.SetActive(true);

        this.gameobject_place_btn.SetActive(false);

        this.placementIndicator.SetActive(false);
    }

    //更新现实世界是否识别到平面，以及现实平面的位置 Update whether the plane is recognized in the real world and the position of the real plane
    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        var hits = new List<ARRaycastHit>();

        this.raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);


        this.placementPoseIsValid = hits.Count > 0;


        if (this.placementPoseIsValid)
        {
            this.placementPose = hits[0].pose;

            float distance = (this.placementPose.position - Camera.main.transform.position).sqrMagnitude;

            if (distance < 0.15f || distance > 5.5f)
                this.placementPoseIsValid = false;
            else
            {
                var cameraForward = Camera.main.transform.forward;
                var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

                this.placementPose.rotation = Quaternion.LookRotation(cameraBearing);
            }
        }
    }

    //更新平面指示器是否显示和显示的位置 Update whether the plane indicator is displayed and where it is displayed
    private void UpdatePlacementIndicator()
    {
        if (this.placementPoseIsValid)
        {
            this.placementIndicator.SetActive(true);
            this.placementIndicator.transform.SetPositionAndRotation(this.placementPose.position, this.placementPose.rotation);

            StartCoroutine(Canvas_grounp_fade.hide(this.gameobject_hint_scanning));

            this.gameobject_place_btn.SetActive(true);
        }
        else
        {
            this.placementIndicator.SetActive(false);

            StartCoroutine(Canvas_grounp_fade.show(this.gameobject_hint_scanning));

            this.gameobject_place_btn.SetActive(false);
        }
    }

    //放置物体 Place objects
    private void PlaceObject()
    {
        GameObject obj = Instantiate(this.objectToPlace, this.placementPose.position, this.placementPose.rotation);

        //set the light position
        this.transform_directional_light.position = Camera.main.transform.position;
        this.transform.LookAt(obj.transform.position);
    }

    //切换模型 Switch model
    public void switch_buidling()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("ar_object");
        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i].gameObject);
        }

        this.PlaceObject();
    }

    //event
    #region 
    //监听重置按钮 Monitor reset button
    public void on_reset_btn()
    {
        Audio_control.instance.play_btn_sound();

        this.change_to_recognizing();
    }

    //监听返回按钮 Monitor back button
    public void on_back_btn()
    {
        Audio_control.instance.play_btn_sound();

        SceneManager.LoadSceneAsync("main_ui");
    }

    //监听放置按钮 Monitor placement button
    public void on_place_btn()
    {
        Audio_control.instance.play_btn_sound();

        this.change_to_object_is_placed();
    }
    #endregion
}

