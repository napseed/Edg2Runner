using System.Collections.Generic;
using UnityEngine;


public class PlayerUpgrade : MonoBehaviour
{
    private Dictionary<(Data.Company, Data.UpgradeType), int> levels = new();

    public void ApplyUpgrade(UpgradeEffect effect)
    {
        if (effect == null)
        {
            Debug.LogWarning("업그레이드 효과가 null입니다.");
            return;
        }

        Debug.Log($"업그레이드 적용: {effect.name} (레벨 {effect.level}) - {effect.description}");
    }

    public void SetUpgradeLevel(Data.Company company, Data.UpgradeType type, int level)
    {
        var key = (company, type);
        if (!levels.ContainsKey(key) || levels[key] < level)
        {
            levels[key] = level;
        }
    }

    public int GetUpgradeLevel(Data.Company company, Data.UpgradeType type)
    {
        var key = (company, type);
        return levels.TryGetValue(key, out int level) ? level : 0;
    }
}
