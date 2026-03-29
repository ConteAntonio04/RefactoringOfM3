using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject pickUpWeapon = Instantiate(weaponPrefab, collision.transform.position, Quaternion.identity, collision.transform);
            pickUpWeapon.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
        }
    }
}
