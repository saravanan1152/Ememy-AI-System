using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Variyapls : MonoBehaviour
{
    [GUIColor("RGB(0, 1, 0)")]
    [SerializeField] private float health = 500f;
    [GUIColor("RGB(0, 1, 0)")]
    [SerializeField] public float attackPower = 20f;

    [SerializeField][Range(2, 30)] float detectionRange = 10f;

    [SerializeField] float nexttime;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyAI targetAI;

    [Tooltip("Set the TransparantFX")]
    [SerializeField] LayerMask targetLayer;

    [Tooltip("Assing bullet ")]
    [SerializeField] GameObject projectailPrefab;

    [Tooltip("Assing bulletSpawn Point ")]
    [SerializeField] Transform projectailPoint;
    private float projectilSpeed = 30;

    private Vector3 throwForce;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ShoodClip;
    // [SerializeField] private AudioClip CollideClip;
    // [SerializeField] private AudioClip ExplotionClip;
    [AssetSelector]
    [SerializeField] private ParticleSystem explotion;
    [SerializeField] private ParticleSystem ShootingParticle;

    [SerializeField] private Zombi _zombi;
    private Renderer renter;

    [SerializeField] RandomMovement randomMovement;
}
