using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RPG.Falu.Web.Models
{
    public sealed class Rpg
    {
        private RpgModel context;

        private static readonly Rpg _instance = new Rpg();

        public static Rpg Instance { get { return _instance;  } }

        private Rpg()
        {
            if (context == null) context = new RpgModel();
        }

        #region Properties

        public List<SelectListItem> CharactersDdl { get
            {
                return context.Characters.Select(x => new SelectListItem { Text = x.NameFirst + " " + x.NameLast + " (" + x.Player.Name + ")", Value = x.CharacterId.ToString() }).ToList();
            }
        }

        internal void Add(Session s)
        {
            context.Sessions.Add(s);
            context.SaveChanges();
        }

        internal void Update(Session s)
        {
            var old = context.Sessions.Find(s.SessionId);

            old.Date = s.Date;
            old.Notes = s.Notes;

            context.SaveChanges();
        }

        internal void RemoveSession(int Id)
        {
            var session = context.Sessions.Find(Id);

            context.Sessions.Remove(session);
            context.SaveChanges();
        }

        #endregion

        #region Methods

        #endregion

    }
}
