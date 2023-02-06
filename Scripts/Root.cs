using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Root : MonoBehaviour
{
    public float rootheight;
    // public bool isFull; //determines movement length
    public int moveLength; // 0 = full 1 = half 2 = back
    float currentpos;//root and stem meet when root at (2.9, 3.6) and Stem at (2.9, 6.34)
    Transform transform;
    public List<Root> rootList; //creates a list of other objects with Root script attached
    float EndHeight = -2.56f;
    float MidHeight = 0.92f;
    float MaxHeight = 3.6f;
    bool ToEnd;//these variables indicate that the methods to move the root activate
    bool ToMid;
    bool ToStart;
    public bool Finished = false;//check for root at end goal
    public FinishCheck finishCheck;
    public AudioSource Grow;
    // Start is called before the first frame update
    void Start()
    {
        currentpos = rootheight;
        transform = GetComponent<Transform>();


    }

    void OnMouseDown()
    {
        Vector3 tposition = transform.position;
        PlaySound();

        // NOTE: currently, this checks to see if the root you click on is "full" or "half," then moves all of its associated roots by that much.
        // if we want each root to only move by its own full/half amount I think I know how to do that it would just involve moving things around a bit
        // so it checks for (isFull) on the target root as well and not just here on mouse down

        if (moveLength == 0)// Checks to see if movement is full or half
        {
            for (int i = 0; i < rootList.Count; i++) //does this for every root in the list (aka not just this one but this one and a selection of others)
            {
                rootList[i].FullMove(); //moved this method out of here so it can be called for other roots - see below
            }
        }
        if (moveLength == 1)
        {
            for (int i = 0; i < rootList.Count; i++)
            {
                rootList[i].HalfMove();
            }

        }
        if (moveLength == 2)
        {
            for (int i = 0; i < rootList.Count; i++)
            {
                rootList[i].BackMove();
            }

        }

    }

    void PlaySound()
    {
        float rand = (Random.value); //generates random float from 0-1
        Grow.pitch = ((rand / 5) + 0.8f); //converts the 0-1 range to a 0.8-1.0 range which is a good pitch range
        Grow.Play();//plays sound
    }

    public void FullMove()
    { // This can be called by other roots, so roots can control each other. same with HalfMove() and Backmove()
        if (currentpos == MaxHeight)
        {
            ToEnd = true;
        }
        if (currentpos == MidHeight)
        {
            ToMid = true;
        }
        if (currentpos == EndHeight)
        {
            ToStart = true;
        }
    }

    public void HalfMove()
    {
        if (currentpos == MaxHeight)
        {
            ToMid = true;
        }
        if (currentpos == MidHeight)
        {
            ToEnd = true;
        }
        if (currentpos == EndHeight)
        {
            ToStart = true;
        }
    }

    public void BackMove()
    {
        if (currentpos == MaxHeight)
        {
            ToEnd = true;
        }
        if (currentpos == MidHeight)
        {
            ToStart = true;
        }
        if (currentpos == EndHeight)
        {
            ToMid = true;
        }

    }
    void MoveToEnd()
    {
        Vector3 tposition = transform.position;
        tposition.y = EndHeight;
        transform.position = tposition;
        currentpos = tposition.y;
        ToEnd = false;
        Finished = true;
        finishCheck.RunCheck();

    }

    public void MoveToMax() // public so that the reset button can call this for any root
    {
        Vector3 tposition = transform.position;
        tposition.y = MaxHeight;
        transform.position = tposition;
        currentpos = tposition.y;
        ToStart = false;
        Finished = false;
    }

    void MoveToMid()
    {
        Vector3 tposition = transform.position;
        tposition.y = MidHeight;
        transform.position = tposition;
        currentpos = tposition.y;
        ToMid = false;
        Finished = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (ToStart == true)
        {
            MoveToMax();
        }
        if (ToMid == true)
        {
            MoveToMid();
        }
        if (ToEnd == true)
        {
            MoveToEnd();
        }
    }

}
