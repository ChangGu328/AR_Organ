using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyGameStudio.Disslove_urp
{
    public class Dissolve : MonoBehaviour
    {
        [Header("show speed")]
        [Range(0, 5f)]
        private float speed_show = 0.5f;

        [Header("hide speed")]
        [Range(0, 5f)]
        private float hide_show = 0.5f;

        [Header("materials")]
        public Material material_dislove;
        //public Material material_eyes;




        private bool is_showing = false;
        private bool is_hiding = false;
        private float threshold = 0;

        [Header("min max threshold")]
        private float min_threshold = 0;
        private float max_threshold = 1;

        public MeshRenderer render;
        public Material mat;


        void OnEnable()
        {
            this.show();
        }

        //void Start()
        //{

        //    Debug.Log(">>>>>"+this.material);
        //}

        // Update is called once per frame
        void Update()
        {
            if (this.is_showing)
            {
                //this.threshold = Mathf.Lerp(this.threshold, this.min_threshold, Time.deltaTime * this.speed_show);

                this.threshold -= Time.deltaTime * this.speed_show;

                if (this.threshold <= this.min_threshold)
                {
                    this.threshold = this.min_threshold;

                    this.is_showing = false;
                }

                this.material_dislove.SetFloat("_threshold", this.threshold);


                //if ((1 - this.threshold) > 0.7f)
                //    this.material_eyes.color = new Color(1, 1, 1, 1 - this.threshold);
                if (this.render != null && this.mat != null)
                {
                    if (this.threshold <= 0.05)
                    {
                        this.render.material = mat;
                    }
                }

            }

            if (this.is_hiding)
            {
                //this.threshold = Mathf.Lerp(this.threshold, this.max_threshold, Time.deltaTime * this.speed_show);

                this.threshold += Time.deltaTime * this.speed_show;

                if (this.threshold >= this.max_threshold)
                {
                    this.threshold = this.max_threshold;

                    this.is_hiding = false;
                }

                this.material_dislove.SetFloat("_threshold", this.threshold);

            }
        }

        public void show()
        {
            this.is_hiding = false;

            this.threshold = this.max_threshold;

            if (this.material_dislove != null)
                this.material_dislove.SetFloat("_threshold", this.threshold);

            if (this.render != null)
            {
                this.render.material = this.material_dislove;
            }

            //if (this.material_eyes != null)
            //    this.material_eyes.color = new Color(1, 1, 1, 0);

            this.is_showing = true;
        }

        public void hide()
        {
            this.is_showing = false;

            this.threshold = this.min_threshold;

            this.material_dislove.SetFloat("_threshold", this.threshold);

            this.is_hiding = true;
        }
    }
}