using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireShell : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _turret;
    [SerializeField] private Transform _turretBase;
    [SerializeField] private GameObject _enemy;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed = 3f;

    [SerializeField] private float _attackCooldown;
    private float _nextFireTime = 0f;

    [SerializeField] private bool _lowAttack;

    private void CreateBullet()
    {
        GameObject shell = Instantiate(_bullet, _turret.transform.position, _turret.transform.rotation);

        shell.GetComponent<Rigidbody>().velocity = _speed * _turretBase.forward;
    }  
    
    private float? RotateTurret()
    {
        float? angle = CalculateAngle(_lowAttack);

        if(angle != null)
        {
            _turretBase.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }

        return angle;
    }

    private float? CalculateAngle(bool low)
    {
        Vector3 targetDirection = _enemy.transform.position - transform.position;

        float y = targetDirection.y;
        targetDirection.y = 0f;
        float x = targetDirection.magnitude - 2f;
        float gravity = 9.8f;
        float sSqr = _speed * _speed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if(underTheSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float hightAngle = sSqr + root;
            float lowAngle = sSqr - root;

            if (low)
                return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
            else
                return (Mathf.Atan2(hightAngle, gravity * x) * Mathf.Rad2Deg);
        }

        return null;
    }


    private void Update()
    {
        Vector3 direction = (_enemy.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);

        float? angle = RotateTurret();

        if(angle != null)
        {
            if(Time.time > _nextFireTime)
            {
                _nextFireTime = Time.time + _attackCooldown;
                CreateBullet();
            }       
        }
        else
        {
            transform.Translate(0, 0, _moveSpeed * Time.deltaTime);
        }
    }
}
