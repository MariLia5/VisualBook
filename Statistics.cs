using System;

[Serializable]
public class Statistics
{
    private int _observation;
    private int _health;
    private int _blood;
    private int _bone;
    private int _blister;
    private int _sms;
    private int _decoration;

    public Statistics()
    {
        Reset();
    }

    public int Observation => _observation;
    public int Health => _health;
    public int Blood => _blood;
    public int Bone => _bone;
    public int Blister => _blister;
    public int Sms => _sms;
    public int Decoration => _decoration;

    public void AddObservation(int value = 1) => _observation += value;
    public void SetHealth(int value) => _health = Math.Max(0, value);
    public void AddHealth(int value) => SetHealth(_health + value);
    public void AddBlood(int value = 1) => _blood += value;
    public void AddBone(int value = 1) => _bone += value;
    public void AddBlister(int value = 1) => _blister += value;
    public void AddSms(int value = 1) => _sms += value;
    public void AddDecoration(int value = 1) => _decoration += value;

    public void Reset()
    {
        _observation = 0;
        _health = 5;
        _blood = 0;
        _bone = 0;
        _blister = 0;
        _sms = 0;
        _decoration = 0;
    }

    public string GetDisplayText()
    {
        return "БАЗОВЫЕ ХАРАКТЕРИСТИКИ:\r\n" +
               $"Имя: Майк Джонс\r\n" +
               $"Должность: частный детектив, бывший сотрудник ФБР\r\n" +
               $"ХП: {_health}\r\n" +
               $"Наблюдательность: {_observation}\r\n";
    }

    public void LoadFrom(Statistics other)
    {
        _observation = other._observation;
        _health = other._health;
        _blood = other._blood;
        _bone = other._bone;
        _blister = other._blister;
        _sms = other._sms;
        _decoration = other._decoration;
    }
}