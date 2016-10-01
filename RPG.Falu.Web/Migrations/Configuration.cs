using RPG.Falu.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RPG.Falu.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RpgModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RpgModel context)
        {
            var species = new List<Species>();
            species.Add(new Species { Type = SpeciesTypes.Human });
            species.Add(new Species { Type = SpeciesTypes.MonCalamari });
            context.Species.AddOrUpdate(x => x.Type, species.ToArray());

            var careers = new List<Career>();
            careers.Add(new Career { Type = CareerTypes.Spy });
            careers.Add(new Career { Type = CareerTypes.Engineer });
            context.Careers.AddOrUpdate(x => x.Type, careers.ToArray());

            context.SaveChanges();

            var specializations = new List<Specialization>();
            // spy section
            var spy = context.Careers.SingleOrDefault(o => o.Type == CareerTypes.Spy);
            specializations.Add(new Specialization { Type = SpecializationTypes.Infiltrator, Career = spy });

            //engineer section 
            var engineer = context.Careers.SingleOrDefault(o => o.Type == CareerTypes.Engineer);
            specializations.Add(new Specialization { Type = SpecializationTypes.Scientist, Career = engineer });

            context.Specializations.AddOrUpdate(x => x.Type, specializations.ToArray());

            var players = new List<Player>();

            players.Add(new Player
            {
                Name = "Phillip",
                Email = "phillip.bercot@gmail.com"
            });

            players.Add(new Player
            {
                Name = "Nathan",
                Email = "nathanandrewbell@gmail.com"
            });

            context.Players.AddOrUpdate(x => x.Name, players.ToArray());

            context.SaveChanges();

            var player = context.Players.SingleOrDefault(o => o.Name == "Phillip");
            var mySpecies = context.Species.SingleOrDefault(o => o.Type == SpeciesTypes.Human);
            var mySpecialization = context.Specializations.SingleOrDefault(o => o.Type == SpecializationTypes.Infiltrator);
            var status = new Status { Soak = 4, WoundsThresh = 12, WoundsCurrent = 0, StrainThresh = 12, StrainCurrent = 0, DefenseRanged = 0, DefenseMelee = 0 };
            var duty = new Duty { Type = DutyTypes.CounterIntelligence, Description = "The PC knows that the survival of the Alliance depends upon its ability to hide from the Empire and avoid complete destruction at the hands of its overwhelming military superiority. To this end, he wants to hunt down and eliminate enemy agents and threats,  feed false information to Imperial intelligence networks, and cover the movements of all Alliance assets from observation and reporting.", Magnitude = 12 };

            var statusList = new List<Status>();
            statusList.Add(status);

            var axpList = new List<XP>();
            axpList.Add(new XP { Value = 24 });

            var txpList = new List<XP>();
            txpList.Add(new XP { Value = 129 });

            context.Characters.AddOrUpdate(x => x.NameFirst, new Character
            {
                NameFirst = "T'aryn",
                NameLast = "Mallus",
                Player = player,
                Gender = GenderTypes.Female,
                Age = 29,
                Height = 1.7,
                Build = "Medium",
                Hair = "Brown",
                Eyes = "Green",
                Species = mySpecies,
                Specialization = mySpecialization,
                Status = statusList,
                AvailableXP = axpList,
                TotalXP = txpList,
                Duty = duty,
                Credits = 275
            });

            context.SaveChanges();

            var taryn = context.Characters.SingleOrDefault(o => o.NameLast == "Mallus");

            if (taryn.Characteristics == null || !taryn.Characteristics.Any())
            {
                var characteristics = new List<Characteristic>();
                characteristics.Add(new Characteristic { Type = CharacteristicTypes.Brawn, Value = 2, Character = taryn });
                characteristics.Add(new Characteristic { Type = CharacteristicTypes.Agility, Value = 3, Character = taryn });
                characteristics.Add(new Characteristic { Type = CharacteristicTypes.Intellect, Value = 2, Character = taryn });
                characteristics.Add(new Characteristic { Type = CharacteristicTypes.Cunning, Value = 3, Character = taryn });
                characteristics.Add(new Characteristic { Type = CharacteristicTypes.Willpower, Value = 2, Character = taryn });
                characteristics.Add(new Characteristic { Type = CharacteristicTypes.Presence, Value = 2, Character = taryn });

                context.Characteristics.AddOrUpdate(x => x.CharacteristicId, characteristics.ToArray());
            }

            var nate = context.Players.SingleOrDefault(o => o.Name == "Nathan");
            var nateSpecies = context.Species.SingleOrDefault(o => o.Type == SpeciesTypes.MonCalamari);
            var nateSpecialization = context.Specializations.SingleOrDefault(o => o.Type == SpecializationTypes.Scientist);
            var nateStatus = new Status { Soak = 2, WoundsThresh = 12, WoundsCurrent = 0, StrainThresh = 12, StrainCurrent = 0, DefenseRanged = 0, DefenseMelee = 0 };
            var nateDuty = new Duty { Type = DutyTypes.TechProcurement, Description = "There is no more prolific or productive time for technological developments than during a war, and this one is no exception.This Player Character sees the true opportunity for Alliance victory in the hands of scientists, engineers, and technicians.Not only can they get the most performance from existing machines and resources, but they can design and develop new ships, weapons, medical techniques, and equipment that can provide the vital edge necessary to survive against the Empire’s might.The way this PC sees it, stealing the best developments of the Empire is a crucial way to even the odds.", Magnitude = 0 };

            var nateStatusList = new List<Status>();
            nateStatusList.Add(nateStatus);

            var nAxpList = new List<XP>();
            nAxpList.Add(new XP { Value = 24 });

            var nTxpList = new List<XP>();
            nTxpList.Add(new XP { Value = 129 });

            context.Characters.AddOrUpdate(x => x.NameFirst, new Character
            {
                NameFirst = "Chookk",
                NameLast = "Penadir",
                Player = nate,
                Gender = GenderTypes.Male,
                Age = 40,
                Height = 2.2,
                Build = "Medium",
                Hair = "None",
                Eyes = "Yellow",
                Species = nateSpecies,
                Specialization = nateSpecialization,
                Status = nateStatusList,
                AvailableXP = nAxpList,
                TotalXP = nTxpList,
                Duty = nateDuty,
                Credits = 185
            });

            context.SaveChanges();

            var chookk = context.Characters.SingleOrDefault(o => o.NameLast == "Penadir");

            if (chookk.Characteristics == null || !chookk.Characteristics.Any())
            {
                var nateCharacteristics = new List<Characteristic>();
                nateCharacteristics.Add(new Characteristic { Type = CharacteristicTypes.Brawn, Value = 2, Character = chookk });
                nateCharacteristics.Add(new Characteristic { Type = CharacteristicTypes.Agility, Value = 4, Character = chookk });
                nateCharacteristics.Add(new Characteristic { Type = CharacteristicTypes.Intellect, Value = 4, Character = chookk });
                nateCharacteristics.Add(new Characteristic { Type = CharacteristicTypes.Cunning, Value = 1, Character = chookk });
                nateCharacteristics.Add(new Characteristic { Type = CharacteristicTypes.Willpower, Value = 2, Character = chookk });
                nateCharacteristics.Add(new Characteristic { Type = CharacteristicTypes.Presence, Value = 2, Character = chookk });

                context.Characteristics.AddOrUpdate(x => x.CharacteristicId, nateCharacteristics.ToArray());

                context.SaveChanges();
            }

            #region Skills

            var skills = new List<Skill>();

            var tc = taryn.Characteristics;
            var b = tc.SingleOrDefault(o => o.Type == CharacteristicTypes.Brawn);
            var a = tc.SingleOrDefault(o => o.Type == CharacteristicTypes.Agility);
            var i = tc.SingleOrDefault(o => o.Type == CharacteristicTypes.Intellect);
            var c = tc.SingleOrDefault(o => o.Type == CharacteristicTypes.Cunning);
            var w = tc.SingleOrDefault(o => o.Type == CharacteristicTypes.Willpower);
            var p = tc.SingleOrDefault(o => o.Type == CharacteristicTypes.Presence);

            skills.Add(new Skill { Type = SkillTypes.Astrogation, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Athletics, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = b });
            skills.Add(new Skill { Type = SkillTypes.Charm, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = p });
            skills.Add(new Skill { Type = SkillTypes.Coercion, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = w });
            skills.Add(new Skill { Type = SkillTypes.Computers, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Cool, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = p });
            skills.Add(new Skill { Type = SkillTypes.Coordination, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.Deception, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.Discipline, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = w });
            skills.Add(new Skill { Type = SkillTypes.Leadership, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = p });
            skills.Add(new Skill { Type = SkillTypes.Mechanics, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Medicine, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Negotiation, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = p });
            skills.Add(new Skill { Type = SkillTypes.Perception, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.PilotingPlanetary, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.PilotingSpace, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.Resilience, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = b });
            skills.Add(new Skill { Type = SkillTypes.Skulduggery, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.Stealth, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.Streetwise, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.Survival, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.Vigilance, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = w });

            skills.Add(new Skill { Type = SkillTypes.Brawl, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = b });
            skills.Add(new Skill { Type = SkillTypes.Gunnery, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.Melee, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = b });
            skills.Add(new Skill { Type = SkillTypes.RangedLight, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.RangedHeavy, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = a });

            skills.Add(new Skill { Type = SkillTypes.CoreWorlds, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Education, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Lore, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.OuterRim, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Underworld, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Warfare, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Xenology, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });

            context.Skills.AddRange(skills.ToArray());

            skills = new List<Skill>();

            var cc = chookk.Characteristics;
            b = cc.SingleOrDefault(o => o.Type == CharacteristicTypes.Brawn);
            a = cc.SingleOrDefault(o => o.Type == CharacteristicTypes.Agility);
            i = cc.SingleOrDefault(o => o.Type == CharacteristicTypes.Intellect);
            c = cc.SingleOrDefault(o => o.Type == CharacteristicTypes.Cunning);
            w = cc.SingleOrDefault(o => o.Type == CharacteristicTypes.Willpower);
            p = cc.SingleOrDefault(o => o.Type == CharacteristicTypes.Presence);

            skills.Add(new Skill { Type = SkillTypes.Astrogation, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Athletics, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = b });
            skills.Add(new Skill { Type = SkillTypes.Charm, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = p });
            skills.Add(new Skill { Type = SkillTypes.Coercion, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = w });
            skills.Add(new Skill { Type = SkillTypes.Computers, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Cool, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = p });
            skills.Add(new Skill { Type = SkillTypes.Coordination, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.Deception, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.Discipline, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = w });
            skills.Add(new Skill { Type = SkillTypes.Leadership, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = p });
            skills.Add(new Skill { Type = SkillTypes.Mechanics, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Medicine, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Negotiation, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = p });
            skills.Add(new Skill { Type = SkillTypes.Perception, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.PilotingPlanetary, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.PilotingSpace, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.Resilience, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = b });
            skills.Add(new Skill { Type = SkillTypes.Skulduggery, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.Stealth, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.Streetwise, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.Survival, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = c });
            skills.Add(new Skill { Type = SkillTypes.Vigilance, Career = false, Rank = 0, Class = SkillClassTypes.General, Characteristic = w });

            skills.Add(new Skill { Type = SkillTypes.Brawl, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = b });
            skills.Add(new Skill { Type = SkillTypes.Gunnery, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.Melee, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = b });
            skills.Add(new Skill { Type = SkillTypes.RangedLight, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = a });
            skills.Add(new Skill { Type = SkillTypes.RangedHeavy, Career = false, Rank = 0, Class = SkillClassTypes.Combat, Characteristic = a });

            skills.Add(new Skill { Type = SkillTypes.CoreWorlds, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Education, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Lore, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.OuterRim, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Underworld, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Warfare, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });
            skills.Add(new Skill { Type = SkillTypes.Xenology, Career = false, Rank = 0, Class = SkillClassTypes.Knowledge, Characteristic = i });

            context.Skills.AddRange(skills.ToArray());

            #endregion

            #region Sessions

            context.Sessions.AddOrUpdate(o => o.Date, new Session { Date = new DateTime(2016, 09, 26), Notes = "LOCATIONS WITHIN FALU Dak's House: Any and all items retrieved from ambushes are stored in a back room in Dak's residence.Last Ambush Site: A narrow roadway at the very southern edge of town which is lined with long abandoned  apartment buildings.The PCs left the four Stormtroopers and two agents unconscious, unarmored, and unarmed. Mannie's Tech-o-Rama: A vendor that sells, repairs, and services mainstream tech devices. Slicer's Paradise: A vendor that specializes in repairing and servicing tech devices. Lester's Place: An underground/back alley 'shop' run by Lester Orhand. Lectronfire Residence: The modest home of the Lectronfire family.Dressed as Stormtroopers the PCs managed to scare the living hell out of Whaymel and his wife when trying to determine why his name was on the list retrieved on the Data Pad. Shipburn Residence: The home of Baksed Shipburn.PCs decided it was better not to actually visit the residence after remembering that he is a staunch supporter of The Emipre.This is where the first session left off. Mucecud Residence: The apartment of FSF officer Mirach Mucecud. GTG Heavy Industries: Grewhit Gen's place of business. PCs broke into the place and hacked into Grewhit's computer." });

            #endregion

        }
    }
}
