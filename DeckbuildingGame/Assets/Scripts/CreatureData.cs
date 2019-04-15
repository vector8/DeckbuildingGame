using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CreatureData", menuName = "Creature Data", order = 52)]
public class CreatureData : ScriptableObject
{
    public string creatureName;
    public Sprite image;
    public int damage, health;

    [System.Serializable]
    public class CreatureEffect
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

        public enum Trigger
        {
            Summoned,
            StartTurn,
            EndTurn,
            Activated,
            Died
        }

        public Trigger trigger;
        public TargetType targetType;
        public EffectType effectType;
        public int activationCost;
        public string effectValue;
        public CreatureData creatureSummoned;
    }

    public List<CreatureEffect> effects;

    public string generateDescription()
    {
        string result = "";

        for (int i = 0; i < effects.Count; i++)
        {
            string currentEffect = "";

            switch (effects[i].trigger)
            {
                case CreatureEffect.Trigger.Summoned:
                    currentEffect = LocalizationManager.instance.getLocalizedString("OnSummon");
                    break;
                case CreatureEffect.Trigger.StartTurn:
                    currentEffect = LocalizationManager.instance.getLocalizedString("OnStartTurn");
                    break;
                case CreatureEffect.Trigger.EndTurn:
                    currentEffect = LocalizationManager.instance.getLocalizedString("OnEndTurn");
                    break;
                case CreatureEffect.Trigger.Activated:
                    currentEffect = LocalizationManager.instance.getLocalizedString("OnActivation");
                    break;
                case CreatureEffect.Trigger.Died:
                    currentEffect = LocalizationManager.instance.getLocalizedString("OnDeath");
                    break;
                default:
                    break;
            }

            switch (effects[i].effectType)
            {
                case CreatureEffect.EffectType.Damage:
                    currentEffect += LocalizationManager.instance.getLocalizedString("Damage").ToLower();
                    break;
                case CreatureEffect.EffectType.GenerateResources:
                    currentEffect += LocalizationManager.instance.getLocalizedString("GenerateResources").ToLower();
                    break;
                case CreatureEffect.EffectType.Summon:
                    currentEffect += LocalizationManager.instance.getLocalizedString("Summon").ToLower();
                    currentEffect += currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString(effects[i].creatureSummoned.creatureName));
                    break;
                case CreatureEffect.EffectType.Heal:
                    currentEffect += LocalizationManager.instance.getLocalizedString("Heal").ToLower();
                    break;
                default:
                    break;
            }

            currentEffect = currentEffect.Replace("{0}", effects[i].effectValue);

            switch (effects[i].targetType)
            {
                case CreatureEffect.TargetType.NoTarget:
                    break;
                case CreatureEffect.TargetType.SingleTargetCreature:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetCreature"));
                    break;
                case CreatureEffect.TargetType.SingleTargetPlayer:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetPlayer"));
                    break;
                case CreatureEffect.TargetType.SingleTargetWorker:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetWorker"));
                    break;
                case CreatureEffect.TargetType.SingleTargetCreatureOrPlayer:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetCreatureOrPlayer"));
                    break;
                case CreatureEffect.TargetType.SingleTargetAnything:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("TargetEnemy"));
                    break;
                case CreatureEffect.TargetType.AllCreatures:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("AllCreatures"));
                    break;
                case CreatureData.CreatureEffect.TargetType.AllPlayers:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("AllPlayers"));
                    break;
                case CreatureData.CreatureEffect.TargetType.AllWorkers:
                    currentEffect = currentEffect.Replace("{1}", LocalizationManager.instance.getLocalizedString("AllWorkers"));
                    break;
                case CreatureData.CreatureEffect.TargetType.Everything:
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
