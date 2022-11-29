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
                new SpriteOptions(SpriteEnum.Custom, 10000001, "Icon"),
                new SpriteOptions(SpriteEnum.Custom, 10000002, "Icon"),
                new SpriteOptions(SpriteEnum.Custom, 10000003, "Icon")
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(AphoMoreMists.PackageId, new List<KeypageOptions>
            {
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

}



