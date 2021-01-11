using UnityEngine;

public class mobileInput : MonoBehaviour 
{
    public float speed = 3f;
    public string obstruct;
    public string finish;
    public GameObject cam;
    public Vector2  refPosition;
    public Vector2 deltaPosition;
    public Vector3 offset;
    public float leftSpeed;
    public float rightSpeed;
    public float upSpeed;
    public float downSpeed; 
    public string coin;
    public bool isStarted = true;
    public bool isPaused = true;
    public bool isDead = true;
    public bool isFinished = true;
    public bool isLateral = true;
    
    public void TapToStart()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began) 
        { 
            refPosition = touch.position;  
        }
        isStarted = true;
    }
    
    public void LeftAndRightRotation(rightSpeed, leftSpeed)
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            deltaPosition = touch.position - refPosition;
            if (deltaPosition.x > 0) 
            { 
                //sağa belirlenen hızda ilerle
                transform.Translate(rightSpeed, 0, 0);
            }
            else if (deltaPosition.x < 0) 
            { 
                //sola belirlenen hızda ilerle
                transform.Translate(leftSpeed, 0, 0);
            }
                refPosition=touch.position;
        }
    }
    
    public void UpAndDownRotation(upSpeed, downSpeed)
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            deltaPosition = touch.position - refPosition;
            if (deltaPosition.y > 0) 
            { 
                //move upwards
                transform.Translate(0, upSpeed, 0);
            }
            else if (deltaPosition.y < 0) 
            { 
                //move downwards
                transform.Translate(0, downSpeed, 0);
            }
                refPosition=touch.position;
    }
    
    void DirectionChangeWithTap(isLateral = true, upSpeed, downSpeed, leftSpeed, rightSpeed)
    {
        Touch touch = Input.GetTouch(0);
        refPosition = this.position;
        if (touch.phase == TouchPhase.Began) 
        { 
            deltaPosition = touch.position - refPosition;
            if (isLateral)
            {
                upSpeed = 0;
                downSpeed = 0;
                if (deltaPosition.x > 0)
                {
                    transform.Translate(rightSpeed, 0, 0);
                }
                if (deltaPosition.x > 0)
                {
                    transform.Translate(leftSpeed, 0, 0);
                }
            }
            if (!isLateral)
            {
                leftSpeed = 0;
                rightSpeed = 0;
                if (deltaPosition.y > 0)
                {
                    transform.Translate(0, upSpeed, 0);
                }
                if (deltaPosition.y > 0)
                {
                    transform.Translate(0, downSpeed, 0);
                }
            }
        }
        if (touch.phase == TouchPhase.Ended)
        {
            refPosition = refPosition;
        }
    }
    void PauseOnNonTapControlledGame()
    {
        if (touch.phase == TouchPhase.Began) 
        { 
            if (touch.phase != TouchPhase.Stationary)
            {
                isPaused = true;
            } 
        }
    }
    }
}