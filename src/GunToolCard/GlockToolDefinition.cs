﻿using LBoL.Base;
using LBoL.ConfigData;
using LBoL.Core.Battle.BattleActions;
using LBoL.Core.Battle;
using LBoL.Core;
using LBoL.Core.Cards;
using LBoL.Core.Units;
using LBoLEntitySideloader;
using LBoLEntitySideloader.Attributes;
using LBoLEntitySideloader.Entities;
using LBoLEntitySideloader.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using static GunToolCard.Plugin;
using System.Reflection;
using YamlDotNet.RepresentationModel;
using HarmonyLib;

namespace GunToolCard
{
    public sealed class GlockToolDefinition : CardTemplate
    {
        public override IdContainer GetId()
        {
            return nameof(GlockTool);
        }

        public override CardImages LoadCardImages()
        {
            var cardImages = new CardImages(ResourceLoader.LoadTexture(GetId() + ".png", manifestSource));

            CardConfig.FromId(UniqueId).SubIllustrator.Do(s => cardImages.subs.Add(ResourceLoader.LoadTexture(GetId() + s + ".png", manifestSource)));
            return cardImages;
        }

        public override YamlMappingNode LoadYaml()
        {
            return ResourceLoader.LoadYaml(GetId() + ".yaml", manifestSource);
        }

        public override CardConfig MakeConfig()
        {
             var cardConfig = new CardConfig(
               Index: sequenceTable.Next(typeof(CardConfig)),
               Id: GetId(),
               Order: 10,
               AutoPerform: false,
               Perform: new string[0][],
               GunName: "Simple1",
               GunNameBurst: "Simple1",
               DebugLevel: 0,
               Revealable: false,
               IsPooled: true,
               IsUpgradable: false,
               Rarity: Rarity.Rare,
               Type: CardType.Tool,
               TargetType: TargetType.SingleEnemy,
               Colors: new List<ManaColor>() {  },
               IsXCost: false,
               Cost: new ManaGroup() { Any = 1 },
               UpgradedCost: null,
               MoneyCost: null,
               Damage: null,
               UpgradedDamage: null,
               Block: null,
               UpgradedBlock: null,
               Shield: null,
               UpgradedShield: null,
               Value1: null,
               UpgradedValue1: null,
               Value2: null,
               UpgradedValue2: null,
               Mana: null,
               UpgradedMana: null,
               Scry: null,
               UpgradedScry: null,
               ToolPlayableTimes: 1,
               Keywords: Keyword.Exile,
               UpgradedKeywords: default,
               EmptyDescription: false,
               RelativeKeyword: default,
               UpgradedRelativeKeyword: default,

               RelativeEffects: new List<string>() { },
               UpgradedRelativeEffects: new List<string>() { },
               RelativeCards: new List<string>() { },
               UpgradedRelativeCards: new List<string>() { },
               Owner: null,
               Unfinished: false,
               Illustrator: "@abikozyozi",
               SubIllustrator: new List<string>() { "alt1" }
            );

            return cardConfig;
        }

        [EntityLogic(typeof(GlockToolDefinition))]
        public sealed class GlockTool : Card
        {
            protected override IEnumerable<BattleAction> Actions(UnitSelector selector, ManaGroup consumingMana, Interaction precondition)
            {
                EnemyUnit selectedEnemy = selector.SelectedEnemy;
                yield return new ForceKillAction(base.Battle.Player, selectedEnemy);
                yield break;
            }
        }
    }
}