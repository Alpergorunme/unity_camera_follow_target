using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public bool follow;
    public Transform target;
    public Vector3 fixeed;
    [Range(0,10)]
    public float position_smooth;
    [Range(0,10)]
    public float rotation_smooth;
    Rigidbody _rb;
    void Start()
    {
        _rb =GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target)
        {
            this._rb.velocity.Normalize();
            transform.LookAt(target);

            Quaternion k_rot=transform.rotation;
            Vector3 follow_pos = target.position + target.TransformDirection(fixeed);


            if(follow_pos.y <target.position.y)
            {
                follow_pos.y = target.position.y;
            }

            transform.position = Vector3.Lerp(transform.position,follow_pos,Time.deltaTime * position_smooth);

            transform.rotation = Quaternion.Lerp(k_rot,transform.rotation, Time.deltaTime  * rotation_smooth);

            if(transform.position.y < 0.1f)
            {
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            }
        }
    }
}
