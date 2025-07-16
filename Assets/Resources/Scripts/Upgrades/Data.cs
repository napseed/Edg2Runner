using UnityEngine;
using System;
using NUnit.Framework;
using System.Collections.Generic;

public class Data
{
    public enum Company
    {
        SOFIA,
        OHKco,
        Weaponizer,
        Windmill,
        amada,
        TriChrome,
        ZETA,
        etc,
    }

    // 기업별 업그레이드의 종류, 일단 기업당 6종류로 제한
    public enum UpgradeType
    {
        up1, up2, up3, up4, up5, up6,
    }

    [Serializable]
    public struct UpgradeKey
    {
        public Company company;
        public UpgradeType type;
        public int level;

        public UpgradeKey(Company co, UpgradeType type, int level)
        {
            this.company = co;
            this.type = type;
            this.level = level;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(company, type, level);
        }
    }

}
