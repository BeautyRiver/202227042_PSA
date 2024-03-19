using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private Queue.LinkQueue<GameObject> queue;
    public GameObject bullet;
    public float fireDelay = 0.5f; // �߻� ������ ������ �ð� (��)
    private float lastFireTime = 0f; // ������ �߻� �ð�
    private int number = 0;
    private void Awake()
    {        
        queue = new Queue.LinkQueue<GameObject>();
        MakeBullets();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastFireTime + fireDelay)
        {
            GameObject obj = queue.Dequeue();
            if (obj != null)
            {
                Debug.Log("Dequeued bullet: " + obj.name);
                obj.SetActive(true);
            }
            else
            {
                Debug.Log("Failed to dequeue a bullet.");
            }

            if (queue.IsEmpty())
                MakeBullets();

            lastFireTime = Time.time;
        }
    }

    private void MakeBullets()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity, transform);
            obj.name = "Bullet_" + number++;
            Enqueue(obj);
            obj.SetActive(false);
        }
    }

    public void Enqueue(GameObject gameObject)
    {
        queue.Enqueue(gameObject);
    }
   
}
