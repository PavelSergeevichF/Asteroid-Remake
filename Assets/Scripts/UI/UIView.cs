using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Text _textScore;
    [SerializeField] private Text _textLive;
    [SerializeField] private Image _laserEnergy;
    [SerializeField] private List<Image> _imageLive;

    public Text TextScore => _textScore;
    public Text TextLive => _textLive;
    public List<Image> ImageLive => _imageLive;
    public Image LaserEnergy => _laserEnergy;
}
