using System.Collections;
using UnityEngine;

public class SwerveEffect : DVDSign
{
    private Quaternion target;
    private void Start()
    {
        StartCoroutine("ColorSwap");
        StartCoroutine("Tilt");
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, target, speed * Time.fixedDeltaTime);
    }

    IEnumerator Tilt()
    {
        while (true)
        {
            float z;
            z = Random.Range(-45, 45);
            
            if (z == 0) yield return null;

            target = Quaternion.Euler(0, 0, z);
            yield return new WaitForSeconds(delay);
        }
    }
}
