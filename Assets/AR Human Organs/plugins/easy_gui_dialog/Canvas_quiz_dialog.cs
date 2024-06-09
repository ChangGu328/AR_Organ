using System;
using TMPro;
using Unity.XR.CoreUtils.Bindings.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace bear.j.easy_dialog
{
    public class Canvas_quiz_dialog : MonoBehaviour
    {
        [Header("问题")] public Text quiz_title;

        [Header("答案按钮")] public Button btnA, btnB, btnC;
        [Header("取消按钮")] public Button cancel_btn;
        
        public int index;

        [Header("background")] public Image image_panel;

        public string correctOption;
        private Main_ui_control _mainUIControl;

        // Use this for initialization
        private void OnEnable()
        {
            GetComponent<Canvas>().worldCamera = Camera.main;

            //show the quiz dialog
            StartCoroutine(Canvas_grounp_fade.show(gameObject));
        }

        private void Start()
        {
            btnA.onClick.AddListener(() => OnOptionSelected(btnA.name));
            btnB.onClick.AddListener(() => OnOptionSelected(btnB.name));
            btnC.onClick.AddListener(() => OnOptionSelected(btnC.name));
        }


        /// <summary>
        ///     "title"  means box's title.
        ///     "content"  means box's content.
        ///     "cancel_str" means the cancel button text.
        ///     "confirm_str"  means  the confirm button text.
        /// </summary>
        public static void quiz_dialog(int index, string quiz_title, string answerA, string answerB, string answerC,
            string correctOption)
        {
            var go = Resources.Load<GameObject>("Canvas_quiz_dialog");
            go.GetComponent<Canvas_quiz_dialog>().init(index, quiz_title, answerA, answerB, answerC, correctOption);
            //go.GetComponent<Canvas_confirm_box>().confirm_btn.onClick.AddListener(test);
            Instantiate(go);
        }

        /// <summary>
        ///     "title"  means box's title.
        ///     "content"  means box's content.
        ///     "cancel_str" means the cancel button text.
        ///     "confirm_str"  means  the confirm button text.
        /// </summary>
        public void init(int index, string quiz_title, string answerA, string answerB, string answerC,
            string correctOption)
        {
            ////set the canvas width and height
            GetComponent<CanvasScaler>().referenceResolution = new Vector2(Screen.width, Screen.height);

            //1.set the title
            this.quiz_title.text = quiz_title;
            this.index = index;
            //2.set the answer
            btnA.gameObject.SetActive(true);
            btnB.gameObject.SetActive(true);
            btnC.gameObject.SetActive(true);
            btnA.GetComponentInChildren<Text>().text = answerA;
            btnB.GetComponentInChildren<Text>().text = answerB;
            btnC.GetComponentInChildren<Text>().text = answerC;

            //3.set the correctAnswer
            this.correctOption = correctOption;

            //4.set the size
            var scale = Screen.width / 1334f;
            image_panel.GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);


            cancel_btn.gameObject.SetActive(true);
            
        }


        //listen the cancel button 
        public void on_cancel_btn_event()
        {
            //播放音效
            //Audio_control.instance.play_btn_sound();

            //隐藏窗口
            StartCoroutine(Canvas_grounp_fade.hide(gameObject, true));
        }

        public void OnOptionSelected(string selectedOption)
        {
            //播放音效
            //Audio_control.instance.play_btn_sound();
            
            //隐藏窗口
            StartCoroutine(Canvas_grounp_fade.hide(gameObject, true));
            
            if (selectedOption == "answer" + correctOption)
            {
                //TODO:答案正确
                Debug.Log("correct");
                Canvas_toast.toast("Correct!");
                Config.instance.unlock_index = index;
                //Config.instance.refresh_lock_btn(this.btns_lock_array);
                StartCoroutine(Main_ui_control.load_scene("AR"));
            }
            else
            {
                //TODO:答案错误
                Debug.Log("error");
                Canvas_toast.toast("Wrong Answer");
                quiz_dialog(index, quiz_title.text,
                btnA.GetComponentInChildren<Text>().text, btnB.GetComponentInChildren<Text>().text,
                btnC.GetComponentInChildren<Text>().text, correctOption);
            }
        }
    }
}