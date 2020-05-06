using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    private int life;
    public float velocity;

    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        life = Random.Range(1, 3);

        material.color = new Color(255, 0, 0, 100);

        switch (life)
        {
            case 1:                
                material.color = new Color(5, 150, 0, 100);
                velocity += 4f;
                break;

            case 2:                
                material.color = new Color(50, 130, 0, 100);
                velocity += 2f;
                break;

            case 3:             
                material.color = new Color(5, 150, 0, 100);
                velocity += 1f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 
            velocity * Time.deltaTime);

        transform.LookAt(target.transform.position);
    }
}
