using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    [Header("등록된 업그레이드 정의들")]
    public List<UpgradeDefinition> allDefinitions;

    // 업그레이드 정의 조회
    public UpgradeDefinition GetDefinition(Data.Company company, Data.UpgradeType type)
    {
        return allDefinitions.Find(def => def.company == company && def.type == type);
    }

    // 업그레이드 선택 후 적용
    public void ApplyUpgradeToPlayer(PlayerUpgrade player, Data.Company company, Data.UpgradeType type, int level)
    {
        var def = GetDefinition(company, type);
        if (def == null)
        {
            Debug.LogWarning("정의되지 않은 업그레이드입니다.");
            return;
        }

        var effect = def.GetEffectByLevel(level);
        if (effect != null)
        {
            player.ApplyUpgrade(effect);
            player.SetUpgradeLevel(company, type, level);

        }
    }
}
