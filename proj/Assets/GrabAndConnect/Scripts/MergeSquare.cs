using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSquare : MonoBehaviour
{
    int ID;
    public GameObject MergedObject;
    Transform Block1;
    Transform Block2;
    public AudioSource audioPlayer;

    
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
        if (collision.gameObject.CompareTag("MergeSquare"))
        {
            if (ID < collision.gameObject.GetComponent<MergeSquare>().ID)
            { return;}
            Debug.Log($"SENDING MESSAGE FROM {gameObject.name}");
            Block1 = transform;
            Block2 = collision.transform;
            GameObject O = Instantiate(MergedObject, transform.position, Quaternion.identity) as GameObject;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            audioPlayer.Play();
        }
    }
}