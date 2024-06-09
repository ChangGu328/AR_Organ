using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using I2.Loc;
using bear.j.easy_dialog;
using System;

public class AR_object_control : MonoBehaviour
{
    private const int SIZE= 50;
    private const float TIMEDELAY=5f;
    [Header("AR物体")]
    public GameObject[] array_AR_Objects;

    [Header("控制动画的按钮")]
    public Button[] animation_btns;

    [Header("底部面板的animator")]
    public Animator animator_bottom_panel;

    [Header("箭头的animator")]
    public Animator animator_arrow;

    [Header("控制底部面板显示或者隐藏的箭头物体的rect transform")]
    public RectTransform RectTransform_btn_bottom_arrow;

    [Header("显示标题的UGUI text")]
    public Text text_title;

    [Header("解锁按钮")]
    public Button[] btns_lock_array;

    //当前AR游戏物体
    private GameObject obj_current_AR_Object;

    //当前AR游戏物体的animator
    private Animator animator_current_AR_Object;

    // Start is called before the first frame update
    void Start()
    {
        //初始化面板的位置
        this.init_panel();

        //切换恐龙
        this.switch_AR_Object();

        //刷新一遍上锁的按钮
        Config.instance.refresh_lock_btn(this.btns_lock_array);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("A");
        //    Canvas_toast.toast(LocalizationManager.GetTranslation("解锁成功"), TIMEDELAY);
        //    Debug.Log(LocalizationManager.GetTranslation("解锁成功"));
        //    //this.show_panel();
        //}

        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    Debug.Log("B");
        //    //this.hide_panel();
        //}
    }

    //底部面板回到原来的位置
    public void init_panel()
    {
        this.animator_arrow.Play("null");
        this.animator_bottom_panel.Play("null");
    }

    //显示底部面板
    public void show_panel()
    {
        this.animator_arrow.Play("arrow_up");
        this.animator_bottom_panel.Play("panel_show");
    }

    //隐藏底面板
    public void hide_panel()
    {
        this.animator_arrow.Play("arrow_down");
        this.animator_bottom_panel.Play("panel_hide");
    }

    //设置标题
    private void set_title()
    {
        this.text_title.text = LocalizationManager.GetTranslation(Config.instance.index_ar_object + "");
    }

