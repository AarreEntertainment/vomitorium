using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    bool activated;
    public GameObject pipe;
    public Transform SpawnPoint;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        activated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && Vector3.Distance(Player.transform.position, SpawnPoint.position) < 80)
        {
            GameObject pip = Instantiate(pipe);
            pip.transform.position = SpawnPoint.position;
            pipeSpawner ps = pip.GetComponent<pipeSpawner>();
            ps.Player = Player;
            ps.pipe = pipe;
            activated = false;
        }
        else if(!activated && Vector3.Distance(Player.transform.position, SpawnPoint.position) > 90)
        {
            Destroy(gameObject);
        }
    }
}
