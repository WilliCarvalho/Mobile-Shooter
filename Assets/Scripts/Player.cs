using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera characterCamera;
    public float cameraSmoothness;
    public float velocity;
    public float zDistance;
    private Ray ray;
    private RaycastHit hit;

    public GameObject _gun;
    private Gun gun;

    // Update is called once per frame
    void Update()
    {
        gun = _gun.GetComponent<Gun>();

        Move(velocity, ray, hit);
        CameraManagement(characterCamera, transform.position, zDistance, cameraSmoothness);
    }

    void Move(float vel, Ray ray, RaycastHit hit)
    {
        //Verify touchScreen
        if (Input.GetButton("Fire1"))
        {
            //Get the touch on the screen and converts it in a 3D cartesian information
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Verify where the ray collided and keeps the information in 'hit' variable
            // 'out' means that the distance of the ray is infinity
            if (Physics.Raycast(ray, out hit))
            {
                //get the actual coordinate in the touch on the screen in the 3D enviroment
                Vector3 destiny = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                //Look to where I'm pointing on
                transform.LookAt(destiny);
                
                //Map layer - Move
                if(hit.collider.tag == "Map")
                {
                    //Move to the touched direction
                    transform.position = Vector3.Lerp(transform.position, destiny, velocity * Time.deltaTime);
                }
                else if (hit.collider.tag == "Enemy")
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        gun.Shoot(_gun);
                    }
                }
            }
        }
    }

    private void CameraManagement(Camera cam, Vector3 objective, float zDistance, float smoothness)
    {
        Vector3 o = Vector3.zero;

        if (Vector3.Distance(o, cam.transform.position) > 3f)
        {
            o = new Vector3(objective.x, cam.transform.position.y, objective.z - zDistance);
        }
            cam.transform.position = Vector3.Lerp(cam.transform.position, o, smoothness);
    }
}
