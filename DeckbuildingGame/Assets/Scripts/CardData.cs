using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "Card Data", order = 51)]
public class CardData : ScriptableObject
{
    public string cardName;
    public int cost;
    public Sprite image;

    [System.Serializable]
    public class CardEffect
    {
        public enum TargetType
        {
            NoTarget,
            SingleTargetCreature,
            SingleTargetPlayer,
            SingleTargetWorker,
            SingleTargetCreatureOrPlayer,
            SingleTargetAnything,
            AllCreatures,
            AllPlayers,
            AllWorkers,
            Everything
        }

        public enum EffectType
        {
            Damage,
            GenerateResources,
            Summon,
            Heal
        }

        public TargetType targetType;
        public EffectType effectType;
        public string effectValue;
        public CreatureData creatureSummoned;
    }

    public List<CardEffect> effects;

    public string generateDescription()
    {
        string result = "";

        for (int i = 0; i < effects.Count; i++)
        {
            string currentEffect = "";
            switch (effects[i].effectType)
            {
                case CardData.CardEffect.EffectType.Damage:
                    currentEffect = LocalizationManager.instance.getLocalizedString("Damage");
                    break;
                case CardData.CardEffect.EffectType.GenerateResources:
                    currentEffect = LocalizationManager.instance.getLocalizedString("GenerateResources");
                    break;
                case CardData.CardEffect.EffectType.Summon:
                    currentEffect = LocalizationManager.instance.getLocalizedString("Summon");
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString(effects[i].creatureSummoned.creatureName));
                    break;
                case CardData.CardEffect.EffectType.Heal:
                    currentEffect = LocalizationManager.instance.getLocalizedString("Heal");
                    break;
                default:
                    break;
            }

            currentEffect = currentEffect.Replace("{0}", effects[i].effectValue);

            switch (effects[i].targetType)
            {
                case CardData.CardEffect.TargetType.NoTarget:
                    break;
                case CardData.CardEffect.TargetType.SingleTargetCreature:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetCreature"));
                    break;
                case CardData.CardEffect.TargetType.SingleTargetPlayer:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetPlayer"));
                    break;
                case CardData.CardEffect.TargetType.SingleTargetWorker:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetWorker"));
                    break;
                case CardData.CardEffect.TargetType.SingleTargetCreatureOrPlayer:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetCreatureOrPlayer"));
                    break;
                case CardData.CardEffect.TargetType.SingleTargetAnything:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetEnemy"));
                    break;
                case CardData.CardEffect.TargetType.AllCreatures:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("AllCreatures"));
                    break;
                case CardData.CardEffect.TargetType.AllPlayers:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("AllPlayers"));
                    break;
                case CardData.CardEffect.TargetType.AllWorkers:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("AllWorkers"));
                    break;
                case CardData.CardEffect.TargetType.Everything:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("Everything"));
                    break;
                default:
                    break;
            }

            result += currentEffect + "\n";
        }

        return result;
    }
}
