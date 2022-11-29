using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    public float EnemyDamage;
    public float EnemyHealth;
    public float speed;

    void Start()
    {

    }


    void Update()
    {
        transform.position = transform.position + transform.forward * -speed * Time.deltaTime;
        

        /*transform.Translate(Vector3.zero * Time.deltaTime * speed);

        if (transform.position.y < -5f) {
            float randomX = Random.Range(-14f, 14f);
            transform.position = new Vector3(randomX, 1.5f, 0);
        }*/

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player_sc player = other.transform.GetComponent<Player_sc>();
            if (player != null)
            {
                player.Hasar();
            }
            Destroy(this.gameObject);
        }
        else if (other.tag == "Ates")
        {
            EnemyHealth -= GameObject.FindObjectOfType<Fire_sc>().Damage;
            if (EnemyHealth < 1)
            {
                GameObject.FindObjectOfType<Fire_sc>().Target_Counter();
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "Tower"){
            Destroy(this.gameObject);
        }
    }
}
