﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Do217 : EnemyPlane
{
    public GameObject bulletPrefab;

    public override void InitializeEnemy()
    {
        this.rb.velocity = new Vector3(0, -1, 0) * speed;
    }

    public override void Attack()
    {
        Vector3 leftBulletPos = new Vector3(transform.position.x - 0.15f, transform.position.y - .65f, transform.position.z);
        Vector3 rightBulletPos = new Vector3(transform.position.x + 0.15f, transform.position.y - .65f, transform.position.z);
        Vector3 middleBulletPos = new Vector3(transform.position.x, transform.position.y - .75f, transform.position.z);

        GameObject go1 = Instantiate(bulletPrefab, leftBulletPos, Quaternion.identity);
        GameObject go2 = Instantiate(bulletPrefab, rightBulletPos, Quaternion.identity);
        GameObject go3 = Instantiate(bulletPrefab, middleBulletPos, Quaternion.identity);

        EnemyBullet bullet1 = go1.GetComponent<EnemyBullet>();
        EnemyBullet bullet2 = go2.GetComponent<EnemyBullet>();
        EnemyBullet bullet3 = go3.GetComponent<EnemyBullet>();

        bullet1.targetVector = new Vector3(0, -1, 0);
        bullet2.targetVector = new Vector3(0, -1, 0);
        bullet3.targetVector = new Vector3(0, -1, 0);

        bullet1.speed = 200;
        bullet2.speed = 200;
        bullet3.speed = 200;

        bullet1.damage = 10;
        bullet2.damage = 10;
        bullet3.damage = 10;
    }
}
