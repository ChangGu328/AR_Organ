using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using I2.Loc;
using System;
using UnityEngine.UI;
using bear.j.easy_dialog;

public class Config : MonoBehaviour
{
    //单列模式
    public static Config instance;

    //days
    public int lock_days = 7;

    //is need ad
    public bool is_ad = true;

    //物体索引
    public int index_ar_object = 1;

    //要解锁的物体的索引
    public int unlock_index = 0;

    //statu
    public AR_statu ar_statu = AR_statu.recognizing;

    void Awake()
    {
        //跨多场景的单例模式
        #region 
        if (Config.instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Config.instance = this;

            //切换场景时不销毁
            DontDestroyOnLoad(gameObject);
        }
        #endregion

        //永不息屏
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //获取远程配置
        //this.FetchRemoteConfiguration();

        //设置APP的语言
        #region 
        if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified)
        {
            LocalizationManager.CurrentLanguage = "Chinese";
        }
        else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
        {
            //LocalizationManager.CurrentLanguage = "ChineseTraditional";
            LocalizationManager.CurrentLanguage = "Chinese";
        }
        else if (Application.systemLanguage == SystemLanguage.French)
        {
            LocalizationManager.CurrentLanguage = "French";
        }
        else if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            LocalizationManager.CurrentLanguage = "Spanish";
        }
        else if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            LocalizationManager.CurrentLanguage = "Portuguese";
        }
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            LocalizationManager.CurrentLanguage = "Russian";
        }
        else if (Application.systemLanguage == SystemLanguage.Arabic)
        {
            LocalizationManager.CurrentLanguage = "Arabic";
        }
        else if (Application.systemLanguage == SystemLanguage.German)
        {
            LocalizationManager.CurrentLanguage = "German";
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            LocalizationManager.CurrentLanguage = "Japanese";
        }
        else if (Application.systemLanguage == SystemLanguage.Korean)
        {
            LocalizationManager.CurrentLanguage = "Korean";
        }
        //else if (Application.systemLanguage == SystemLanguage.Italian)
        //{
        //    LocalizationManager.CurrentLanguage = "Italian";
        //}
        //else if (Application.systemLanguage == SystemLanguage.Vietnamese)
        //{
        //    LocalizationManager.CurrentLanguage = "Vietnamese";
        //}
        else
        {
            LocalizationManager.CurrentLanguage = "English";
        }
        //LocalizationManager.CurrentLanguage = "English";
        #endregion

        //初始化解锁一部分器官
        PlayerPrefs.SetString("0", "-1");
        PlayerPrefs.SetString("1", "-1");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Debug.Log("PlayerPrefs.DeleteAll()");
            PlayerPrefs.DeleteAll();
        }
    }

    //初始化哪些物体需要解锁，哪些不需要
    public void refresh_lock_btn(Button[] btns_lock_array)
    {
        if (Config.instance.is_ad)
        {
            for (int i = 0; i < btns_lock_array.Length; i++)
            {
                if (btns_lock_array[i] != null)
                {
                    if (is_out_of_date(PlayerPrefs.GetString(i + "")))
                    {
                        btns_lock_array[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        btns_lock_array[i].gameObject.SetActive(false);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < btns_lock_array.Length; i++)
            {
                btns_lock_array[i].gameObject.SetActive(false);
            }
        }
    }

    //是否解锁后已过期
    private bool is_out_of_date(string str)
    {
        if (Config.instance.is_ad == false)
            return false;
        if (str == "-1")
            return false;
        if (str == "")
            return true;
        else
        {
            try
            {
                System.DateTime record = System.Convert.ToDateTime(str);

                System.DateTime now = System.DateTime.Now;

                System.TimeSpan record_time = new System.TimeSpan(record.Ticks);

                System.TimeSpan now_time = new System.TimeSpan(now.Ticks);

                System.TimeSpan tsSub = record_time.Subtract(now_time).Duration();

                if (tsSub.Days <= Config.instance.lock_days)
                    return false;
                //Debug.Log("resume  List  " + tsSub.Days + "   " + tsSub.Hours + "  " + tsSub.TotalMilliseconds);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

    }

    //获取远程配置
    #region 
    private struct userAttributes { }
    private struct appAttributes { }
    public void FetchRemoteConfiguration()
    {
        if (this.gameObject.activeSelf)
        {
            ConfigManager.FetchCompleted += ApplyRemoteSettings;
            ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
            //Debug.Log("fetched sample>>>" + ConfigManager.appConfig.GetBool("is_ad"));
        }
    }
    public void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        switch (configResponse.requestOrigin)
        {
            case ConfigOrigin.Default:
                //Config.is_ad = false;
                Debug.Log("0.No Setting Loaded this session; using default values>>>>>>>>" + Config.instance.is_ad);
                break;

            case ConfigOrigin.Cached:
                //if (PlayerPrefs.GetString("Config.is_ad") == "")
                //{
                //    Config.is_ad = false;
                //}
                //else
                //{
                //    Config.is_ad = bool.Parse(PlayerPrefs.GetString("Config.is_ad"));
                //}
                Debug.Log(ConfigManager.appConfig.GetString("str") + " 1.No Setting Loaded this session; using cached values from a previous session>>>>>>>>" + Config.instance.is_ad);
                break;

            case ConfigOrigin.Remote:
                try
                {
                    if (Config.instance.is_ad != ConfigManager.appConfig.GetBool("is_ad"))
                    {
                        Config.instance.is_ad = ConfigManager.appConfig.GetBool("is_ad");

                        PlayerPrefs.SetString("Config.is_ad", Config.instance.is_ad + "");
                    }
                }

                catch (Exception)
                {
                    throw;
                }
                Debug.Log(ConfigManager.appConfig.GetString("str") + " 2.new Setting Loaded this session; using values accordingly>>>>>>>>" + Config.instance.is_ad);
                //DebugControl.Instance.AddOneDebug(ConfigManager.appConfig.GetString("str") + " 2.new Setting Loaded this session; using values accordingly>>>>>>>>" + Config.is_ad);
                break;
        }
    }
    #endregion
}

//AR识别时的状态
public enum AR_statu
{
    recognizing,                           //recognizing
    object_is_placed                       //object_is_placed
}