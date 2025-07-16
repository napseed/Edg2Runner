using System.Collections.Generic;
using UnityEngine;
using static Data;

[CreateAssetMenu(menuName = "Upgrade/UpgradeDefinition")]
public class UpgradeDefinition : ScriptableObject
{
    public Data.Company company;
    public Data.UpgradeType type;

    public List<UpgradeEffect> effects;

    public UpgradeEffect GetEffectByLevel(int level)
    {
        return effects.Find(upgrade => upgrade.level == level);
    }
}
