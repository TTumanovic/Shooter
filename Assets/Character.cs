using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public abstract class Character : MonoBehaviour, IDamageable
{
    //I
    public int maxHealth = 100;
    protected int currentHealth;

    public Material defaultMaterial;
    public Material flashMaterial;

    protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        //Inkap
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (defaultMaterial == null && spriteRenderer != null)
        {
            defaultMaterial = spriteRenderer.material;
        }
    }

    public virtual void TakeDamage(int damageAmount)
    {
        //Poli
        currentHealth -= damageAmount;

        if (flashMaterial != null)
        {
            StartCoroutine(FlashMaterial());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //Abstract
    protected abstract void Die();

    protected IEnumerator FlashMaterial()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material = defaultMaterial;
    }
}

internal interface IDamageable
{
}