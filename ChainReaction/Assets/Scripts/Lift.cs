using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour

{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject target;
    [SerializeField] GameObject lift;
    [SerializeField] bool liftActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            liftActive = true;
        }
    }

    public void Update()
    {
        if(liftActive) LiftUp();
    }

    public void LiftUp()
    {
        lift.transform.position = Vector2.MoveTowards(lift.transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
