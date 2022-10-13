using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireShellOldBackup : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _turret;
    [SerializeField] private GameObject _enemy;
    
    private void CreateBullet()
    {
        Instantiate(_bullet, _turret.transform.position, _turret.transform.rotation);
    }

    private Vector3 CalculateTrajectory()
    {
        Vector3 position = _enemy.transform.position - transform.position;
        Vector3 velocity = _enemy.transform.forward * _enemy.GetComponent<Drive>().speed;

        float s = _bullet.GetComponent<MoveShell>().Speed;
        float a = Vector3.Dot(velocity, velocity) - s * s;
        float b = Vector3.Dot(position, velocity);
        float c = Vector3.Dot(position, position);
        float d = b * b - c * a;

        if (d < 0.1f)
            return Vector3.zero;

        float sqrt = Mathf.Sqrt(d);
        float time1 = (-b - sqrt) / c;
        float time2 = (-b + sqrt) / c;

        float t;

        if (time1 < 0 && time2 < 0)
            t = 0;
        else if(time1 < 0)
            t = time2;
        else if(time2 < 0)
            t = time1;
        else
            t = Mathf.Max(new float[] { time1, time2});

        return t * position + velocity;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 aimAt = CalculateTrajectory();

            if (aimAt != Vector3.zero)
                transform.forward = aimAt;

            CreateBullet();
        }
    }
}
