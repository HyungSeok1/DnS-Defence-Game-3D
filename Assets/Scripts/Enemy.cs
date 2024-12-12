using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Particle;

    public float speed = 5f;
    
    [SerializeField]
    Vector3 direction;
    Vector3 normal;
    Color color;
    Quaternion lookRotation;

    public float health;
    public GameObject player;
    
    void Awake()
    {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(),true);
        //랜덤한 xz 평면 상의 방향을 설정
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    void FixedUpdate()
    {   if (UI_Controller.attempting){
            // Move in the current direction
            Vector3 newPosition = transform.position + direction * Time.deltaTime * speed;
            newPosition.y = 0; // Keep the y position fixed
            transform.position = newPosition;
            transform.LookAt(transform.position + direction);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") // Change direction upon hitting a wall
        {
            // Reflect the direction vector off the wall
            direction = Vector3.Reflect(direction, collision.contacts[0].normal);
        }else if (collision.gameObject.tag == "Player") // Reduce health upon hitting the player
        {
            health -= UI_Controller.attackPower;
            if (health <= 0)
            {
                Die(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    void Die(float x, float y, float z)
    {
        Vector3 particlePos = new Vector3(x, y, z);
        GameObject ParticleSysInstance = Instantiate(Particle, particlePos, Quaternion.identity);
        ParticleSystem.MainModule ps = ParticleSysInstance.GetComponent<ParticleSystem>().main;
        Destroy(this.gameObject);
        UI_Controller.enemies--;
        UI_Controller.kills++;
    }

}
