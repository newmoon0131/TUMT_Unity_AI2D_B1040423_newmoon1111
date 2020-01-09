﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCC
{
    public class CamC : MonoBehaviour
    {
        

        public float speed = 3;
        private Transform target;
        private void Start()
        {
            target = GameObject.Find("玩家").transform;
        }
        private void LateUpdate()
        {
            Vector3 cam = transform.position;
            Vector3 tar = target.position;
            tar.z = -10;
            tar.y = Mathf.Clamp(tar.y,-0.8f,0.9f);
            transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);

        }
    }
}
