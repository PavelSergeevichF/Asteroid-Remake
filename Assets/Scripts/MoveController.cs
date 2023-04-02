using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class MoveController 
{
    private GameObject _gameObject;
    private Quaternion _staticOBJ;
    private Vector3 _target;

    public MoveController(GameObject gameObject)
    {
        _gameObject = gameObject;
        _staticOBJ = Quaternion.identity;
    }

    public void MovingForward(float speed)
    {
        Moving(speed, Quaternion.Angle(_gameObject.gameObject.transform.localRotation, _staticOBJ));
    }
    public void Moving(float speed, float angelData)
    {
        var newVelocity = 0f;
        newVelocity = Time.fixedDeltaTime * speed;
        Debug.Log($"angelData {angelData}");
        _gameObject.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(Mathf.Sin(angelData / 180 * Mathf.PI) * speed, Mathf.Cos(angelData / 180 * Mathf.PI) * speed, 0);
    }
    public void MovingForwardAster(float speed)
    {
        _gameObject.gameObject.GetComponent<Rigidbody2D>().MovePosition(_gameObject.transform.position + _target * Time.deltaTime * speed);
    }

    public void MovingTarget(float speed, GameObject Player) 
    {
        Vector3 target = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        _gameObject.gameObject.transform.position = Vector3.MoveTowards(_gameObject.gameObject.transform.position , target , Time.deltaTime * speed);
    }
    public void SetTargrt()
    {
        int tmp = 200;
        float tmpPosX = Random.Range(-tmp, tmp);
        float PosX = tmpPosX / 100;
        float tmpPosY = Random.Range(-tmp, tmp);
        float PosY = tmpPosY / 100;
        PosX *= ((_gameObject.transform.position.x < 0 && PosX < 0) || (_gameObject.transform.position.x > 0 && PosX > 0)) ? 1 : -1;
        PosY *= ((_gameObject.transform.position.y < 0 && PosY < 0) || (_gameObject.transform.position.y > 0 && PosY > 0)) ? 1 : -1;
        _target = new Vector3( PosX, PosY, 0);
        _target = _target * -1;
    }
}
