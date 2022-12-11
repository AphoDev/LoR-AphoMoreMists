using System.Collections.Generic;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using UnityEngine;

namespace AphoMoreMists
{
    //PASSIVES
    public class PassiveAbility_Apho_MistBloody_Mythical : PassiveAbilityBase
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
                owner.personalEgoDetail.AddCard(new LorId(AphoMoreMists.PackageId, 28));
            }
        }

        public override void OnRoundStart()
        {
            UpdateResist();
            if (!_egoAwaken && owner.emotionDetail.EmotionLevel >= 4)
            {
                _egoAwaken = true;
                owner.allyCardDetail.AddNewCard(new LorId(AphoMoreMists.PackageId, 26));
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
    public class PassiveAbility_Apho_MistBloody_Succ : PassiveAbilityBase
    {
        public static string Name = "Bloodsucker";
        public static string Desc = "Recover 5 HP on a successful attack.";
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            this.owner.RecoverHP(5);
        }
    }
    public class PassiveAbility_Apho_MistBloody_TheBloodiest : PassiveAbilityBase
    {
        public static string Name = "The Bloodiest";
        public static string Desc = "At the start of the Scene, gain 4 Blood.";
        public override void OnWaveStart()
        {
            owner.bufListDetail.AddBuf(new BattleUnitBuf_Nosferatu_Emotion_Blood());
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            if (battleUnitBuf_Nosferatu_Emotion_Blood != null)
            {
                battleUnitBuf_Nosferatu_Emotion_Blood.Add(4);
            }
            if (owner.bufListDetail.GetActivatedBufList().FindAll(x => x is BattleUnitBuf_Nosferatu_Emotion_Blood).Count > 1)
            {
                List<BattleUnitBuf> list = owner.bufListDetail.GetActivatedBufList().FindAll(x => x is BattleUnitBuf_Nosferatu_Emotion_Blood);
                for (int i = 1; i < list.Count; i++)
                {
                    list[0].stack += list[i].stack;
                    owner.bufListDetail.RemoveBuf(list[i]);
                }
            }
        }
        public override void OnRoundEndTheLast()
        {
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            if (battleUnitBuf_Nosferatu_Emotion_Blood != null)
            {
                battleUnitBuf_Nosferatu_Emotion_Blood.Add(4);
            }
            if (owner.bufListDetail.GetActivatedBufList().FindAll(x => x is BattleUnitBuf_Nosferatu_Emotion_Blood).Count > 1)
            {
                List<BattleUnitBuf> list = owner.bufListDetail.GetActivatedBufList().FindAll(x => x is BattleUnitBuf_Nosferatu_Emotion_Blood);
                for (int i = 1; i < list.Count; i++)
                {
                    list[0].stack += list[i].stack;
                    owner.bufListDetail.RemoveBuf(list[i]);
                }
            }
        }
    }
    public class PassiveAbility_Apho_MistBloody_Prowess : PassiveAbilityBase
    {
        public static string Name = "Bloody Prowess";
        public static string Desc = "Dice Power +1 per 3 stacks of Blood (Max. 5)";
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            int num = Mathf.Min(battleUnitBuf_Nosferatu_Emotion_Blood.stack / 3, 5);
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
    public class DiceCardSelfAbility_Apho_MistBloody_Blunt : DiceCardSelfAbilityBase
    {
        public static string Name = "Downstanding Slash";
        public static string Desc = "If 8 or more damage was dealt with this page, draw 1 page, gain 1 Blood, and reduce the Cost of all other 'Downstanding Slashes' by 1";
        private int _activateLine = 8;
        private int _totalDamage;

        public override string[] Keywords => new string[2] { "DrawCard_Keyword", "Nosferatu_BloodHope" };

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
                BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
                if (battleUnitBuf_Nosferatu_Emotion_Blood == null)
                {
                    owner.bufListDetail.AddBuf(new BattleUnitBuf_Nosferatu_Emotion_Blood());
                }
                Activate();
            }
        }

        private void Activate()
        {
            //FIX FOR FOW
            BattleUnitBuf_Apho_FoWfix battleUnitBuf_Apho_FoWfix = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Apho_FoWfix) as BattleUnitBuf_Apho_FoWfix;
            if (battleUnitBuf_Apho_FoWfix == null)
            {
                owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_FoWfix());
            }
            //FIX FOR FOW END
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 21)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }
            base.owner.allyCardDetail.DrawCards(1);
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            battleUnitBuf_Nosferatu_Emotion_Blood.Add(1);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBloody_Pierce : DiceCardSelfAbilityBase
    {
        public static string Name = "Sanguine Spear";
        public static string Desc = "If 8 or more damage was dealt with this page, draw 1 page, gain 1 Blood, and reduce the Cost of all other 'Sanguine Spears' by 1";
        private int _activateLine = 8;
        private int _totalDamage;
        public override string[] Keywords => new string[2] { "DrawCard_Keyword", "Nosferatu_BloodHope" };

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
                BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
                if (battleUnitBuf_Nosferatu_Emotion_Blood == null)
                {
                    owner.bufListDetail.AddBuf(new BattleUnitBuf_Nosferatu_Emotion_Blood());
                }
                Activate();
            }
        }

        private void Activate()
        {
            //FIX FOR FOW
            BattleUnitBuf_Apho_FoWfix battleUnitBuf_Apho_FoWfix = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Apho_FoWfix) as BattleUnitBuf_Apho_FoWfix;
            if (battleUnitBuf_Apho_FoWfix == null )
            {
                owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_FoWfix());
            }
            //FIX FOR FOW END
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 22)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            base.owner.allyCardDetail.DrawCards(1);
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            battleUnitBuf_Nosferatu_Emotion_Blood.Add(1);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBloody_Slash : DiceCardSelfAbilityBase
    {
        public static string Name = "Level Laceration";
        public static string Desc = "If 8 or more damage was dealt with this page, restore 2 Light, gain 1 Blood, and reduce the Cost of all other 'Level Lacerations' by 1";
        private int _activateLine = 8;
        private int _totalDamage;
        public override string[] Keywords => new string[2] { "Energy_Keyword", "Nosferatu_BloodHope" };
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
                BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
                if (battleUnitBuf_Nosferatu_Emotion_Blood == null)
                {
                    owner.bufListDetail.AddBuf(new BattleUnitBuf_Nosferatu_Emotion_Blood());
                }
                Activate();
            }
        }

        private void Activate()
        {
            //FIX FOR FOW
            BattleUnitBuf_Apho_FoWfix battleUnitBuf_Apho_FoWfix = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Apho_FoWfix) as BattleUnitBuf_Apho_FoWfix;
            if (battleUnitBuf_Apho_FoWfix == null)
            {
                owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_FoWfix());
            }
            //FIX FOR FOW END
            foreach (BattleDiceCardModel item in base.owner.allyCardDetail.GetAllDeck().FindAll((BattleDiceCardModel x) => x != card.card && x.GetID() == new LorId(AphoMoreMists.PackageId, 23)))
            {
                item.GetBufList();
                item.AddCost(-1);
            }

            base.owner.cardSlotDetail.RecoverPlayPointByCard(2);
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            battleUnitBuf_Nosferatu_Emotion_Blood.Add(1);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBloody_Spirit : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Gain 2 Blood";
        public override string[] Keywords => new string[2] {"Nosferatu_BloodHope", "Strength_Keyword" };
        public override void OnStartBattle()
        {
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            if (battleUnitBuf_Nosferatu_Emotion_Blood == null)
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Nosferatu_Emotion_Blood());
            }
        }
        public override void OnUseCard()
        {
            //FIX FOR FOW
            BattleUnitBuf_Apho_FoWfix battleUnitBuf_Apho_FoWfix = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Apho_FoWfix) as BattleUnitBuf_Apho_FoWfix;
            if (battleUnitBuf_Apho_FoWfix == null)
            {
                owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_FoWfix());
            }
            //FIX FOR FOW END
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            if (battleUnitBuf_Nosferatu_Emotion_Blood == null)
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Nosferatu_Emotion_Blood());
            }
            battleUnitBuf_Nosferatu_Emotion_Blood.Add(2);
        }
    }
    public class DiceCardAbility_Apho_MistBloody_Spirit_pw : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Gain 1 Blood";
        public override void OnWinParrying()
        {
            BattleUnitModel owner = base.owner;
            if (owner == null)
            {
                return;
            }
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            if (battleUnitBuf_Nosferatu_Emotion_Blood == null)
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Nosferatu_Emotion_Blood());
            }
            battleUnitBuf_Nosferatu_Emotion_Blood.Add(1);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBloody_Onrush : DiceCardSelfAbilityBase
    {
        public static string Desc = " If target is defeated or Staggered, gain 1 Blood, and use this page again on a random enemy.";
        private bool _isBreakedStart;
        public override string[] Keywords => new string[1] { "Nosferatu_BloodHope" };
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
            BattleUnitModel target = RandomUtil.SelectOne(aliveList);
            Singleton<StageController>.Instance.AddAllCardListInBattle(card, target);
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            if (battleUnitBuf_Nosferatu_Emotion_Blood == null)
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_Nosferatu_Emotion_Blood());
            }
            battleUnitBuf_Nosferatu_Emotion_Blood.Add(1);
            //FIX FOR FOW
            BattleUnitBuf_Apho_FoWfix battleUnitBuf_Apho_FoWfix = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Apho_FoWfix) as BattleUnitBuf_Apho_FoWfix;
            if (battleUnitBuf_Apho_FoWfix == null)
            {
                owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_FoWfix());
            }
            //FIX FOR FOW END
        }
    }
    public class DiceCardSelfAbility_Apho_MistBloody_Manifest : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] Restore 6 Light; recover 1 HP per stack of Blood; fully recover Stagger Resist. Manifest the E.G.O of the Red Mist next Scene.";
        public override string[] Keywords => new string[2] { "Nosferatu_BloodHope", "Energy_Keyword" };

        public override void OnUseCard()
        {
            card.card.exhaust = true;
            base.owner.cardSlotDetail.RecoverPlayPointByCard(6);
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            base.owner.RecoverHP(battleUnitBuf_Nosferatu_Emotion_Blood.stack);
            base.owner.breakDetail.RecoverBreak(base.owner.breakDetail.GetDefaultBreakGauge());
            if (!base.owner.passiveDetail.HasPassive<PassiveAbility_250422>() && !base.owner.passiveDetail.HasPassiveInReady<PassiveAbility_250422>())
            {
                base.owner.passiveDetail.AddPassive(new PassiveAbility_250422());
            }

            base.owner.personalEgoDetail.AddCard(new LorId(AphoMoreMists.PackageId, 27));
        }

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return !owner.bufListDetail.HasAssimilation() && base.OnChooseCard(owner);
        }
    }
    public class DiceCardAbility_Apho_MistBloody_Manifest_pw : DiceCardAbilityBase
    {
        public static string Desc = "[On Clash Win] Recover user's HP by the natural roll value.";
        public override void OnWinParrying()
        {
            BattleUnitModel owner = base.owner;
            if (owner == null)
            {
                return;
            }
            owner.RecoverHP(this.behavior.DiceVanillaValue);
        }
    }
    public class DiceCardSelfAbility_Apho_MistBloody_H : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Hit] Recover HP equal to half the damage dealt";
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            int recovery = behavior.DiceResultDamage / 2;
            if (recovery > 0)
            {
                base.owner.RecoverHP(recovery);
            }
        }
    }
    public class DiceCardAbility_Apho_MistBloody_V : DiceCardAbilityBase
    {
        public override string[] Keywords => new string[2] { "bstart_Keyword", "Nosferatu_BloodHope" };
        public static string Desc = "[Combat Start] Gain max Blood this Scene and next Scene.\n[On Hit] Destroy a Combat Page set on another random Speed die of the target.";
    }
    public class DiceCardSelfAbility_Apho_MistBloody_V : DiceCardSelfAbilityBase
    {
        public override void OnStartBattle()
        {
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            if (battleUnitBuf_Nosferatu_Emotion_Blood != null)
            {
                battleUnitBuf_Nosferatu_Emotion_Blood.StackToMax();
            }
        }
        public override void OnEndBattle()
        {
            owner.bufListDetail.AddBuf(new BattleUnitBuf_Apho_MistBloody_V());
        }
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
    public class BattleUnitBuf_Apho_MistBloody_V : BattleUnitBuf
    {
        public override void OnRoundEndTheLast()
        {
            BattleUnitBuf_Nosferatu_Emotion_Blood battleUnitBuf_Nosferatu_Emotion_Blood = this._owner.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Nosferatu_Emotion_Blood) as BattleUnitBuf_Nosferatu_Emotion_Blood;
            if (battleUnitBuf_Nosferatu_Emotion_Blood != null)
            {
                battleUnitBuf_Nosferatu_Emotion_Blood.StackToMax();
            }
            this._owner.bufListDetail.RemoveBuf(this);
        }
    }
    //FIX FOR FOW
    public class BattleUnitBuf_Apho_FoWfix : BattleUnitBuf
    {
        public override void OnRoundStart()
        {
            if (this._owner.bufListDetail.GetActivatedBufList().FindAll(x => x is BattleUnitBuf_Nosferatu_Emotion_Blood).Count > 1)
            {
                List<BattleUnitBuf> list = this._owner.bufListDetail.GetActivatedBufList().FindAll(x => x is BattleUnitBuf_Nosferatu_Emotion_Blood);
                for (int i = 1; i < list.Count; i++)
                {
                    list[0].stack += list[i].stack;
                    this._owner.bufListDetail.RemoveBuf(list[i]);
                }
            }
        }
    }
}