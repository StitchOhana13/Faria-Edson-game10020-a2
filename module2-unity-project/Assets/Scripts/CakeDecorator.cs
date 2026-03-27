using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum CakeStates { Plain, Vanilla, Chocolate, Strawberry }

public class CakeDecorator : MonoBehaviour, IHittable
{
    public Sprite plainCake;
    public Sprite strawberryCake;
    public Sprite chocolateCake;
    public Sprite vanillaCake;

    public Character character;
    public float characterDistance = 5.0f;
    public bool useDistance = false;

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
                break;
            case CakeStates.Vanilla:
                spriteRenderer.sprite = vanillaCake;
                break;
            case CakeStates.Chocolate:
                spriteRenderer.sprite = chocolateCake;
                break;
            case CakeStates.Strawberry:
                spriteRenderer.sprite = strawberryCake;
                break;
        }
        animator.SetTrigger("StartHit");
    }

    public void Hit(GameObject gameObject)
    {
        if (cakeState == CakeStates.Plain)
        {
            // if (Vanilla shot) hits the cake, the state is changed to VanillaCake, and so on for Chocolate cakes and Strawberry cakes
            //if ()
            //cakeState = WallEyeState.Defeated;
            //UpdateState();
            //OnCakeStateChanged.Invoke(cakeState);
        }
    }

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
