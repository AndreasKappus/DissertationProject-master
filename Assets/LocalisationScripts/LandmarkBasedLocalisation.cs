using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LandmarkBasedLocalisation : MonoBehaviour {

    public GameObject particles;

    public Transform t_landmarks;
    public Vehicle vehicle;
    public List<Transform> landmark_list;

    void Start() {
        vehicle.GetComponent<Rigidbody>();

        Transform[] landmarks = t_landmarks.GetComponentsInChildren<Transform>(); // gets child components of the Landmark game-object
        landmark_list = new List<Transform>();

        for (int i = 0; i < landmarks.Length; i++) // the child components are then added to the instantiated list 
        {
            if (landmarks[i] != t_landmarks.transform)
            {
                landmark_list.Add(landmarks[i]);

            }
        }

    }

    void FixedUpdate() {

        generateParticles();
    }


    void generateParticles()
    {
        // variable declarations for the Landmark localisation algorithm.
        float particle_pos_x = 0f; 
        float particle_pos_z = 0f;
        GameObject g_particle;
        Vector3 car_position = vehicle.car.position; // agent has built in GPS to help localise
        float distance;

        for (int j = 0; j < landmark_list.Count; j++)
        {

            distance = Vector3.Distance(car_position, landmark_list[j].transform.position); // distance between agent and the currently indexed landmark position
            
            // new particle position set to be randomnly between the agent position and currently indexed landmark position
            particle_pos_x = Random.Range(car_position.x, landmark_list[j].position.x); 
            particle_pos_z = Random.Range(car_position.z, landmark_list[j].position.z);
            Vector3 position = new Vector3(particle_pos_x, 5f, particle_pos_z);

            if(distance <= 5) // generate a particle when condition is met
            {
                g_particle = Instantiate(particles, position, Quaternion.identity);
                Destroy(g_particle, 1.5f); // destroy particles after 1.5 seconds to allow plenty of time for analysis
            }
                        
        }

    }

}
    


