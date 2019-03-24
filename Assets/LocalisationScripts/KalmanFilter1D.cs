using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KalmanFilter1D : MonoBehaviour {

    public Text location_x;
    public Text location_y;
    public Vehicle vehicle;
    // public List<float> velocity_measurements = new List<float>();
    public float noise = 10;

    void Start()
    {
        vehicle.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        
        float mu = 0; // mean uncertainty
        float motion = vehicle.car.velocity.magnitude;
        float sensor_measurements_x = sensorNoise(vehicle.car.position.x); // get values from sensor noise method to get the "noisy" measurements
        float measurement_sig = 4; // measurement uncertainty ( experiment with the "uncertainty" values)
        float motion_sig = 2; // motion uncertainty
        float sig = 1000; // initial uncertainty
        float sensor_measurements_y = sensorNoise(vehicle.car.position.z);
       

        location_x.text = kalmanUpdate(mu, sig, sensor_measurements_x, measurement_sig).ToString();
        location_y.text = kalmanUpdate(mu, sig, sensor_measurements_y, measurement_sig).ToString();

    }
    
    // gets position and uses random numbers to replace the pos variable's values through a certain range, so the kalman filter can get the measurements .etc
    public float sensorNoise(float pos)
    {
        // simulate gps sensor noise through random numbers. 
        pos = Random.Range(pos - noise, pos + noise); // The range of the numbers are the actual position - or + 10.

        return pos;
    }

    // usually Kalman filters would use the values from the predict phase to update the estimated location
    public float kalmanUpdate(float mean1, float var1, float mean2, float var2) 
    {
        float new_mean = (var2 * mean1 + var1 * mean2) / (var1 + var2);
        float new_var = 1 / (1 / var1 + 1 / var2);

        return new_mean;
    }

    // predict future position by adding the position by the mean uncertainty with the current position in this case
    public float kalmanPredict(float mean1, float var1, float mean2, float var2)
    {
        float new_mean = mean1 + mean2;
        float new_var = var1 + var2;

        return new_mean;
    }

    
}
