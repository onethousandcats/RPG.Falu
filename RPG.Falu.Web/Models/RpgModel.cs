using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPG.Falu.Web.Models
{
    public abstract class DbItem
    {
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }

    public enum GenderTypes { Male, Female, Trans, Other }

    public class Character : DbItem
    {
        public int CharacterId { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }

        public GenderTypes Gender { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public string Build { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }

        public string NotableFeatures { get; set; }
        public string Background { get; set; }

        public virtual ICollection<XP> TotalXP { get; set; }
        public virtual ICollection<XP> AvailableXP { get; set; }

        public int Credits { get; set; }

        public virtual Species Species { get; set; }
        public virtual ICollection<Status> Status { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<Characteristic> Characteristics { get; set; }

        public virtual Duty Duty { get; set; }

        public virtual Player Player { get; set; }
    }
    
    public class Player : DbItem
    {
        public int PlayerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Character> Character { get; set; }
    }

    public class XP : DbItem
    {
        public int XPId { get; set; }
        public int Value { get; set; }
    }

    public enum DutyTypes {[Display(Name = "Combat Victory")]CombatVictory, [Display(Name = "Counter-Intelligence")]CounterIntelligence, Intelligence, [Display(Name = "Internal Security")]InternalSecurity, Personnel, [Display(Name = "Political Support")]PoliticalSupport, Recruiting, [Display(Name = "Resource Acquisition")]ResourceAcquisition, Sabotage, [Display(Name = "Space Superiority")]SpaceSuperiority, [Display(Name = "Tech Procurement")]TechProcurement, Support };

    public class Duty : DbItem
    {
        public int DutyId { get; set; }

        public DutyTypes Type { get; set; }
        public string Description { get; set; }

        public int Magnitude { get; set; }

    }

    public enum SpeciesTypes { Bothan, Droid, Gand, Human, Rodian, Trandoshian, [Display(Name = "Twi'lek")]Twilek, Wookie, Duros, Gran, Ithorian, [Display(Name = "Mon Calamari")]MonCalamari, Sollustan };

    public class Species : DbItem
    {
        public int SpeciesId { get; set; }

        public SpeciesTypes Type { get; set; }
    }

    public enum CareerTypes { Ace, Commander, Diplomat, Engineer, Soldier, Spy, Universal }

    public class Career : DbItem
    {
        public int CareerId { get; set; }
        public CareerTypes Type { get; set; }

        public virtual ICollection<Specialization> Specializations { get; set; }
    }

    public enum SpecializationTypes { Driver, Gunner, Pilot, [Display(Name = "Beast Rider")]BeastRider, Hotshot, Rigger, Commodore, [Display(Name = "Squadron Leader")]SquadronLeader, Tactician, Figurehead, Instructor, Strategist, Agitator, Ambassador, Quartermaster, Advocate, Analyst, Propagandist, Mechanic, Saboteur, Scientist, Commando, Medic, Sharpshooter, Heavy, Trailblazer, Vanguard, Scout, Slicer, Infiltrator, [Display(Name = "Force Sensitive Emergent")]ForceSensitiveEmergent, Recruit };

    public class Specialization : DbItem
    {
        public int SpecializationId { get; set; }
        public SpecializationTypes Type { get; set; }
        
        public virtual Career Career { get; set; }
    }

    public class Status : DbItem
    {
        public int StatusId { get; set; }

        public int Soak { get; set; }
        public int WoundsThresh { get; set; }
        public int WoundsCurrent { get; set; }
        public int StrainThresh { get; set; }
        public int StrainCurrent { get; set; }
        public int DefenseRanged { get; set; }
        public int DefenseMelee { get; set; }
    }

    public enum CharacteristicTypes { Brawn, Agility, Intellect, Cunning, Willpower, Presence };

    public class Characteristic : DbItem
    {
        public int CharacteristicId { get; set; }

        public CharacteristicTypes Type { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual Character Character { get; set; }

    }

    public enum SkillClassTypes { General, Combat, Knowledge, Custom }
    public enum SkillTypes { Astrogation, Athletics, Charm, Coercion, Computers, Cool, Coordination, Deception, Discipline, Leadership, Mechanics, Medicine, Negotiation, Perception, [Display(Name="Piloting Planetary")]PilotingPlanetary, [Display(Name = "Piloting Space")]PilotingSpace, Resilience, Skulduggery, Stealth, Streetwise, Survival, Vigilance, Brawl, Gunnery, Melee, [Display(Name = "Ranged Light")]RangedLight, [Display(Name = "Ranged Heavy")]RangedHeavy, [Display(Name = "Core Worlds")]CoreWorlds, Education, Lore, [Display(Name = "Outer Rim")]OuterRim, Underworld, Warfare, Xenology, Other }

    public class Skill : DbItem
    {
        public int SkillId { get; set; }

        public SkillTypes Type { get; set; }

        public SkillClassTypes Class { get; set; }

        public int Rank { get; set; }
        public bool Career { get; set; }

        public virtual Characteristic Characteristic { get; set; }
    }

    #region Session Information

    public class Session : DbItem
    {
        public int SessionId { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }

    #endregion

    public partial class RpgModel : DbContext
    {
        public RpgModel() : base("name=RpgEntities")
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Species> Species { get; set; }

        public DbSet<Career> Careers { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<XP> XPs { get; set; }
        public DbSet<Duty> Duties { get; set; }

        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var nt = HttpContext.Current == null ? "Shai'hulud" : HttpContext.Current.User.Identity.Name;

            var changes = GetAuditLogData();

            var changedEntries = ChangeTracker.Entries<DbItem>();

            var now = DateTime.Now;

            if (changedEntries != null)
            {
                foreach (var ce in changedEntries)
                {
                    if (ce.State == EntityState.Added)
                    {
                        ce.Entity.CreatedOn = now;
                        ce.Entity.CreatedBy = nt;
                    }

                    ce.Entity.ModifiedOn = now;
                    ce.Entity.ModifiedBy = nt;
                }
            }

            return base.SaveChanges();
        }

        public class AuditLog
        {
            public string State { get; set; }
            public string TableName { get; set; }
            public string RecordID { get; set; }
            public string ColumnName { get; set; }
            public string NewValue { get; set; }
            public string OriginalValue { get; set; }
        }

        public List<AuditLog> GetAuditLogData()
        {
            List<AuditLog> AuditLogs = new List<AuditLog>();
            var changeTrack = ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified);
            foreach (var entry in changeTrack)
            {
                if (entry.Entity != null)
                {
                    string entityName = string.Empty;
                    string state = string.Empty;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
                            state = entry.State.ToString();
                            foreach (string prop in entry.OriginalValues.PropertyNames)
                            {
                                object currentValue = entry.CurrentValues[prop];
                                object originalValue = entry.OriginalValues[prop];
                                if (!(currentValue == null && originalValue == null))
                                {
                                    if (currentValue == null && originalValue != null || originalValue == null && currentValue != null || !currentValue.Equals(originalValue))
                                    {
                                        AuditLogs.Add(new AuditLog
                                        {
                                            TableName = entityName,
                                            State = state,
                                            ColumnName = prop,
                                            OriginalValue = Convert.ToString(originalValue),
                                            NewValue = Convert.ToString(currentValue),
                                        });
                                    }
                                }

                            }
                            break;
                        case EntityState.Added:
                            entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
                            state = entry.State.ToString();
                            foreach (string prop in entry.CurrentValues.PropertyNames)
                            {
                                AuditLogs.Add(new AuditLog
                                {
                                    TableName = entityName,
                                    State = state,
                                    ColumnName = prop,
                                    OriginalValue = string.Empty,
                                    NewValue = Convert.ToString(entry.CurrentValues[prop]),
                                });

                            }
                            break;
                        case EntityState.Deleted:
                            entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
                            state = entry.State.ToString();
                            foreach (string prop in entry.OriginalValues.PropertyNames)
                            {
                                AuditLogs.Add(new AuditLog
                                {
                                    TableName = entityName,
                                    State = state,
                                    ColumnName = prop,
                                    OriginalValue = Convert.ToString(entry.OriginalValues[prop]),
                                    NewValue = string.Empty,
                                });

                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return AuditLogs;
        }
    }
}
