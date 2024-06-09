using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animal_control : MonoBehaviour
{

    [Header("索引")]
    public int index;

    [Header("存放有哪些动画的字符串数组")]
    public List<string> str_list_animation;


    [ContextMenu("create_str_array_animation")]
    public void create_str_array_animation()
    {
#if UNITY_EDITOR

        Animator animator = this.GetComponent<Animator>();
        this.str_list_animation.Clear();

        //通过读取animator，来获取这个模型包含有哪些动画, 并设置动画按钮的显示与隐藏
        UnityEditor.Animations.AnimatorControllerLayer layer = ((UnityEditor.Animations.AnimatorController)animator.runtimeAnimatorController).layers[0];//获取这个Animator组件上对应某一层的AnimatorController资源
        UnityEditor.Animations.AnimatorStateMachine sm = layer.stateMachine;  //获取层状态机
        UnityEditor.Animations.ChildAnimatorState[] ams = sm.states;//获取该层状态机的子状态机

        //隐藏没有设置动画片段的动画按钮
        for (int i = 0; i < ams.Length; i++)
        {
            if (ams[i].state.motion != null)
            {
                //Debug.Log(i + ">>>>>>" + ams[i].state.name);
                this.str_list_animation.Add(ams[i].state.name);
            }
        }
#endif
    }
}