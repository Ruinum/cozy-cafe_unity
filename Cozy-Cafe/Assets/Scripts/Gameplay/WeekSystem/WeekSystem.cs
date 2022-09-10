using System.Collections.Generic;
using Ruinum.Core;


public class WeekSystem : BaseSingleton<WeekSystem>
{
    private List<DayLogic> _dayLogics = new List<DayLogic>();
    private DayType _currentDay = DayType.Monday;

    private void Start()
    {
        _dayLogics.Add(new DayLogic(DayType.Monday));
        _dayLogics.Add(new DayLogic(DayType.Tuesday));
        _dayLogics.Add(new DayLogic(DayType.Wednesday));
        _dayLogics.Add(new DayLogic(DayType.Thursday));
        _dayLogics.Add(new DayLogic(DayType.Friday));
        _dayLogics.Add(new DayLogic(DayType.Saturday));
        _dayLogics.Add(new DayLogic(DayType.Sunday));
    }
    
    public void ChangeDay()
    {
        switch (_currentDay)
        {
            case DayType.Monday: _currentDay = DayType.Tuesday; break;
            case DayType.Tuesday: _currentDay = DayType.Wednesday; break;
            case DayType.Wednesday: _currentDay = DayType.Thursday; break;
            case DayType.Thursday: _currentDay = DayType.Friday; break;
            case DayType.Friday: _currentDay = DayType.Saturday; break;
            case DayType.Saturday: _currentDay = DayType.Sunday; break;
            case DayType.Sunday: _currentDay = DayType.Monday; break;
            default: break;
        }
    }

    private void AddDayLogic(IDayLogic dayLogic, DayType dayType)
    {
        for (int i = 0; i < _dayLogics.Count; i++)
        {
            if (_dayLogics[i].DayType != dayType) continue;
            _dayLogics[i].AddDayLogic(dayLogic);
        }
    }

    private void RemoveDayLogic(IDayLogic dayLogic, DayType dayType)
    {
        for (int i = 0; i < _dayLogics.Count; i++)
        {
            if (_dayLogics[i].DayType != dayType) continue;
            _dayLogics[i].RemoveDayLogic(dayLogic);
        }
    }    
}
