using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        shouldMove = true;
    }
    public bool shouldMove = true;
    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime);

        }


    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            shouldMove = false;
            CarManager.Instance.DestroyCar(this);
        }
    }


}
