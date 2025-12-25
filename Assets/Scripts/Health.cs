using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField, Range(0f, 100f)]
  private int _maxHealth = 100;
  [SerializeField, ReadOnly]
  private int _health = 100;

  public int Value => _health;
  public float Percent => (float)Value / _maxHealth;

  public event Action<float> OnHealthChanged;
  public void SetDamage(int value)
    {
        _health -= value;
        OnHealthChanged?.Invoke(Percent);
        if (_health <= 0)
        {
            Debug.Log($"<b>{name}</b> is dead!", this);
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
            #else
            Time.timeScale = 0;
            #endif
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _health = _maxHealth;
            OnHealthChanged?.Invoke(Percent);
        }
    }
    private void Awake()
    {
        _health = _maxHealth;
    }
}
