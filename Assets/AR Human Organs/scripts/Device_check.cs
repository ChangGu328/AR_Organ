using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using bear.j.easy_dialog;
using UnityEngine.SceneManagement;
using I2.Loc;

public class Device_check : MonoBehaviour
{
    [SerializeField] ARSession m_Session;

    IEnumerator Start()
    {
        ARSession.stateChanged += ARSession_stateChanged;

        if ((ARSession.state == ARSessionState.None) || (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            Canvas_confirm_box.confirm_box
            (
                 LocalizationManager.GetTranslation("提示"),
                 LocalizationManager.GetTranslation("对不起，您的设备不支持AR功能，请更换其他设备"),
                 LocalizationManager.GetTranslation("取消"),
                 LocalizationManager.GetTranslation("确定"),
                 true,
                 delegate () 
                 {
                     Audio_control.instance.play_btn_sound();
                 },
                 delegate ()
                 {
                     Audio_control.instance.play_btn_sound();
                     SceneManager.LoadSceneAsync("main_ui");
                 }
           );
        }
        else
        {
            // Start the AR session
            m_Session.enabled = true;
        }
    }
    private void ARSession_stateChanged(ARSessionStateChangedEventArgs obj)
    {
        //throw new System.NotImplementedException();
    }
}
