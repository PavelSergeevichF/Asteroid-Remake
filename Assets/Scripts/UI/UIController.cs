using UnityEngine;

public class UIController : IFixedExecute
{
    private SOPlayerModel _sOPlayerModel;
    private UIView _uIView;
    private int _tempScore = 0;


    public UIController(UIView uIView, SOPlayerModel sOPlayerModel)
    {
        _uIView = uIView;
        _sOPlayerModel = sOPlayerModel;
    }

    public void FixedExecute()
    {
        _uIView.LaserEnergy.fillAmount = _sOPlayerModel.LaserEnergy;
        _uIView.TextScore.text = _sOPlayerModel.Score.ToString();
        SetViewLive();
        CheckScore();
    }
    private void SetViewLive()
    {
        ClearImage();
        if (_sOPlayerModel.Livs< _uIView.ImageLive.Count)
        {
            _uIView.TextLive.gameObject.SetActive(false);
            for (int i=0; i< _sOPlayerModel.Livs; i++)
            {
                _uIView.ImageLive[i].gameObject.SetActive(true);
            }
        }
        else 
        {
            _uIView.TextLive.gameObject.SetActive(true);
            _uIView.ImageLive[0].gameObject.SetActive(true);
            _uIView.TextLive.text = _sOPlayerModel.Livs.ToString();
        }
    }
    private void ClearImage()
    {
        foreach(var img in _uIView.ImageLive)
        {
            img.gameObject.SetActive(false);
        }
    }
    private void CheckScore()
    {
        if (_sOPlayerModel.Score > _tempScore + 50)
        {
            _tempScore = _sOPlayerModel.Score;
            _sOPlayerModel.Livs++;
        }
    }
}
