using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.TimeTask
{
    public class UpdateMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;
        private void Update()
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
    }

}