    //设置显示或者隐藏哪些动画按钮
    public void set_animation_btns(Animation_type[] animation_type_array)
    {
        for (int i = 0; i < this.animation_btns.Length; i++)
        {
            this.animation_btns[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < animation_type_array.Length; i++)
        {
            this.animation_btns[(int)animation_type_array[i]].gameObject.SetActive(true);
        }
    }

    //切换AR物体
    public void switch_AR_Object()
    {
        //隐藏全部AR物体
        for (int i = 0; i < this.array_AR_Objects.Length; i++)
        {
            if (this.array_AR_Objects[i].activeSelf == true)
            {
                this.array_AR_Objects[i].SetActive(false);
            }
        }


        //根据Config的index来确定显示哪个AR物体
        for (int i = 0; i < this.array_AR_Objects.Length; i++)
        {
            if (Config.instance.index_ar_object == i)
            {
                this.array_AR_Objects[i].SetActive(true);
                //switch (i)
                //{
                //    case 0:
                //        StartCoroutine(ShowToasts());
                //        IEnumerator ShowToasts()
                //        {
                //            Canvas_toast.toast("心脏是人体的泵，位于胸腔中央偏左下",SIZE, TIMEDELAY);
                //            yield return new WaitForSeconds(2);
                //            Canvas_toast.toast("负责推动血液循环，供应全身组织器官所需的氧气和养分",SIZE, TIMEDELAY);
                //        }
                //        break;
                //    default:
                //        StartCoroutine(ShowToasts1());
                //        IEnumerator ShowToasts1()
                //        {
                //            Canvas_toast.toast("心脏",SIZE, TIMEDELAY);
                //            yield return new WaitForSeconds(2);s
                //            Canvas_toast.toast("hello",SIZE, TIMEDELAY);
                //        }
                //        break;
                //}
                switch (i)
                {
                    case 0:
                        Canvas_toast.toast("心脏是人体的泵，位于胸腔中央偏左下",SIZE, TIMEDELAY);
                        break;

                    case 1:
                        Canvas_toast.toast("肺是呼吸系统的主要器官，位于胸腔内，左右各一。",SIZE, TIMEDELAY);
                        break;
                    case 2:
                        Canvas_toast.toast("骨骼支撑身体结构，保护内部器官，并与肌肉系统合作。",SIZE, TIMEDELAY);
                        break;
                    case 3:
                        Canvas_toast.toast("肌肉通过收缩和放松来实现身体的运动和维持姿势。",SIZE, TIMEDELAY);
                        break;
                    case 4:
                        Canvas_toast.toast("大脑是中枢神经系统主要部分，控制身体的生理心理功能。",SIZE, TIMEDELAY);
                        break;
                    case 5:
                        Canvas_toast.toast("胃负责暂时储存食物并利用胃酸和酶对食物进行初步消化。",SIZE, TIMEDELAY);
                        break;
                    case 6:
                        Canvas_toast.toast("肝脏是人体最大的内脏器官，位于右上腹。",SIZE, TIMEDELAY);
                        break;
                    case 7:
                        Canvas_toast.toast("牙齿是口腔内的硬组织结构，用于咀嚼食物，帮助消化。",SIZE, TIMEDELAY);
                        break;
                    case 8:
                        Canvas_toast.toast("牙齿是口腔内的硬组织结构，用于咀嚼食物，帮助消化。",SIZE, TIMEDELAY);
                        break;
                    case 9:
                        Canvas_toast.toast("牙齿是口腔内的硬组织结构，用于咀嚼食物，帮助消化。",SIZE, TIMEDELAY);
                        break;
                    case 10:
                        Canvas_toast.toast("脊柱是背部骨骼结构，保护脊髓支撑身体，给身体灵活性",SIZE, TIMEDELAY);
                        break;
                    case 11:
                        Canvas_toast.toast("脾脏是位于左上腹部的一个重要淋巴器官，参与免疫反应",SIZE, TIMEDELAY);
                        break;
                    case 12:
                        Canvas_toast.toast("大肠是消化系统的最后一部分，负责吸收水分和形成粪便",SIZE, TIMEDELAY);
                        break;
                    case 13:
                        Canvas_toast.toast("小肠是消化和吸收主要场所，通过皱褶绒毛高效吸收营养",SIZE, TIMEDELAY);
                        break;
                    case 14:
                        Canvas_toast.toast("包括肾脏、输尿管、膀胱和尿道，负责过滤血液产生尿液",SIZE, TIMEDELAY);
                        break;
                    case 15:
                        Canvas_toast.toast("脑干连接大脑和脊髓，控制基本的生命功能",SIZE, TIMEDELAY);
                        break;
                    case 16:
                        Canvas_toast.toast("位于大脑下方，主要负责协调运动和身体姿势的维持。",SIZE, TIMEDELAY);
                        break;
                    case 17:
                        break;
                    case 18:
                        break;
                    case 19:
                        break;
                    case 20:
                        Canvas_toast.toast("阑尾是一个位于大肠起始部位的小管状结构",SIZE, TIMEDELAY);
                        break;
                    case 21:
                        Canvas_toast.toast("耳朵不仅负责听觉，还包括维持平衡的结构",SIZE, TIMEDELAY);
                        break;
                    case 22:
                        Canvas_toast.toast("舌头是口腔内肌肉，参与味觉感知、咀嚼和言语功能",SIZE, TIMEDELAY);
                        break;
                    case 23:
                        Canvas_toast.toast("眼睛是视觉器官，通过接收光线转为神经信号传给大脑",SIZE, TIMEDELAY);
                        break;
                    case 24:
                        Canvas_toast.toast("胎盘是在怀孕期间形成的临时器官，连接母体和胎儿。",SIZE, TIMEDELAY);
                        break;
                    case 25:
                        Canvas_toast.toast("气管是呼吸系统的一部分，是空气进出肺部的通道。",SIZE, TIMEDELAY);
                        break;
                    case 26:
                        Canvas_toast.toast("脊髓是中枢神经系统的延伸部分，负责传导神经信号。",SIZE, TIMEDELAY);
                        break;
                    default:
                        break;

            }

                //Canvas_toast.toast( "心脏是人体的泵，位于胸腔中央偏左下方.负责推动血液循环，供应全身组织器官所需的氧气和养分。" ,SIZE, 5f);
                //设置当前AR物体的变量，便于后面好调用
                this.obj_current_AR_Object = this.array_AR_Objects[i];
                this.animator_current_AR_Object = this.array_AR_Objects[i].GetComponent<Animator>();
            }
        }

        //设置标题
        this.set_title();

        //设置显示或者隐藏对应的动画按钮,通过存放在列表中的动画名字和按钮的名字做比对, 来决定显示哪些按钮，隐藏哪些按钮
        #region 
        //for (int i = 0; i < this.animation_btns.Length; i++)
        //{
        //    this.animation_btns[i].gameObject.SetActive(false);
        //}

        //List<string> str_list_animation = this.obj_current_AR_Object.GetComponent<Animal_control>().str_list_animation;
        //for (int i = 0; i < str_list_animation.Count; i++)
        //{
        //    for (int j = 0; j < this.animation_btns.Length; j++)
        //    {
        //        if (this.animation_btns[j].name == "Button_" + str_list_animation[i])
        //        {
        //            this.animation_btns[j].gameObject.SetActive(true);
        //        }
        //    }
        //}
        #endregion

        //播放声音
        if (Audio_control.instance != null)
            Audio_control.instance.play_dinosaur_show_sound();
    }


    //按钮事件
    #region 
    //切换恐龙
    public void on_dinosaur_btn(int index)
    {
        if (Config.instance.index_ar_object != index)
        {
            Config.instance.index_ar_object = index;
        }

        Audio_control.instance.play_btn_sound();

        //切换恐龙
        this.switch_AR_Object();
        //Debug.Log("switch_dinosaur>>>" + index);
    }

    //动画按钮点击事件
    public void on_animation_btn_click(string animation_name)
    {
        if (this.animator_current_AR_Object.GetCurrentAnimatorStateInfo(0).IsName(animation_name))
            return;

        //Debug.Log("on_lock_btn_click>>>" + animation_type);
        Audio_control.instance.play_btn_sound_half();

        this.animator_current_AR_Object.SetTrigger(animation_name);
        Debug.Log(animation_name);
        if (animation_name == "die")
        {
            this.animator_current_AR_Object.GetComponent<AudioSource>().Pause();
        }
        else if (this.animator_current_AR_Object.GetComponent<AudioSource>().isPlaying == false)
        {
            this.animator_current_AR_Object.GetComponent<AudioSource>().Play();
        }
    }

    //解锁按钮的 事件监听
    public void on_lock_btn_click(int index)
    {
        //播放按钮声音
        Audio_control.instance.play_btn_sound();

        //I2.Loc.LocalizationManager.GetTranslation("Sorry, no more data!"));
        //Canvas_confirm_box.confirm_box
        //(
        //    //LocalizationManager.GetTranslation("提示"),
        //    //LocalizationManager.GetTranslation("观看广告可解锁物体"),
        //    //LocalizationManager.GetTranslation("取消"),
        //    //LocalizationManager.GetTranslation("确定"),
        //    //false,
        //    //delegate ()
        //    //{
        //    //    //播放按钮声音
        //    //    Audio_control.instance.play_btn_sound();
        //    //},
        //    //delegate ()
        //    //{
        //    //    //播放按钮声音
        //    //    Audio_control.instance.play_btn_sound();

        //    //    //解锁的索引
        //    //    Config.instance.unlock_index = index;

        //    //    Ad_control.instance.remove_all_self_event();

        //    //    Ad_control.instance.completed_event += this.completed_event;

        //    //    Ad_control.instance.failed_loaded_event += this.skipped_event;

        //    //    Ad_control.instance.failed_event += this.failed_event;

        //    //    Ad_control.instance.show_ad();
        //    //}
        //);
    }

    //底部控制底部面板的按钮被点击
    public void on_bottom_arrow_btn()
    {
        if (this.RectTransform_btn_bottom_arrow.localEulerAngles.z == 0)
        {
            Audio_control.instance.play_btn_sound();
            this.show_panel();
        }
        else if (this.RectTransform_btn_bottom_arrow.localEulerAngles.z == 180)
        {
            Audio_control.instance.play_btn_sound();
            this.hide_panel();
        }
    }
    #endregion

    //广告事件
    #region 
    //广告看完的事件
    public void completed_event()
    {
        //存一个时间
        PlayerPrefs.SetString(Config.instance.unlock_index + "", System.DateTime.Now + "");

        //toast 提示
        Canvas_toast.toast(LocalizationManager.GetTranslation("解锁成功"), TIMEDELAY);

        //重新初始化一下 哪些被锁了
        Config.instance.refresh_lock_btn(this.btns_lock_array);

        //播放成功的声音
        Audio_control.instance.play_ad_success_sound();

        //切换到识别状态
        //this.main_control.change_to_recognizing();

        //隐藏面板
        //this.is_hiding = true;
    }
    //广告略过的事件
    public void skipped_event()
    {
        Canvas_confirm_box.confirm_box
        (
            LocalizationManager.GetTranslation("提示"),
            LocalizationManager.GetTranslation("对不起，出现网络问题，请稍后再试"),
            LocalizationManager.GetTranslation("取消"),
            LocalizationManager.GetTranslation("确定"),
            true,
            delegate () { },
            delegate ()
            {

                //播放按钮的声音
                Audio_control.instance.play_btn_sound();

                //重新初始化一下 哪些被锁了
                Config.instance.refresh_lock_btn(this.btns_lock_array);
            }
        );
    }
    //广告失败的事件
    public void failed_event()
    {
        Canvas_confirm_box.confirm_box
          (
              LocalizationManager.GetTranslation("提示"),
              LocalizationManager.GetTranslation("对不起，出现网络问题，请稍后再试"),
              LocalizationManager.GetTranslation("取消"),
              LocalizationManager.GetTranslation("确定"),
              true,
              delegate () { },
              delegate ()
              {
                  //播放按钮的声音
                  Audio_control.instance.play_btn_sound();

                  //重新初始化一下 哪些被锁了
                  Config.instance.refresh_lock_btn(this.btns_lock_array);

                  //切换到识别状态
                  //this.main_control.change_to_recognizing();

                  //隐藏面板
                  //this.is_hiding = true;
              }
          );
    }
    #endregion
}


//有哪些动画类型
public enum Animation_type
{
    idle,
    walk,
    run,
    jump,
    sleep,
    eat,
    attack,
    die,
    fly
}
