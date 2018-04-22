using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;



    // Update is called once per frame
    void Update() {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    bool IsTimeToSpawn (GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float spawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn Rate Capped by framerate!");
        }

        float treshold = spawnsPerSecond * Time.deltaTime / 5;

        if (Random.value < treshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
