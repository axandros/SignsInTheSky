using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimator : MonoBehaviour
{
    private enum SpinDirection { right,left}

    [SerializeField]
    private float spinSpeed = 3; 

    private SpinDirection dir = SpinDirection.left;

    // Start is called before the first frame update
    void Start()
    {
        Sprite sp = GetComponent<Sprite>();
        dir = Random.value > 0.5 ? SpinDirection.right : SpinDirection.left;
        if (dir == SpinDirection.right)
        {
            spinSpeed = -1 * Mathf.Abs(spinSpeed);
        }
        else { spinSpeed = Mathf.Abs(spinSpeed); }
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        float speed = spinSpeed * Random.Range(0.7f, 1.7f);
        transform.Rotate(Vector3.forward, speed); //0.0f,1.0f,1.0f,Space.Self);
    }
}
