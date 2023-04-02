using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : IFixedExecute
{
    private PlayerView _playerView;
    private FireController _fireController; 
    private MoveController _moveController;
    private Quaternion StaticAnge = Quaternion.identity;
    private float _speed;
    private float _angel=0f;
    private float _angelData = 0f;

    public PlayerController(PlayerView playerView)
    {
        _playerView = playerView;
        _fireController = new FireController(_playerView);
        _moveController = new MoveController(playerView.gameObject);
        _playerView.SOPlayerModel.Livs = 2;
        _speed = 0f;
        _playerView.Collision += Colision;
        _playerView.SOPlayerModel.Score = 0;
    }

    public void FixedExecute()
    {
        Move(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.LeftControl)) { Teleportation();  }
        _fireController.Execute();
    }

    private void Rotate(float vol)
    {
        if (vol > 0.2f)
        {
            _angel -= _playerView.SOPlayerModel.SpeedRotation;

        }
        if(vol < -0.2f)
        {
            _angel += _playerView.SOPlayerModel.SpeedRotation;
        }
        if (_angel > 359)
        {
            _angel -= 360;
        }
        if(_angel<0)
        {
            _angel += 360;
        }
        _playerView.gameObject.transform.rotation = Quaternion.Euler(0, 0, _angel );
        _angelData = Quaternion.Angle(_playerView.gameObject.transform.rotation, StaticAnge);
        _angelData *= _angel > 180 ? 1 : -1;
    }
    private void Move(float vol)
    {
        if (vol > 0.5f)
        {
            int ratio = _speed > 0 ? 1 : 2;
            _speed += _speed < _playerView.SOPlayerModel.MaxSpeed ? (_playerView.SOPlayerModel.Acceleration * ratio) : 0;
        }
        if (vol < -0.5f)
        {
            int ratio = _speed < 0 ? 1 : 2;
            _speed -= _speed > -_playerView.SOPlayerModel.MaxSpeed ? (_playerView.SOPlayerModel.Acceleration * ratio) : 0;
        }
        else 
        {
            if (vol > -0.1f && vol < 0.5f)
            {
                if (_speed > 0)
                {
                    _speed -= _playerView.SOPlayerModel.Acceleration;
                }
                if (_speed < 0)
                {
                    _speed += _playerView.SOPlayerModel.Acceleration;
                }
            }
        }
        _moveController.Moving(_speed, _angelData);
        CheckPose();
    }
    private void CheckPose()
    {
        if (_playerView.gameObject.transform.position.x > _playerView.SOPlayerModel.MaxPos.x || _playerView.gameObject.transform.position.x < _playerView.SOPlayerModel.MinPos.x)
            _playerView.gameObject.transform.position =
                new Vector3(_playerView.gameObject.transform.position.x*-1, _playerView.gameObject.transform.position.y, _playerView.gameObject.transform.position.z);
        if (_playerView.gameObject.transform.position.y > _playerView.SOPlayerModel.MaxPos.y || _playerView.gameObject.transform.position.y < _playerView.SOPlayerModel.MinPos.y)
            _playerView.gameObject.transform.position =
                new Vector3(_playerView.gameObject.transform.position.x , _playerView.gameObject.transform.position.y * -1, _playerView.gameObject.transform.position.z);
    }

    private void Teleportation()
    {
        Vector3 pos = new Vector3(
            (Random.Range(_playerView.SOPlayerModel.MinPos.x * 100, _playerView.SOPlayerModel.MaxPos.x * 100) / 100),
            (Random.Range(_playerView.SOPlayerModel.MinPos.y * 100, _playerView.SOPlayerModel.MaxPos.y * 100) / 100),
            0);
        _playerView.gameObject.transform.position = pos;
    }

    private void Colision() 
    {
        _playerView.gameObject.transform.position = new Vector3();
        _playerView.SOPlayerModel.Livs--;
    }
}
