using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum CakeStates { Plain, Vanilla, Chocolate, Strawberry }

public class CakeDecorator : MonoBehaviour, IHittable
{
    public Door door;

    public Sprite plainCake;
    public Sprite strawberryCake;
    public Sprite chocolateCake;
    public Sprite vanillaCake;

    public GameObject VanillaCake;
    public GameObject ChocolateCake;
    public GameObject StrawberryCake;

    public Character character;
    public float characterDistance = 5.0f;
    public bool useDistance = false;

    public bool vanillaCakeDecorated;
    public bool chocolateCakeDecorated;
    public bool strawberryCakeDecorated;

    //public CakesDecorator cakeDecoration = cakesDecorated;

    //public UnityEvent<CakeDecorator> CakesDecorated;

    [HideInInspector]
    public CakeStates cakeState = CakeStates.Plain;

    [HideInInspector]
    public UnityEvent<CakeStates> OnCakeStateChanged;

    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (OnCakeStateChanged == null)
        {
            OnCakeStateChanged = new UnityEvent<CakeStates>();
        }
    }

    void Update()
    {
        if (!useDistance) return;

        // eye can only open and close if not defeated
        if (cakeState != CakeStates.Vanilla)
        {
            //// when character is close enough to the eye, open it
            //if (Vector3.Distance(transform.position, character.transform.position) < characterDistance)
            //{
            //    // we don't want to trigger this every frame,
            //    // only initially when the eye state is set
            //    if (cakeState != CakeStates.Open)
            //    {
            //        cakeState = CakeStates.Open;
            //        UpdateState();
            //    }
            //}
            //else
            //{
            //    // when outside of range, close the eye
            //    if (cakeState != CakeStates.Closed)
            //    {
            //        cakeState = CakeStates.Closed;
            //        UpdateState();
            //    }
            //}
        }
    }

    void UpdateState()
    {
        switch (cakeState)
        {
            // set the sprite of the cake according to whatever state it is in.
            case CakeStates.Plain:
                spriteRenderer.sprite = plainCake;
                //door.lockState = false;
                break;
            case CakeStates.Vanilla:
                spriteRenderer.sprite = vanillaCake;
                vanillaCakeDecorated = true;
                break;
            case CakeStates.Chocolate:
                spriteRenderer.sprite = chocolateCake;
                //chocolateCakeDecorated = true;
                break;
            case CakeStates.Strawberry:
                spriteRenderer.sprite = strawberryCake;
                //strawberryCakeDecorated = true;
                break;
        }
        animator.SetTrigger("StartHit");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "VanillaCake")
        {
            //VanillaCake.SetActive(true);
            cakeState = CakeStates.Vanilla;
            UpdateState();
            Destroy(other.gameObject);
            //Destroy(gameObject);

        }
        else if (other.gameObject.tag == "ChocolateCake")
        {
            //ChocolateCake.SetActive(true);
            cakeState = CakeStates.Chocolate;
            UpdateState();
            Destroy(other.gameObject);
            //Destroy(gameObject);

        }
        else if (other.gameObject.tag == "StrawberryCake")
        {
            //strawberryCakeDecorated = true;
            cakeState = CakeStates.Strawberry;
            UpdateState();
            //StrawberryCake.SetActive(true);
            Destroy(other.gameObject);
            //Destroy(gameObject);
            
        }
    }

    public void Hit(GameObject gameObject)
    {
        //if (cakeState == CakeStates.Plain)
        //{
        //    // if (Vanilla shot) hits the cake, the state is changed to VanillaCake, and so on for Chocolate cakes and Strawberry cakes
        //    //if ()
        //    //cakeState = WallEyeState.Defeated;
        //    //UpdateState();
        //    //OnCakeStateChanged.Invoke(cakeState);
        //}
    }

    //void lockDoor()
    //{
    //    if (vanillaCakeDecorated == true)
    //    {
    //        door.SetLock(false);
    //    }
    //    else
    //    {
    //        door.SetLock(true);
    //    }
    //}

    // this is called from the toggle Unity Event
    //public void OpenClose(bool close)
    //{
    //    if (cakeState != WallEyeState.Defeated)
    //    {
    //        if (close)
    //        {
    //            cakeState = WallEyeState.Closed;
    //            UpdateState();
    //            OnCakeStateChanged.Invoke(cakeState);
    //        }
    //        else
    //        {
    //            cakeState = WallEyeState.Open;
    //            UpdateState();
    //            OnCakeStateChanged.Invoke(cakeState);
    //        }
    //    }
    //}

}
