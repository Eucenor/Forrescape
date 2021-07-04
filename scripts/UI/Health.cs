using UnityEngine;
using UnityEngine.UI;
public class Health:MonoBehaviour 
{
   [SerializeField] private Image[] images;
   [SerializeField] private Sprite healthFull;
   [SerializeField] private Sprite healthEmpty;
   [SerializeField] private int currentHealth;
   [SerializeField] private int heartCount;
    public delegate void playerDead();
    public static event playerDead OnPlayerDead;

    public bool hasDied = false;
    public void TakeDamage(){
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            hasDied = true;
            OnPlayerDead.Invoke();
        }
        images[currentHealth-1].sprite = healthEmpty;
       currentHealth--;

   }
   
   public int getCurrentHealth(){
       return currentHealth;
   }
   private void Awake(){
        SetDefaultHealth();
   }
    public void SetDefaultHealth()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i < heartCount)
            {
                images[i].enabled = true;
            }
            else
            {
                images[i].enabled = false;
            }
            if (i < currentHealth)
            {
                images[i].sprite = healthFull;
            }
            else
            {
                images[i].sprite = healthEmpty;
            }
        }
    }
   
}
