//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diablo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public Game()
        {
            this.UsersGames = new HashSet<UsersGame>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<int> Duration { get; set; }
        public int GameTypeId { get; set; }
        public bool IsFinished { get; set; }
    
        public virtual GameType GameType { get; set; }
        public virtual ICollection<UsersGame> UsersGames { get; set; }
    }
}
