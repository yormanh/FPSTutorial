using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMovement : MonoBehaviour
{
    [SerializeField] float mfVelocity = 10f;

    Transform mPlayer;

    CharacterController mCharacterController;

    // Start is called before the first frame update
    void Awake()
    {
        mCharacterController = GetComponent<CharacterController>();
        mPlayer = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lPlayerPosition = mPlayer.position;
        lPlayerPosition.y = this.transform.position.y;

        this.transform.LookAt(lPlayerPosition);
        mCharacterController.SimpleMove(this.transform.forward * mfVelocity);

    }
}
