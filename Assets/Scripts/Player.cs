using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float motionSpeed = 3f;
    [SerializeField] private bool teleporting;
    private bool isDead;
    [SerializeField] private int health, maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        health = maxHealth;
    }
    

    public void Move(Vector3 motionVector)
    {
        transform.position += motionVector * motionSpeed * Time.deltaTime;
    }

    public void TakeDamage( int damage) {
        if (health > 0)
        {
            health -= damage;
        }
        if (health <= 0) 
        {
            health = 0;
            isDead = true;
        }
    }

    public void Heal(int healing_points ) {
        if (health < maxHealth)
            health += healing_points;
        if (health > maxHealth)
            health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleport"))
        {
            if (!teleporting)
            {
                Teleport(other.gameObject);
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Teleport"))
        {
            teleporting = false;
        }
    }

    public void Teleport(GameObject pad)
    {
        int index = pad.transform.GetSiblingIndex();
        GameObject siblingPad;
        if (index == 0)
        {
            siblingPad = pad.transform.parent.GetChild(index + 1).gameObject;
        }
        else
        {
            siblingPad = pad.transform.parent.GetChild(index - 1).gameObject;
        }
        transform.position = siblingPad.transform.position + siblingPad.transform.TransformVector(0, 0, 1);
        teleporting = true;
    }
}
