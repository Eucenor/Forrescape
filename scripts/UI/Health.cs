using UnityEngine;
using UnityEngine.UI;
public class Health:MonoBehaviour 
{
//this file is to manage the health bar on the top left corner of the screen(the one with hearts filled and empty)
//an array of images that will be  put on screen
   [SerializeField] private Image[] images;
   // the sprites are images in a sense. this one is full health image
   [SerializeField] private Sprite healthFull;
   // health empty image
   [SerializeField] private Sprite healthEmpty;
   // what our current health is
   [SerializeField] private int currentHealth;
   //max health
   [SerializeField] private int heartCount;
   // delegate and event of that delegate that invokes when the player dies
    public delegate void playerDead();
    public static event playerDead OnPlayerDead;
   //old implementation for knowing if player is dead
    public bool hasDied = false;
    // when player takes damage. btw the health system is bugged rn player is kind of immortal 
    public void TakeDamage(){
    
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            hasDied = true;
            OnPlayerDead.Invoke();
        }
        // when we take damage turn current healthfull sprite to health empty to show we took damage
        images[currentHealth-1].sprite = healthEmpty;
        //update current health 
       currentHealth--;

   }
   
   public int getCurrentHealth(){
       return currentHealth;
   }
   //awake runs when the level loads first and the script is initialized/loaded in level.so this is like initializing the health of the player when game starts
   private void Awake(){
        SetDefaultHealth();
   }
   
    public void SetDefaultHealth()
    {
    //iterate through the image array
        for (int i = 0; i < images.Length; i++)
        {
        // heartcount is max number of hearts we have currently. perhaps we can in game, use a potion to increase our max health that kind of stuff
            if (i < heartCount)
            {
                images[i].enabled = true;
            }
            else
            {
                images[i].enabled = false;
            }
            //setting the health full and empty based on current health
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
