using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float damage;
    private Transform target;
    public GameObject impactEffect;
    public float speed = 70f;

    // Start is called before the first frame update
    void Start(){

    }
    // Update is called once per frame
    void Update(){
      if (target == null){
        Destroy(gameObject);
        return;
      }
      Vector2 dir = target.position - transform.position;
      float distanceThisFrame = speed * Time.deltaTime;

      if (dir.magnitude <= distanceThisFrame){
        HitTarget();
        return;
      }
      transform.Translate (dir.normalized * distanceThisFrame, Space.World);
    }

    // Start is called before the first frame update
  public void Seek (Transform _target) {
    target = _target;
    }

    public void SetDamage(float _damage) {
        damage = _damage;
    }

  void HitTarget (){
    GameObject effectInstance = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
    Destroy(effectInstance, 2f);
    Damage(target);
    Destroy(gameObject);
  }

  void Damage(Transform enemy)
  {
    Enemy e = enemy.GetComponent<Enemy>();

    if (e != null)
    {
     e.TakeDamage(damage);
    }
  }
}
