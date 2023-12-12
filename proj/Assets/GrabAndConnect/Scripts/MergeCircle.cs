using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeCircle : MonoBehaviour
{
    int ID;
    public GameObject MergedObject;
    Transform Block1;
    Transform Block2;
    public AudioSource audioPlayer;
    public GameObject DeleteDoor;
    public GameObject effects;
    
    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"SENDING MESSAGE FROM {gameObject.name}");
        if (collision.gameObject.CompareTag("MergeCircle"))
        {
            if (ID < collision.gameObject.GetComponent<MergeCircle>().ID)
            { return;}
            Debug.Log($"SENDING MESSAGE FROM {gameObject.name}");
            Block1 = transform;
            Block2 = collision.transform;
            GameObject O = Instantiate(MergedObject, transform.position, Quaternion.identity) as GameObject;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            audioPlayer.Play();
            Destroy(DeleteDoor);
            GameObject E = Instantiate(effects, transform.position, Quaternion.identity) as GameObject;
            E.GetComponent<ParticleSystem>().Clear();
            E.GetComponent<ParticleSystem>().Play();
        }
    }
}