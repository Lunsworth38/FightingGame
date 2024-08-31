using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        changeHealthSlider();
    }

    public void LoseHealth(float value)
    {
        health = health - value;
    }

    public void GainHealth(float value)
    {
        health = health + value;
    }

    void changeHealthSlider()
    {
        float healthValue =health / maxHealth;
        healthBar.value = healthValue;
    }
}
