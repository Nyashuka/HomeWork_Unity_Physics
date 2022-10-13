using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.TimeTask
{
    public class SecondsUpdate : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;

        private float _timeStartOffset = 0;
        private bool _gotStartTime = false;

        //private void Start()
        //{
        //    _timeStartOffset = Time.realtimeSinceStartup;
        //}

        private void Update()
        {
            if (!_gotStartTime)
            {
                _timeStartOffset = Time.realtimeSinceStartup;
                _gotStartTime = true;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, 
                                            (Time.realtimeSinceStartup - _timeStartOffset) * _speed);
        }
    }
}

