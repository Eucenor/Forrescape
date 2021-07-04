using System.Collections;
using UnityEngine;
public class Movement : MonoBehaviour
{
     
    public Animations animations;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpvelocity = 10f;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private AudioSource footSound;
    private BoxCollider2D boxCollider;
    private Rigidbody2D player;
    private float direction;
    private bool isColliding = true;
    private bool isJumping = false;
    private bool isCrouching = false;
    private bool isFalling = false;
    private bool isMoving = false;
    private  bool shouldMove = true;
    public void SetShouldMove(bool value)
    {
        this.shouldMove = value;
    }
    void Awake(){
        player = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animations>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update(){
        direction =  Input.GetAxisRaw("Horizontal");
        if (this.shouldMove)
        {
            Accelerate();

            CheckIsColliding();
            setFlags();
            if (isMoving)
            {
                StartCoroutine(SpawnDust());
            }
            PlayFootsteps();
            HandleMovement();
        }
    }
    private void Accelerate(){
        if(Input.GetKey(KeyCode.LeftShift)){
            this.speed = 10f;
        }
        else{
            this.speed = 6f;
        }
    }
    private void FixedUpdate(){
        
        animations.PlayAnimations(direction,isJumping,isCrouching,isFalling);
    }
    private void setFlags(){
        isFalling = (player.velocity.y<=0 && !isColliding);
        isJumping = (player.velocity.y>0.2 && !isColliding);
        isCrouching = Input.GetKey(KeyCode.S);
        isMoving = (player.velocity.x!= 0 && (!isJumping && !isFalling));
    }
    private void CheckIsColliding(){
        if(boxCollider.enabled)
        {
            RaycastHit2D hitinfo = Physics2D.BoxCast(boxCollider.transform.position,boxCollider.size,0f,Vector2.down,2f,platformLayerMask);
            isColliding=hitinfo.collider!=null?true:false;
            Debug.DrawRay(transform.position,transform.localScale*10,Color.red);
        }
    }
   
    private void HandleMovement(){
        if(!isCrouching)
        {
            boxCollider.enabled = true;
            if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow)){
            player.velocity = new Vector2(-speed,player.velocity.y);            
            }
            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            player.velocity = new Vector2(speed,player.velocity.y);
            }
            else{
                player.velocity = new Vector2(0,player.velocity.y);
            }
            if(isColliding && Input.GetKeyDown(KeyCode.Space)){
                player.velocity = Vector2.up*jumpvelocity; 
            }   
        }
        else{
            boxCollider.enabled = false;
        }
        
    }
    private void PlayFootsteps(){
        if(isMoving){
            if(!footSound.isPlaying){
                footSound.Play();
            }
        }
        else{
            footSound.Stop();
        }
    }
    IEnumerator SpawnDust(){
        dust.Play();
        
        yield return new WaitForSeconds(3);
    }
   
   
}    
    

