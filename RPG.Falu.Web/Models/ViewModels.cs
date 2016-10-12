using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Falu.Web.Models
{
    public class CharacterViewModel
    {
        public string Character { get; set; }
        public SpeciesTypes Species { get; set; }
        public CareerTypes Career { get; set; }
        public SpecializationTypes Specialization { get; set; }

        public GenderTypes Gender { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public string Build { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }

        public string NotableFeatures { get; set; }
        public string Background { get; set; }

        public int TotalXP { get; set; }
        public int AvailableXP { get; set; }

        public int Credits { get; set; }

        public Player Player { get; set; }

        public Status Status { get; set; }

        public List<Characteristic> Characteristics { get; set; }
        public List<Skill> Skills { get; set; }

        public Duty Duty { get; set; }

        public CharacterViewModel()
        {

        }

        public CharacterViewModel(int Id)
        {
            using (var context = new RpgModel())
            {
                var me = context.Characters.Find(Id);

                Character = $"{me.NameFirst} {me.NameLast}";
                Species = me.Species.Type;
                Career = me.Specialization.Career.Type;
                Specialization = me.Specialization.Type;

                Gender = me.Gender;
                Age = me.Age;
                Height = me.Height;
                Build = me.Build;
                Hair = me.Hair;
                Eyes = me.Eyes;

                NotableFeatures = me.NotableFeatures;
                Background = me.Background;

                Player = me.Player;
                Status = me.Status.OrderBy(o => o.CreatedOn).FirstOrDefault();

                Characteristics = me.Characteristics.ToList();

                Skills = context.Skills.Where(o => o.Characteristic.Character.CharacterId == me.CharacterId).ToList();

                TotalXP = me.TotalXP.OrderBy(o => o.CreatedOn).FirstOrDefault().Value;
                AvailableXP = me.AvailableXP.OrderBy(o => o.CreatedOn).FirstOrDefault().Value;

                Credits = me.Credits;

                Duty = me.Duty;
            }
        }
    }

    public class HomeViewModel
    {
        public Session LastSession { get; set; }

        public HomeViewModel()
        {
            using (var context = new RpgModel())
            {
                LastSession = context.Sessions.OrderByDescending(o => o.Date).FirstOrDefault();
            }
        }
    }
}
