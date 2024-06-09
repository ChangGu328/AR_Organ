using bear.j.easy_dialog;
using epoching.loading_circle;
using I2.Loc;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_ui_control : MonoBehaviour
{
    [Header("解锁按钮")]
    public Button[] btns_lock_array;

    void Start()
    {
        //刷新一遍上锁的按钮
        Config.instance.refresh_lock_btn(this.btns_lock_array);
    }

    //点击按钮
    public void on_obj_btn(int index)
    {
        //设置index
        Config.instance.index_ar_object = index;
        Debug.Log("1");
        //播放按钮声音
        Audio_control.instance.play_btn_sound();
        Debug.Log("2");
        //I2.Loc.LocalizationManager.GetTranslation("Sorry, no more data!"));
        Canvas_confirm_box.confirm_box
        (
            LocalizationManager.GetTranslation("提示"),
            // 这个AR_warning不是提示框直接展示的内容，是对应的这一句话
            LocalizationManager.GetTranslation("AR_warning"),
            LocalizationManager.GetTranslation("取消"),
            LocalizationManager.GetTranslation("确定"),
            true,
            delegate () 
            {
                Audio_control.instance.play_btn_sound();
                Debug.Log("3");
            },
            delegate ()
            {
                //播放按钮声音
                Audio_control.instance.play_btn_sound();
                Debug.Log("4");
                //切换到加载场景
                StartCoroutine(load_scene("AR"));
            }
        );
    }
    


    public void on_lock_btn_click(int index)
    {
        // 播放按钮声音
        Audio_control.instance.play_btn_sound();
        //设置index
        Config.instance.index_ar_object = index;
        Debug.Log("1");
        // 根据索引选择不同的参数
        string question = "";
        string optionA = "";
        string optionB = "";
        string optionC = "";
        string correctAnswer = "";
        // 根据索引设置不同的参数
        switch (index)
        {
            case 0:
                question = "心脏参加“肌肉力量大赛”，它每分钟泵血量相当于几瓶标准可乐？";
                optionA = "A. 1瓶";
                optionB = "B. 5瓶";
                optionC = "C. 10瓶";
                correctAnswer = "B";
                break;

            case 1:
                question = "肺泡壁能让蚂蚁穿过吗？";
                optionA = "A. 能，蚂蚁健步如飞";
                optionB = "B. 不能，蚂蚁得绕道走";
                optionC = "C. 不知道";
                correctAnswer = "A";
                break;

            case 2:
                question = "假设你的骨头按数字排列，成人通常会有几串“206”糖葫芦？";
                optionA = "A. 1串";
                optionB = "B. 2串";
                optionC = "C. 3串";
                correctAnswer = "A";
                break;

            case 3:
                question = "骨骼肌的特殊技能？";
                optionA = "A. 变色伪装";
                optionB = "B. 发射生物电";
                optionC = "C. 分泌激素";
                correctAnswer = "B";
                break;

            case 4:
                question = "大脑哪个区域管控安全？";
                optionA = "A. 大脑皮层的音乐鉴赏区";
                optionB = "B. 脑干的安全监控中心";
                optionC = "C. 前额叶皮层的决策与控制区";
                correctAnswer = "B";
                break;

            case 5:
                question = "在胃的“消化实验”中，哪种“试剂”帮助它溶解金属？";
                optionA = "A. “盐水溶液”";
                optionB = "B. “强硫酸溶液”";
                optionC = "C. “王水溶液”";
                correctAnswer = "A";
                break;

            case 6:
                question = "肝脏除了解毒还有什么功能？";
                optionA = "A. “体内银行”，存储维生素和矿物质";
                optionB = "B. “天气预报员”，调节体温";
                optionC = "C. “能量工厂”，将多余的糖转化为脂肪储存";
                correctAnswer = "A";
                break;

            case 7:
                question = "牙釉质为何最硬？";
                optionA = "A. 因为它能抵御所有食物的“磨砺”";
                optionB = "B. 它能在阳光下闪耀七彩光芒";
                optionC = "C. 它的硬度仅次于钻石";
                correctAnswer = "A";
                break;
            case 8:
                question = "脑干不负责哪项功能？";
                optionA = " A. 发起“呼吸号令”";
                optionB = "B. 组织“心跳节奏乐队”";
                optionC = "C. 主持“思维辩论大赛”";
                correctAnswer = "C";
                break;
            case 9:
                question = "小脑帮助避免什么情况？";
                optionA = "A.“跌倒明星”——走路不稳";
                optionB = "B.“语言错乱”——说话不清";
                optionC = "C. “记忆断片”——短期记忆丧失";
                correctAnswer = "A";
                break;
           
            case 10:
                question = "脊柱神经通过什么沟通？";
                optionA = "A. 龙之眼（视觉神经出口）";
                optionB = "B. 知识之泉（脊髓末端）";
                optionC = "C. 神经之桥（椎间孔）";
                correctAnswer = "C";
                break;

            case 11:
                question = "脾脏如何处理老化的红细胞“员工”？";
                optionA = "A. 召集所有“员工”（白细胞）开会讨论";
                optionB = "B. 举办“清理大赛”，看谁吞噬最多";
                optionC = "C. 直接“丢弃”至血液回收站";
                correctAnswer = "B";
                break;

            case 12:
                question = "大肠中哪种微生物产气？";
                optionA = "A. “甜蜜分解者”——喜糖细菌";
                optionB = "B. “沉默的转化者”——无氧呼吸菌";
                optionC = "C. “气体魔术师”——产气杆菌";
                correctAnswer = "C";
                break;
            case 13:
                question = "小肠中哪种酶解蛋白质？";
                optionA = "A. “蛋白破解者”——蛋白酶";
                optionB = "B. “碳水征服者”——淀粉酶";
                optionC = "C. “脂肪溶解大师”——脂肪酶";
                correctAnswer = "A";
                break;
            case 14:
                question = "哪个器官过滤血液废物？";
                optionA = "A. 心脏的“净化车间”";
                optionB = "B. 肾脏的“过滤工厂”";
                optionC = "C. 膀胱的“存储仓库”";
                correctAnswer = "B";
                break;
            case 15:
                question = "脑干不负责哪项功能？";
                optionA = " A. 发起“呼吸号令”";
                optionB = "B. 组织“心跳节奏乐队”";
                optionC = "C. 主持“思维辩论大赛”";
                correctAnswer = "C";
                break;
            case 16:
                question = "小脑帮助避免什么情况？";
                optionA = "A.“跌倒明星”——走路不稳";
                optionB = "B.“语言错乱”——说话不清";
                optionC = "C. “记忆断片”——短期记忆丧失";
                correctAnswer = "A";
                break;
            case 17:
                question = "大肠中哪种微生物产气？";
                optionA = "A. “甜蜜分解者”——喜糖细菌";
                optionB = "B. “沉默的转化者”——无氧呼吸菌";
                optionC = "C. “气体魔术师”——产气杆菌";
                correctAnswer = "C";
                break;
            case 18:
                question = "小肠中哪种酶解蛋白质？";
                optionA = "A. “蛋白破解者”——蛋白酶";
                optionB = "B. “碳水征服者”——淀粉酶";
                optionC = "C. “脂肪溶解大师”——脂肪酶";
                correctAnswer = "A";
                break;
            case 19:
                question = "哪个器官过滤血液废物？";
                optionA = "A. 心脏的“净化车间”";
                optionB = "B. 肾脏的“过滤工厂”";
                optionC = "C. 膀胱的“存储仓库”";
                correctAnswer = "B";
                break;
            
            case 20:
                question = "阑尾可能扮演什么角色？";
                optionA = "A. 微生物储存库";
                optionB = "B. 增强免疫反应";
                optionC = "C. 所有上述功能";
                correctAnswer = "C";
                break;
            case 21:
                question = "耳朵哪个结构捕捉声波？";
                optionA = "A. 鼓膜";
                optionB = "B. 听小骨";
                optionC = "C. 外耳道";
                correctAnswer = "C";
                break;
            case 22:
                question = "舌头哪种味蕾感知苦味？";
                optionA = "A. 甜味";
                optionB = "B. 酸味";
                optionC = "C. 苦味";
                correctAnswer = "C";
                break;
            case 23:
                question = "哪种结构使眼睛聚焦？";
                optionA = "A. 角膜";
                optionB = "B. 晶状体";
                optionC = "C. 玻璃体";
                correctAnswer = "B";
                break;
            case 24:
                question = "胎盘如何确保物质交换？";
                optionA = "A. 直接血管连接";
                optionB = "B. 分泌激素调节";
                optionC = "C. A和B";
                correctAnswer = "C";
                break;
            case 25:
                question = "气管靠什么结构保持开放？";
                optionA = "A. 气管软骨环";
                optionB = "B. 平滑肌纤维";
                optionC = "C. 粘液层";
                correctAnswer = "A";
                break;
            case 26:
                question = "脊髓在哪实现快速反应？";
                optionA = "A. 条件反射";
                optionB = "B. 非条件反射";
                optionC = "C.以上都是";
                correctAnswer = "A";
                break;
            default:
                // 如果索引不匹配任何 case，可以提供一个默认的处理逻辑
                break;
        }

        // 创建 quiz 对话框
        Canvas_quiz_dialog.quiz_dialog(index,question, optionA, optionB, optionC, correctAnswer);
    }


    public void turn_to_ar(int index)
    {
        //设置index
        if (Config.instance != null)
        {
            Config.instance.index_ar_object = index;
        }
        else
        {
            Debug.LogError("Config.instance is null! Make sure it's properly initialized.");
        }

        Debug.Log("1");
        //播放按钮声音
        Audio_control.instance.play_btn_sound();
        Debug.Log("2");
        //I2.Loc.LocalizationManager.GetTranslation("Sorry, no more data!"));
        Canvas_confirm_box.confirm_box
        (
            LocalizationManager.GetTranslation("提示"),
            // 这个AR_warning不是提示框直接展示的内容，是对应的这一句话
            LocalizationManager.GetTranslation("AR_warning"),
            LocalizationManager.GetTranslation("取消"),
            LocalizationManager.GetTranslation("确定"),
            true,
            delegate ()
            {
                Audio_control.instance.play_btn_sound();
                Debug.Log("3");
            },
            delegate ()
            {
                //播放按钮声音
                Audio_control.instance.play_btn_sound();
                Debug.Log("4");
                //切换到加载场景
                StartCoroutine(load_scene("AR"));
            }
        );
    }

    //点击解锁按钮
    public void again_or_cancel(int index)
    {
        //播放按钮声音
        Audio_control.instance.play_btn_sound();

        //I2.Loc.LocalizationManager.GetTranslation("Sorry, no more data!"));
        Canvas_confirm_box.confirm_box
        (
            LocalizationManager.GetTranslation("提示"),
            // 我不知道怎么修改这个提示的内容？
            // 这边提示询问：是否再尝试一次

            LocalizationManager.GetTranslation("AR_warning"),
            //LocalizationManager.GetTranslation("答题即可解锁"),
            LocalizationManager.GetTranslation("取消"),
            LocalizationManager.GetTranslation("确定"),
            false,    
            // 如果不尝试就直接退出
            delegate ()
            {
                Audio_control.instance.play_btn_sound();
                StartCoroutine(load_scene("main_ui"));
            },
            delegate ()
            {
                //播放按钮声音
                Audio_control.instance.play_btn_sound();
                //如果再次尝试就直接初始化？
   
            }
        );
    }

    //加载场景
    public static IEnumerator load_scene(string scene)
    {
        Loading_circle.waiting();

        AsyncOperation op = SceneManager.LoadSceneAsync(scene);
        while (!op.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        Loading_circle.wait_over();
    }

    
}
