﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ju87 : EnemyPlane
{
    public GameObject bulletPrefab;
    private GameObject player;

    public override void InitializeEnemy()
    {
        rb.velocity = new Vector3(0, -1, 0) * speed;

        player = GameObject.Find("plane");
    }

    public override void Attack()
    {
        //player is behind GameObject
        if (player.transform.position.y < transform.position.y)
        {
            attackSpeed = 1;
            GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            EnemyBullet bullet = go.GetComponent<EnemyBullet>();
            bullet.targetVector = (player.transform.position - transform.position).normalized;
            bullet.speed = 150;
            bullet.damage = 10;
        }
        else
        {
            //player is in front of GameObject
            attackSpeed = 2;

            Vector3 leftBulletPos = gameObject.transform.GetChild(1).gameObject.transform.position;
            Vector3 rightBulletPos = gameObject.transform.GetChild(2).gameObject.transform.position;

            GameObject go1 = Instantiate(bulletPrefab, leftBulletPos, Quaternion.identity);
            GameObject go2 = Instantiate(bulletPrefab, rightBulletPos, Quaternion.identity);

            EnemyBullet bullet1 = go1.GetComponent<EnemyBullet>();
            EnemyBullet bullet2 = go2.GetComponent<EnemyBullet>();

            bullet1.targetVector = new Vector3(0, 1, 0);
            bullet2.targetVector = new Vector3(0, 1, 0);

            bullet1.speed = 150;
            bullet2.speed = 150;
            bullet1.damage = 10;
            bullet2.damage = 10;
        }
    }
}
