using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public GameObject track;

    public float time;
    private Rotate[] parallaxList;

    // Use this for initialization
    void Start()
    {
        parallaxList = GetComponentsInChildren<Rotate>();
    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector2(track.transform.position.x - transform.position.x, track.transform.position.y - transform.position.y);
        foreach (var parallax in parallaxList)
        {
            parallax.Move(move);
        }
        transform.position = new Vector3(transform.position.x + move.x, transform.position.y, transform.position.z);
    }
}
