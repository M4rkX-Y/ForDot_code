using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Switch : MonoBehaviour
{

    private string check;
    private bool onetime = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string json = File.ReadAllText(Application.dataPath + "/Script/api.json");
        Debug.Log(json);
        apiData loadapiData = JsonUtility.FromJson<apiData>(json);
        check = loadapiData.ignition_status;
        Debug.Log(check);

        if (Input.GetKeyUp("space"))
        {
            Water2D.Water2D_Spawner.instance.Spawn();
        }

        if (Input.GetKeyUp("escape"))
        {
            Water2D.Water2D_Spawner.instance._breakLoop = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Return)) {
            Water2D.Water2D_Spawner.instance.Spawn();
        }
        
        if (!onetime){
            if (check == "ON") {
            Water2D.Water2D_Spawner.instance.Spawn();
            onetime = true;
            }
        }
        
    }
    private class apiData{
        public int fuel_value;
        public int fuel_distance_to_empty;
        public string location_longitude;
        public string location_latitude;
        public int speed;
        public string direction;
        public string door_unspecified_front_door;
        public string door_unspecified_front_role;
        public string engine_status;
        public int engine_duration;
        public bool tire_warning;
        public string charge_value;
        public string charge_start;
        public string charge_end;
        public string ignition_status;
        public bool battery_value;
        public int battery_distanceToEmpty;
        public int mileage;
        public int odometer;
        public bool charge_plug_value;
    }
}
