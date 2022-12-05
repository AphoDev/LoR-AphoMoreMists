using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using UI;
using UnityEngine;

namespace AphoMoreMists
{
    public static class AphoMoreMists
    {
        public static string PackageId = "AphoMoreMists";
        public static string Path;
    }
    public class AphoMoreMistsInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(AphoMoreMists.Path + "/ArtWork"));
            ArtUtil.PreLoadBufIcons();
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, AphoMoreMists.PackageId);
            KeypageUtil.ChangeKeypageItem(Singleton<BookXmlList>.Instance, AphoMoreMists.PackageId);
            PassiveUtil.ChangePassiveItem(AphoMoreMists.PackageId);
            LocalizeUtil.AddGlobalLocalize(AphoMoreMists.PackageId);
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
            CustomMapHandler.ModResources.CacheInit.InitCustomMapFiles(Assembly.GetExecutingAssembly());
        }

        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(AphoMoreMists.PackageId);
            AphoMoreMists.Path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(AphoMoreMists.PackageId, AphoMoreMists.Path);
            OnInitRewards();
            OnInitSprites();
            OnInitKeypages();
            OnInitPassives();
            OnInitCards();
            OnInitDropBooks();
            OnInitCategories();
        }

        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(null, null, new List<LorId>
            {
                new LorId(AphoMoreMists.PackageId, 10000001)
            }));
        }

        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(AphoMoreMists.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "AphoMoreMists_Icon"),
                new SpriteOptions(SpriteEnum.Custom, 10000002, "AphoMoreMists_Icon"),
                new SpriteOptions(SpriteEnum.Custom, 10000003, "AphoMoreMists_Icon")
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(AphoMoreMists.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(1, keypageColorOptions: new KeypageColorOptions(Color.red, Color.red)),
                new KeypageOptions(2, keypageColorOptions: new KeypageColorOptions(new Color(1f, 0.3f, 0f), new Color(1f, 0.3f, 0f))),
                new KeypageOptions(3, keypageColorOptions: new KeypageColorOptions(Color.gray, Color.gray)),
                new KeypageOptions(10000001, keypageColorOptions: new KeypageColorOptions(Color.red, Color.red)),
                new KeypageOptions(10000002, keypageColorOptions: new KeypageColorOptions(new Color(1f, 0.3f, 0f), new Color(1f, 0.3f, 0f))),
                new KeypageOptions(10000003, keypageColorOptions: new KeypageColorOptions(Color.gray, Color.gray)),
            });
        }

        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(AphoMoreMists.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(1, transferable: false),
                new PassiveOptions(2, transferable: false, passiveColorOptions: new PassiveColorOptions(new Color(1f, 0.3f, 0f), new Color(1f, 0.3f, 0f))),
                new PassiveOptions(3, passiveColorOptions: new PassiveColorOptions(new Color(0.89f, 0.259f, 0.204f), new Color(1f, 0.3f, 0f))),
                new PassiveOptions(4, passiveColorOptions: new PassiveColorOptions(new Color(0.89f, 0.259f, 0.204f), new Color(1f, 0.3f, 0f))),
                new PassiveOptions(5, passiveColorOptions: new PassiveColorOptions(new Color(0.89f, 0.259f, 0.204f), new Color(1f, 0.3f, 0f))),
                new PassiveOptions(6, transferable: false, passiveColorOptions: new PassiveColorOptions(Color.gray, Color.gray)),
                new PassiveOptions(7, passiveColorOptions: new PassiveColorOptions(Color.gray, Color.gray)),
                new PassiveOptions(8, passiveColorOptions: new PassiveColorOptions(Color.gray, Color.gray)),
                new PassiveOptions(9, passiveColorOptions: new PassiveColorOptions(Color.gray, Color.gray))
            });
        }

        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(AphoMoreMists.PackageId, new List<CardOptions>
            {
                new CardOptions(1, cardColorOptions: new CardColorOptions(new Color(1f, 0.3f, 0f))),
                new CardOptions(2, cardColorOptions: new CardColorOptions(new Color(1f, 0.3f, 0f))),
                new CardOptions(3, cardColorOptions: new CardColorOptions(new Color(1f, 0.3f, 0f))),
                new CardOptions(4, cardColorOptions: new CardColorOptions(new Color(1f, 0.3f, 0f))),
                new CardOptions(5, cardColorOptions: new CardColorOptions(new Color(1f, 0.3f, 0f))),
                new CardOptions(6, cardColorOptions: new CardColorOptions(new Color(1f, 0.45f, 0f))),
                new CardOptions(7, cardColorOptions: new CardColorOptions(new Color(1f, 0.45f, 0f))),
                new CardOptions(8, cardColorOptions: new CardColorOptions(new Color(1f, 0.45f, 0f))),
                new CardOptions(11, cardColorOptions: new CardColorOptions(Color.gray)),
                new CardOptions(12, cardColorOptions: new CardColorOptions(Color.gray)),
                new CardOptions(13, cardColorOptions: new CardColorOptions(Color.gray)),
                new CardOptions(14, cardColorOptions: new CardColorOptions(Color.gray)),
                new CardOptions(15, cardColorOptions: new CardColorOptions(Color.gray)),
                new CardOptions(16, cardColorOptions: new CardColorOptions(new Color(0.945f, 0.898f, 0.675f))),
                new CardOptions(17, cardColorOptions: new CardColorOptions(new Color(0.945f, 0.898f, 0.675f))),
                new CardOptions(18, cardColorOptions: new CardColorOptions(new Color(0.945f, 0.898f, 0.675f)))
            });
        }

        private static void OnInitDropBooks()
        {
            ModParameters.DropBookOptions.Add(AphoMoreMists.PackageId, new List<DropBookOptions>
            {
                new DropBookOptions(1, new DropBookColorOptions(Color.red, Color.red))
            });
        }

        private static void OnInitCategories()
        {
            ModParameters.CategoryOptions.Add(AphoMoreMists.PackageId, new List<CategoryOptions>
            {
                new CategoryOptions(AphoMoreMists.PackageId, "_1", baseGameCategory: UIStoryLine.TheRedMist, categoryBooksId: new List<int> { 10000001, 10000002, 10000003 }, customIconSpriteId: "", baseIconSpriteId: "", categoryNameId: "", categoryName: "", chapter: 7, bookDataColor: null, credenzaBooksId: new List<int> { 10000001, 10000002, 10000003 })
            });
        }
    }
    //PASSIVES
    public class PassiveAbility_Apho_MistFinal : PassiveAbilityBase
    {
        public static string Name = "Legendary";
        public static string Desc = "Untransferable. Draw 4 additional pages at the start of the Act. Reduce the cost of all 'Upstanding Slash', 'Spear', and 'Level Slash' by 1." +
            "Unique E.G.O becomes accessible." +
            "At Emotion Level 4 or above, the Combat Page 'Manifest E.G.O' is added to hand. (Once per Act)";
        private bool _egoAwaken;
        public override void OnWaveStart()
        {
            owner.allyCardDetail.DrawCards(4);
            if (!owner.personalEgoDetail.ExistsCard(607022))
            {
                owner.personalEgoDetail.AddCard(607022);
            }

            foreach (BattleDiceCardModel item in owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x.GetID() == 607003))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            foreach (BattleDiceCardModel item2 in owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x.GetID() == 607004))
            {
                item2.GetBufList();
                item2.AddCost(-1);
            }

            foreach (BattleDiceCardModel item3 in owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x.GetID() == 607005))
            {
                item3.GetBufList();
                item3.AddCost(-1);
            }
        }
        public override void OnRoundStart()
        {
            UpdateResist();
            if (!_egoAwaken && owner.emotionDetail.EmotionLevel >= 4)
            {
                _egoAwaken = true;
                owner.allyCardDetail.AddNewCard(607008);
            }
        }

        private void UpdateResist()
        {
            BehaviourDetail detail = RandomUtil.SelectOne<BehaviourDetail>(BehaviourDetail.Slash, BehaviourDetail.Penetrate, BehaviourDetail.Hit);
            if (HasEgoPassive())
            {
                owner.Book.SetResistHP(BehaviourDetail.Slash, AtkResist.Endure);
                owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Endure);
                owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Penetrate, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
                owner.Book.SetResistHP(detail, AtkResist.Normal);
                owner.Book.SetResistBP(detail, AtkResist.Normal);
            }
        }

        public bool HasEgoPassive()
        {
            return owner.passiveDetail.HasPassive<PassiveAbility_250422>();
        }
    }
    public class PassiveAbility_Apho_MistBlazing_Mythical : PassiveAbilityBase
    {
        public static string Name = "Mythical";
        public static string Desc = "Untransferable." +
            "Unique E.G.O becomes accessible." +
            "At Emotion Level 4 or above, the Combat Page 'Manifest E.G.O' is added to hand. (Once per Act)";
        private bool _egoAwaken;
        public override void OnWaveStart()
        {
            List<BattleDiceCardModel> list = owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoMoreMists.PackageId, 8));
            if (list.Count <= 0)
            {
                owner.personalEgoDetail.AddCard(new LorId(AphoMoreMists.PackageId, 8));
            }
        }

        public override void OnRoundStart()
        {
            UpdateResist();
            if (!_egoAwaken && owner.emotionDetail.EmotionLevel >= 4)
            {
                _egoAwaken = true;
                owner.allyCardDetail.AddNewCard(new LorId(AphoMoreMists.PackageId, 6));
            }
            else if (owner.personalEgoDetail.ExistsCard(607021))
            {
                owner.personalEgoDetail.RemoveCard(607021);
            }
        }

        private void UpdateResist()
        {
            BehaviourDetail detail = RandomUtil.SelectOne<BehaviourDetail>(BehaviourDetail.Slash, BehaviourDetail.Penetrate, BehaviourDetail.Hit);
            if (HasEgoPassive())
            {
                owner.Book.SetResistHP(BehaviourDetail.Slash, AtkResist.Endure);
                owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Endure);
                owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Penetrate, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
                owner.Book.SetResistHP(detail, AtkResist.Normal);
                owner.Book.SetResistBP(detail, AtkResist.Normal);
            }
        }
        public bool HasEgoPassive()
        {
            return owner.passiveDetail.HasPassive<PassiveAbility_250422>();
        }
    }
    public class PassiveAbility_Apho_MistBlazing_Combustion : PassiveAbilityBase
    {
        public static string Name = "Combustion";

        public static string Desc = "At the start of the Scene, inflict 2 Burn to all enemies.";

        public override void OnRoundStart()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((owner.faction != Faction.Player) ? Faction.Player : Faction.Enemy);
            foreach (BattleUnitModel item in aliveList)
            {
                item.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 2);
            }
        }
    }
    public class PassiveAbility_Apho_MistBlazing_TheHottest : PassiveAbilityBase
    {
        public static string Name = "The Hottest";

        public static string Desc = "Take no damage from Burn. Inflict 1 Burn to each other on hit.";

        public override bool IsImmune(KeywordBuf buf)
        {
            return buf == KeywordBuf.Burn || base.IsImmune(buf);
        }

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (target != null)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 1, owner);
                target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 1, owner);
            }
        }
    }
    public class PassiveAbility_Apho_MistBlazing_Prowess : PassiveAbilityBase
    {
        public static string Name = "Pyro Prowess";

        public static string Desc = "Dice Power +1 per 5 stacks of Burn on self or target (Max. 5)";

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            int num = Mathf.Min(owner.bufListDetail.GetKewordBufStack(KeywordBuf.Burn) + target.bufListDetail.GetKewordBufStack(KeywordBuf.Burn) / 5, 5);
            if (num > 0)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = num
                });
            }
        }
    }
    public class PassiveAbility_Apho_MistSmoke_Mythical : PassiveAbilityBase
    {
        public static string Name = "Mythical";
        public static string Desc = "Untransferable. Unique E.G.O becomes accessible." +
            "At Emotion Level 4 or above, the Combat Page 'Manifest E.G.O' is added to hand. (Once per Act)";
        private bool _egoAwaken;
        public override void OnWaveStart()
        {
            List<BattleDiceCardModel> list = owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoMoreMists.PackageId, 8));
            if (list.Count <= 0)
            {
                owner.personalEgoDetail.AddCard(new LorId(AphoMoreMists.PackageId, 18));
            }
        }

        public override void OnRoundStart()
        {
            UpdateResist();
            if (!_egoAwaken && owner.emotionDetail.EmotionLevel >= 4)
            {
                _egoAwaken = true;
                owner.allyCardDetail.AddNewCard(new LorId(AphoMoreMists.PackageId, 16));
            }
            else if (owner.personalEgoDetail.ExistsCard(607021))
            {
                owner.personalEgoDetail.RemoveCard(607021);
            }
        }

        private void UpdateResist()
        {
            BehaviourDetail detail = RandomUtil.SelectOne<BehaviourDetail>(BehaviourDetail.Slash, BehaviourDetail.Penetrate, BehaviourDetail.Hit);
            if (HasEgoPassive())
            {
                owner.Book.SetResistHP(BehaviourDetail.Slash, AtkResist.Endure);
                owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Endure);
                owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Penetrate, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
                owner.Book.SetResistHP(detail, AtkResist.Normal);
                owner.Book.SetResistBP(detail, AtkResist.Normal);
            }
        }
        public bool HasEgoPassive()
        {
            return owner.passiveDetail.HasPassive<PassiveAbility_250422>();
        }
    }
    public class PassiveAbility_Apho_MistSmoke_Puffy : PassiveAbilityBase
    {
        public static string Name = "Puffier Brume";

        public static string Desc = "All allies gain the effect of 'Puffy Brume'.";

        public override void OnWaveStart()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(owner.faction);
            List<BattleUnitModel> list = new List<BattleUnitModel>();
            foreach (BattleUnitModel item in aliveList)
            {
                if (!item.IsDead() && !item.passiveDetail.HasPassive<PassiveAbility_240026>())
                {
                    list.Add(item);
                }
            }

            foreach (BattleUnitModel item2 in list)
            {
                if (!item2.passiveDetail.HasPassive<PassiveAbility_240026>())
                {
                    item2.passiveDetail.AddPassive(new PassiveAbility_240026());
                }
            }
        }
    }
    public class PassiveAbility_Apho_MistSmoke_TheHaziest : PassiveAbilityBase
    {
        public static string Name = "The Haziest";

        public static string Desc = "Gain 2 Smoke at the start of the Scene.";

        public override void OnRoundStart()
        {
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Smoke, 2, owner);
        }
    }
    public class PassiveAbility_Apho_MistSmoke_Prowess : PassiveAbilityBase
    {
        public static string Name = "Puffy Prowess";

        public static string Desc = "Dice Power +1 per 3 stacks of Smoke on self or target (Max. 5)";

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            int num = Mathf.Min(owner.bufListDetail.GetKewordBufStack(KeywordBuf.Smoke) + target.bufListDetail.GetKewordBufStack(KeywordBuf.Smoke) / 3, 5);
            if (num > 0)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = num
                });
            }
        }
    }

    //DiceCardAbility
    public class DiceCardSelfAbility_Apho_MistBlazing_Blunt : DiceCardSelfAbilityBase
    {
        public static string Name = "Searing Smash";

        public static string Desc = "If 8 or more damage was dealt with this page, draw 1 page and reduce the Cost of all other 'Searing Smashes' by 1";

        private int _activateLine = 8;

        private int _totalDamage;

        public override string[] Keywords => new string[1] { "DrawCard_Keyword" };

        public override void OnUseCard()
        {
            _totalDamage = 0;
        }

        public override void AfterGiveDamage(int damage, BattleUnitModel target)
        {
            _totalDamage += damage;
        }

        public override void OnEndBattle()
        {
            if (_totalDamage >= _activateLine)
            {
                Activate();
            }
        }

        private void Activate()
        {
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 1)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            base.owner.allyCardDetail.DrawCards(1);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBlazing_Pierce : DiceCardSelfAbilityBase
    {
        public static string Name = "Scorching Spear";

        public static string Desc = "If 8 or more damage was dealt with this page, draw 1 page and reduce the Cost of all other 'Scorching Spear' by 1";

        private int _activateLine = 8;

        private int _totalDamage;

        public override string[] Keywords => new string[1] { "DrawCard_Keyword" };

        public override void OnUseCard()
        {
            _totalDamage = 0;
        }

        public override void AfterGiveDamage(int damage, BattleUnitModel target)
        {
            _totalDamage += damage;
        }

        public override void OnEndBattle()
        {
            if (_totalDamage >= _activateLine)
            {
                Activate();
            }
        }

        private void Activate()
        {
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 2)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            base.owner.allyCardDetail.DrawCards(1);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBlazing_Slash : DiceCardSelfAbilityBase
    {
        public static string Name = "Charring Cut";

        public static string Desc = "If 8 or more damage was dealt with this page, restore 2 Light and reduce the Cost of all other 'Charring Cuts' by 1";

        private int _activateLine = 8;

        private int _totalDamage;

        public override string[] Keywords => new string[1] { "Energy_Keyword" };

        public override void OnUseCard()
        {
            _totalDamage = 0;
        }

        public override void AfterGiveDamage(int damage, BattleUnitModel target)
        {
            _totalDamage += damage;
        }

        public override void OnEndBattle()
        {
            if (_totalDamage >= _activateLine)
            {
                Activate();
            }
        }

        private void Activate()
        {
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 3)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            base.owner.cardSlotDetail.RecoverPlayPointByCard(2);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBlazing_Spirit : DiceCardSelfAbilityBase
    {
        public static string Desc = "[Combat Start] When inflicting Burn using Combat Pages this Scene, inflict 1 additional stack\n[On Use] Gain 2 Burn";

        public override string[] Keywords => new string[3] { "bstart_Keyword", "Burn_Keyword", "Strength_Keyword" };

        public override void OnStartBattle()
        {
            base.owner.bufListDetail.AddBuf(new DiceCardSelfAbility_burnPlus.BattleUnitBuf_burnPlus());
        }

        public override void OnUseCard()
        {
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 2, base.owner);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBlazing_Onrush : DiceCardSelfAbilityBase
    {
        public static string Desc = " If target is defeated or Staggered, inflict 1 Burn to all enemies, and use this page again on a random enemy.";

        private bool _isBreakedStart;

        public override string[] Keywords => new string[1] { "Burn_Keyword" };

        public override void OnUseCard()
        {
            _isBreakedStart = false;
            if (card.target != null && card.target.IsBreakLifeZero())
            {
                _isBreakedStart = true;
            }
        }

        public override void OnEndBattle()
        {
            if (card.target == null || (!card.target.IsDead() && (_isBreakedStart || !card.target.IsBreakLifeZero())))
            {
                return;
            }

            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction != Faction.Player) ? Faction.Player : Faction.Enemy);
            if (aliveList.Count <= 0)
            {
                return;
            }

            foreach (BattleUnitModel item in aliveList)
            {
                item.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 1);
            }

            BattleUnitModel target = RandomUtil.SelectOne(aliveList);
            Singleton<StageController>.Instance.AddAllCardListInBattle(card, target);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBlazing_Manifest : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Restore 6 Light; gain 10 Burn; fully recover Stagger Resist. Manifest the E.G.O of the Red Mist next Scene.";

        public override string[] Keywords => new string[2] { "Burn_Keyword", "Energy_Keyword" };

        public override void OnUseCard()
        {
            card.card.exhaust = true;
            base.owner.cardSlotDetail.RecoverPlayPointByCard(6);
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 10);
            base.owner.breakDetail.RecoverBreak(base.owner.breakDetail.GetDefaultBreakGauge());
            if (!base.owner.passiveDetail.HasPassive<PassiveAbility_250422>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_250422>())
            {
                base.owner.passiveDetail.AddPassive(new PassiveAbility_250422());
            }

            base.owner.personalEgoDetail.AddCard(new LorId(AphoMoreMists.PackageId, 7));
        }

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return !owner.bufListDetail.HasAssimilation() && base.OnChooseCard(owner);
        }
    }
    public class DiceCardAbility_Apho_MistBlazing_H : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 10 Burn";

        public override string[] Keywords => new string[1] { "Burn_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 10, base.owner);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBlazing_V : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[1] { "Burn_Keyword" };

        public override void OnSucceedAttack()
        {
            if (card.target == null)
            {
                return;
            }

            BattleUnitModel target = card.target;
            int targetSlotOrder = card.targetSlotOrder;
            List<BattlePlayingCardDataInUnitModel> list = new List<BattlePlayingCardDataInUnitModel>();
            for (int i = 0; i < target.cardSlotDetail.cardAry.Count; i++)
            {
                if (i != targetSlotOrder)
                {
                    BattlePlayingCardDataInUnitModel battlePlayingCardDataInUnitModel = target.cardSlotDetail.cardAry[i];
                    if (battlePlayingCardDataInUnitModel != null && !battlePlayingCardDataInUnitModel.isDestroyed && battlePlayingCardDataInUnitModel.GetDiceBehaviorList().Count > 0)
                    {
                        list.Add(battlePlayingCardDataInUnitModel);
                    }
                }
            }

            if (list.Count > 0)
            {
                RandomUtil.SelectOne(list).DestroyPlayingCard();
            }
        }
    }
    public class DiceCardSelfAbility_Apho_MistSmoke_Blunt : DiceCardSelfAbilityBase
    {
        public static string Name = "Blunt Brume";

        public static string Desc = "If 8 or more damage was dealt with this page, draw 1 page and reduce the Cost of all other 'Blunt Brume' by 1";

        private int _activateLine = 8;

        private int _totalDamage;

        public override string[] Keywords => new string[1] { "DrawCard_Keyword" };

        public override void OnUseCard()
        {
            _totalDamage = 0;
        }

        public override void AfterGiveDamage(int damage, BattleUnitModel target)
        {
            _totalDamage += damage;
        }

        public override void OnEndBattle()
        {
            if (_totalDamage >= _activateLine)
            {
                Activate();
            }
        }

        private void Activate()
        {
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 11)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            base.owner.allyCardDetail.DrawCards(1);
        }
    }
    public class DiceCardSelfAbility_Apho_MistSmoke_Pierce : DiceCardSelfAbilityBase
    {
        public static string Name = "Smoky Spear";

        public static string Desc = "If 8 or more damage was dealt with this page, draw 1 page and reduce the Cost of all other 'Smoky Spears' by 1";

        private int _activateLine = 8;

        private int _totalDamage;

        public override string[] Keywords => new string[1] { "DrawCard_Keyword" };

        public override void OnUseCard()
        {
            _totalDamage = 0;
        }

        public override void AfterGiveDamage(int damage, BattleUnitModel target)
        {
            _totalDamage += damage;
        }

        public override void OnEndBattle()
        {
            if (_totalDamage >= _activateLine)
            {
                Activate();
            }
        }

        private void Activate()
        {
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 12)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            base.owner.allyCardDetail.DrawCards(1);
        }
    }
    public class DiceCardSelfAbility_Apho_MistSmoke_Slash : DiceCardSelfAbilityBase
    {
        public static string Name = "Haze Slash";

        public static string Desc = "If 8 or more damage was dealt with this page, restore 2 Light and reduce the Cost of all other 'Haze Slashes' by 1";

        private int _activateLine = 8;

        private int _totalDamage;

        public override string[] Keywords => new string[1] { "Energy_Keyword" };

        public override void OnUseCard()
        {
            _totalDamage = 0;
        }

        public override void AfterGiveDamage(int damage, BattleUnitModel target)
        {
            _totalDamage += damage;
        }

        public override void OnEndBattle()
        {
            if (_totalDamage >= _activateLine)
            {
                Activate();
            }
        }

        private void Activate()
        {
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 13)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            base.owner.cardSlotDetail.RecoverPlayPointByCard(2);
        }
    }
    public class DiceCardSelfAbility_Apho_MistSmoke_Spirit : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Gain 4 Smoke";

        public override string[] Keywords => new string[2] { "Smoke_Keyword", "Strength_Keyword" };

        public override void OnUseCard()
        {
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Smoke, 4, base.owner);
        }
    }
    public class DiceCardSelfAbility_Apho_MistSmoke_Onrush : DiceCardSelfAbilityBase
    {
        public static string Desc = " If target is defeated or Staggered, give 1 Smoke to all allies, and use this page again on a random enemy.";

        private bool _isBreakedStart;

        public override string[] Keywords => new string[1] { "Smoke_Keyword" };

        public override void OnUseCard()
        {
            _isBreakedStart = false;
            if (card.target != null && card.target.IsBreakLifeZero())
            {
                _isBreakedStart = true;
            }
        }

        public override void OnEndBattle()
        {
            if (card.target == null || (!card.target.IsDead() && (_isBreakedStart || !card.target.IsBreakLifeZero())))
            {
                return;
            }

            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((base.owner.faction != Faction.Player) ? Faction.Player : Faction.Enemy);
            if (aliveList.Count <= 0)
            {
                return;
            }

            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(card.owner.faction))
            {
                alive.bufListDetail.AddKeywordBufByCard(KeywordBuf.Smoke, 1, base.owner);
            }

            BattleUnitModel target = RandomUtil.SelectOne(aliveList);
            Singleton<StageController>.Instance.AddAllCardListInBattle(card, target);
        }
    }
    public class DiceCardSelfAbility_Apho_MistSmoke_Manifest : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Restore 6 Light; gain 10 Smoke; fully recover Stagger Resist. Manifest the E.G.O of the Red Mist next Scene.";

        public override string[] Keywords => new string[2] { "Smoke_Keyword", "Energy_Keyword" };

        public override void OnUseCard()
        {
            card.card.exhaust = true;
            base.owner.cardSlotDetail.RecoverPlayPointByCard(6);
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Smoke, 10);
            base.owner.breakDetail.RecoverBreak(base.owner.breakDetail.GetDefaultBreakGauge());
            if (!base.owner.passiveDetail.HasPassive<PassiveAbility_250422>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_250422>())
            {
                base.owner.passiveDetail.AddPassive(new PassiveAbility_250422());
            }

            base.owner.personalEgoDetail.AddCard(new LorId(AphoMoreMists.PackageId, 17));
        }

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return !owner.bufListDetail.HasAssimilation() && base.OnChooseCard(owner);
        }
    }
    public class DiceCardAbility_Apho_MistSmoke_H : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 10 Smoke";

        public override string[] Keywords => new string[1] { "Smoke_Keyword" };

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Smoke, 10, base.owner);
        }
    }
    public class DiceCardSelfAbility_Apho_MistSmoke_V : DiceCardSelfAbilityBase
    {
        public override string[] Keywords => new string[1] { "Smoke_Keyword" };

        public override void OnSucceedAttack()
        {
            if (card.target == null)
            {
                return;
            }

            BattleUnitModel target = card.target;
            int targetSlotOrder = card.targetSlotOrder;
            List<BattlePlayingCardDataInUnitModel> list = new List<BattlePlayingCardDataInUnitModel>();
            for (int i = 0; i < target.cardSlotDetail.cardAry.Count; i++)
            {
                if (i != targetSlotOrder)
                {
                    BattlePlayingCardDataInUnitModel battlePlayingCardDataInUnitModel = target.cardSlotDetail.cardAry[i];
                    if (battlePlayingCardDataInUnitModel != null && !battlePlayingCardDataInUnitModel.isDestroyed && battlePlayingCardDataInUnitModel.GetDiceBehaviorList().Count > 0)
                    {
                        list.Add(battlePlayingCardDataInUnitModel);
                    }
                }
            }

            if (list.Count > 0)
            {
                RandomUtil.SelectOne(list).DestroyPlayingCard();
            }
        }
    }

}



