﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllShips
{

    public class BaseBulletStarter : MonoBehaviour {

        public GameObject bulletPrefab; 
        [Tooltip("Lest of empty child GameObjects on the ship where bullet will appear")]
        public Transform[] bulletStartPoses;
        [Tooltip("If 0 than new sortingOrder will implemented for bullet")]
        public int bulletSortingOrder = 0;
        public float bulletSpeed;
        [Tooltip("Delay between each bullet if repeat fire mode")]
        public float fireDelay;
        [Tooltip("Should bullets appear one after another or all at once. Use for ships with many bulletStartPoses")]
        public bool fireInSequence;

        bool repeatFire = false;
        int fireIndex = 0;

        void OneShot(int index)
        {
            if (IfIndexGood(index))
            {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletStartPoses[index].position, Quaternion.identity);
                if (bulletSortingOrder != 0)
                {
                    bullet.GetComponent<SpriteRenderer>().sortingOrder = bulletSortingOrder;
                }
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.linearVelocity = bulletSpeed * (-bulletStartPoses[index].up);
            }
        }
        bool IfIndexGood(int index)
        {
            if (bulletStartPoses != null && index >= 0 && index < bulletStartPoses.Length)
            {
                return true;
            } else
            {
                Debug.LogWarning("index is out of range in bulletStartPoses");
                return false;
            }
        }

        public void StartRepeateFire()
        {
            if (!repeatFire)
            {
                repeatFire = true;
                fireIndex = 0;
                StartCoroutine(RepeateFire());
            }
        }
    
        public void StopRepeatFire()
        {
            repeatFire = false;
        }

        public void MakeOneShot()
        {
            for (int index = 0; index < bulletStartPoses.Length; index++)
                OneShot(index);
        }

        private void OnDestroy()
        {
            StopCoroutine(RepeateFire());
        }

        IEnumerator RepeateFire()
        {
            while (repeatFire)
            {
                if (fireInSequence) {
                    OneShot(fireIndex);
                    if (++fireIndex >= bulletStartPoses.Length)
                        fireIndex = 0;
                } else
                {
                    MakeOneShot();
                }
                yield return new WaitForSeconds(fireDelay);
            }
        }
    }
}
