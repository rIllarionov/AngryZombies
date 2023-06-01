using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private float _maxVelocity = -5f;
    [SerializeField] private ZombieCounter _counter;

    private Rigidbody2D _enemyRigidBody;
    private float _maxRotationDegree = 30f;
    private float _minRotationDegree = 270f;

    private void Awake()
    {
        _enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_enemyRigidBody.transform.eulerAngles.z > _maxRotationDegree &&
            _enemyRigidBody.transform.eulerAngles.z < _minRotationDegree)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Skull"))
        {
            Die();
        }

        if (_enemyRigidBody.velocity.y < _maxVelocity)
        {
            Die();
        }
    }

    private void Die()
    {
        // Создаем эффект "взрыв" на месте убитого зомби.
        CreateExplosion();
        // ПРоигрываем звук смерти зомби.
        PlayDeathSound();
        // Разрушаем объект зомби.
        Destroy(gameObject);
        _counter.ChangeCount();
    }

    private void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(_deathSound, transform.position);
    }

    private void CreateExplosion()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }
}