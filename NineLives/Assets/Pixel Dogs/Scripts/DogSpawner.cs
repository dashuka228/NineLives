using UnityEngine;
using System.Collections;

public class DogSpawner : MonoBehaviour
{
    DogDatabase database;
    // Use this for initialization
	void Start ()
    {
        database = GameObject.FindGameObjectWithTag("DogDatabase").GetComponent<DogDatabase>();
        SpawnDog(Random.Range(0,8));
	}
	
	void SpawnDog (int iD)
    {

        GameObject newDog = Instantiate(database.dogDatabase[iD].dogObject, this.transform.position, Quaternion.identity) as GameObject;

        //assign name
        newDog.name = "Fido";
    }
}
