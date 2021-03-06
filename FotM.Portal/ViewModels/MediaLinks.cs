﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FotM.Domain;

namespace FotM.Portal.ViewModels
{
    public static class MediaLinks // TODO: inject per region/locale
    {
        public static string RaceImageLink(Race race, Gender gender)
        {
            return RaceImageLink((int) race, (int) gender);
        }

        public static string RaceImageLink(int raceId, int genderId)
        {
                return string.Format("http://media.blizzard.com/wow/icons/18/race_{0}_{1}.jpg",
                    raceId, genderId);
        }

        public static string ClassImageLink(CharacterClass charClass)
        {
            return ClassImageLink((int) charClass);
        }

        public static string ClassImageLink(int classId)
        {
            return string.Format("http://media.blizzard.com/wow/icons/18/class_{0}.jpg", classId);
        }

        public static string SpecImageLink(int specId)
        {
            return SpecImageLink((CharacterSpec) specId);
        }

        public static string SpecImageLink(CharacterSpec spec)
        {
            switch (spec)
            {
                    // TODO: Add warr fury
                case CharacterSpec.Warrior_Arms:
                    return "http://media.blizzard.com/wow/icons/18/ability_warrior_savageblow.jpg";
                case CharacterSpec.Warrior_Protection:
                    return "http://media.blizzard.com/wow/icons/18/ability_warrior_defensivestance.jpg";
                case CharacterSpec.Warrior_Fury:
                    return "http://media.blizzard.com/wow/icons/18/ability_warrior_savageblow.jpg";

                    // TODO: update druid guardian
                case CharacterSpec.Druid_Balance:
                    return "http://media.blizzard.com/wow/icons/18/spell_nature_starfall.jpg";
                case CharacterSpec.Druid_Feral:
                    return "http://media.blizzard.com/wow/icons/18/ability_druid_catform.jpg";
                case CharacterSpec.Druid_Guardian:
                    return "http://media.blizzard.com/wow/icons/18/ability_druid_catform.jpg";
                case CharacterSpec.Druid_Restoration:
                    return "http://media.blizzard.com/wow/icons/18/spell_nature_healingtouch.jpg";

                case CharacterSpec.Priest_Discipline:
                    return "http://media.blizzard.com/wow/icons/18/spell_holy_powerwordshield.jpg";
                case CharacterSpec.Priest_Holy:
                    return "http://media.blizzard.com/wow/icons/18/spell_holy_guardianspirit.jpg";
                case CharacterSpec.Priest_Shadow:
                    return "http://media.blizzard.com/wow/icons/18/spell_shadow_shadowwordpain.jpg";

                case CharacterSpec.Mage_Arcane:
                    return "http://media.blizzard.com/wow/icons/18/spell_holy_magicalsentry.jpg";
                case CharacterSpec.Mage_Fire:
                    return "http://media.blizzard.com/wow/icons/18/spell_fire_firebolt02.jpg";
                case CharacterSpec.Mage_Frost:
                    return "http://media.blizzard.com/wow/icons/18/spell_frost_frostbolt02.jpg";

                case CharacterSpec.Monk_Brewmaster:
                    return "http://media.blizzard.com/wow/icons/18/spell_monk_brewmaster_spec.jpg";
                case CharacterSpec.Monk_Mistweaver:
                    return "http://media.blizzard.com/wow/icons/18/spell_monk_mistweaver_spec.jpg";
                case CharacterSpec.Monk_Windwalker:
                    return "http://media.blizzard.com/wow/icons/18/spell_monk_windwalker_spec.jpg";

                case CharacterSpec.Hunter_BeastMastery:
                    return "http://media.blizzard.com/wow/icons/18/ability_hunter_bestialdiscipline.jpg";
                case CharacterSpec.Hunter_Marksmanship:
                    return "http://media.blizzard.com/wow/icons/18/ability_hunter_focusedaim.jpg";
                case CharacterSpec.Hunter_Survival:
                    return "http://media.blizzard.com/wow/icons/18/ability_hunter_camouflage.jpg";

                    // TODO: update paladin protection
                case CharacterSpec.Paladin_Holy:
                    return "http://media.blizzard.com/wow/icons/18/spell_holy_holybolt.jpg";
                case CharacterSpec.Paladin_Retribution:
                    return "http://media.blizzard.com/wow/icons/18/spell_holy_auraoflight.jpg";
                case CharacterSpec.Paladin_Protection:
                    return "http://media.blizzard.com/wow/icons/18/spell_holy_auraoflight.jpg";


                case CharacterSpec.Rogue_Assassination:
                    return "http://media.blizzard.com/wow/icons/18/ability_rogue_eviscerate.jpg";
                case CharacterSpec.Rogue_Combat:
                    return "http://media.blizzard.com/wow/icons/18/ability_backstab.jpg";
                case CharacterSpec.Rogue_Subtlety:
                    return "http://media.blizzard.com/wow/icons/18/ability_stealth.jpg";

                case CharacterSpec.Shaman_Elemental:
                    return "http://media.blizzard.com/wow/icons/18/spell_nature_lightning.jpg";
                case CharacterSpec.Shaman_Enhancement:
                    return "http://media.blizzard.com/wow/icons/18/spell_shaman_improvedstormstrike.jpg";
                case CharacterSpec.Shaman_Restoration:
                    return "http://media.blizzard.com/wow/icons/18/spell_nature_magicimmunity.jpg";

                case CharacterSpec.Warlock_Affliction:
                    return "http://media.blizzard.com/wow/icons/18/spell_shadow_deathcoil.jpg";
                case CharacterSpec.Warlock_Demonology:
                    return "http://media.blizzard.com/wow/icons/18/spell_shadow_metamorphosis.jpg";
                case CharacterSpec.Warlock_Destruction:
                    return "http://media.blizzard.com/wow/icons/18/spell_shadow_rainoffire.jpg";

                case CharacterSpec.DeathKnight_Blood:
                    return "http://media.blizzard.com/wow/icons/18/spell_deathknight_bloodpresence.jpg";
                case CharacterSpec.DeathKnight_Frost:
                    return "http://media.blizzard.com/wow/icons/18/spell_deathknight_frostpresence.jpg";
                case CharacterSpec.DeathKnight_Unholy:
                    return "http://media.blizzard.com/wow/icons/18/spell_deathknight_unholypresence.jpg";

                default:
                    throw new NotImplementedException();
            }
        }

        public static string FactionImageLink(int factionId)
        {
            return string.Format("http://media.blizzard.com/wow/icons/18/faction_{0}.jpg", factionId);
        }

        public static string FactionImageLink(Faction faction)
        {
            return FactionImageLink((int) faction);
        }
    }
}