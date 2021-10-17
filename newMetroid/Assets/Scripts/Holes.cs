using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    public Transform outsideWorld;
    public Transform insideWorld;

    private string playerDirCheck; //make sure that the player is indeed go through the hole
    private Vector3 scale;
    private bool isZooming;

    private void Awake()
    {
        scale = this.transform.localScale;
        Debug.Log(scale);
    }

    private void OnEnable()
    {
        this.transform.localScale = Vector3.zero;
        isZooming = true;
        AudioManager.instance.Play("OpenHole");
    }

    private void Update()
    {
        if (isZooming)
        {
            if (scale.x - transform.localScale.x > 0.0000000000001f || scale.y - transform.localScale.y > 0.0000000000001f)
                this.transform.localScale += scale.normalized * Time.deltaTime * 5f;
            else
                isZooming = false;
        }

    }

    private void PlayerSpacetimeTravel()
    {
        AudioManager.instance.Play("Travel");
        Vector2 temp = outsideWorld.position;
        outsideWorld.position = insideWorld.position;
        insideWorld.position = temp;
        GameManager.instance.SetHolesActive(false);
    }

    private void InteractableObjectSpacetimeTravel(Transform objectTransform)
    {
        AudioManager.instance.Play("Travel");
        Vector2 currentTrans = objectTransform.localPosition;

        if (objectTransform.parent.parent == outsideWorld || objectTransform.parent == outsideWorld)
            objectTransform.SetParent(insideWorld);
        else
            objectTransform.SetParent(outsideWorld);

        objectTransform.localPosition = currentTrans;

        GameManager.instance.SetHolesActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemies" || collision.tag == "Interactable")
        {
            InteractableObjectSpacetimeTravel(collision.gameObject.transform);
            Debug.Log("Travel Object");
        }

        if (collision.tag == "Check")
        {
            if (playerDirCheck == null)
            {
                playerDirCheck = collision.name;
                //Debug.Log(playerDirCheck);
            }
            else if (playerDirCheck != null)
            {
                switch (collision.name)
                {
                    case "UpCheck":
                        {
                            if (playerDirCheck == "DownCheck")
                            {
                                PlayerSpacetimeTravel();
                                playerDirCheck = null;
                            }
                            break;
                        }
                    case "DownCheck":
                        {
                            if (playerDirCheck == "UpCheck")
                            {
                                PlayerSpacetimeTravel();
                                playerDirCheck = null;
                            }
                            break;
                        }
                    case "LeftCheck":
                        {
                            if (playerDirCheck == "RightCheck")
                            {
                                PlayerSpacetimeTravel();
                                playerDirCheck = null;
                            }
                            break;
                        }
                    case "RightCheck":
                        {
                            if (playerDirCheck == "LeftCheck")
                            {
                                PlayerSpacetimeTravel();
                                playerDirCheck = null;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

        }
    }
}
