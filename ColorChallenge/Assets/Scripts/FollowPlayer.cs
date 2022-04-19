using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Track Player Model")]public Transform player;

    private void Update()
    {
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(0f, player.position.y, -10f);
        }
    }
}
