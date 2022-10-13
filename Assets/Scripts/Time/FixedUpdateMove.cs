using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.TimeTask
{
    public class FixedUpdateMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;

        private void FixedUpdate()
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
    }
}

